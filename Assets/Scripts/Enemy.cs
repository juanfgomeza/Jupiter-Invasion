using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;      
    [SerializeField] int enemyKillPoints = 15;
    [SerializeField] int enemyHealth = 4;

    ScoreBoard scoreBoard;
    GameObject parentSpawn;


    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
        parentSpawn = GameObject.FindWithTag("SpawnAtRuntime");

    }

    void AddRigidBody()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"{this.name} has been hit by {other.gameObject.name}");
        ProcessHit();
        if (enemyHealth <= 0)
        {
            KillEnemy();
        }
        
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parentSpawn.transform;
        enemyHealth--;
        
    }
    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(enemyKillPoints);
        GameObject fx = Instantiate(deathFX, this.transform.position, Quaternion.identity);
        fx.transform.parent = parentSpawn.transform;             
        Destroy(this.gameObject);
    }
    
}
