using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public int ammo=10;
    public GameObject cannonBallPrefab;
    List<GameObject> cannonBallList;

    private void Start()
    {
        cannonBallList= new List<GameObject>();
        for (int i = 0; i < ammo; i++)
        {
            cannonBallList.Add(cannonBallPrefab);
        }
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag== "RedCannonBall")
        {
            cannonBallList.Add(cannonBallPrefab);
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag== "GreenCannonBall")
        {
            cannonBallList.Add(cannonBallPrefab);
            Destroy(collision.gameObject);
        }
    }
}
