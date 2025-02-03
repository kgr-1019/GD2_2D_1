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
    [SerializeField] private bool isAlive = true;
    [SerializeField] private string thisScene;
    private bool canMove = true;

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
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= movingSpeed * Time.deltaTime;
            direction = -1;
            // ������
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            position.x += movingSpeed * Time.deltaTime;
            direction = 1;
            // �E����
            transform.localScale = new Vector2(1, 1);
        }

        // �W�����v������i�����X�y�[�X�L�[��������āA������ɑ��x���Ȃ����Ɂj
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpP);
        }

        transform.position = position;


        // �Ђ̂���΂�
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(fire, firePosition.transform.position, Quaternion.identity); //�e�𐶐�
            
        }

        
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
