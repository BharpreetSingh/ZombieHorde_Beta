using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    public GameObject player;

    //Finding player game object
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // resets ammo to full on enter
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(("Player")))
        {
            player.GetComponentInChildren<PlayerCombat>().ammo=5;
            Destroy(this.gameObject);
        }
    }
}
