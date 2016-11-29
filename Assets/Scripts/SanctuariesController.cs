using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SanctuariesController : MonoBehaviour {

    public int wave = 1;
    public int phase = 1;
    public bool PlayerIsMoving = false;

    public List<List<GameObject>> fields = new List<List<GameObject>>();
    private GameObject player;
   
    void Start ()
    {

        player = GameObject.Find("Player");
        int row = 5;
        int column = 3;
        GameObject.Find("Main Camera").GetComponent<MaincameraController>().view = new Vector3(column, 0, row);
        Object field = Resources.Load("Prefabs/Field");
        for(int i = 0; i < row; i++)
        {
            fields.Add(new List<GameObject>());
            for(int j = 0; j < column; j++)
            {
                GameObject f = (GameObject)Instantiate(field, new Vector3(j * 2, 0.1f * (i + j), i * 2), Quaternion.identity);
                fields[i].Add(f);
                f.transform.parent = transform;
            }
        }
	}
	
	void Update ()
    {
        switch (wave)
        {
            case 1:
                if(phase == 1)
                {
                    HereIsSanctuary(0, 0, 'g');
                    PlayerIsMoving = true;
                    phase++;
                }
                else if(phase == 2)
                {

                }
                else if(phase == 3)
                {
                    PlayerIsMoving = false;
                    if (fields[(int)player.transform.position.x][(int)player.transform.position.z].GetComponent<FieldController>().red
                        &&(player.GetComponent<PlayerController>().faith == 'b' || player.GetComponent<PlayerController>().faith == 'g'))
                    {
                        Debug.Log("dbr");
                    }
                    if (fields[(int)player.transform.position.x][(int)player.transform.position.z].GetComponent<FieldController>().blue
                        && (player.GetComponent<PlayerController>().faith == 'r' || player.GetComponent<PlayerController>().faith == 'g'))
                    {
                        Debug.Log("dbb");
                    }
                    if (fields[(int)player.transform.position.x][(int)player.transform.position.z].GetComponent<FieldController>().green
                        && (player.GetComponent<PlayerController>().faith == 'r' || player.GetComponent<PlayerController>().faith == 'b'))
                    {
                        Debug.Log("dbg");
                    }
                }
                break;
            case 100:
                if (phase == 1)
                {

                }
                else if (phase == 2)
                {

                }
                else if (phase == 3)
                {

                }
                break;
            default:
                break;
        }
	}

    void HereIsSanctuary(int row,int col,char faith)
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

    }
}
