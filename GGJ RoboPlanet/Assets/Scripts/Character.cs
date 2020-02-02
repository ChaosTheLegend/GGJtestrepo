using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField]
    private float speed;  //Скорость персонажа

    protected Vector2 direction; //Направление персонажа

    public Vector2 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    private void FixedUpdate()
    {

        Move();
    }

    public void Move()
    {
        transform.Translate(Direction.normalized * speed * Time.deltaTime);
    }

}
