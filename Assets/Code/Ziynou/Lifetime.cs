using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float timeToLive = 2;
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}
