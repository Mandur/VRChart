using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class BoxScript : MonoBehaviour, IInputClickHandler, IFocusable
{
    public void OnFocusEnter()
    {
        Debug.Log("enter");
    }

    public void OnFocusExit()
    {
        Debug.Log("exit");
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var graph=GetComponentInParent<GraphController>();
        graph.changeVisibility(this.name);
    }

    // Use this for initialization
    void Start () {
    }


    // Update is called once per frame
    void Update () {
		
	}
}
