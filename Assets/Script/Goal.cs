using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField] public bool isGoal = false;
    [SerializeField] private Image fadeImage; // フェード用のImage
    private float fadeDuration = 5f; // フェードにかかる時間
    private bool isFading = false; // フェード中かどうかのフラグ
    private float fadeElapsedTime = 0f; // フェード経過時間
    private bool isFadeInFinish = false;// フェードインが終わったかどうか
    [SerializeField] private TextMeshProUGUI gameClearText;// ゲームクリアテキスト
    [SerializeField] private string nextScene;

    void Start()
    {
        gameClearText.gameObject.SetActive(false);
    }

    // フェードインの関数
    public void FadeIn()
    {

        if (!isFading)
        {
            isFading = true;

            // Imageを表示させて、最初は表示しない
            fadeImage.gameObject.SetActive(true);

            // 初期透明度を0にする
            Color color = fadeImage.color;
            color.a = 0;
            fadeImage.color = color;

            fadeElapsedTime = 0f; // フェード時間をリセット
        }
    }

    void Update()
    {
        if (isFading)
        {
            // フェード処理の進行
            fadeElapsedTime += Time.deltaTime * 2.5f;

            // アルファ値を更新
            // アルファ値が負の値や1を超えないようにする
            Color color = fadeImage.color;
            color.a = Mathf.Clamp01(fadeElapsedTime / fadeDuration);

            // 更新されたアルファ値を設定する
            fadeImage.color = color;

            // フェードが完了したら
            if (fadeElapsedTime >= fadeDuration)
            {
                // フェード完了後にアルファを1に設定
                color.a = 1;
                fadeImage.color = color;

                // フェード処理が完了したらフラグをリセット
                isFadeInFinish = true;
            }
        }

        // フェードインが終わったら
        if (isFadeInFinish)
        {
            gameClearText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                FadeManager.Instance.LoadScene(nextScene,1f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isGoal = true;
            FadeIn();
        }
    }
}
