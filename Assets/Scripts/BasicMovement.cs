using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
    public GameObject obj;
    public Vector3 movement;

    public bool IsMoving;
    private float MoveTimer;
    private Vector3 NextPosition;
    private Quaternion NextRotation;
    private Vector3 vero;
    private int row, col;
    private GameObject sanc;
    private StackForUndo sfu;
    void Start()
    {
        sanc = GameObject.Find("Sanctuaries");
        row = sanc.GetComponent<SizeOfSanc>().row;
        col = sanc.GetComponent<SizeOfSanc>().column;
        sfu = GameObject.Find("Canvas").transform.FindChild("Undo").GetComponent<StackForUndo>();
    }
    public bool Set (GameObject MoveObj, Vector3 movement)
    {
        if (!IsMoving)
        {
            obj = MoveObj;
            if (movement == Vector3.forward)
            {
                NextPosition = MoveObj.transform.position + 2 * MoveObj.transform.forward;
                NextPosition = new Vector3(NextPosition.x, 1 + 0.1f * ((NextPosition.x + NextPosition.z) / 2), NextPosition.z);
                if (NextPosition.x >= -0.1 && NextPosition.x <= (row -1) * 2 + 0.1 && NextPosition.z >= -0.1 && NextPosition.z <= (col-1) * 2 + 0.1)
                {
                    IsMoving = true;
                    vero = 2 * MoveObj.transform.forward;
                    NextRotation = new Quaternion(0, 0, 0, 0);
                    sfu.PushStack(MoveObj);
                    if (obj.name == "Player")
                    {
                        transform.FindChild("Footman").GetComponent<Animator>().SetTrigger("walkBattleForward");
                    }
                }
                
            }
            if (movement == Vector3.back)
            {
                IsMoving = true;
                NextPosition = Vector3.zero;
                NextRotation = transform.rotation * Quaternion.Euler(0, -180, 0);
            }
            if (movement == Vector3.right)
            {
                IsMoving = true;
                NextPosition = Vector3.zero;
                NextRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            }
            if (movement == Vector3.left)
            {
                IsMoving = true;
                NextPosition = Vector3.zero;
                NextRotation = transform.rotation * Quaternion.Euler(0, -90, 0);
            }
        }
        
        return (IsMoving);
    }
	public void Update ()
    {
        
        if (IsMoving)
        {
            MoveTimer += Time.deltaTime;

            if (MoveTimer < 1.5f && NextPosition != Vector3.zero)
            {
                obj.transform.position = Vector3.SmoothDamp(obj.transform.position, NextPosition, ref vero, 0.5f);
            }
            else if (NextPosition != Vector3.zero)
            {
                obj.transform.position = NextPosition;

                IsMoving = false;
                if(obj.name == "Player")
                {
                    obj.transform.GetComponent<PlayerController>().HowMuchMoved++;
                }
                MoveTimer = 0;
            }

            if (MoveTimer < 1.5f && NextRotation != new Quaternion(0, 0, 0, 0))
            {
                obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, NextRotation, 0.1f);
            }
            else if (NextRotation != new Quaternion(0, 0, 0, 0))
            {
                transform.rotation = NextRotation;

                IsMoving = false;
                MoveTimer = 0;

            }
        }
    }
}
