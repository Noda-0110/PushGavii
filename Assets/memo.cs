using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memo : MonoBehaviour
{
    //MoveGabiはnowstageに現在のステージ数を入力しておくとクリア状況が更新される、次のステージではなく現在のステージ数を入力
    //
    //,JumpCountには、Life[10],Jump[4]でUI-Imageの数字を入れる、０～
    //PlayerにはChara、Worpには生き返りたい位置に物を置き入れる
    //ガービィが乗ることのできる全ての物にGround、触れたら死ぬものはEnemyタグをつける
    //ステージ選択画面へ戻る処理はガービィが持っているものをボタンに付ける
    //○○StageMoveでは回転や市野リセットを行う為にboolのrestartを持ち、LifeControllerでtruefalseを切り替えを行う、同じ処理を持つ二つのオブジェクトの初期化はできない
}
