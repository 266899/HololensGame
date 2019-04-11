using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 1f;
    private Vector3 target;
    private GameObject player;


    void Start()
    {
        //player = GameObject.Find("MixedRealityCamera").transform;
        //target = new Vector3(player.position.x, player.position.y, player.position.z); Destroy(gameObject, 3f);

        Transform playerTr = GameObject.Find("MixedRealityCamera").transform;
        target = new Vector3(playerTr.position.x, playerTr.position.y, playerTr.position.z); Destroy(gameObject, 3f);
    }

	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, bulletSpeed);
        //transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider playerCollider)
    {
        Player player = playerCollider.GetComponent<Player>();

        if (playerCollider.tag == "Player")
        {
            player.TakeDamage(10f);
        }
        Destroy(gameObject);
    }

    
}
