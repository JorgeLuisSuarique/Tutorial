using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform tager;
    Vector3 offset;
    void Start()
    {
        offset = tager.transform.position - transform.position;
    }

    void Update()
    {
        Vector3 pos = tager.transform.position - offset;
        this.transform.position = Vector3.Lerp(this.transform.position, pos, 1.5f);
	}
}
