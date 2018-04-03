using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LegendScript : MonoBehaviour {
    public GameObject text;
    public Toggle Toggle; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Camera.current != null) this.transform.LookAt(Camera.current.transform);
    }

    public void populateLegend(Dictionary<string, Material> materialList)
    {

        float offset = 0;

        foreach(var key in materialList.Keys)
        {
            var gameObject=Instantiate(text,new Vector3(-10,offset,-10),Quaternion.Euler(0,0,0));
            offset -= 1.5f;
            gameObject.GetComponent<TextMesh>().text= key;
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = materialList[key];
            gameObject.transform.parent = this.transform;
          
           
        }


    }


}


