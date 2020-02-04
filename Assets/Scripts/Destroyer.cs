using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destroyer : MonoBehaviour
{
    public float lifeTime = 10f;

    void Update()
    {
        if(lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0)
            {
                Destruction();
            }
        }

        if(this.transform.position.x <= -20)
        {
            Destruction();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "CloudsDestroyer")
        {
            Destruction();
        }
    }

    void Destruction()
    {
        Destroy(this.gameObject);
    }
}
