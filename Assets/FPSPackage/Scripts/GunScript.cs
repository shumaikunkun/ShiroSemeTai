using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

    public AudioClip gunSound;
    AudioSource audioSource; //音源（スピーカー）
    //RaycastHit hit; //弾が当たった時の情報

    int flame;
    bool isAttack = false;

    Quaternion quaternion;

    // ゲームが始まった時に1回呼ばれるメソッド
    void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = gunSound;
        GetComponent<BoxCollider>().enabled = false;  //刀を動かしているときだけダメージを与える。
    }

    // ゲームの1フレームごとに呼ばれるメソッド
    void Update()
    {
        PlayerScript playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();  //他のソースコードから参照

        //if (playerScript.playerHP > 0)
        {


            if (isAttack)
            {

                if (flame < 5)
                {
                    transform.Rotate(new Vector3(0, 0, -15));
                    transform.position -= new Vector3(0, 0.02f, 0);
                }
                else if (flame < 10)
                {
                    GetComponent<BoxCollider>().enabled = false;
                    transform.Rotate(new Vector3(0, 0, 15));
                    transform.position += new Vector3(0, 0.02f, 0);
                }
                else
                {
                    isAttack = false;
                    
                }

                flame++;
            }
            else
            {
                //攻撃が完了してから次の攻撃に入る
                if (Input.GetMouseButtonDown(0))
                {

                    isAttack = true;
                    GetComponent<BoxCollider>().enabled = true;  //斬ってる間だけ刀に触れた敵にダメージを与えられる
                    flame = 0;
                    audioSource.Play();
                    //if (playerScript.reloadCount > 0)
                    //{
                    //audioSource.Play();
                    //Shot();

                    //Instantiate(explosion, transform.position, Quaternion.identity);
                    //playerScript.reloadCount--;
                    //playerScript.bulletCount--;
                    //}
                }
            }
        }

        //if (Input.GetKey(KeyCode.Z) && playerScript.reloadCount==0&& playerScript.bulletCount > 0)
        //{  //Zを入力して、弾数あって、リロード数0発ならリロードする
        //    playerScript.reloadCount = 10;
        //}
	}

	// 銃をうつ時に行いたいことをこの中に書く
	//void Shot(){
    //    Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    //    Ray ray = Camera.main.ScreenPointToRay(center);
    //    float distance = 100;
    //    if(Physics.Raycast(ray,out hit, distance))
    //    {
    //        //Instantiate(sparks, hit.point, Quaternion.identity);
    //        if (hit.collider.tag == "Enemy")
    //        {
    //            hit.collider.SendMessage("Damage");
    //        }
    //    }
	//}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("attack");
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("Damage");
        }
    }

}
