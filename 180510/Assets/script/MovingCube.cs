using UnityEngine;
using System.Collections;

public class MovingCube : MonoBehaviour
{
	[SerializeField]
	//Joystickの値は_joystickとする
	private Joystick _joystick = null;

	//SPEEDに速度を入れる
	[SerializeField]
	private float SPEED = 0.1f;

	//{posをジョイスティックの現在地に置き換える処理}を毎フレーム呼び出す
	//現在地が変わらなかったらアニメーターをidleへ移行させる
    //アニメーターにjoystickから渡ってきた方向を渡す[未実装]
	private void Update () 
	{
		//pos（Vector3座標）で動かす宣言
        Vector3 pos = transform.position;
              
        //posのxとzにそれぞれジョイスティックの移動量（nullから新しいxまで距離）を与えてSPEEDとTimeでposの移動をなだらかにする
    	GetComponent<Animator>().SetBool("Idle", false);
        pos.x += _joystick.Position.x * Time.deltaTime * SPEED;
        pos.z += _joystick.Position.y * Time.deltaTime * SPEED;

        //Vector3座標にposを代入
        transform.position = pos;

		//ジョイスティックの入力の状態（xyが0か）だったらidle状態をオンする
		if (transform.localPosition == null)
        {
            GetComponent<Animator>().SetBool("Idle", true);
        }

    	//Unityのアニメーターに_joystickのx(y)をDirectionのx(y)として返す
        GetComponent<Animator>().SetFloat("Movement_X", _joystick.Position.x);
        GetComponent<Animator>().SetFloat("Movement_Y", _joystick.Position.y);

    }

}