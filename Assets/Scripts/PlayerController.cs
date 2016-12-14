using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class PlayerController : MonoBehaviour {

    public char faith;
    public int HowMuchMoved = 1;

    private GameObject sanc;
    private int phase;
    private BasicMovement move;
    public void Start ()
    {
        move = gameObject.AddComponent<BasicMovement>();
        sanc = GameObject.Find("Sanctuaries");
        phase = sanc.GetComponent<SanctuariesController>().phase;
        GameObject.Find("Canvas").transform.Find("Undo").GetComponent<StackForUndo>().MakeStack(this.gameObject);
    }
	
	void Update () {
        phase = sanc.GetComponent<SanctuariesController>().phase;
        if (phase == 2)
        {
            if (HowMuchMoved < 3)
            {
                float movehor = Input.GetAxisRaw("Horizontal");
                float movever = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(movehor, 0, movever);
                
                if (movement != Vector3.zero)
                {
                    move.Set(gameObject,movement);
                }
                if (move.Update())
                {
                    HowMuchMoved++;
                }
            }
            else if (HowMuchMoved >= 3)
            {
                HowMuchMoved = 1;
                sanc.GetComponent<SanctuariesController>().phase += 1;
            }
            
        }
        
	}
}
