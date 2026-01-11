using UnityEngine;

public class ObstacleMap : MonoBehaviour
{
    public GameObject obstaclesGran;
    private GameObject[] obstacles;
    
    public GameObject[] obstaclesMap;
    public GameObject mapStartPoint, mapFinishPoint;
    public GameObject canvas;
    public Transform startPoint, finishPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int x = 0;
        obstacles = new GameObject[obstaclesGran.transform.childCount];
        foreach (Transform obj in obstaclesGran.transform)
        {
            obstacles[x] = obj.gameObject;
            x++;
        }
        obstaclesMap = new GameObject[obstacles.Length];
        for (int i = 0; i < obstacles.Length; i++)
        {
            GameObject obj = Instantiate(obstacles[i], transform.position, Quaternion.identity, canvas.transform);
            obstaclesMap[i] = obj;
            obj.transform.localScale = new Vector3(25f, 25f, 25f);
            obj.layer = 5;
            obj.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            obj.GetComponent<SpriteRenderer>().sortingOrder = 1001;
        }
    }

    void Update()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            float objLerp = Mathf.InverseLerp(startPoint.position.y, finishPoint.position.y, obstacles[i].transform.position.y);
            obstaclesMap[i].transform.position = new Vector3(mapFinishPoint.transform.position.x, Mathf.Lerp(mapStartPoint.transform.position.y, mapFinishPoint.transform.position.y, objLerp) + 0.25f, obstaclesMap[i].transform.position.z);
        }
    }
}
