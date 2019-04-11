using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 1f;
    public Transform player;
    private Vector3 target;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }

	void Update ()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed);
        //transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.tag == "Player")
        {
            //Player.health -= 10f;
            Debug.Log("-10hp");
        }
        
        Destroy(gameObject);
    }
}
