using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] int currentLives;
    [SerializeField] private int pointsPerLost = 1;

    [SerializeField] private Text liveText;


    // Start is called before the first frame update
    void Start()
    {
        liveText.text = lives.ToString();
        currentLives = lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LostLives()
    {
        currentLives -= pointsPerLost;
        liveText.text = currentLives.ToString();
        if (currentLives == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
