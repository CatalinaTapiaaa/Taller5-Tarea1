using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject particle;
    public float speed;
    public float jumpForce;
    public float speedAumentar;
    public bool victory;

    Rigidbody2D rb2D;
    Vector3 input;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(move * speed, rb2D.velocity.y);
        speed += speedAumentar * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(Vector2.up * jumpForce);
        } 
    }
    //deslizar al avanzar

    public void Muerte()
    {
        Instantiate(particle);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            victory = true;
        }
    }
}
