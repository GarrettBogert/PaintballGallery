using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Camera cam;
    public GameObject gunBarrel;
    public GameObject gun;
    public GameObject paintball;
    public AudioClip shoot;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }
    Vector3 getRandomVector()
    {
        return new Vector3(Random.RandomRange(-360, 360), Random.RandomRange(-360, 360), Random.RandomRange(-360, 360));
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Quaternion targetRotation = Quaternion.LookRotation(ray.direction);

        gun.transform.rotation = targetRotation;
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().clip = shoot;          
            GetComponent<AudioSource>().PlayOneShot(shoot, 1f);
            var paintballInstance = Instantiate(paintball, gunBarrel.transform.position, Quaternion.Euler(getRandomVector()));
            var rb = paintballInstance.GetComponent<Rigidbody>();
           rb.AddForce(gunBarrel.transform.forward * 1400);
            rb.AddTorque(-200, 4, -400);
        }
    }
}
