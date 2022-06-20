using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    Rigidbody rb;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToTarg = Vector3.Distance(transform.position, target.transform.position);

        if (target && distToTarg > 10)
        {
            transform.LookAt(target.transform.position);

            rb.velocity = (transform.forward * 10);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
