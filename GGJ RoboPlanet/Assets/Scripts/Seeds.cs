using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : Object
{

    // Start is called before the first frame update
    protected override void Start()
    {
        //scoreFuel = GameObject.Find("FuelScore").GetComponent<Text>();
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
            gm.GetComponent<GameManager>().AddSeeds();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
