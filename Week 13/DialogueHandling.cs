using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueHandling : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private readonly WaitForSeconds waitForCompleteDialogue = new(3f); //caching the wfs to prevent loop errors
    private bool isTriggered = false; //prevents dialogue from overlapping, see note in function
    private readonly string streamA = "Hello, Player!";
    private readonly string streamB = "Welcome to my Village!";
    private readonly string streamC = "Be careful! There are enemies ahead!";
    private List<string> dialogueStream;

    protected virtual void BuildDialogueStream() //creates an overridable string list w/ the base dialogue here
    {
        CreateDialogueTree(streamA, streamB, streamC);
    }

    public void CreateDialogueTree(string streamA, string streamB, string streamC) //creates a list storing a stream of dialogue on trigger
    {
        dialogueStream = new List<string>
        {
            streamA,
            streamB,
            streamC
        };
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BuildDialogueStream(); //calls to create dialogue trees on trigger

            if(isTriggered == true) //prevents dialogue from overlapping feed, stops repetitive phrasing. e.g. w/out you can trigger the dialoge repetedly causing some phrases to double up and get repetitive, w/this the full dialogue will complete before being triggerred agian
                {
                    return;
                }
            else
                {
                StartCoroutine(ShowDialogue());
                }
        }
    }

    IEnumerator ShowDialogue()
    {
        isTriggered = true;

        for (int i = 0; i < dialogueStream.Count; i++) 
        {
            //exception handling
            if (string.IsNullOrEmpty(dialogueStream[i]))
            {
                isTriggered = false;
                yield break;
            }

            dialogueText.text = dialogueStream[i]; //accessing dialogue at each index, then applying delay before next text sequence

            yield return waitForCompleteDialogue;
        }
        isTriggered = false;
        dialogueText.text = "";
    }
}

