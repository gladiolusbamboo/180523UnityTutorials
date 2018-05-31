using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  // スコアを表示するUI
  public GameObject scoreUI;

  // ハイスコアを表示するUI
  public GameObject highScoreUI;

  // スコア
  private int score = 0;

  // ハイスコア
  private int highScore = 0;

  // PlayerPrefsで保存するためのキー
  private string highScoreKey = "highScore";

  void Start()
  {
    PlayerPrefs.DeleteAll();
    Initialize();
  }

  void Update()
  {
    // スコアがハイスコアより大きければ
    if (highScore < score)
    {
      highScore = score;
    }

    // スコア・ハイスコアを表示する
    scoreUI.GetComponent<Text>().text = score.ToString();
    highScoreUI.GetComponent<Text>().text = "HighScore:" + highScore.ToString();
  }

  // ゲーム開始前の状態に戻す
  private void Initialize()
  {
    // スコアを０に戻す
    score = 0;

    // ハイスコアを取得する。保存されてなければ０を取得する
    highScore = PlayerPrefs.GetInt(highScoreKey, 0);
  }

  // ポイントの追加
  public void AddPoint(int point)
  {
    score = score + point;
  }

  // ハイスコアの保存
  public void Save()
  {
    // ハイスコアを保存する
    PlayerPrefs.SetInt(highScoreKey, highScore);
    PlayerPrefs.Save();

    // ゲーム開始前の状態に戻す
    Initialize();
  }
}
