using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public FloatRange   timeBetweenSpawns, scale, randomVelocity, angularVelocity;
    public Stuff[]      stuffPrefabs;
    public float        velocity = 15;
    public Material     stuffMaterial;

    float timeSinceLastSpawn;
    float currentSpawnDelay;

	void FixedUpdate () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay) {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;

            SpawnStuff ();
        }
	}

    void SpawnStuff() {
        // pick a random prefab
        Stuff prefab = stuffPrefabs [Random.Range (0, stuffPrefabs.Length)];

        // instantiate it
        Stuff spawn = Instantiate<Stuff> (prefab);
        spawn.GetComponent<MeshRenderer> ().material = stuffMaterial;

        // position it
        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity + 
            Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;

    }
}
