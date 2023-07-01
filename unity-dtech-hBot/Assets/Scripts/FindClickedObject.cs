using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindClickedObject : MonoBehaviour
{

    public TMP_Text theTurbine;

    public string Value;
    public string Name;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Name.Length > 0)
        {
            theTurbine.text = "Joint " + Name +  " is at: "+ Value + " º";
        }
        else
        {
            theTurbine.text = "Click in one Robot Joint";
        }
    }
}
