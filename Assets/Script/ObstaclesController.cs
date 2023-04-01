using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public List<GameObject> obstacles=new List<GameObject> ();
    float zPosition;

    private void OnEnable()
    {
        EventManager.CannonPosition += CannonPosition;
    }
    private void OnDisable()
    {
        EventManager.CannonPosition -= CannonPosition;
    }
    void CannonPosition(Vector3 cannonPos)
    {
        CreateObstacle(cannonPos);
    }

    void Start()
    {
        CreateObstacle(new Vector3(0, 0, 20));
    }

    
    void Update()
    {
        
    }

    void CreateObstacle(Vector3 cannonPos)
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            Instantiate(obstacles[i], new Vector3(Random.Range(-2,2), obstacles[i].transform.position.y, cannonPos.z +zPosition), obstacles[i].transform.rotation);
            
            zPosition += 15;
        }
        zPosition = 15;
    }

}
