using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class PlayerController : MonoBehaviour {

    public char faith;
    public int move = 1;

    private GameObject sanc;
    private int phase;
    private bool IsMoving;
    private float MoveTimer;
    private Vector3 NextPosition;
    private Vector3 vero;

    private Stack<Vector3> forUndo = new Stack<Vector3>();
	void Start () {
        sanc = GameObject.Find("Sanctuaries");
        phase = sanc.GetComponent<SanctuariesController>().phase;
	}
	
	void Update () {
        phase = sanc.GetComponent<SanctuariesController>().phase;
        if (phase == 2)
        {
            //Debug.Log("moved");
            
            if (move <= 4)
            {
                float movehor = Input.GetAxisRaw("Horizontal");
                float movever = Input.GetAxisRaw("Vertical");
                Vector3 movement = new Vector3(movehor, 0, movever);
                Vector3 NowPosition = Vector3.zero;
                
                if(movement == Vector3.right && !IsMoving)
                {
                    IsMoving = true;
                    NowPosition = transform.position;
                    NextPosition = transform.position + 2*movement;
                    NextPosition += new Vector3(0, 0.1f, 0);
                    vero = 2*movement;
                    forUndo.Push(transform.position);
                }
                if(movement == Vector3.left && !IsMoving)
                {
                    IsMoving = true;
                    NowPosition = transform.position;
                    NextPosition = transform.position + 2*movement;
                    NextPosition += new Vector3(0, -0.1f, 0);
                    vero = 2 * movement;
                    forUndo.Push(transform.position);
                }
                if(movement == Vector3.forward && !IsMoving)
                {
                    IsMoving = true;
                    NowPosition = transform.position;
                    NextPosition = transform.position + 2*movement;
                    NextPosition += new Vector3(0, 0.1f, 0);
                    vero = 2 * movement;
                    forUndo.Push(transform.position);
                }
                if(movement == Vector3.back && !IsMoving)
                {
                    IsMoving = true;
                    NowPosition = transform.position;
                    NextPosition = transform.position + 2*movement;
                    NextPosition += new Vector3(0, -0.1f, 0);
                    vero = 2 * movement;
                    forUndo.Push(transform.position);
                }
                if (IsMoving)
                {
                    MoveTimer += Time.deltaTime;
                    if(MoveTimer < 1f)
                    {
                        transform.position = Vector3.SmoothDamp(transform.position,NextPosition,ref vero,0.25f);
                        Debug.Log(NextPosition);
                    }
                    else
                    {
                        
                        transform.position = NextPosition;
                        
                        move++;
                        Debug.Log("moved");
                        IsMoving = false;
                        MoveTimer = 0;
                    }
                }
                
            }
            else if(move > 4)
            {
                forUndo.Clear();
                move = 0;
                sanc.GetComponent<SanctuariesController>().phase += 1;
            }
            
        }
        
	}
}
