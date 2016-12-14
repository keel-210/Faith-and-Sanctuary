using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SanctuariesController : MonoBehaviour {

    public int wave = 1;
    public int phase = 1;
    
    public List<List<GameObject>> fields = new List<List<GameObject>>();
    public SanctuariesController sanc;
   
    void Start ()
    {
        int row = GetComponent<SizeOfSanc>().row;
        int column = GetComponent<SizeOfSanc>().column;
        GameObject.Find("Main Camera").GetComponent<MaincameraController>().view = new Vector3(row-1, 0, column-1);
        Object field = Resources.Load("Prefabs/Field");
        for(int i = 0; i < row; i++)
        {
            fields.Add(new List<GameObject>());
            for(int j = 0; j < column; j++)
            {
                GameObject f = (GameObject)Instantiate(field, new Vector3(i * 2, 0.1f * (i + j), j * 2), Quaternion.identity);
                fields[i].Add(f);
                f.transform.parent = transform;
            }
        }
	}
	
	public void Update()
    {
        if (sanc)
        {
            sanc.WaveControll();
        }
        else
        {
            Debug.Log("no sanc");
        }
        
    }

    protected virtual void WaveControll()
    {
        Debug.Log("test");
    }
    
}
