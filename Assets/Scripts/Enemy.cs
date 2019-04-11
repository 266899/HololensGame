using System.Collections;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Enemy : MonoBehaviour, IInputClickHandler, IFocusable
{
    public GameObject deathParticles;
    public GameObject gunPoint;
    public GameObject bullet;
    public GameObject playerObject;
    private float timer;
    public float shootDelay = 3f;
    private Renderer renderer;
    private Color defaultColor;
    public static int killCount;

    // Use this for initialization
    void Start () {
        playerObject = GameObject.Find("MixedRealityCamera");
        renderer = GetComponent<Renderer>();
        defaultColor = Color.white;
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
            Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);          
            timer = 0;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    { 
        StartCoroutine(destroyObject());
    }

    IEnumerator destroyObject()
    {
        killCount++;
        Destroy(gameObject);
        Destroy(Instantiate(deathParticles, transform.position, Quaternion.identity), 1f);
        yield break;
    }

    public void OnFocusEnter()
    {
        renderer.material.color = Color.red;
    }

    public void OnFocusExit()
    {
        renderer.material.color = defaultColor;
    }
}
