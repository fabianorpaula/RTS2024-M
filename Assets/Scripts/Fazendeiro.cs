using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fazendeiro : MonoBehaviour
{

    private NavMeshAgent Agente;
    public int madeira = 0;
    private int limiteMadeira = 10;
    public GameObject Local_Casa;
    public GameObject Local_Floresta;
    public GameObject Local_Carne;
    public GameObject Local_Ouro;
    private float temporizador;

    public enum Estados { Trabalhar, Retornar };
    public Estados MeuEstado;
    
    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        MeuEstado = Estados.Trabalhar;
    }

    // Update is called once per frame
    void Update()
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


    void IrTrabalhar()
    {
        Agente.SetDestination(Local_Floresta.transform.position);
        float DistanciaObjetivo = Vector3.Distance(transform.position, 
            Local_Floresta.transform.position);

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
            
            if(madeira >= limiteMadeira)
            {
                Debug.Log("TERMINEI");
                MeuEstado = Estados.Retornar;
            }
            else
            {
                madeira++;
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

    void Depositar()
    {
        Local_Casa.GetComponent<Casa>().ReceberMadeira(madeira);
        madeira = 0;
        MeuEstado = Estados.Trabalhar;
    }
}
