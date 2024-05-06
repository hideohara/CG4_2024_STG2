using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameOverText;
    private bool gameOverFlag = false;
    public AudioSource hitAudioSource;
    public AudioSource overAudioSource;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private int gameTimer= 0;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ゲームオーバーなら
        if (gameOverFlag==true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
            return;
        }

        // 敵の発生
        gameTimer++;
        int max = 50 - gameTimer / 100;
        int r = Random.Range(0, max);
        if (r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0.0f, 15), Quaternion.identity);
        }

        // スコア表示
        scoreText.text = "SCORE  " + score;

    }

    // ゲームオーバー開始
    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        gameOverFlag = true;
        overAudioSource.Play();
    }

    public bool IsGameOver()
    {
        return gameOverFlag;
    }

    // 弾と敵が衝突
    public void Hit()
    {
        hitAudioSource.Play();
        score += 1;
    }
}