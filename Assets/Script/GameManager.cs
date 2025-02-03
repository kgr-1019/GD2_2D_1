using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string thisScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FadeManager.Instance.LoadScene(thisScene, 1f);
            //SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }
}
