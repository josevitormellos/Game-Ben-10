using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationRotation : MonoBehaviour
{
    public float x,y,z;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            gameObject.transform.Rotate(x, y, z, Space.World);
  
       

        
    }
}
