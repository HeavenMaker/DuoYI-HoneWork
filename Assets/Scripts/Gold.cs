using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    private Transform m_Transform;

	void Start () {

        m_Transform = gameObject.GetComponent<Transform>();
		
	}
	
	void Update () {

        m_Transform.Rotate(Vector3.up*3);
		
	}
}
