using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float selfDestructDelay = 3f;
    void Update()
    {
        Destroy(this.gameObject, selfDestructDelay);
    }
}
