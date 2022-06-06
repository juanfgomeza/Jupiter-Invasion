using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticles;
    float levelLoadDelay = 1f;    
    
    void OnTriggerEnter(Collider other) 
    {
        //Debug.Log($"{this.name} triggered with {other.gameObject.name}");
        StartCrashSequence();        

    }

    void StartCrashSequence()
    {
        explosionParticles.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;        
        Invoke("ReloadLevel",levelLoadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }
}
