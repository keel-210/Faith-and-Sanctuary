using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public char faith;
    public int move = 1;

    private GameObject sanc;
    private int phase;
	void Start () {
        sanc = GameObject.Find("Sanctuaries");
        phase = sanc.GetComponent<SanctuariesController>().phase;
	}
	
	void Update () {
        phase = sanc.GetComponent<SanctuariesController>().phase;
        if (phase == 2)
        {
            Debug.Log("moved");
            
            if (move <= 3)
            {
                float movehor = Input.GetAxisRaw("Horizontal");
                float movever = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(movehor, 0, movever);
                move++;
            }
            else if(move > 3)
            {
                move = 0;
                sanc.GetComponent<SanctuariesController>().phase += 1;
            }
            
        }
        
	}
}
