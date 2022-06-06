using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parentSpawnObjects;

    void OnParticleCollision(GameObject other) 
    {
        //Debug.Log($"{this.name} has been hit by {other.gameObject.name}");
        GameObject vfx = Instantiate(deathVFX,this.transform.position,Quaternion.identity);
        vfx.transform.parent = parentSpawnObjects;
        Destroy(this.gameObject);
    }
}
