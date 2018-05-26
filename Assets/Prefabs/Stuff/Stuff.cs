using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject {

    public Rigidbody Body { get; private set; }

    MeshRenderer[] meshRenderers;

    public void SetMaterial (Material m) {
        for (int i = 0; i < meshRenderers.Length; i++) {
            meshRenderers [i].material = m;
        }
    }

	void Awake () {
        Body = GetComponent<Rigidbody> ();
        meshRenderers = GetComponentsInChildren<MeshRenderer> ();
	}
        
    void OnTriggerEnter (Collider enteredCollider) {
        if (enteredCollider.CompareTag ("Kill Zone")) {
            ReturnToPool ();
        }
    }

    // TODO: replace this deprecated API:
    // This message has been deprecated and will be removed in a later version of Unity.
    // Add a delegate to SceneManager.sceneLoaded instead to get notifications after scene loading has completed
    void OnLevelWasLoaded() {
        ReturnToPool ();
    }
}
