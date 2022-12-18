using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedDrop : MonoBehaviour
{
    public GameObject player;

    //Gets the play game object
    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //when picked up by player, get player health and reset to full, destroy the health pack object
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(("Player")))
        {
            player.GetComponentInChildren<PlayerCombat>().HP = 5;
            Destroy(this.gameObject);
        }
    }
}