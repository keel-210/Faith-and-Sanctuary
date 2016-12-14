﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWaves : SanctuariesController {

    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    protected override void WaveControll()
    {
        switch (wave)
        {
            case 1:
                if (phase == 1)
                {
                    HereIsSanctuary(1, 2, 'g');
                    HereIsSanctuary(1, 2, 'r');
                    phase++;
                }
                else if (phase == 2)
                {

                }
                else if (phase == 3)
                {
                    if (fields[(int)player.transform.position.x / 2][(int)player.transform.position.z / 2].GetComponent<FieldController>().red
                        && (player.GetComponent<PlayerController>().faith == 'b' || player.GetComponent<PlayerController>().faith == 'g'))
                    {
                        Debug.Log("dbr");
                    }
                    if (fields[(int)player.transform.position.x / 2][(int)player.transform.position.z / 2].GetComponent<FieldController>().blue
                        && (player.GetComponent<PlayerController>().faith == 'r' || player.GetComponent<PlayerController>().faith == 'g'))
                    {
                        Debug.Log("dbb");
                    }
                    if (fields[(int)player.transform.position.x / 2][(int)player.transform.position.z / 2].GetComponent<FieldController>().green
                        && (player.GetComponent<PlayerController>().faith == 'r' || player.GetComponent<PlayerController>().faith == 'b'))
                    {
                        Debug.Log("dbg");
                    }
                }
                break;
            
            default:
                break;
        }
    }

    void HereIsSanctuary(int row, int col, char faith)
    {
        if (faith == 'r')
        {
            fields[row][col].GetComponent<FieldController>().red = true;
        }
        if (faith == 'b')
        {
            fields[row][col].GetComponent<FieldController>().blue = true;
        }
        if (faith == 'g')
        {
            fields[row][col].GetComponent<FieldController>().green = true;
        }
        Instantiate(Resources.Load("Prefabs/HereIsSanc"), new Vector3(row * 2, 0.1f * (row + col) + 2.4f, col * 2), Quaternion.Euler(-90, -45, -90));
    }
}
