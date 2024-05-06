using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    float moveSpeed = 8.0f;
    private GameObject gameManager; // GameObjectそのものが入る変数
    private GameManagerScript gameManagerScript; // Scriptが入る変数


    // Start is called before the first frame update
    void Start()
    {
        // ゲームマネージャーのスクリプトを探す
        gameManager = GameObject.Find("GameManager"); // オブジェクトの名前から探す
        gameManagerScript = gameManager.GetComponent<GameManagerScript>(); // Scriptを取得する

        rb.velocity = new Vector3(0, 0, moveSpeed);
        Destroy (gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            gameManagerScript.Hit();
        }
    }

}
