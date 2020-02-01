using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public GameObject Background;
    public GameObject BackgroundPrefab;
    public float BackgroundScale;

    int bgsize = 1;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    void DoubleBG()
    {
        //bgBounds.size *= 3f;

    }

    // Update is called once per frame
    void Update()
    {
        Background.transform.position = transform.position * BackgroundScale;
        Background.transform.position = new Vector3(Background.transform.position.x, Background.transform.position.y, 20f);

        //camera.transform.rotation = transform.rotation;
        //camera.transform.position = new Vector3(transform.position.x, transform.position.y, -1f) + CameraOffset;
    }
}
