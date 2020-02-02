using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Object
{
    
    

    // Start is called before the first frame update
    protected override void Start()
    {
       // restart = GameObject.Find("Restart").GetComponent<Button>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().SetRestartVisible();
            if (!gm.GetComponent<GameManager>().isComplete)
               Destroy(collision.gameObject, 0f);
            Time.timeScale = 0f;
        }
    }
}
