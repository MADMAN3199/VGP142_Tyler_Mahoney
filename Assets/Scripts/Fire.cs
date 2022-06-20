using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    Transform rayOrigin;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    Rigidbody projectilePrefab;
    [SerializeField]
    float projectileForce;

    public LayerMask layersToCheck;

   public float startingVectorOffset = -45;
   public int numOfLines = 16;
   public int degToRotate = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit[] hitInfo = new RaycastHit[numOfLines];

        float degPerLine = (float)degToRotate / (float)numOfLines;

        rayOrigin.transform.Rotate(Vector3.up, startingVectorOffset);

        for (int i = 0; i < numOfLines; i++)
        {
            Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hitInfo[i], 10.0f, layersToCheck);
            Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * 10.0f, Color.red, 0.5f);
            rayOrigin.transform.Rotate(Vector3.up, degPerLine);
        }

        rayOrigin.transform.Rotate(Vector3.up, startingVectorOffset);

        //if (Physics.Raycast(rayOrigin.transform.position, transform.forward, out hitInfo, 10.0f, layersToCheck))
        //{
        //    Debug.Log("Hit" + hitInfo.transform.gameObject.name);

        //    hitInfo.transform.gameObject.SetActive(false);
        //}
        //Vector3 endPos = transform.forward * 10.0f;

        //Debug.DrawRay(rayOrigin.transform.position, endPos, Color.red);
    }

    public void FireProjectile()
    {
        if (rayOrigin && projectilePrefab)
        {
            Rigidbody temp = Instantiate(projectilePrefab, rayOrigin.position, rayOrigin.rotation);
            temp.AddForce(cameraTransform.transform.forward * projectileForce, ForceMode.Impulse);

            Destroy(temp.gameObject, 2.0f);
        }
    }
}
