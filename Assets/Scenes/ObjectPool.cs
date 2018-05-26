using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    PooledObject prefab;

    // not using a stack here as they aren't serialized by Unity and won't survive a recompile.
    List<PooledObject> availableObjects = new List<PooledObject>();

    public PooledObject GetObject() {
        PooledObject o;
        int lastAvailableIndex = availableObjects.Count - 1;
        if (lastAvailableIndex >= 0) {
            o = availableObjects [lastAvailableIndex];
            availableObjects.RemoveAt (lastAvailableIndex);
            o.gameObject.SetActive (true);
        } else {
            o = Instantiate<PooledObject> (prefab);
            o.transform.SetParent (this.transform, false);
            o.Pool = this;
        }
        return o;
    }

    public void AddObject (PooledObject o) {
        o.gameObject.SetActive (false);
        availableObjects.Add (o);
    }

    public static ObjectPool GetPool (PooledObject prefab) {
        GameObject obj;
        ObjectPool pool;

        string poolName = prefab.name + " Pool";

        if (Application.isEditor) {
            obj = GameObject.Find (poolName);
            if (obj) {
                pool = obj.GetComponent<ObjectPool> ();
                if (pool) {
                    return pool;
                }
            }
        }

        obj  = new GameObject (poolName);
        pool = obj.AddComponent<ObjectPool> ();
        pool.prefab = prefab;

        return pool;
    }
}
