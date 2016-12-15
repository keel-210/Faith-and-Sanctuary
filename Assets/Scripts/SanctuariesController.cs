using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SanctuariesController : MonoBehaviour {

    public int wave = 1;
    public int phase = 1;
    public List<List<GameObject>> fields = new List<List<GameObject>>();
    public SanctuariesController sanc;
    
    void Update()
    {
        if (sanc)
        {
            sanc.WaveController();
            wave = sanc.wave;
            phase = sanc.phase;
        }
    }
    
    protected virtual void WaveController()
    {
        Debug.Log("test");
    }
}
