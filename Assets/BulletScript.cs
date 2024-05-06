using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    float moveSpeed = 8.0f;
    private GameObject gameManager; // GameObject���̂��̂�����ϐ�
    private GameManagerScript gameManagerScript; // Script������ϐ�


    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���}�l�[�W���[�̃X�N���v�g��T��
        gameManager = GameObject.Find("GameManager"); // �I�u�W�F�N�g�̖��O����T��
        gameManagerScript = gameManager.GetComponent<GameManagerScript>(); // Script���擾����

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
