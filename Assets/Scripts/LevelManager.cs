using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int numberLanes, numNPCs;
    public float laneSeparation;
    public GameObject startPoint, endPoint;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < numberLanes; i++)
        {
            Vector2 startLine = new Vector2(i * laneSeparation, startPoint.transform.position.y);
            Vector2 endLine = new Vector2(i * laneSeparation, endPoint.transform.position.y);
            Gizmos.DrawLine(startLine, endLine);
        }
    }
}
