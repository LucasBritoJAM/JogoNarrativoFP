using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialogo dialogue;

    private bool atRange;

    private bool isTalking;


    void Update()
    {
        isTalking = FindObjectOfType<DiialogManager>().isTalking;

        if (((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) && atRange) && !isTalking)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {

        FindObjectOfType<DiialogManager>().StartDialog(dialogue);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            atRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            atRange = false;
            FindObjectOfType<DiialogManager>().EndDialogue();
        }
    }
}
