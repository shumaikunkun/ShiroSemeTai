using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        // もしPlayerにさわったら
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("bbb");
            col.SendMessage("Damage"); //ダメージを与えて
            Destroy(this.gameObject);
        }
        // 自分は消える
        if (col.gameObject.tag == "Field")
        { 
            Debug.Log("aaa");
            Vector3 allowPos = transform.position;
            transform.position = allowPos;
            Quaternion allowRot = transform.rotation;
            transform.rotation = allowRot;
            Destroy(this.gameObject);
        }
    }

}