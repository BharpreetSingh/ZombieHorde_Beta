using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextSpawnTime;

    public GameObject Prefab;
    public GameObject GM;
    public float spawnDelay;





    public int Spawned;

    private void Update()
    {

        //sets time betwwen spawns based on wave
        spawnDelay = GM.GetComponent<GameManager>().spawnRate; 

        //Sets limit on spawned zombies 
        if ((ShouldSpawn()) && (Spawned<=15))
        {
            Spawn();
        }


    }
    private void Spawn() //spawns enemy after time interval 
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(Prefab, transform.position, transform.rotation);
        Spawned++;
    }
    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }

}
