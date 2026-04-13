using UnityEngine;
using System.Collections.Generic;

public class PositionTracker : MonoBehaviour
{
    public GameObject startPoint, endPoint;
    public GameObject[] carsList;
    public List<(GameObject car, float dist)> distCars;

    private ActivateCars activateCars;
    private LevelManager levelManager;

    void OnEnable()
    {
        ActivateCars.CarsActivated += SetTracking;
    }

    void OnDisable()
    {
        ActivateCars.CarsActivated -= SetTracking;
    }

    void Start()
    {
        activateCars = GameObject.Find("ActivateCars").GetComponent<ActivateCars>();
        levelManager = GetComponent<LevelManager>();
    }

    void SetTracking()
    {
        carsList.Add(activateCars.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject.SetActive(true));
        int count = 0;
        for (int i = 0; i < activateCars.transform.ChildCount; i++)
        {
            if (activateCars.transform.GetChild(i) != null && activateCars.transform.GetChild(i).activeSelf)
            {
                carsList.Add(activateCars.transform.GetChild(i));
                count++;
                if (count > levelManager.numNPCs)
                {
                    break;
                }
            }
        }
        foreach (GameObject car in carsList)
        {
            distCars.Add((car, GetDistance(car, goal)));
        }
        distCars.Sort((a, b) => a.dist.CompareTo(b.dist));  
    }

    void Update()
    {
        //ordena segons la posició la llista en temps real
        for (int i = 0; i < distCars.Count; i++)
        {
            var car = distCars[i].car;
            distCars[i] = (car, GetDistance(car, goal));
        }
        distCars.Sort((a, b) => a.dist.CompareTo(b.dist));
        //textUI.text = (distCars.FindIndex(a => a.car == playerCar) + 1).ToString();

        //int num = distCars.FindIndex(a => a.car == playerCar);
        //if (num >= sprites.Count) { num = sprites.Count - 1; }
        //numero.sprite = sprites[num];

    }

    float GetDistance(GameObject a, GameObject b)
    {
        if (a.transform.position.y >= b.transform.position.y)
        {
            return 0f;
        }
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
}
