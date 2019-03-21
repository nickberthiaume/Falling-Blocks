using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

	// Use this for initialization
	void Start () {
        FindObjectOfType<PlayerControl>().OnPlayerDeath += OnGameOver;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
	}

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
