using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBottom : MonoBehaviour
{
   public DialogueManager DialogueManager;
   public int id;

   
    public void SetChangeIdiom()
 {
    DialogueManager.SetIdiom(id);
    DialogueManager.ChangeIdiom();
    }
    public void SetIdiom()
    {
        DialogueManager.ChangeIdiom();
    }
}
