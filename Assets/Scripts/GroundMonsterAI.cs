﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonsterAI : MonoBehaviour {


	// Use this for initialization
    private DialogueManager manager;
    private Player player;

    private Transform target;
    public float speed;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        target = player.GetComponent<Transform>();
        manager = FindObjectOfType<DialogueManager>();
    }

	private void OnTriggerStay2D(Collider2D other)
	{
        if (other.gameObject.name == "Player"){
            ChasePlayer();
            Flip();
            manager.ShowBox(19);
        }
	}

    void ChasePlayer(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x<target.position.x)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
