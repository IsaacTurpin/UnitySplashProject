using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public float waterHeight = 0f;

    Rigidbody m_Rigidbody;

    public GameObject splash;

    public float time = 3;

    bool active = false;



    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;
        if (difference < 2.5)
        {
            splash.SetActive(true);
            active = true;
        }
        if(active == true)
        {
            time -= Time.deltaTime;

            if(time <= 0)
            {
                splash.SetActive(false);
            }
        }
        else
        {
            splash.SetActive(false);
        }
    }

    
}
