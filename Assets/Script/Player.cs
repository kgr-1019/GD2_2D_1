using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("最初")]
    [SerializeField] private float startPos;

    [Header("移動関連")]
    private Rigidbody2D rb;
    [SerializeField] private float movingSpeed;
    [SerializeField]private float jumpP = 2f; // ジャンプ力

    [Header("ひのこ飛ばし関連")]
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject firePosition;
    [SerializeField]public bool isRight = true;
    public int direction=1;

    [Header("プレイヤーが死んだら")]
    [SerializeField] private string thisScene;
    private bool canMove = true;

    [Header("ジャンプ制限")]
    private int jumpCount = 0;
    private int maxJumpCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        Vector2 position = transform.position;

        // 登場する
        if (startPos > position.x)
        {
            position.x += movingSpeed * Time.deltaTime;
        }

        // 移動
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= movingSpeed * Time.deltaTime;
            direction = -1;
            // 左向き
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += movingSpeed * Time.deltaTime;
            direction = 1;
            // 右向き
            transform.localScale = new Vector2(1, 1);
        }

        // ジャンプをする（もしスペースキーが押されて、上方向に速度がない時に）
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector2.up * jumpP);
            jumpCount++;
        }

        transform.position = position;


        // ひのこ飛ばし
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ひのこ生成
            Instantiate(fire, firePosition.transform.position, Quaternion.identity); //弾を生成
            
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Light"))
        {
            jumpCount = 0;
        }
    }
}
