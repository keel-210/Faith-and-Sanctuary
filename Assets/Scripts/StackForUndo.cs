using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackForUndo : MonoBehaviour {

    private List<ObjAndStack> OAS = new List<ObjAndStack>();
    private int listcount = 0;

    public void MakeStack(GameObject obj)
    {
        ObjAndStack oas = new ObjAndStack();
        oas.pos.Push(obj.transform.position);
        oas.obj = obj;
        OAS.Add(oas);
        listcount++;
    }
	
    public void PushStack(GameObject obj)
    {
        
        for(int i = 0; i < listcount; i++)
        {
            if(OAS[i].obj == obj)
            {
                OAS[i].pos.Push(obj.transform.position);
            }
        }
    }
    public void Clear()
    {
        for (int i = 0; i < listcount; i++)
        {
            OAS[i].pos.Clear();
        }
    }

	public void Undo()
    {
        for (int i = 0; i < listcount; i++)
        {
            if (OAS[i].pos.Count != 0)
            {
                OAS[i].obj.transform.position = OAS[i].pos.Pop();
                if(OAS[i].obj.name == "Player")
                {
                    if (OAS[i].obj.transform.GetComponent<PlayerController>().HowMuchMoved > 0)
                    {
                        OAS[i].obj.transform.GetComponent<PlayerController>().HowMuchMoved--;
                    }
                }
            }
        }
    }

    private class ObjAndStack
    {
        public GameObject obj;
        public Stack<Vector3> pos = new Stack<Vector3>();
    }
}
