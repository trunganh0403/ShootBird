using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public static Dialog instance;
    public Text titalTx;
    public Text contentx;

    private void Awake()
    {
        if (instance == null)
        instance = this;
    }
    public void SetTex(string tital,string conten)
    {
        if (titalTx != null)
        {
            titalTx.text = tital;
        }
        if (contentx != null)
        {
            contentx.text = conten;
        }
    } 
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }    
}
