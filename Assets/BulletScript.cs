using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    float moveSpeed = 8.0f;
    //public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0, 0, moveSpeed);
        Destroy (gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            //gameManagerScript.Hit(transform.position);
        }
    }

}
