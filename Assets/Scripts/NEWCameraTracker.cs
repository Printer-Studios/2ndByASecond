using UnityEngine;

public class NEWCameraTracker : MonoBehaviour
{
    //PER PROBAR
    
    public GameObject tofollwo;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, tofollwo.transform.position.y, -10);
    }
}
