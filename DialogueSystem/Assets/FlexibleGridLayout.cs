using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{

    public int rows;
    public int columns;
    public Vector2 cellSize;

    public override void CalculateLayoutInputVertical()
    {
        
    }
 
    public override void SetLayoutHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
    }

    public override void SetLayoutVertical()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
