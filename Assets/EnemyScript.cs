using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float moveSpeedY = 0.1f;
    private GameObject gameManager; // GameObjectそのものが入る変数
    private GameManagerScript gameManagerScript; // Scriptが入る変数

    // Start is called before the first frame update
    void Start()
    {
        // ゲームマネージャーのスクリプトを探す
        gameManager = GameObject.Find("GameManager"); // オブジェクトの名前から探す
        gameManagerScript = gameManager.GetComponent<GameManagerScript>(); // Scriptを取得する

        Destroy(gameObject, 5);
        //transform.rotation = Quaternion.Euler(0, 180, 0);

        // 乱数で左右へ
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }

        Vector3 velocity = new Vector3(0, 0, moveSpeedY);
        transform.position += transform.rotation * velocity;

        // 左右で反転
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        if (transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }

    }
}
