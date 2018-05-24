using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // 移動スピード
  public float speed = 5;

  // PlayerBulletプレハブ
  public GameObject bullet;

  private IEnumerator Start()
  {
    while (true)
    {
      // たまをプレイヤーと同じ位置/角度で作成
      Instantiate(bullet, transform.position, transform.rotation);
      // 0.05秒待つ
      yield return new WaitForSeconds(0.05f);
    }
  }

  void Update()
  {
    // GetAxisRawはキーボードでの移動のときに使える
    // ← で x = -1、→ で x = 1、何も押してない時 x = 0
    float x = Input.GetAxisRaw("Horizontal");
    // ↓ で y = -1、↑ で y = 1、何も押してない時 x = 0
    float y = Input.GetAxisRaw("Vertical");

    // 単位ベクトル化
    Vector2 direction = new Vector2(x, y).normalized;

    // 移動する向きとスピードを代入する
    GetComponent<Rigidbody2D>().velocity = direction * speed;
  }
}
