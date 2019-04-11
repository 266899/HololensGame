using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject cursor;
    private float shootingDistance = 100f;

    public static bool alive = true;
    public static float health = 100f;
    
	void Update ()
    {   
        RaycastHit hit;
        Ray forwardRay = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(forwardRay, out hit, shootingDistance))
        {
            if (hit.collider.tag == "Enemy")
            {
                cursor.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                cursor.GetComponent<Renderer>().material.color = Color.green;
            }
        }

        CheckAlive();
	}

    public void CheckAlive()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
