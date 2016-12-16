using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    private Animator anime;
	void Start()
    {
        anime = transform.GetComponent<Animator>();
    }

    public void Walk()
    {
        anime.SetTrigger("walkBattleForward");
    }
}
