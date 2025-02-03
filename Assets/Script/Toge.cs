using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("プレイヤーが死んだら")]
    [SerializeField] private bool isAlive = true;
    [SerializeField] private string thisScene;
    [SerializeField] private float waitTime = 1f;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが死んだらリスタート
        if (!isAlive)
        {
            FadeManager.Instance.LoadScene(thisScene, 1f);
            isAlive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーがトゲと当たったら死ぬ
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDeathSequence(collision.gameObject));
        }
    }

    private IEnumerator PlayerDeathSequence(GameObject player)
    {
        Rigidbody2D rb=player.GetComponent<Rigidbody2D>();
        Player playerScript=player.GetComponent<Player>();
        rb.velocity= Vector3.zero;
        rb.isKinematic = true;

        playerScript.SetCanMove(false);

        yield return new WaitForSeconds(waitTime);

        rb.isKinematic = false;
        rb.gravityScale = 1;

        yield return new WaitForSeconds(1f);
        Destroy(player);
        isAlive = false;
    }
}
