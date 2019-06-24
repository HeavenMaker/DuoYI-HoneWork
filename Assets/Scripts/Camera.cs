using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Transform m_Transform;
    private Transform player_Transform;

	void Start () {

        m_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.Find("Player").GetComponent<Transform>();


	}
	
	void Update () {

        Vector3 delt = new Vector3(0.380f, 10.670f, -6.266f);
        m_Transform.position = player_Transform.position + delt;
    }
}
