using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace RPG.Dialogue.Editor
{
    public class DialogueModificationProcessor : UnityEditor.AssetModificationProcessor
    {
        private static AssetMoveResult OnWillMoveAsset( string sourcePath, string destinationPath )
        {
            Dialogue dialogue = AssetDatabase.LoadMainAssetAtPath( sourcePath ) as Dialogue;
            if(dialogue == null)
            {
                return AssetMoveResult.DidNotMove;
            }

            if( Path.GetDirectoryName( sourcePath ) != Path.GetDirectoryName( destinationPath ) )
            {
                return AssetMoveResult.DidNotMove;
            }

            dialogue.name = Path.GetFileNameWithoutExtension(destinationPath); 

            return AssetMoveResult.DidMove;

        }
    }
}

