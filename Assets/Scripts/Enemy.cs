using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parentSpawnObjects;
    [SerializeField] int enemyHitPoints = 15;
    [SerializeField] int enemyHealth = 4;

    ScoreBoard scoreBoard;

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        
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
        vfx.transform.parent = parentSpawnObjects;
        enemyHealth--;
        scoreBoard.IncreaseScore(enemyHitPoints);
    }
    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, this.transform.position, Quaternion.identity);
        vfx.transform.parent = parentSpawnObjects;
        Destroy(this.gameObject);
    }
    
}
