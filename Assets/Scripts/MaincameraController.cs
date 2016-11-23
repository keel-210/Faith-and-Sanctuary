using UnityEngine;
using System.Collections;

public class MaincameraController : MonoBehaviour {
    public Vector3 view;
	void Update ()
    {
        transform.LookAt(view);
	}
}
