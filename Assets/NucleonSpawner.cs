using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

    public float timeBetweenSpawns  = 0.05f;
    public float spawnDistance      = 15f;
    public Nucleon[] nucleonPrefabs;

    public int objectCount { get; private set; }

    float timeSinceLastSpawn;

    // Use this for initialization
	void Start () {
		
	}

    // FixedUpdate keeps spawning independent of frame rate
	void FixedUpdate () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns) {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon ();
        }
	}

    void SpawnNucleon() {
        // pick a random prefab
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];

        // instantiate it
        Nucleon spawn = Instantiate<Nucleon> (prefab);
        objectCount++;

        // position it
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}
