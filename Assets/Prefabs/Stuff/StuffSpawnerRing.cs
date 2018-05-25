using UnityEngine;

public class StuffSpawnerRing : MonoBehaviour {
    
    public int          numberOfSpawners    = 6;
    public float        radius              = 5;
    public float        tiltAngle           = 45;
    public StuffSpawner spawnerPrefab;
    public Material[]   stuffMaterials;

	void Awake () {
        for (int i = 0; i < numberOfSpawners; i++) {
            CreateSpawner (i);
        }
	}

    void CreateSpawner (int index)
    {
        Transform rotator = new GameObject ("Rotator").transform;
        rotator.SetParent (transform, false);
        rotator.localRotation = Quaternion.Euler (0f, index * 360f / numberOfSpawners, 0f);

        StuffSpawner spawner = Instantiate<StuffSpawner> (spawnerPrefab);
        spawner.transform.SetParent (rotator, false);
        spawner.transform.localPosition = new Vector3 (0f, 0f, radius);
        spawner.transform.localRotation = Quaternion.Euler (tiltAngle, 0f, 0f);

        spawner.stuffMaterial = stuffMaterials [index % stuffMaterials.Length];
    }
}
