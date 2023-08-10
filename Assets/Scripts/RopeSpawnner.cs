using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawnner : MonoBehaviour
{
    [SerializeField] private GameObject ropePartPrefab;
    [SerializeField] private GameObject ropeEndPrefab;
    [SerializeField] private GameObject parentRope;
    [SerializeField] [Range(1, 100)] private int length = 1;
    [SerializeField] private float ropePartDistance = 0.1f;
    [SerializeField] private bool snapfirst;
    [SerializeField] private bool snaplast;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int count = (int)(length / ropePartDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject temp;

            if (i == 0)
            {
                temp = Instantiate(ropeEndPrefab, new Vector3(transform.position.x, transform.position.y + ropePartDistance * (i + 1), transform.position.z), Quaternion.identity, parentRope.transform);
                temp.transform.eulerAngles = new Vector3(180, 0, 0);

                temp.name = parentRope.transform.childCount.ToString();
            }
            else 
            {
                temp = Instantiate(ropePartPrefab, new Vector3(transform.position.x, transform.position.y + ropePartDistance * (i + 1), transform.position.z), Quaternion.identity, parentRope.transform);
                temp.transform.eulerAngles = new Vector3(180, 0, 0);

                temp.name = parentRope.transform.childCount.ToString();
            }

            Debug.Log("count = " + count + ".............");

            if (i == 0)
            {
                Debug.Log("i = 0............");
                Destroy(ropeEndPrefab.GetComponent<CharacterJoint>());
              
            }
            else if (i == (count - 1))
            {
                Debug.Log("i = count.............");
                temp.GetComponent<CharacterJoint>().connectedBody = ropeEndPrefab.GetComponent<Rigidbody>();
            }
            else
            {
                Debug.Log("i = " + i + ".............");
                temp.GetComponent<CharacterJoint>().connectedBody = parentRope.transform.Find((parentRope.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
    }
}

