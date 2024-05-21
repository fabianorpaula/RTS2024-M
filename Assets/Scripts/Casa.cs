using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int depositoMadeira;
    public int depositoCarne;
    public int depositoOuro;

    //Informacoes
    public GameObject Floresta;
    public GameObject Carne;
    public GameObject Ouro;


    public GameObject Fazendeiro;
    public List<GameObject> Fazendeiros;

    //public casa
    public int QtdCasas = 1; 

    //Controloador de tempo
    public float relogio;
    public float passador;
    public float passador2;


    /// <summary>
    /// ParaLogica
    /// </summary>
    int qtdC;

    void Start()
    {
        Time.timeScale = 5;
        InicializarFazendeiroAutomatizado("Carne");
        InicializarFazendeiroAutomatizado("Carne");
        InicializarFazendeiroAutomatizado("Madeira");
        InicializarFazendeiroAutomatizado("Carne");
    }

    // Update is called once per frame
    void Update()
    {
        TempoPassando();
        Logica();
    }

    void Logica()
    {
        if(depositoCarne > 250)
        {
            if(qtdC < 3)
            {
                InicializarFazendeiroAutomatizado("Carne");
                qtdC++;
            }
            else
            {
                InicializarFazendeiroAutomatizado("Madeira");
                qtdC = 0;
            }
            
        }

        if(depositoMadeira > 300)
        {
            ConstruirCasa();
        }
    }

    public void ConstruirCasa()
    {
        if (depositoMadeira - 100 > 0)
        {
            QtdCasas++;
            depositoMadeira = depositoMadeira - 100;
        }
    }

    public void ReceberMadeira(int madeiraRecebida)
    {
        depositoMadeira = depositoMadeira + madeiraRecebida;
    }
    public void ReceberCarne(int carneRecebida)
    {
        depositoCarne = depositoCarne + carneRecebida;
    }
    public void ReceberOuro(int ouroRecebido)
    {
        depositoOuro = depositoOuro + ouroRecebido;
    }


    void InicializarFazendeiroAutomatizado(string trabalho)
    {
        if(QtdCasas*5 > Fazendeiros.Count)
        {
            if (depositoCarne - 50 > 0)
            {
                depositoCarne = depositoCarne - 50;
                GameObject meuFazendeiro = Instantiate(Fazendeiro, transform.position,
                Quaternion.identity);
                meuFazendeiro.GetComponent<Fazendeiro>().Local_Carne = Carne;
                meuFazendeiro.GetComponent<Fazendeiro>().Local_Floresta = Floresta;
                meuFazendeiro.GetComponent<Fazendeiro>().Local_Ouro = Ouro;
                meuFazendeiro.GetComponent<Fazendeiro>().Local_Casa = this.gameObject;

                meuFazendeiro.GetComponent<Fazendeiro>().Linkedin(trabalho);

                Fazendeiros.Add(meuFazendeiro);
            }
        }
        

        

    }


    void TempoPassando()
    {
        relogio += Time.deltaTime;
        passador += Time.deltaTime;
        passador2 += Time.deltaTime;
        if (passador >= 10)
        {
            ConsumoCarne();
            passador = 0;
        }
        if (passador2 >= 30)
        {
            ConsumoMadeira();
            passador2 = 0;
        }
    }


    void ConsumoCarne()
    {
        //Carne
        depositoCarne = depositoCarne - (Fazendeiros.Count * 1);

    }
    void ConsumoMadeira()
    {
        //madeira
        depositoMadeira = depositoMadeira - (Fazendeiros.Count * 1);
    }


}
