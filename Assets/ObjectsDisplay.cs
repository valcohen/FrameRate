using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(NucleonSpawner))]
public class ObjectsDisplay : MonoBehaviour {

    public Text objectsCountLabel;
	
    public NucleonSpawner nucleonSpawner;

    void Awake() {
    }
        
	void Update () {
        objectsCountLabel.text = nucleonSpawner.objectCount.ToString ("N0");
	}
}
