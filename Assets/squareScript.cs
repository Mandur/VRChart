using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareScript : MonoBehaviour,IInputClickHandler {
    private GraphController graph;
    // Use this for initialization
    void Start () {
        graph = GameObject.Find("graph").GetComponent<GraphController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("clicke" + this.transform.parent.name);
        graph.changeVisibility(this.transform.parent.name);
    }
}
