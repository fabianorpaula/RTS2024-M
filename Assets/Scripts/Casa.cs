using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        InicializarFazendeiroAutomatizado("Carne");
        InicializarFazendeiroAutomatizado("Carne");
        InicializarFazendeiroAutomatizado("Madeira");
        InicializarFazendeiroAutomatizado("Ouro");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GameObject meuFazendeiro = Instantiate(Fazendeiro, transform.position,
            Quaternion.identity);
        meuFazendeiro.GetComponent<Fazendeiro>().Local_Carne = Carne;
        meuFazendeiro.GetComponent<Fazendeiro>().Local_Floresta = Floresta;
        meuFazendeiro.GetComponent<Fazendeiro>().Local_Ouro = Ouro;
        meuFazendeiro.GetComponent<Fazendeiro>().Local_Casa = this.gameObject;

        meuFazendeiro.GetComponent<Fazendeiro>().Linkedin(trabalho);
    }


}
