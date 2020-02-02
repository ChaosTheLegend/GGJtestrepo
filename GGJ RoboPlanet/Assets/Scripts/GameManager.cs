using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject restart;

    [SerializeField]
    public GameObject next;

    [SerializeField]
    public Text scoreFuel;

    [SerializeField]
    public Text scoreSeeds;

    [SerializeField]
    public GameObject planet;

    [SerializeField]
    public int allSeeds;

    private int currentSeeds;

    public bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        restart.SetActive(false);
        next.SetActive(false);
        planet.SetActive(false);
        currentSeeds = 0;
        isComplete = false;
        scoreSeeds.text = currentSeeds.ToString() + " / " + allSeeds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRestartVisible()
    {
        restart.SetActive(true);
    }

    public void SetScoreFuel(float s)
    {
        scoreFuel.text = s.ToString();
    }

    public void AddSeeds()
    {
        currentSeeds += 1;
        scoreSeeds.text = currentSeeds.ToString() + " / " + allSeeds.ToString();
        if (currentSeeds == allSeeds)
        {
            isComplete = true;
            planet.SetActive(true);
            next.SetActive(true);
        }
    }
}
