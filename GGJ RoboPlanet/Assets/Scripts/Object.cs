using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    private Vector3 targetPosition;

    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void SetTargetPosition(float x)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(x, -(Camera.main.pixelHeight), Camera.main.nearClipPlane));
    }

    private void FixedUpdate()
    {

        Move();
    }

    public void Move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
