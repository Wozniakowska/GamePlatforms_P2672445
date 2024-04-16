using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootBullet : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float speed = 25;
    public Transform spawnLocation;

    void Start()
    {
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.activated.AddListener(ShootBullets);
    }

    public void ShootBullets(ActivateEventArgs eventArgs)
    {
       // Create bullets
        GameObject spawnPrefab = Instantiate(BulletPrefab, spawnLocation.position, Quaternion.identity);

        // hold the gun straight
        Vector3 gunForward = transform.forward;

        // Shoot the bullets forward
        spawnPrefab.GetComponent<Rigidbody>().velocity = gunForward * speed;

        // Match gun rotation for the bullets
        spawnPrefab.transform.rotation = Quaternion.LookRotation(gunForward);

        // Destoy the bullets after 5secs
        Destroy(spawnPrefab, 5);
    }
}