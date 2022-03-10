using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIdle : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    float offset = 0;
    float leftBound = 5;
    float rightBound = 5;
    bool isLeftBound = false;
    bool isRightBound = false;
    Vector2 initPos;

    void Start()
    {
        initPos = transform.position;
    }

    private void FixedUpdate() {
        if(!isRightBound)
        {
            
        }
    }
}
