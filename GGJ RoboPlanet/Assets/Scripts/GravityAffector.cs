using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffector : MonoBehaviour
{
    public float grvradius;
    public float grvforce;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Attract(Rigidbody2D toAttract)
    {
        Vector2 dir = rb.position - toAttract.position;
        float dis = dir.magnitude;

        if (dis <= grvradius && dis >= 0)
        {
            float force = grvforce * toAttract.GetComponent<Attractable>().Mass / (dis * dis);
            Vector3 fr = dir.normalized * force;
            toAttract.AddForce(fr);
        }
    }


    private void FixedUpdate()
    {
        Attractable[] atr = FindObjectsOfType<Attractable>();
        foreach (Attractable at in atr)
        {
            Attract(at.GetComponent<Rigidbody2D>());
        }
    }
    // Update is called once per frame
    void Update()
    {  
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, grvradius);
    }
}
