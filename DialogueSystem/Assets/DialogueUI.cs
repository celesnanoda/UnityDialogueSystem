using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPG.Dialogue;
using TMPro;
using UnityEngine.UI;

namespace RPG.UI
{
    public class DialogueUI : MonoBehaviour
    {
        Conversation playerConversation;
        [SerializeField] TextMeshProUGUI AIText;
        [SerializeField] Button nextButton;

        // Start is called before the first frame update
        void Start()
        {
            playerConversation = GameObject.FindGameObjectWithTag("Player").GetComponent<Conversation>();
            nextButton.onClick.AddListener( Next );

            UpdateUI();
           
        }

        void Next()
        {
            playerConversation.Next();
            UpdateUI();
        }

        // Update is called once per frame
        void UpdateUI()
        {
            AIText.text = playerConversation.GetText();
            nextButton.gameObject.SetActive( playerConversation.HasNext() );
        }
    }
}


