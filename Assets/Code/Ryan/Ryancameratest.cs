using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryancameratest : MonoBehaviour
{

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, target.transform.position.y + 4, transform.position.z);
    }
}

