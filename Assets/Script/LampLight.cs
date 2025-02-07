using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    [SerializeField] private float speed;
    private float targetSize = 3f;
    private float currentSize = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSize < targetSize)
        {
            currentSize += speed * Time.deltaTime;
            transform.localScale = new Vector3(currentSize, currentSize, currentSize);
        }
    }
}
