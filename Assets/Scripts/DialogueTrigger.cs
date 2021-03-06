using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
    private bool dialogueStarted = false;

    public void TriggerDialogue()
	{
        DialogueManager.instance.StartDialogue(dialogue);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dialogueStarted)
        {
            TriggerDialogue();
            dialogueStarted = true;
        }
    }
    public void StartDialogue()
    {
        TriggerDialogue();
    }
}
