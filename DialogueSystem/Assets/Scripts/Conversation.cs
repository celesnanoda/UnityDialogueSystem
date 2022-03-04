using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;

namespace RPG.Dialogue
{
    public class Conversation : MonoBehaviour
    {

        [SerializeField] Dialogue currentDialogue;
        [SerializeField] DialogueNode currentNode = null;
        bool isChoosing = false;
        [SerializeField] GameObject popupUI;
        bool canStartConversation;
        public static bool inConversation;
        public event Action OnConversationUpdated;

        GameObject NPC;

        //IEnumerator Start()
        //{
        //    yield return new WaitForSeconds( 2 );
        //    StartDialogue( testDialogue );
        //}

        public void StartDialogue( Dialogue newDialogue )
        {
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            OnConversationUpdated();
        }

        public bool IsActive()
        {
            return currentDialogue != null;
        }

        public bool IsChoosing()
        {
            return isChoosing;
        }

        public string GetText()
        {
            if(currentNode == null)
            {
                return "";
            }

            return currentNode.GetText();
        }
      
        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren( currentNode );
        }

        public void SelectChoice( DialogueNode chosenNode )
        {
            currentNode = chosenNode;
            isChoosing = true;
            Next();
        }

        public void Next()
        {

            int numPlayerResponses = currentDialogue.GetPlayerChildren( currentNode ).Count();

            if( numPlayerResponses > 0 )
            {
                isChoosing = true;
                OnConversationUpdated();
                return;
            }

            DialogueNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
            int randomIndex = UnityEngine.Random.Range(0, children.Count());
            currentNode = children[ randomIndex ];
            OnConversationUpdated();
        }

        public void Quit()
        {

            currentDialogue = null;
            currentNode = null;
            inConversation = false;
            isChoosing = false;
            OnConversationUpdated();

            GameObject.FindGameObjectWithTag("Player").
                GetComponent<SimplePlayerController>().
                SwitchToPlayerCamera();

        }

        public bool HasNext()
        {
            return currentDialogue.GetAllChildren( currentNode ).Count() > 0;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 offset = new Vector3( 3, 0, 15 );
            Gizmos.DrawWireCube( transform.position, offset );
        }

        private void OnTriggerEnter( Collider other )
        {

            if ( other.CompareTag( "NPC" ) )
            {

                canStartConversation = true;
                NPC = other.gameObject;
                popupUI.SetActive( true );

            }

        }

        private void OnTriggerExit( Collider other )
        {

            if ( other.CompareTag( "NPC" ) )
            {
                canStartConversation = false;
                NPC = null;
                popupUI.SetActive( false );

            }

        }

        private void Update()
        {
            if(canStartConversation && !inConversation)
            {
                if( Input.GetButtonDown("Fire1"))
                {
                    CinemachineVirtualCamera cam = NPC.GetComponentInChildren<CinemachineVirtualCamera>();
                    CameraSwitcher.SwitchCamera( cam );

                    inConversation = true;
                    Dialogue NPCDialogue = NPC.GetComponent<NPCDialogue>().GetDialogue();
                    StartDialogue( NPCDialogue );
                }
             
            }
        }
    }

}


