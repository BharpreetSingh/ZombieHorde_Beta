using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool pause = false;
    public int Wave = 1;
    public GameObject Boss, PauseUI, player;

    public float spawnRate;
    public TextMeshProUGUI waveText;

    private void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false) // turn on pause
        {
            pause = !pause;
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause == true) // turn off pause
        {
            pause = !pause;
            ResumeGame();
        }
        waveText.text = Wave.ToString();


        // sets wave values 
        if (Wave == 1) { spawnRate = 10; }
        if (Wave == 2) { spawnRate = 7.5f; }
        if (Wave == 3) { spawnRate = 5f; }
        if (Wave == 4) { Boss.SetActive(true); spawnRate = 2.5f; }



    }

    // sets runtime to 0 and disables player move and combat and shows Pause ui
    public void PauseGame() 
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
        player.GetComponent<PlayerMove>().enabled = false;
        player.GetComponentInChildren<PlayerCombat>().enabled = false;
    }

    // sets runtime to 1 and enables player move and combat and hides the Pause ui
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponentInChildren<PlayerCombat>().enabled = true;
    }
}
