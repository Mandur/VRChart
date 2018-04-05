using Assets;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour {

    public GameObject zAxisTextPrefab;
    public GameObject barPrefab;
    public Dictionary<string, Material> materialList;
    public List<GameObject> bars;
    public int scale = 10;
    private int categoriesValues;
    private DataSource dataSource;
    public LegendScript menu;


    // Use this for initialization
    void Start()
    {
        var months = new System.Random(DateTime.Now.Millisecond).Next(12, 36);


        dataSource = new DataSource();
        dataSource.generateMockDataSource(months,0, 2000);
        materialList = new Dictionary<string, Material>();

        Vector3 currentOffset = Vector3.zero;

        foreach (var kvp in dataSource.dataSetCategories)
        {
        
           var material = new Material(Shader.Find("Specular"));
            material.color = UnityEngine.Random.ColorHSV();
            materialList.Add(kvp.Key,material);
            foreach (var item in dataSource.dataSet.Where(p => p.key == kvp.Key))
            {
                GameObject go = Instantiate(barPrefab);
                go.transform.localScale = new Vector3(1, (float)item.value * scale, 1);
                go.transform.position = new Vector3(currentOffset.x, go.transform.localScale.y / 2, currentOffset.z);



                go.GetComponent<MeshRenderer>().material = material;
                currentOffset.x += 2;
                go.transform.parent = this.transform;
                bars.Add(go);
            }
            var line = gameObject.GetComponent<LineRenderer>();
            var distance = Vector3.Distance(new Vector3(-5, 5, currentOffset.z), new Vector3(currentOffset.x + 5, 5, currentOffset.z));
            line.materials[0].mainTextureScale = new Vector3(distance, 1, 1);

            currentOffset.x = 0;
            currentOffset.z += 2;
        }
        menu.populateLegend(materialList);
        setZAxisLabels(months);


    }


    public void setZAxisLabels(int totalMonths)
    {



        var i = 1;
        var year = DateTime.Now.Year - 3;
        var currentOffset = Vector3.zero;
        var xOffset = -4;
        while (i <= totalMonths)
        {
            var go = Instantiate(zAxisTextPrefab, new Vector3(xOffset, 0, -4.5f), Quaternion.Euler(90, -45, 0));
            var month = i % 12 == 0?12:i%12;
            var display = new DateTime(year, month, 1).ToString("MMM yyyy");
            xOffset += 2;
            year = month == 12 ? year + 1 : year;
            go.GetComponent<TextMesh>().text = display;
            //gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = 
            //gameObject.transform.parent = this.transform;
            i++;
        }


    }






    // Update is called once per frame
    void Update () {
		
	}

}
