using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming_S : MonoBehaviour
{
    public GameObject firePoint;
    public Rigidbody projectile;

    private bool allowFire = true;
    public float fireWait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /// Creates Triangle in screen space to find coordinates of mouse
        Vector3 MouseScreenToCameraSpace = new Vector3(Input.mousePosition.x, 0f, Input.mousePosition.y);
        Vector3 PlayerScreenToCameraSpace = new Vector3(Camera.main.WorldToScreenPoint(transform.position).x, 0f, Camera.main.WorldToScreenPoint(transform.position).y);

        Vector3 PlayerToMouse = MouseScreenToCameraSpace - PlayerScreenToCameraSpace;
        ///
        Debug.DrawLine(transform.position, PlayerToMouse);
        transform.LookAt(PlayerToMouse);

        if (Input.GetButton("Fire1") && (allowFire))
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        // Firing mechanics
        allowFire = false;
        Rigidbody clone;
        clone = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        clone.velocity = firePoint.transform.TransformDirection(Vector3.forward * 20);
        yield return new WaitForSeconds(fireWait);
        allowFire = true;
    }
}
