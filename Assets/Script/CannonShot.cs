using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    Vector3 firePoint;

    Camera cam;
    Vector3 initialVelocity;

    bool pressingMouse = false;

    private void Start()
    {

        cam = Camera.main;
    }

    private void Update()
    {
        firePoint = new Vector3(transform.position.x, transform.position.y + 0.45f, transform.position.z + 0.85f);
        if (Input.GetMouseButtonDown(1))
        {
            pressingMouse = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            pressingMouse = false;
            Fire();
        }

        if (pressingMouse)
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z + 20);
            initialVelocity = target - firePoint;
        }
    }

    void Fire()
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, firePoint, Quaternion.identity);
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();
        rb.AddForce(initialVelocity, ForceMode.Impulse);
    }
}
