using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScoreBoard : MonoBehaviour
{
    void OnTriggerEnter()
    {
        UnityEngine.SceneManagement.
        SceneManager.LoadScene("ScoreBoard");
    }
}