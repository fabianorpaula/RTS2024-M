using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : MonoBehaviour
{
    public int depositoMadeira;
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
}
