using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int depositoMadeira;
    public int depositoCarne;
    public int depositoOuro;
    void Start()
    {
        
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
}
