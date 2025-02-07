using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    [SerializeField] private float speed;
    private float targetSize = 3f;
    private float currentSize = 0f;
    private bool isExpanding = true;// サイズが拡大中かどうか
    private float timer = 0f;// 目標サイズに達したら開始するタイマー
    private bool timerActive = false;// タイマーがアクティブかどうか
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (isExpanding)
        {
            if (currentSize < targetSize)
            {
                currentSize += speed * Time.deltaTime;
                transform.localScale = new Vector3(currentSize, currentSize, currentSize);
            }
            else
            {
                isExpanding = false;// サイズが目標値に達したら拡大を停止
                timerActive = true;// タイマーをアクティブに
            }
        }
        else
        {
            // 三秒間数えてるとき
            if (timerActive)
            {
                timer += Time.deltaTime;

                // タイマーが三秒を超えたら非アクティブにする
                if (timer >= 3f)
                {
                    timerActive = false;
                }
            }
            else// 三秒間数えてないとき
            {
                if (currentSize > 0f)
                {
                    currentSize -= speed * Time.deltaTime;
                    transform.localScale = new Vector3(currentSize, currentSize, currentSize);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void isGoal()
    {
        Debug.Log("Goal! ");       
    }
}
