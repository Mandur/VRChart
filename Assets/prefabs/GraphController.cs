using Assets;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

    public GameObject barPrefab;
    public Dictionary<string, Material> materialList;
    public List<GameObject> bars;
    public int scale = 10;
    private int categoriesValues;
    private DataSource dataSource;
    public CubeScript menu;


    // Use this for initialization
    void Start()
    {
        dataSource = new DataSource();
        dataSource.generateMockDataSource(0, 2000);
        materialList = new Dictionary<string, Material>();

        Vector3 currentOffset = Vector3.zero;

        foreach (var kvp in dataSource.dataSetCategories)
        {
        
           var material = new Material(Shader.Find("Specular"));
            material.color = UnityEngine.Random.ColorHSV();
            materialList.Add(kvp.Key,material);
            foreach (var item in dataSource.dataSet2.Where(p => p.key == kvp.Key))
            {
                GameObject go = Instantiate(barPrefab);
                go.transform.localScale = new Vector3(1, (float)item.value * scale, 1);
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
