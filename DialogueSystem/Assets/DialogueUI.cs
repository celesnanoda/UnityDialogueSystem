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
        [SerializeField] GameObject AIResponse;
        [SerializeField] Transform choiceRoot;
        [SerializeField] GameObject choicePrefab;
        [SerializeField] Button quitButton;

        // Start is called before the first frame update
        void Start()
        {

            playerConversation = GameObject.FindGameObjectWithTag("Player").GetComponent<Conversation>();
            playerConversation.OnConversationUpdated += UpdateUI;
            nextButton.onClick.AddListener( () => playerConversation.Next() );
            quitButton.onClick.AddListener( () => playerConversation.Quit() );
            
            UpdateUI();
           
        }

        // Update is called once per frame
        void UpdateUI()
        {

            gameObject.SetActive( playerConversation.IsActive() );
            if ( !playerConversation.IsActive() ) return;
      
            AIResponse.SetActive( !playerConversation.IsChoosing() );
            choiceRoot.gameObject.SetActive( playerConversation.IsChoosing() );

            if( playerConversation.IsChoosing() )
            {
                BuildChoiceList();
            }
            else
            {
                AIText.text = playerConversation.GetText();
                nextButton.gameObject.SetActive( playerConversation.HasNext() );
            }

            
            
        }

        private void BuildChoiceList()
        {
            foreach ( Transform node in choiceRoot )
            {
                Destroy( node.gameObject );
            }
            foreach ( DialogueNode choice in playerConversation.GetChoices() )
            {
                GameObject choiceInstance = Instantiate( choicePrefab, choiceRoot );
                choiceInstance.GetComponentInChildren<TextMeshProUGUI>().text = choice.GetText();
                Button button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener( () =>
                    {
                        playerConversation.SelectChoice( choice );
                    } 
                );
            }
        }
    }
}


