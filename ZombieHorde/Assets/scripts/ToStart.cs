using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToStart : MonoBehaviour
{
    //triggers scene change
    public void GameStart()
    {
        SceneManager.LoadScene("start");
    }
}
