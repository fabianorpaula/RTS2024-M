using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DadosVisualizador : MonoBehaviour
{

    public TMP_Text nome;
    public TMP_Text comida;
    public TMP_Text madeira;
    public TMP_Text ouro;
    public TMP_Text exercito;
    public TMP_Text estado;

    public Casa MinhaCasa;


    // Update is called once per frame
    void Update()
    {
        

        if(MinhaCasa.morto == false)
        {
            nome.text = "Nome: "+MinhaCasa.meuNome
                +"   F:"+MinhaCasa.Fazendeiros.Count.ToString()
                +"/C:"+MinhaCasa.QtdCasas.ToString();
            comida.text = "Comida: "+MinhaCasa.depositoCarne.ToString();
            madeira.text = "Madeira: "+MinhaCasa.depositoMadeira.ToString();
            ouro.text = "Ouro: "+MinhaCasa.depositoOuro.ToString();
            exercito.text = "Exercito: "+MinhaCasa.forcaMilitar.ToString();
            estado.text = "VIVO";
        }
        else
        {
            estado.text = "MORTO : PERDEU";
        }

    }
}
