using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildButtonController : ButtonController {

    protected override void Click(string objectname)
    {
        if ("GoStraight".Equals(objectname))
        {
            GoStraightClick();
        }
        else if ("RightTurn".Equals(objectname))
        {
            RightTurnClick();
        }
        else if ("LeftTurn".Equals(objectname))
        {
            LeftTurnClick();
        }
        else if ("TurnBack".Equals(objectname))
        {
            TurnBackClick();
        }
        else if ("Undo".Equals(objectname))
        {
            UndoClick();
        }
        else if ("".Equals(objectname))
        {

        }
    }

    private void GoStraightClick()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<BasicMovement>().Set(player, Vector3.forward);
    }

    private void RightTurnClick()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<BasicMovement>().Set(player, Vector3.right);
    }

    private void LeftTurnClick()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<BasicMovement>().Set(player, Vector3.left);
    }

    private void TurnBackClick()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<BasicMovement>().Set(player, Vector3.back);
    }

    private void UndoClick()
    {
        transform.GetComponent<StackForUndo>().Undo();
    }
}
