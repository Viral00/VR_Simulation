using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSpawnObject : MonoBehaviour
{
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    [SerializeField] private GameObject VrButton;
    private GameObject VrButtonPresser;
    [SerializeField] private SpherePool spherePool;
    [SerializeField] private Transform spawnPoint;
    private bool isPressed;

    private void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (isPressed)
        {
            VrButton.transform.localPosition = new Vector3(0, 0.003f, 0);
            VrButtonPresser = collider.gameObject;
            OnPress?.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == VrButtonPresser)
        {
            VrButton.transform.localPosition = new Vector3(0, 0.015f, 0);
            OnRelease?.Invoke();
            isPressed = false;
        }
    }

    public void SpawnObjectFromPool() 
    {
        GameObject SphereObject = spherePool.GetPooledObject();

        if(spherePool != null)
        {
            SphereObject.transform.position = spawnPoint.transform.position;
            SphereObject.SetActive(true);
        }
    }
}
