using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBottom : MonoBehaviour
{
    /// <summary>
    /// Reference to the DialogueManager that manages the dialogue changes.
    /// </summary>
    public DialogueManager DialogueManager;

    /// <summary>
    /// Identifier for the language to be set.
    /// </summary>
    public int id;

    /// <summary>
    /// Sets the language ID and updates the dialogues.
    /// </summary>
    public void SetChangeIdiom()
    {
        // Set the language ID and change the dialogues
        DialogueManager.SetIdiom(id);
        DialogueManager.ChangeIdiom();
    }

    /// <summary>
    /// Updates the dialogues using the current language ID.
    /// </summary>
    public void SetIdiom()
    {
        // Change the dialogues using the current language ID
        DialogueManager.ChangeIdiom();
    }
}
