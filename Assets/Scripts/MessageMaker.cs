using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMaker : MonoBehaviour {

    public MessageMaker message;

    protected int stage = 0;
    public void Make(int wave)
    {
        if (message)
        {
            message.MakeMessage(wave);
        }
    }

    protected virtual void MakeMessage(int wave)
    {
        Debug.Log("test");
    }
}
