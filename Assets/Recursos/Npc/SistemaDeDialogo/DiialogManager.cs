using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> frases;

    public bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        isTalking = false;
        frases = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSetence();
        }
    }

    public void StartDialog(Dialogo dialogue)
    {
        animator.SetBool("EstaAberto", true);

        Debug.Log("Conversando com" + dialogue.nome);

        nameText.text = dialogue.nome;

        frases.Clear();

         foreach (string frase in dialogue.frases)
        {
            frases.Enqueue(frase);
        }
        isTalking = true;
        DisplayNextSetence();
    }

    public void DisplayNextSetence()
    {
        if (frases.Count == 0)
        {
            EndDialogue();
            return;
        }

        string frase = frases.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(frase));
    }

    IEnumerator TypeSentence (string frase)
    {
        dialogueText.text = "";
        foreach (char letter in frase.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("Fim Da conversa");
        animator.SetBool("EstaAberto", false);
        isTalking = false;
    }
}
