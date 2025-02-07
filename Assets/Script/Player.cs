using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("�ŏ�")]
    [SerializeField] private float startPos;

    [Header("�ړ��֘A")]
    private Rigidbody2D rb;
    [SerializeField] private float movingSpeed;
    [SerializeField]private float jumpP = 2f; // �W�����v��

    [Header("�Ђ̂���΂��֘A")]
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject firePosition;
    [SerializeField]public bool isRight = true;
    public int direction=1;

    [Header("�v���C���[�����񂾂�")]
    [SerializeField] private string thisScene;
    private bool canMove = true;

    [Header("�W�����v����")]
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

        // �o�ꂷ��
        if (startPos > position.x)
        {
            position.x += movingSpeed * Time.deltaTime;
        }

        // �ړ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= movingSpeed * Time.deltaTime;
            direction = -1;
            // ������
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += movingSpeed * Time.deltaTime;
            direction = 1;
            // �E����
            transform.localScale = new Vector2(1, 1);
        }

        // �W�����v������i�����X�y�[�X�L�[��������āA������ɑ��x���Ȃ����Ɂj
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumpCount)
        {
            rb.AddForce(Vector2.up * jumpP);
            jumpCount++;
        }

        transform.position = position;


        // �Ђ̂���΂�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �Ђ̂�����
            Instantiate(fire, firePosition.transform.position, Quaternion.identity); //�e�𐶐�
            
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
