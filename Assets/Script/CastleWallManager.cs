using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleWallManager : MonoBehaviour
{
    public Material orange;
    GameObject piece;
    Rigidbody rb;
    Collider[] colliders;
    List<GameObject> toBeShotList;
    Vector3 fragmentationPos;
    Vector3 cubesPivot;

    float cubesPivotDistance;
    public float cubeSize = 0.2f;
    public float fragmentationRadius = 4;
    public float fragmentationForce = 50;
    public float fragmentationUpward = 0.4f;
    public int cubesInRow = 5;
    int fragmentationControlInt;

    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        fragmentationControlInt = Random.Range(1, 10);
        toBeShotList = new List<GameObject>();
    }


    void Update()
    {
        Debug.Log(fragmentationControlInt);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            toBeShotList.Add(collision.gameObject);
            if (toBeShotList.Count== fragmentationControlInt)
            {
                FragmentationCube();
            }
        }
    }

    void FragmentationCube()
    {
        gameObject.SetActive(false);

        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        fragmentationPos = transform.position;
        colliders = Physics.OverlapSphere(fragmentationPos, fragmentationRadius);
        foreach (Collider hit in colliders)
        {
            rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fragmentationForce, transform.position, fragmentationRadius, fragmentationUpward);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot + new Vector3(0, 0.5f, 0);
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.GetComponent<Renderer>().material.color = orange.color;
        Destroy(piece.GetComponent<BoxCollider>());
        Destroy(piece, 5);
    }

}