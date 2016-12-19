using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessage : MessageMaker {
    public GameObject panel;
    public Text tex;
    protected override void MakeMessage(int wave)
    {
        if(wave == 1)
        {
            panel.SetActive(true);
            bool next = (0 < (Input.GetAxisRaw("Next1") + Input.GetAxisRaw("Next2")));

            switch (stage)
            {
                case 0:
                    tex.text = "テスト";
                    if (next)
                    {
                        stage++;
                    }
                    break;
                case 1:
                    tex.text = "";
                    GameObject.Find("Sanctuaries").GetComponent<SanctuariesController>().sanc.phase++;
                    break;
            }
            
        }
    }
}
