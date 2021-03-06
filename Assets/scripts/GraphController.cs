﻿using Assets;
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
    private List<LineRenderer> lineRenderers;


    // Use this for initialization
    void Start()
    {
        lineRenderers = new List<LineRenderer>();
        for (int i = 0; i < 6; i++)
        {
            var lr = new GameObject(string.Format("lr{0}", i));
            lr.transform.parent = this.transform;
            lineRenderers.Add(lr.AddComponent<LineRenderer>());
        }
        var months = new System.Random(DateTime.Now.Millisecond).Next(12, 36);


        dataSource = new DataSource();
        dataSource.generateMockDataSource(months, 0, 2000);
        materialList = new Dictionary<string, Material>();
        float lastXOffset = 0;
        Vector3 currentOffset = Vector3.zero;

        foreach (var kvp in dataSource.dataSetCategories)
        {

            var material = new Material(Shader.Find("Transparent/Diffuse"));
            material.color = UnityEngine.Random.ColorHSV();
            materialList.Add(kvp.Key, material);
            foreach (var item in dataSource.dataSet.Where(p => p.key == kvp.Key))
            {
                GameObject go = Instantiate(barPrefab);
                go.name = item.key;
                go.transform.localScale = new Vector3(1, (float)item.value * scale, 1);
                go.transform.position = new Vector3(currentOffset.x, go.transform.localScale.y / 2, currentOffset.z);
                go.GetComponent<MeshRenderer>().material = material;
                currentOffset.x += 2;

                go.transform.parent = this.transform;
                bars.Add(go);

            }
            /*
            var line = gameObject.GetComponent<LineRenderer>();
            var distance = Vector3.Distance(new Vector3(-5, 5, currentOffset.z), new Vector3(currentOffset.x + 5, 5, currentOffset.z));
            line.materials[0].mainTextureScale = new Vector3(distance, 1, 1);
            */
            lastXOffset = currentOffset.x;
            currentOffset.x = 0;
            currentOffset.z += 2;
        }
        for (int i = 0; i < 6; i++)
        {
            var line = lineRenderers[i];
            line.material = new Material(Shader.Find("Particles/Additive"));
            line.startColor = Color.blue;
            line.endColor = Color.blue;
            line.widthMultiplier = 0.1f;
            line.positionCount = 3;
            line.SetPosition(0, new Vector3(0, i * 2, currentOffset.z));
            line.SetPosition(1, new Vector3(lastXOffset, i * 2, currentOffset.z));
            line.SetPosition(2, new Vector3(lastXOffset, i * 2, 0));
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
        var axisContainer = new GameObject("AxisLegend");
        while (i <= totalMonths)
        {
            var go = Instantiate(zAxisTextPrefab, new Vector3(xOffset, 0, -4.5f), Quaternion.Euler(90, -45, 0));
            go.transform.Translate(new Vector3(2, 0, 0));
            go.transform.parent = axisContainer.transform;

            var month = i % 12 == 0 ? 12 : i % 12;
            var display = new DateTime(year, month, 1).ToString("MMM yyyy");
            xOffset += 2;
            year = month == 12 ? year + 1 : year;
            go.GetComponent<TextMesh>().text = display;
            //gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = 
            //gameObject.transform.parent = this.transform;
            i++;
        }


    }
    public void changeVisibility(string name) {
        foreach(var bar in bars)
        {
            if (bar.name == name)
            { 
                bar.SetActive(!bar.activeSelf);
            }
        }
        }





    // Update is called once per frame
    void Update () {
		
	}

}
