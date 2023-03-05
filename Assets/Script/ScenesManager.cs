using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public GameObject castleWall;
    public GameObject obstacle;
    public GameObject redCannonBall;
    public GameObject greenCannonBall;

    float obstaclePositionZ = 30;
    float obstaclePositionX = -2;
    float castleWallPositionZ = 45;
    float castleWallPositionX = -1;

    private void OnEnable()
    {
        EventManager.CannonPosition += CannonPosition;
    }
    private void OnDisable()
    {
        EventManager.CannonPosition-= CannonPosition;
    }
    void CannonPosition()
    {
        CreateCastleWallAndObstacle();
    }

    void Start()
    {
        CreateCastleWallAndObstacle();
    }

    
    void Update()
    {
        
    }

    void CreateCastleWallAndObstacle()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(castleWall, new Vector3(-1 * castleWallPositionX, 1.5f, castleWallPositionZ), Quaternion.identity);
            castleWallPositionZ += 30;
            castleWallPositionX *= -1;
        }
        for (int i = 0; i < 6; i++)
        {
            Instantiate(obstacle, new Vector3(-1 * obstaclePositionX, 1.5f, obstaclePositionZ), Quaternion.identity);
            obstaclePositionZ += 15;
            obstaclePositionX*=-1;
        }
    }
}
