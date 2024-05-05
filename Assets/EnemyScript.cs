using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float moveSpeedY = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        //transform.rotation = Quaternion.Euler(0, 180, 0);

        // —”‚Å¶‰E‚Ö
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
        Vector3 velocity = new Vector3(0, 0, moveSpeedY);
        transform.position += transform.rotation * velocity;

        // ¶‰E‚Å”½“]
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
