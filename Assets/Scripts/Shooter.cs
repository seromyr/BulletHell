using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyableBullet;

    private float time;
    void Start()
    {
        //destroyableBullet = Resources.Load<GameObject>("Prefabs/KillAbleBullet");
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time + 0.1f)
        {
            var meNew = Instantiate(destroyableBullet, transform.position + transform.forward, transform.rotation);
            meNew.GetComponent<SelfMovingFoward>().direction = transform.position;
            time = Time.time;
        }
        //meNew.transform.parent = null;
    }


}
