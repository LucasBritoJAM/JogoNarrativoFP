using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public GameObject lampadaObjeto;

    private bool atRange;

    public bool estaLigado = true;



    async public void LampadaOn()
    {


        lampadaObjeto.SetActive(true);
        estaLigado = true;


    }

    async public void LampadaOff()
    {


        lampadaObjeto.SetActive(false);
        estaLigado = false;



    }

}
