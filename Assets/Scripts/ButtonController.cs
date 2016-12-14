using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public ButtonController button;

    public void OnClick()
    {
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectname)
    {
        Debug.Log("bb");
    }
}
