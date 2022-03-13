using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIBase : MonoBehaviour
{
    public Color normalColor;
    public Color hoverColor;
    public List<GameObject> tabs;
    public List<GameObject> details;
    public int currentTab;
    public int tabIndex, detailIndex;
    public void PreviousTab()
    {
        foreach( var tab in tabs )
        {
            tab.GetComponent<Image>().color = normalColor;
        }

        if ( currentTab-- <= 0 ) currentTab = tabIndex;
        tabs[currentTab].GetComponent<Image>().color = hoverColor;
         UpdateOptionUI();

    }

     public void NextTab()
    {
        foreach( var tab in tabs )
        {
            tab.GetComponent<Image>().color = normalColor;
        }

        if ( currentTab++ >= tabIndex ) currentTab = 0;
        tabs[currentTab].GetComponent<Image>().color = hoverColor;
        UpdateOptionUI();

    }
    public void UpdateOptionUI()
    {
        foreach( var detail in details )
        {
            detail.SetActive(false);
        }
        details[currentTab].SetActive(true);
    }

}
