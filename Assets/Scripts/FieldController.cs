using UnityEngine;
using System.Collections;

public class FieldController : MonoBehaviour {

    public bool red, blue, green;
    
    public void Light()
    {
        if (red)
        {
            Instantiate(Resources.Load("Prefabs/RedSanc"), transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
        }
        if (blue)
        {
            Instantiate(Resources.Load("Prefabs/BlueSanc"), transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
        }
        if (green)
        {
            Instantiate(Resources.Load("Prefabs/GreenSanc"), transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
        }
    }
}
