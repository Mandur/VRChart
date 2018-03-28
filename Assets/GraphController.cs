using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

    public GameObject barPrefab;

    public List<GameObject> bars;
    private int categoriesValues;
    private DataSource generator;

    // Use this for initialization
    void Start()
    {
        generator = new DataSource();
       

        Vector3 currentOffset = Vector3.zero;

        foreach (var key in generator.dataSet.Keys)
        {
            foreach (var value in generator.dataSet[key])
            {
                GameObject go = Instantiate(barPrefab);
                go.transform.localScale = new Vector3(1, (float)value, 0.1f);
                go.transform.position = new Vector3(currentOffset.x, go.transform.localScale.y / 2, currentOffset.z);
                currentOffset.x += 2;
                go.transform.parent = this.transform;
                bars.Add(go);
            }
            currentOffset.x = 0;
            currentOffset.z += 2;
        }
    }

       

   
           
	
	
	// Update is called once per frame
	void Update () {
		
	}

}
