using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SanctuariesController : MonoBehaviour {

    public int wave = 1;
    public int phase = 1;
    public List<List<FieldController>> fields = new List<List<FieldController>>();
    public SanctuariesController sanc;
    
    void Update()
    {
        if (sanc)
        {
            sanc.WaveController();
        }
    }
    
    protected virtual void WaveController()
    {
        Debug.Log("test");
    }
}
