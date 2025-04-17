using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int Lives = 4;
    public TextMeshProUGUI scoreNo;
    public TextMeshProUGUI LivesNo;
    public List<GameObject> Objects;
    public bool IsGameActive;
    //public GameObject Box;
    private float spawnrate = 2f;
    //private float Enemyspawnrate = 6f;
    public TextMeshProUGUI GameOver;
    public Button PlayButton;
    public GameObject BeginGame;
    public Button ExitButton;
    public Button ReplayButton;

    private AudioSource PlaySound;
    public AudioClip Crash;
    public AudioClip Point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOver.gameObject.SetActive(false);
        ReplayButton.gameObject.SetActive(false);
        PlaySound = GetComponent<AudioSource>();
    }

    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, Objects.Count);
            Instantiate(Objects[index]);

            if (spawnrate > 0.3f) 
            {
                spawnrate -= 0.01f;
            }
        }
    }
    //IEnumerator SpawnObstacle()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnrate);
    //        int enemyindex = Random.Range(0, 5);
    //        Instantiate(Obstacle);
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
       
    }
    public void Score(int scoreAdd)
    {
        score += scoreAdd;
        scoreNo.text = "Score: " + score;
        PlaySound.PlayOneShot(Point, 1.0f);
    }
    //public void ScoreDeduct(int scoreDeduct)
    //{
    //    score -= scoreDeduct;
    //    scoreNo.text = "Score: " + score;
    //}

    public void ChangeHealth(int health)
    {
        Lives += health;
        LivesNo.text = "Health: " + Lives;
        PlaySound.PlayOneShot(Crash, 1.0f);
        if(Lives <= 0)
        {
            GamesOver();
        }
    }
    public void GamesOver()
    {
        GameOver.gameObject.SetActive(true);
        ReplayButton.gameObject.SetActive(true);
        IsGameActive = false;
    }
    public void StartGame()
    {
        IsGameActive = true;
        Score(0);
        StartCoroutine(SpawnTarget());
        ChangeHealth(0);
        //StartCoroutine(SpawnObstacle());
        scoreNo.gameObject.SetActive(true);
        LivesNo.gameObject.SetActive(true);
        BeginGame.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
        print("You have exited the game");
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ExitButton.gameObject.SetActive(true);
    }
}
