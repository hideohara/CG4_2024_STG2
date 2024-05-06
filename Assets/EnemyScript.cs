using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float moveSpeedY = 0.1f;
    private GameObject gameManager; // GameObject���̂��̂�����ϐ�
    private GameManagerScript gameManagerScript; // Script������ϐ�

    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���}�l�[�W���[�̃X�N���v�g��T��
        gameManager = GameObject.Find("GameManager"); // �I�u�W�F�N�g�̖��O����T��
        gameManagerScript = gameManager.GetComponent<GameManagerScript>(); // Script���擾����

        Destroy(gameObject, 5);
        //transform.rotation = Quaternion.Euler(0, 180, 0);

        // �����ō��E��
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

        // ���E�Ŕ��]
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
