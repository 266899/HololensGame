using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    private GameObject objects;
    public GameObject enemyPrefab;
    public float spawnDelay = 4;
    private float timeOfLastSpawn = 0;

    // Use this for initialization
    void Start () {
        objects = GameObject.Find("SpatialMapping");
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - timeOfLastSpawn > spawnDelay)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        timeOfLastSpawn = Time.time;
        int count = objects.transform.childCount;
        int randomObject = Random.Range(0, count);
        GameObject enemy = Instantiate(enemyPrefab);
        Vector3[] array = objects.transform.GetChild(randomObject).GetComponent<MeshFilter>().mesh.vertices;
        int randomPos = Random.Range(0, array.Length);
        enemy.transform.position = array[randomPos];
    }
}
