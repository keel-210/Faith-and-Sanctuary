using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public float time;
	void Start () {
        Invoke("DestroyOnTime", time);
	}
	
	void DestroyOnTime () {
        Destroy(this.gameObject);
	}
}
