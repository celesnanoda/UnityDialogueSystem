using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class OptionsUI : UIBase
{
    [SerializeField] GameObject optionTabs;
    [SerializeField] GameObject optionDetails;

    public static Action OnRightButton;
    public static Action OnLeftButton;
    public static Action OnUpButton;
    public static Action OnDownButton;
    public static Action OnConfirmButton;
    public static Action OnBackButton;


    private void Start()
    {
        for( int i = 0; i < optionTabs.transform.childCount; i++ )
        {
            tabs.Add( optionTabs.transform.GetChild(i).gameObject );
        }
        for( int i = 0; i < optionDetails.transform.childCount; i++ )
        {
            details.Add( optionDetails.transform.GetChild(i).gameObject );
        }

        tabIndex = tabs.Count - 1;
        detailIndex = details.Count - 1;
        currentTab = 0;
        tabs[currentTab].GetComponent<Image>().color = hoverColor;
        UpdateOptionUI();
    }

    public void Update()
    {
         if( Input.GetKeyDown(KeyCode.E))
         {
             NextTab();
         }   
         else if( Input.GetKeyDown(KeyCode.Q))
         {
             PreviousTab();
         }
         else if( Input.GetButtonDown( "Right" ))
         {
             if(OnRightButton != null) OnRightButton();
         }
          else if( Input.GetButtonDown( "Left" ))
         {
             if(OnLeftButton != null)OnLeftButton();
         }
          else if( Input.GetButtonDown( "Up" ))
         {
            if(OnUpButton != null) OnUpButton();
         }
          else if( Input.GetButtonDown( "Down" ))
         {
            if(OnDownButton != null) OnDownButton();
         }
    }

    public static void ResetInput()
    {
        OnRightButton = null;
        OnUpButton = null;
        OnLeftButton = null;
        OnDownButton = null;
    }

}
