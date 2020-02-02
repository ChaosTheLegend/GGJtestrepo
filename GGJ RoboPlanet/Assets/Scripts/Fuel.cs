using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : Object
{
    private Text scoreFuel;

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
            Debug.Log("Player !!!!!!!!!!");
            collision.GetComponent<Player>().PlusFuel();
            Destroy(this.gameObject, 0.2f);
        }
    }
}
