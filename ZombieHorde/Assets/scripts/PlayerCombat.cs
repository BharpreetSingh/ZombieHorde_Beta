using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerCombat : MonoBehaviour
{
    public int ammo;
    public int HP;

    RaycastHit hit;
    public Transform CurrentObject;
    public Transform Gun;
    public GameObject GameOver, YouWin, GM, Boss, PauseUI;

    public GameObject ammoSlider, hpSlider;

    public ParticleSystem Gun1, Gun2;

    public AudioSource gunAudio;
    public AudioClip gun, die;


    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;


    public int kills;

    private void Start()
    {
        HP = 5;
    }
    void Update() 
    {
        //Triggers next wave when kills are reached 
        if (kills == 10){GM.GetComponent<GameManager>().Wave = 2;}
        if (kills == 20){GM.GetComponent<GameManager>().Wave = 3;}
        if (kills == 30){GM.GetComponent<GameManager>().Wave = 4;}
        if (kills == 60 && Boss.activeInHierarchy==false){GM.GetComponent<GameManager>().Wave = 0; YouWin.SetActive(true); }

        //raycast from the player
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 30f)) 
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
           

            CurrentObject = hit.transform;
            
        }


        // triggers shooting, checks if raycast hits enemy, boss or nothing. Spawns bullet, moves it and destroys it
        if (Input.GetMouseButtonDown(0) && ammo > 0) 
        {
            
            Shot();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            Destroy(bullet, 1f);
            if (hit.transform.CompareTag("enemy"))
            {
                ShotEnemy();
            }
            if (hit.transform.CompareTag("boss"))
            {
                ShotBoss();
            }
            


        }

        //Ui for Ammo slider and Hp slider
        float ammoF = (float)ammo;
        ammoSlider.GetComponent<Slider>().value = ammoF;
        float hpF = (float)HP;
        hpSlider.GetComponent<Slider>().value = hpF;

        //kills player at 0 health, pauses gameplay and activates losing ui
        if (HP == 0) 
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
            PauseUI.SetActive(true);
            GetComponentInParent<PlayerMove>().enabled = false;
            GetComponent<PlayerCombat>().enabled = false;
            gunAudio.clip = die;
            gunAudio.Play();
        }

    }

    //plays audio, vfx and removes ammo
    public void Shot() 
    {
        ammo--;
        gunAudio.clip = gun;
        gunAudio.Play();
        Gun1.Emit(200);
        Gun2.Emit(200);

    }

    //When zombies are shot reduces ther health by 1
    public void ShotEnemy() 
    {
        CurrentObject.gameObject.GetComponent<ZombieMove>().Kill(Random.Range(0f,100f));
        kills++;
    }

    //When boss is shot reduces ther health by 1
    public void ShotBoss()
    {
        CurrentObject.gameObject.GetComponent<BossMove>().HP--;
    
    }
}
