using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendeiro : MonoBehaviour
{

    private NavMeshAgent Agente;
    public int madeira = 0;
    public int limiteMadeira = 10;
    public int carne = 0;
    public int limiteCarne = 10;
    public int ouro = 0;
    public int limiteOuro = 10;
    public int forcaMilitar = 1;

    public GameObject Local_Casa;
    public GameObject Local_Floresta;
    public GameObject Local_Carne;
    public GameObject Local_Ouro;
    public GameObject Local_Exercito;
    private float temporizador;

    public enum Estados { Trabalhar, Retornar, Guerra };
    public Estados MeuEstado;

    public enum Proficao { Madereiro, Carneiro, Oureiro, Militar};
    public Proficao Emprego;
    
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        MeuEstado = Estados.Trabalhar;
    }

    // Update is called once per frame
    void Update()
    {

        if(Emprego == Proficao.Militar)
        {
            IrGuerra();

        }
        else
        {
            if (MeuEstado == Estados.Trabalhar)
            {
                IrTrabalhar();
            }
            if (MeuEstado == Estados.Retornar)
            {
                IrPraCasa();
            }
        }
       


    }

    void IrGuerra()
    {
        
        if (Emprego == Proficao.Militar)
        {
            Vector3 Destino = Local_Exercito.transform.position;
            Agente.SetDestination(Destino);
            float DistanciaObjetivo = Vector3.Distance(transform.position,
                Destino);

            if (DistanciaObjetivo < 5)
            {
                ProducaoGuerra();
            }
        }
    }

    void IrTrabalhar()
    {
        Vector3 Destino = Local_Casa.transform.position;
        if(Emprego == Proficao.Madereiro)
        {
            Destino = Local_Floresta.transform.position;
        }
        if (Emprego == Proficao.Carneiro)
        {
            Destino = Local_Carne.transform.position;
        }
        if (Emprego == Proficao.Oureiro)
        {
            Destino = Local_Ouro.transform.position;
        }
        Agente.SetDestination(Destino);
        float DistanciaObjetivo = Vector3.Distance(transform.position,
            Destino);

        if (DistanciaObjetivo < 5)
        {
            FazerColheita();
        }

    }


    void FazerColheita()
    {
        temporizador += Time.deltaTime;
        if(temporizador > 1)
        {
            temporizador = 0;

            if (Emprego == Proficao.Madereiro)
            {
                ColherMadeira();
            }
            if (Emprego == Proficao.Carneiro)
            {
                ColherCarne();
            }
            if (Emprego == Proficao.Oureiro)
            {
                ColherOuro();
            }

        }

    }

    void IrPraCasa()
    {
        Agente.SetDestination(Local_Casa.transform.position);
        float DistanciaObjetivo = Vector3.Distance(transform.position,
            Local_Casa.transform.position);

        if (DistanciaObjetivo < 3)
        {
            Depositar();
        }
    }

    void ColherMadeira()
    {
        if (madeira >= limiteMadeira)
        {
            //Debug.Log("TERMINEI");
            MeuEstado = Estados.Retornar;
        }
        else
        {
            madeira++;
        }
    }

    void ColherCarne()
    {
        if (carne >= limiteCarne)
        {
            //Debug.Log("TERMINEI");
            MeuEstado = Estados.Retornar;
        }
        else
        {
            carne++;
        }
    }

    void ColherOuro()
    {
        if (ouro >= limiteOuro)
        {
            //Debug.Log("TERMINEI");
            MeuEstado = Estados.Retornar;
        }
        else
        {
            ouro++;
        }
    }

    void ProducaoGuerra()
    {

        temporizador += Time.deltaTime;
        if (temporizador > 1)
        {
            temporizador = 0;
            Local_Casa.GetComponent<Casa>().ProducaoGuerra(forcaMilitar);
        }
    }


    void Depositar()
    {
        Local_Casa.GetComponent<Casa>().ReceberMadeira(madeira);
        madeira = 0;
        Local_Casa.GetComponent<Casa>().ReceberCarne(carne);
        carne = 0;
        Local_Casa.GetComponent<Casa>().ReceberOuro(ouro);
        ouro = 0;
        MeuEstado = Estados.Trabalhar;
    }


    public void Linkedin(string tipoDeTrabalho)
    {
        if(tipoDeTrabalho == "Madeira")
        {
            Emprego = Proficao.Madereiro;
        }
        if(tipoDeTrabalho == "Ouro")
        {
            Emprego = Proficao.Oureiro;
        }
        if (tipoDeTrabalho == "Carne")
        {
            Emprego = Proficao.Carneiro;
        }
        if (tipoDeTrabalho == "Militar")
        {
            Emprego = Proficao.Militar;
            MeuEstado = Estados.Guerra;
        }

    }

    public void Evolucao()
    {
        limiteMadeira++;
        limiteCarne++;
        limiteOuro++;
        forcaMilitar++;
    }

}
