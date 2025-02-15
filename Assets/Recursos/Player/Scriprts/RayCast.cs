using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public int distancia;
    public Camera camera;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.GetComponent<Interruptor>())
                {
                   Interruptor interruptor = hit.collider.GetComponent<Interruptor>();

                    if (interruptor.estaLigado)
                    {
                        interruptor.LampadaOff();
                    }

                    if (interruptor.estaLigado == false)
                    {
                        interruptor.LampadaOn();
                    }

                }
            }

        }
    }
}
