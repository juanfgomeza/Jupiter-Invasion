using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Header, Tooltip and SerializedField are attributes, look them up in Unity docs
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up and down based on player input")][SerializeField] float controlSpeed = 22f;
    [Tooltip("Horizontal range in screen")][SerializeField] float xRange = 11f;
    [Tooltip("Vertical range in screen")][SerializeField] float yRange = 7f;
    
    [Header("Laser Gun Array")]
    [SerializeField] GameObject[] lasers;
    
    [Header("Rotation Settings")]
    [Tooltip("Read about Pitch, Yaw and Roll on the web")][SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 2.5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    float fire;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
                
        
        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");


        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXPos,
        clampedYPos,
        transform.localPosition.z);
    }
    void ProcessFiring()
    {
        // fire when button is pressed
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Pressed fire button!!");
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
        
        

    }

    void SetLasersActive(bool isActive)
    {        
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;

        }        
    }
    


    
}