using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    GameObject groundFirst;
    GameObject groundSecond;
    bool groundControl;
    float cannonPosZ = 95;

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
        cannonPosZ += 100;
        groundControl= true;
    }
    void Start()
    {
        groundFirst = transform.GetChild(0).gameObject;
        groundSecond= transform.GetChild(1).gameObject;
    }

    
    void Update()
    {
        if (groundFirst.transform.position.z < groundSecond.transform.position.z && groundFirst.transform.position.z <= cannonPosZ && groundControl)
        {
            groundFirst.transform.position = new Vector3(groundFirst.transform.position.x, groundFirst.transform.position.y, groundFirst.transform.position.z + 200);
            groundControl= false;
        }
        if (groundSecond.transform.position.z < groundFirst.transform.position.z && groundSecond.transform.position.z <= cannonPosZ && groundControl)
        {
            groundSecond.transform.position = new Vector3(groundSecond.transform.position.x, groundSecond.transform.position.y, groundSecond.transform.position.z + 200);
            groundControl= false;
        }
    }
}
