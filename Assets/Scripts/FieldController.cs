using UnityEngine;
using System.Collections;

public class FieldController : MonoBehaviour {

    public bool red, blue, green;
    private SanctuariesController SancMaster;
    void Start()
    {
        SancMaster = transform.parent.gameObject.GetComponent<SanctuariesController>();
        
    }
    void Update()
    {
        int phase = SancMaster.phase;
        if(phase == 3)
        {
            if (red)
            {
                Instantiate(Resources.Load("Prefabs/RedSanc"), transform.position + new Vector3(0,1f,0), Quaternion.Euler(-90,0,0));
                red = false;
            }
            if (blue)
            {
                Instantiate(Resources.Load("Prefabs/BlueSanc"), transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
                blue = false;
            }
            if (green)
            {
                Instantiate(Resources.Load("Prefabs/GreenSanc"), transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(-90, 0, 0));
                green = false;
                
            }
        }
    }
}
