using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private GameObject lampLight;
    [SerializeField] private bool canLight = false;
    [SerializeField] private bool hasLight = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canLight && !hasLight)
        {
            // ÉâÉCÉgÇê∂ê¨
            Instantiate(lampLight, transform.position, Quaternion.identity);
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
