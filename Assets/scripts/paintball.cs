﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintball : MonoBehaviour {

    Vector3 lastPos;
    RaycastHit hit;
    public Collider ballCol;
    public GameObject splat;
    public GameObject splatDecal;
    

    // Use this for initialization
    void Start () {
        lastPos = this.transform.position;
        ballCol = this.GetComponent<Collider>();
    }
    void Update()
    {
        if (ballCol.enabled == true)
        {
            Debug.DrawRay(lastPos, transform.position);
            if (Physics.Raycast(lastPos, (transform.position - lastPos), out hit, Vector3.Distance(lastPos, transform.position)))
            {
                if (hit.collider.gameObject.tag != "Projectile")
                {
                    this.transform.position = hit.point;
                    Splat(hit.point);
                }
            }
        }
        lastPos = this.transform.position;
    }
    void Splat(Vector3 hitPoint)
    {
        ballCol.enabled = false;
        Instantiate(Resources.Load("paintball_pieces"), transform.position, Quaternion.identity);            
       
        var rot = Quaternion.LookRotation(hit.normal);
        //Goal here is to find where we hit the surface of something, pull an imaginary point in 3d space backwards in the paintball's trajectory, then do a randomized "spray" of raycasts in a general direction from this point at the fence in order to render spray.
        
        var rigidbody = this.GetComponent<Rigidbody>();
        var paintballDirection = rigidbody.velocity;
        var oppositeDirection = -paintballDirection;
        //.002f is a good multiplier for backing up our paintball position away from the surface we hit.
        var pos = hit.point + (oppositeDirection * .002f);
        //Todo: Remove this debug marker alltogether. It is simply an imaginary point from which the spray happens - just above the surface of where it had hit.
        Instantiate(Resources.Load("debug marker"), pos, Quaternion.identity);
        for (int i = 0; i < 50; i++)
        {
            RaycastHit thisHit;           
            var noise = GetRandomNoise(-20f, 20f);            
            Vector3 adjustedDir = noise + paintballDirection;
            var theRay = new Ray(pos, adjustedDir);
            if (Physics.Raycast(theRay, out thisHit, 5))
            {
                Instantiate(Resources.Load("debug marker2"), thisHit.point, Quaternion.identity);
            }
        }

        Destroy(this.gameObject);
    }
    void BallHitCollider(Collider col)
    {
        Destroy(this.gameObject);
    }

    Vector3 GetRandomNoise(float min, float max)
    {
        float xNoise = Random.Range(min, max);
        float yNoise = Random.Range(min, max);
        float zNoise = Random.Range(min, max);

       return new Vector3(
           xNoise,
           yNoise,
           zNoise
        );
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Splat(collision.contacts[0].point);
    }
}
