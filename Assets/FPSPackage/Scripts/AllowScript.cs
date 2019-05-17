using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowScript : MonoBehaviour
{
    float timer = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2) Destroy(this.gameObject);
    }
    void OnTriggerEnter(Collider col)
    {
        // もしPlayerにさわったら
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("Damage"); //ダメージを与えて
            Destroy(this.gameObject);
        }
        // 自分は消える
        
    }
}