using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackForUndo : MonoBehaviour {

    private List<ObjAndStack> OAS = new List<ObjAndStack>();

    public void MakeStack(GameObject obj)
    {
        ObjAndStack oas = new ObjAndStack();
        oas.pos.Push(obj.transform.position);
        oas.obj = obj;
        OAS.Add(oas);
    }
	
    public void PushStack(GameObject obj)
    {
        for(int i = 0; OAS[i] != null; i++)
        {
            if(OAS[i].obj == obj)
            {
                OAS[i].pos.Push(obj.transform.position);
            }
        }
    }
    public void Clear()
    {
        for (int i = 0; OAS[i] != null; i++)
        {
            OAS[i].pos.Clear();
        }
    }

	public void Undo()
    {
        for (int i = 0; OAS[i] != null; i++)
        {
            OAS[i].obj.transform.position = OAS[i].pos.Pop();
        }
    }

    private class ObjAndStack
    {
        public GameObject obj;
        public Stack<Vector3> pos = new Stack<Vector3>();
    }
}
