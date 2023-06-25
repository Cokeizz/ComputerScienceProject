using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private int RotationZ = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.localRotation = Quaternion.Euler(0, 0, RotationZ);
    }
}
