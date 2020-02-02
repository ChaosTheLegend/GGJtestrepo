using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [SerializeField]
    public float time;

    private float time2;

    [SerializeField]
    public float fuel;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        GameObject gm = GameObject.Find("GameManager");
        gm.GetComponent<GameManager>().SetScoreFuel(fuel);
        time2 = time;
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();
        PlayerMovementClamping();
        MinusFuel();
    }

    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        { 
            direction += Vector2.left;
        }
    }

    public void MinusFuel()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().SetScoreFuel(fuel);
            if (!gm.GetComponent<GameManager>().isComplete)
            {
                fuel -= 10/100f;
                
                if (fuel <= 0)
                {
                    Destroy(transform.gameObject, 0.2f);
                    gm.GetComponent<GameManager>().SetRestartVisible();
                }
            }
            time = time2/100;
        }
    }

    public void PlusFuel()
    {
        if (fuel + 10 < 100)
        {
            fuel += 10;
            GameObject gm = GameObject.Find("GameManager");
            gm.GetComponent<GameManager>().SetScoreFuel(fuel);
        }
        else {
            fuel = 100;
        }
    }

    void PlayerMovementClamping()
    {
        var viewpointCoord = Camera.main.WorldToViewportPoint(transform.position);

        if (viewpointCoord.x < 0.0f)
        {
            Debug.Log("Left edge of view");
            viewpointCoord.x = 0.0f;
            transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
        }
        else if (viewpointCoord.x > 1.0f)
        {
            Debug.Log("Right edge of view");
            viewpointCoord.x = 1.0f;
            transform.position = Camera.main.ViewportToWorldPoint(viewpointCoord);
        }
    }
}
