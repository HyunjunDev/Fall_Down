using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public bool setOn = false;
    public GameObject spM;
    private GameObject set;
    
    public void changeSet()
    {
        if(setOn==true)
        {
            setOn = false;
            spM.SetActive(true);
            Debug.Log("1");
            return;
        }
        if(setOn==false)
        {
            setOn = true;
            spM.SetActive(false);
            Debug.Log("2");
        }
    }
}
