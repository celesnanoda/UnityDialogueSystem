using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Dialogue;
public class NPCDialogue : MonoBehaviour
{

    [SerializeField] Dialogue currentDialogue;

    public Dialogue GetDialogue()
    {
        return currentDialogue;
    }

}
