using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Transform m_Transform;

    private GameManager GM;


    public bool life = false;
    // Use this for initialization
    void Start () {

        m_Transform = gameObject.GetComponent<Transform>();

        GM = GameObject.Find("Main Camera").GetComponent<GameManager>();

        
    }

    // Update is called once per frame
    void Update () {

        
        if(life==true)
            PlayerMove();
        
    }
    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Gold")
        {
            GameObject.Destroy(coll.gameObject);
            GM.gameScore += 1;

        }
    }

    public void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        m_Transform.Translate(dir * 0.3f);
    }
}
