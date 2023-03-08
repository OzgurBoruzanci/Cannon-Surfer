using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveManager : MonoBehaviour
{
    public GameObject cannon;
    Vector3 cameraPosition;
    Vector3 distanceBetween;
    void Start()
    {
        distanceBetween = cannon.transform.position - Camera.main.transform.position;
    }


    void LateUpdate()
    {
        //Debug.Log(characterRg.boxsRb.Count);
        cameraPosition = new Vector3(distanceBetween.x, distanceBetween.y, distanceBetween.z);
        Camera.main.transform.position = cannon.transform.position - cameraPosition;
    }
}
