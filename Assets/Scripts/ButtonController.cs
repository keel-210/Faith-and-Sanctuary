using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public ButtonController button;

    public void OnClick()
    {
        button.Click(this.gameObject.name);
    }

    protected virtual void Click(string objectname)
    {
        Debug.Log("bb");
    }
}
