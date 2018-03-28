using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
    public GameObject text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(Camera.current.transform);
    }

    public void populateCube(Dictionary<string, Material> materialList)
    {
        float offset = 0;

        foreach(var key in materialList.Keys)
        {
            Debug.Log(key);
            var gameObject=Instantiate(text,new Vector3(-10,offset,-10),Quaternion.Euler(0,180,0));
            offset -= 1.5f;
            gameObject.GetComponent<TextMesh>().text= key;
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = materialList[key];
            gameObject.transform.parent = this.transform;
          
           
        }

    }
}
