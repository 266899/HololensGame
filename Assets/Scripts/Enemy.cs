using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Enemy : MonoBehaviour, IInputClickHandler
{
    public GameObject deathParticles;
    public GameObject gunPoint;
    public GameObject bullet;
    public GameObject playerObject;
    private float timer;
    public float shootDelay = 3f;

	// Use this for initialization
	void Start () {
        playerObject = GameObject.Find("MixedRealityCamera");
    }

	void Update () {
		FacePlayer();
        Shoot();
    }

    void FacePlayer()
    {
        transform.LookAt(playerObject.GetComponent<Transform>());
        //Vector3 direction = (playerObject.GetComponent<Transform>().position - transform.position).normalized;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (shootDelay < timer)
        {
            //Debug.Log("shoot");
            Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
            timer = 0;
        }
        
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Destroy(gameObject);
        Destroy(Instantiate(deathParticles,transform.position, Quaternion.identity), 1f);
    }
}
