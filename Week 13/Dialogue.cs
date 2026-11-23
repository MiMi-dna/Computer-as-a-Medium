using TMPro;
using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public string[] dialogues =
    {
        "Hello, Player!",
        "Welcome to my village!",
        "Be careful! There are enemies ahead!"
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowDialogue());
        }
    }
    IEnumerator ShowDialogue()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueText.text = dialogues[i];
            //dialogueText.text = dialogues[0];
            //dialogueText.text = "Hello, Player!";

            //second time
            //dialogueText.text = dialogues[1];
            //dialogueText.text = "Welcome to my village!";

            //third time
            //dialogueText.text = dialogues[2];
            //dialogueText.text = "Be careful! There are enemies ahead!";

            yield return new WaitForSeconds(3f);
        }

        dialogueText.text = "";
    }
}
