using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public GameObject player;

    // When player enters/Collides with water they die
    public void OnTriggerEnter(Collider other) 
    {
        if (other.transform.CompareTag("Player")) { player.GetComponent<PlayerCombat>().HP = 0;
            Debug.Log("nigger");
        }

    }
}
