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
                Instantiate(Resources.Load("Prefabs/"), transform.position, Quaternion.identity);
            }
            if (blue)
            {
                Instantiate(Resources.Load("Prefabs/"), transform.position, Quaternion.identity);
            }
            if (green)
            {
                Instantiate(Resources.Load("Prefabs/"), transform.position, Quaternion.identity);
            }
        }
    }
}
