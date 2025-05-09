using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty) 
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;

    }

    IEnumerator SpawnTarget() 
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

    }

    public void GameOver() 
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void RestartGame() 
    { 
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

}
