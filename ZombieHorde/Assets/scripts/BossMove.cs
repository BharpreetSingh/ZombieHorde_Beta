using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossMove : MonoBehaviour
{
    public GameObject player, winUI, GM, pauseUI;
    public GameObject Ammo;
    public int HP;
    NavMeshAgent Nav;

    //get player and nav mesh
    private void Start() 
    {
        Nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //set nav to move towards player, kill boss if hp = 0
    void Update() 
    {
        Nav.SetDestination(player.transform.position);
        if (HP <= 0) { Kill(70); }
    }

    //When zombie hits/collides with  player looses health by 1 
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(("Player")))
        {
            player.GetComponentInChildren<PlayerCombat>().HP--;
        }
    }

    //When boss hp is 0 spawns ammo and triggers "You win" UI
    public void Kill(float random) 
    {
        if (random >= 70f) { Instantiate(Ammo, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation); }
        winUI.SetActive(true);
        pauseUI.SetActive(true);
        Destroy(this.gameObject, 0.2f);
    }
}
