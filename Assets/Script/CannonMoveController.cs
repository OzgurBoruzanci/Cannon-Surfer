using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMoveController : MonoBehaviour
{
    float horizontal;
    float placeWidth = 2.35f;
    public float speed;
    bool speedStop;

    void Start()
    {
        Time.timeScale = 1;
    }
    private void OnEnable()
    {
        EventManager.SpeedRegulation += SpeedRegulation;
    }
    private void OnDisable()
    {
        EventManager.SpeedRegulation -= SpeedRegulation;
    }
    void SpeedRegulation()
    {
        speedStop = true;
    }
    float SpeedControl()
    {
        if (speedStop == true)
        {
            return speed = 0;
        }
        else
        {
            return speed;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MouseControl();
        }
    }
    private void LateUpdate()
    {
        MoveControl();
    }
    void MoveControl()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (-placeWidth), placeWidth);
        transform.position = viewPos;
    }

    void MouseControl()
    {
        horizontal = Input.GetAxis("Mouse X");
        //Vector3 vec = new Vector3(horizontal, 0, SpeedControl());
        Vector3 vec = new Vector3(-5, 0, horizontal*4);
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        transform.position += vec * Time.deltaTime * 5f;
    }
}
