using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string ToLoad;
    public bool Loadable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadScene(string sc)
    {
        SceneManager.LoadScene(sc);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Loadable)
        {
            if (collision.gameObject.tag == "Player")
            {
                LoadScene(ToLoad);
                Loadable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
