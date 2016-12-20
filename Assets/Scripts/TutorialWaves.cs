using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWaves : SanctuariesController {

    private GameObject player;
    private StackForUndo sfu;
    private bool SancHasLitten;
    private bool SancHasDeployed;
    private MessageMaker message;

    void Start()
    {
        player = GameObject.Find("Player");
        message = transform.parent.gameObject.GetComponent<MessageMaker>();
        sfu = GameObject.Find("Canvas").transform.Find("Undo").GetComponent<StackForUndo>();
        int row = transform.GetComponent<SizeOfSanc>().row;
        int column = transform.GetComponent<SizeOfSanc>().column;
        GameObject.Find("Main Camera").GetComponent<MaincameraController>().view = new Vector3(row - 1, 0, column - 1);
        Object field = Resources.Load("Prefabs/Field");
        for (int i = 0; i < row; i++)
        {
            fields.Add(new List<FieldController>());
            for (int j = 0; j < column; j++)
            {
                GameObject f = (GameObject)Instantiate(field, new Vector3(i * 2, 0.1f * (i + j), j * 2), Quaternion.identity);
                fields[i].Add(f.GetComponent<FieldController>());
                f.transform.parent = transform;
            }
        }
    }

    protected override void WaveController()
    {
        
        switch (wave)
        {
            case 1:
                if (phase == 1)
                {
                    SancHasLitten = false;
                    if (!SancHasDeployed)
                    {
                        HereIsSanctuary(1, 2, 'g');
                        HereIsSanctuary(1, 2, 'r');
                        CrossIsSanctuary(0, 2, 'b');
                        SancHasDeployed = true;
                    }
                    Message();
                }
                else if (phase == 2)
                {

                }
                else if (phase == 3)
                {
                    if (!SancHasLitten)
                    {
                        SancLight();
                        SancHasLitten = true;
                    }
                    Death();
                    sfu.Clear();
                    NextWave();
                }
                
                break;
            case 2:
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

    void HereIsSanctuary(int row, int col, char faith)
    {
        if (faith == 'r')
        {
            fields[row][col].red = true;
        }
        if (faith == 'b')
        {
            fields[row][col].blue = true;
        }
        if (faith == 'g')
        {
            fields[row][col].green = true;
        }
        Instantiate(Resources.Load("Prefabs/HereIsSanc"), new Vector3(row * 2, 0.1f * (row + col) + 2.4f, col * 2), Quaternion.Euler(-90, -45, -90));
    }

    void CrossIsSanctuary(int row,int col, char faith)
    {
        int Maxrow = transform.GetComponent<SizeOfSanc>().row;
        int Maxcol = transform.GetComponent<SizeOfSanc>().column;
        if (faith == 'r')
        {
            for(int i = 0; i < 5; i++)
            {
                if (row - i >= 0)
                {
                    fields[row - i][col].red = true;
                }
                if (col - i >= 0)
                {
                    fields[row][col - i].red = true;
                }
                if (row + i < Maxrow)
                {
                    fields[row + i][col].red = true;
                }
                if (col + i < Maxcol)
                {
                    fields[row][col + i].red = true;
                }
            }
            Instantiate(Resources.Load("Prefabs/CrossIsSanc"), new Vector3(row * 2, 0.1f * (row + col) + 2.4f, col * 2), Quaternion.Euler(-90, -45, -90));
        }
        if (faith == 'b')
        {
            for (int i = 0; i < 5; i++)
            {
                if (row - i >= 0)
                {
                    fields[row - i][col].blue = true;
                }
                if (col - i >= 0)
                {
                    fields[row][col - i].blue = true;
                }
                if (row + i < Maxrow)
                {
                    fields[row + i][col].blue = true;
                }
                if (col + i < Maxcol)
                {
                    fields[row][col + i].blue = true;
                }
            }
            Instantiate(Resources.Load("Prefabs/CrossIsSanc"), new Vector3(row * 2, 0.1f * (row + col) + 2.4f, col * 2), Quaternion.Euler(-90, -45, -90));
        }
        if (faith == 'g')
        {
            for (int i = 0; i < 5; i++)
            {
                if (row - i >= 0)
                {
                    fields[row - i][col].green = true;
                }
                if (col - i >= 0)
                {
                    fields[row][col - i].green = true;
                }
                if (row + i < Maxrow)
                {
                    fields[row + i][col].green = true;
                }
                if (col + i < Maxcol)
                {
                    fields[row][col + i].green = true;
                }
            }
            Instantiate(Resources.Load("Prefabs/CrossIsSanc"), new Vector3(row * 2, 0.1f * (row + col) + 2.4f, col * 2), Quaternion.Euler(-90, -45, -90));
        }
        
    }
    void Message()
    {
        message.Make(phase);
    }
    void Death()
    {
        if (fields[Mathf.RoundToInt(player.transform.position.x / 2)][Mathf.RoundToInt(player.transform.position.z / 2)].red
                        && (player.GetComponent<PlayerController>().faith == 'b' || player.GetComponent<PlayerController>().faith == 'g'))
        {
            Debug.Log("dbr");
            player.transform.FindChild("Footman").GetComponent<Animator>().SetTrigger("getHit");
        }
        if (fields[Mathf.RoundToInt(player.transform.position.x / 2)][Mathf.RoundToInt(player.transform.position.z / 2)].blue
            && (player.GetComponent<PlayerController>().faith == 'r' || player.GetComponent<PlayerController>().faith == 'g'))
        {
            Debug.Log("dbb");
            player.transform.FindChild("Footman").GetComponent<Animator>().SetTrigger("getHit");
        }
        if (fields[Mathf.RoundToInt(player.transform.position.x / 2)][Mathf.RoundToInt(player.transform.position.z / 2)].green
            && (player.GetComponent<PlayerController>().faith == 'r' || player.GetComponent<PlayerController>().faith == 'b'))
        {
            Debug.Log("dbg");
            player.transform.FindChild("Footman").GetComponent<Animator>().SetTrigger("getHit");
        }
    }

    void NextWave()
    {
        int row = transform.GetComponent<SizeOfSanc>().row;
        int col = transform.GetComponent<SizeOfSanc>().column;
        for (int i = 0; i < row; i++)
        {
            for(int j = 0; j < col; j++)
            {
                fields[i][j].red = false;
                fields[i][j].blue = false;
                fields[i][j].green = false;
            }
        }
        SancHasDeployed = false;
        SancHasLitten = false;
    }

    void SancLight()
    {
        int row = transform.GetComponent<SizeOfSanc>().row;
        int col = transform.GetComponent<SizeOfSanc>().column;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                fields[i][j].Light();
            }
        }
    }
}
