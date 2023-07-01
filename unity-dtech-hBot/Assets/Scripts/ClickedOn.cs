using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedOn : MonoBehaviour
{
    public bool isClicked;
    public string Joint_Name = "J1";

    public FindClickedObject attributeValue;

    public jt1Controler Output1;
    public jt2Controler Output2;
    public jt3Controler Output3;
    public jt4Controler Output4;
    public jt5Controler Output5;
    public jt6Controler Output6;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (!isClicked)
        {
        // Change the value of the variable when the object is clicked
        isClicked = true;

        attributeValue.Name=Joint_Name;

        if (Joint_Name == "J1")
        { 
        attributeValue.Value=Output1.outStrDirection;
        }
        if (Joint_Name == "J2")
        { 
            attributeValue.Value=Output2.outStrDirection;
        }
        if (Joint_Name == "J3")
        {
            attributeValue.Value=Output3.outStrDirection;
        }
        if (Joint_Name == "J4")
        {
            attributeValue.Value=Output4.outStrDirection;
        }
        if (Joint_Name == "J5")
        {
            attributeValue.Value=Output5.outStrDirection;
        }
        if (Joint_Name == "J6")
        {
            attributeValue.Value=Output6.outStrDirection;
        }
}
else
{
           isClicked = false;

        attributeValue.Name=""; 
}

   
    }


}