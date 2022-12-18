using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieMove : MonoBehaviour
{
    public GameObject player;
    public GameObject Ammo, Med;
    public AudioClip ZombieDied;
    NavMeshAgent Nav;

    private void Start() // get player and nav mesh
    {
        Nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update() // set nav mesh to move towards player
    {
        Nav.SetDestination(player.transform.position);
    }
    public void OnTriggerEnter(Collider other) //deal damage to player on enter
    {
        if (other.CompareTag(("Player")))
        {
            player.GetComponentInChildren<PlayerCombat>().HP--;
            
        }
    }
    public void Kill(float random) //when shot, random chane of enemy dropping healt or ammo prefabs, play death audio and destroy obj
    {
        //if random(1-100) is bigger the 60 spawn ammo
        if (random >= 60f) { Instantiate(Ammo,new Vector3(transform.position.x, transform.position.y +2, transform.position.z), transform.rotation); }

        //if random(1-100) is betwwen 60-30  spawn health
        if (random < 60f && random>=30) { Instantiate(Med,new Vector3(transform.position.x, transform.position.y +2, transform.position.z), transform.rotation); }
        
        //Audio clip
        player.GetComponent<AudioSource>().clip = ZombieDied;
        player.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }
}
