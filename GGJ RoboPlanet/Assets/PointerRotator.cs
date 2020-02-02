using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerRotator : MonoBehaviour
{
    public GameObject center;

    public GameObject player;
    public GameObject target;
    public float detectorrange;

    public float MaxDis;
    public float MinDis;
    Color def;

    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        def = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        angle = -player.transform.rotation.z*180 + 90 + Mathf.Atan2(target.transform.position.y - Camera.main.transform.position.y, target.transform.position.x - Camera.main.transform.position.x) * 180 / Mathf.PI;
        float dis = (new Vector2(target.transform.position.x, target.transform.position.y) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y)).sqrMagnitude;
        float dis2 = (new Vector2(target.transform.position.x, target.transform.position.y) - new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y)).magnitude;


        if (dis <= (detectorrange + 6) * (detectorrange+6))
        {
            GetComponent<Image>().color = new Color(def.r, def.g, def.b, (dis2-6)/detectorrange);
        }
        else
        {
            GetComponent<Image>().color = def;
        }
        
        float pseudoangle = angle - 90f;
        float x = Mathf.Cos(pseudoangle * Mathf.Deg2Rad) * MinDis;
        float y = Mathf.Sin(pseudoangle * Mathf.Deg2Rad) * MaxDis;
        transform.position = center.transform.position + new Vector3(x , y, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle+90);
    }
}
