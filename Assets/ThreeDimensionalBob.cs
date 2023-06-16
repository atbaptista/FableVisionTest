using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDimensionalBob : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(400*transform.forward);
        //Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
