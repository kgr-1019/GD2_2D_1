using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float speed;
    private int direction = 1;
    [SerializeField] private bool isCandle = false;
    [SerializeField] private int candleCount;
    [SerializeField] private int candleTimer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Destroy(gameObject, 0.5f);
        direction = player.GetComponent<Player>().direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCandle)
        {
            Vector2 position = transform.position;

            position.x += speed * direction;

            transform.position = position;

            
        }
        
    }

    void Candle()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Light"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Candle"))
        {
            Destroy(gameObject);
        }
    }
}
