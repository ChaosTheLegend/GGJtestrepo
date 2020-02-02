using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{

    [SerializeField]
    public GameObject enemy;

    [SerializeField]
    public GameObject fuel;

    [SerializeField]
    public GameObject seeds;

    [SerializeField]
    public float time;

    private float time2;

    public enum Objects
    {
        Enemy,
        Seeds,
        Fuel
    }

    // Start is called before the first frame update
    void Start()
    {
        time2 = time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Random = " + Random.Range(1, 4));
            int obj = Random.Range(1, 4);
            switch (obj)
            {
                case 1:
                    enemy.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Camera.main.pixelWidth), Camera.main.pixelHeight, Camera.main.nearClipPlane));
                    Instantiate(enemy);
                    break;
                case 2:
                    fuel.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Camera.main.pixelWidth), Camera.main.pixelHeight, Camera.main.nearClipPlane));
                    Instantiate(fuel);
                    break;
                case 3:
                    seeds.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Camera.main.pixelWidth), Camera.main.pixelHeight, Camera.main.nearClipPlane));
                    Instantiate(seeds);
                    break;
                default:
                    break;
            }
            
            time = time2;
        }
    }
}
