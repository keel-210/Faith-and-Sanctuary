using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanctuariesMaker : MonoBehaviour {

    private SanctuariesController sanc;
    void Awake()
    {
        sanc = transform.GetComponent<SanctuariesController>().sanc;
        int row = transform.GetComponent<SizeOfSanc>().row;
        int column = transform.GetComponent<SizeOfSanc>().column;
        GameObject.Find("Main Camera").GetComponent<MaincameraController>().view = new Vector3(row - 1, 0, column - 1);
        Object field = Resources.Load("Prefabs/Field");
        for (int i = 0; i < row; i++)
        {
            sanc.fields.Add(new List<GameObject>());
            for (int j = 0; j < column; j++)
            {
                GameObject f = (GameObject)Instantiate(field, new Vector3(i * 2, 0.1f * (i + j), j * 2), Quaternion.identity);
                sanc.fields[i].Add(f);
                f.transform.parent = transform;
            }
        }
    }
}
