using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public float    timeBetweenSpawns = 0.05f;
    public Stuff[]  stuffPrefabs;
    public float    velocity = 15;

    float timeSinceLastSpawn;

	void FixedUpdate () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns) {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnStuff ();
        }
	}

    void SpawnStuff() {
        // pick a random prefab
        Stuff prefab = stuffPrefabs [Random.Range (0, stuffPrefabs.Length)];

        // instantiate it
        Stuff spawn = Instantiate<Stuff> (prefab);

        // position it
        spawn.transform.localPosition = transform.position;
        spawn.Body.velocity = transform.up * velocity;

    }
}
