using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] private GameObject candleLight;
    [SerializeField] private bool canLight = false;
    [SerializeField] private bool hasLight = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canLight&&!hasLight)
        {
            // ライトを生成
            Instantiate(candleLight, transform.position, Quaternion.identity);
            hasLight = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            canLight = true;
        }
    }
}
