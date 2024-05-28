using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int depositoMadeira;
    public int depositoCarne;
    public int depositoOuro;
    public int forcaMilitar;
    public bool morto = false;
    public string meuNome = "NOME";

    //Informacoes
    public GameObject Floresta;
    public GameObject Carne;
    public GameObject Ouro;
    public GameObject Exercito;
    


    public GameObject Fazendeiro;
    public List<GameObject> Fazendeiros;
    public List<string> Nomes;
    public int numeroJogador;

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

        meuNome = Nomes[numeroJogador];
        Time.timeScale = 3;
        /*InicializarFazendeiroAutomatizado("Ouro");
        InicializarFazendeiroAutomatizado("Militar");
        InicializarFazendeiroAutomatizado("Madeira");
        InicializarFazendeiroAutomatizado("Carne");*/
    }

    // Update is called once per frame
    void Update()
    {
        if(morto == false)
        {
            TempoPassando();
            Logica();
            VerificaVida();

        }
        
    }

    void VerificaVida()
    {
        if(depositoCarne < 0)
        {
            morto = true;
        }
        if(depositoMadeira < 0)
        {
            morto = true;
        }
    }

   

    void Logica()
    {
        if(numeroJogador < 8)
        {
            if (depositoCarne > 250)
            {
                if (numeroJogador < 4)
                {
                    if (qtdC < 3)
                    {
                        InicializarFazendeiroAutomatizado("Carne");
                        qtdC++;
                    }
                    else
                    {
                        float r2 = Random.Range(0, 100);
                        if(r2 < 75)
                        {
                            InicializarFazendeiroAutomatizado("Madeira");
                        }else if(r2 < 95)
                        {
                            InicializarFazendeiroAutomatizado("Militar");
                        }
                        else
                        {
                            InicializarFazendeiroAutomatizado("Ouro");
                        }
                        
                        qtdC = 0;
                    }
                }
                else if (numeroJogador < 8)
                {
                    float rand = Random.Range(0, 100);

                    if (rand < 25)
                    {
                        InicializarFazendeiroAutomatizado("Carne");
                    }
                    else if (rand < 50)
                    {
                        InicializarFazendeiroAutomatizado("Madeira");
                    }
                    else if (rand < 75)
                    {
                        InicializarFazendeiroAutomatizado("Ouro");

                    }
                    else
                    {
                        InicializarFazendeiroAutomatizado("Militar");
                    }
                }



            }

        }
        //Mais Fazendeiros
        if (numeroJogador >= 8)
        {
            if(depositoCarne > 200)
            {
                float rand = Random.Range(0, 100);

                if (rand < 50)
                {
                    InicializarFazendeiroAutomatizado("Carne");
                }
                else if (rand < 75)
                {
                    InicializarFazendeiroAutomatizado("Madeira");
                }
                else if (rand < 80)
                {
                    InicializarFazendeiroAutomatizado("Ouro");

                }
                else
                {
                    InicializarFazendeiroAutomatizado("Militar");
                }
            }
        }
        //Mais Casas
        if(depositoMadeira > 150)
        {
            ConstruirCasa();
        }
        //Evoluir Fazendeiros
        if(depositoOuro > 100)
        {
            CursoTecnico();
        }
    }

    void CursoTecnico()
    {
        if(depositoOuro - 100 > 0)
        {
            depositoOuro = depositoOuro - 100;
            for (int i = 0; i < Fazendeiros.Count; i++)
            {
                Fazendeiros[i].GetComponent<Fazendeiro>().Evolucao();
            }
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
                meuFazendeiro.GetComponent<Fazendeiro>().Local_Exercito = Exercito;
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
        if (passador >= 7)
        {
            ConsumoCarne();
            passador = 0;
        }
        if (passador2 >= 10)
        {
            ConsumoMadeira();
            passador2 = 0;
        }
    }


    void ConsumoCarne()
    {
        //Carne
        depositoCarne = depositoCarne - (Fazendeiros.Count * 2);

    }
    void ConsumoMadeira()
    {
        //madeira
        depositoMadeira = depositoMadeira - (Fazendeiros.Count * 1);
    }

    public void ProducaoGuerra(int poderSoldado)
    {
        if(morto == false)
        {
            forcaMilitar = forcaMilitar + poderSoldado;
        }
        
    }
}
