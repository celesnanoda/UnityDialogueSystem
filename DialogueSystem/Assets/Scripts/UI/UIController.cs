using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class UIController : MonoBehaviour
{

    public List<GameObject> items;
    public GameObject itemContainer;
    public int currentItem;
    private int itemIndex;
    public UnityEvent registerInput;
    public UnityEvent unregisterInput;
    public Color normalColor;
    public Color hoverColor;
    public ContainerType containerType = ContainerType.Single;
    public ContentExtract extractFrom = ContentExtract.Child;
    private void OnEnable(){
        
  Debug.Log("Enable");

        if( extractFrom == ContentExtract.Child)
        {
              GetContentsInChild();
        }

        registerInput.Invoke();
        UpdateItem();
    } 
    private void OnDisable(){

          Debug.Log("Disable");

        items.Clear();
        OptionsUI.ResetInput();
    } 

    public void GetContentsInChild()
    {   
        for(  int i = 0; i <  itemContainer.transform.childCount; i++)
        {
            items.Add(itemContainer.transform.GetChild(i).gameObject );
        }
        itemIndex = items.Count - 1;
        currentItem = 0;
    }

    public void RegisterUp()
    {
        switch (containerType)
        {
            case ContainerType.Single:
                  OptionsUI.OnUpButton += Previous;
            break;
            case ContainerType.MultiDirectional:
                  OptionsUI.OnUpButton += PreviousRow;
            break;
        } 
    }   
    public void RegisterRight()
    {
        OptionsUI.OnRightButton += Next;
    }   

    public void RegisterLeft()
    {
        OptionsUI.OnLeftButton += Previous;
    }

    public void RegisterDown()
    {
        switch (containerType)
        {
            case ContainerType.Single:
                  OptionsUI.OnDownButton += Next;
            break;
            case ContainerType.MultiDirectional:
                  OptionsUI.OnDownButton += NextRow;
            break;
        } 
    }
    private void Previous()
    {
        currentItem -= 1;
        if( currentItem < 0 ) currentItem = itemIndex - 1;
        UpdateItem();
    }
    private void Next()
    {
        currentItem += 1;
        if( currentItem >= itemIndex ) currentItem = 0;
        UpdateItem();
    }

    private void NextRow()
    {   
        int col = itemContainer.GetComponent<GridLayoutGroup>().constraintCount;
        currentItem += col;
        if( currentItem >= itemIndex ) currentItem = itemIndex - currentItem + col - 1;
        UpdateItem();
    }
     private void PreviousRow()
    {   
        int col = itemContainer.GetComponent<GridLayoutGroup>().constraintCount;
        currentItem -= col;
        if( currentItem < 0 ) currentItem = itemIndex - 1 + currentItem;
        UpdateItem();
    }

    public void ChangeTab()
    {
        GameObject go = items[currentItem].GetComponent<NextTab>().nextTab;
        go.SetActive( true );
    }

    private void UpdateItem()
    {
        foreach(var item in items)
        {
                item.GetComponent<Image>().color = normalColor;
        }
        items[currentItem].GetComponent<Image>().color = hoverColor;
    }

}
public enum ContainerType {Single, MultiDirectional};
public enum ContentExtract {Child, Manual}