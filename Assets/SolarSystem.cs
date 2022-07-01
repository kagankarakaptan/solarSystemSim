using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{

    readonly float G = 0.0001f; //( mass = 5.972E24 kg , distance = 10^9 m )

    GameObject[] celestials;


    // Start is called before the first frame update
    void Awake()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");

        //scaling for visualize
        // foreach (GameObject obj in celestials)
        // {
        //     obj.transform.localScale *= 30f;
        // }

        //random orbital positions
        foreach (GameObject obj in celestials)
        {
            if (obj.name == "Sun" || obj.name == "Moon" || obj.name == "Earth") continue;
            obj.transform.RotateAround(Vector3.zero, Vector3.up, Random.Range(0, 360));
        }

    }

    private void Start()
    {

        initialVelocity();

    }

    private void FixedUpdate()
    {
        gravity();
    }

    void gravity()
    {
        //G*m1*m2/r^2

        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * G * m1 * m2 / r / r);

                }
            }
        }
    }

    void initialVelocity()
    {
        //sqrt of G*m2/r

        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt(G * m2 / r);
                    a.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

}
