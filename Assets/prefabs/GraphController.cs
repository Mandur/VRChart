using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

    public GameObject barPrefab;
    public Dictionary<string, Material> materialList;
    public List<GameObject> bars;
    private int categoriesValues;
    private DataSource generator;
    public CubeScript menu;


    // Use this for initialization
    void Start()
    {
        generator = new DataSource();
        materialList = new Dictionary<string, Material>();

        Vector3 currentOffset = Vector3.zero;

        foreach (var key in generator.dataSet.Keys)
        {
        
           var material = new Material(Shader.Find("Specular"));
            material.color = UnityEngine.Random.ColorHSV();
            materialList.Add(key,material);
            foreach (var value in generator.dataSet[key])
            {
                GameObject go = Instantiate(barPrefab);
                go.transform.localScale = new Vector3(1, (float)value, 1);
                go.transform.position = new Vector3(currentOffset.x, go.transform.localScale.y / 2, currentOffset.z);
                go.GetComponent<MeshRenderer>().material = material;
                currentOffset.x += 2;
                go.transform.parent = this.transform;
                bars.Add(go);
            }
            currentOffset.x = 0;
            currentOffset.z += 2;
        }
        menu.populateCube(materialList);
      
    }

       

   
           
	
	
	// Update is called once per frame
	void Update () {
		
	}

}
