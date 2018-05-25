using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  // Spaceshipコンポーネント
  Spaceship spaceship;

  private IEnumerator Start()
  {
    // Spaceshipコンポーネントを取得
    spaceship = GetComponent<Spaceship>();

    while (true)
    {
      // 弾をプレイヤーと同じ位置/角度で作成
      spaceship.Shot(transform);

      // shotDelay秒待つ
      yield return new WaitForSeconds(spaceship.shotDelay);
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
    spaceship.Move(direction);
  }

  // ぶつかった瞬間に呼び出される
  private void OnTriggerEnter2D(Collider2D c)
  {
    // レイヤー名を取得
    string layerName = LayerMask.LayerToName(c.gameObject.layer);
    Debug.Log($"layerName = {layerName}");
    // レイヤー名がBullet(Enemy)の時は弾を削除
    if (layerName == "Bullet (Enemy)")
    {
      // 弾の削除
      Destroy(c.gameObject);
    }
    // レイヤー名がBullet(Enemy)またはEnemyの場合は爆発
    if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
    {
      // 爆発する
      spaceship.Explosion();

      // プレイヤーを削除
      Destroy(gameObject);
    }
  }
}
