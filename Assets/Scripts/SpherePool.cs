using System.Collections.Generic;
using UnityEngine;

public class SpherePool : MonoBehaviour
{
    [SerializeField] private GameObject SpherePrefab;
    [SerializeField] private Transform SpawnPoint;
    private List<GameObject> poolSphere = new List<GameObject>();
    private int amountToPool = 20;

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject sphere = Instantiate(SpherePrefab, SpawnPoint.position, SpawnPoint.rotation);
            sphere.SetActive(false);
            poolSphere.Add(sphere);
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolSphere.Count; i++)
        {
            if (!poolSphere[i].activeInHierarchy)
            {
                return poolSphere[i];
            }
        }

        return null;
    }
}
