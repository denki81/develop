using UnityEngine;
using System.Collections;

public class MovingCube : MonoBehaviour
{
	//Joystickの値は_joystickとする
	[SerializeField]
	private Joystick _joystick = null;

	//SPEEDに速度を入れる
	[SerializeField]
	private float SPEED = 0.1f;

	//{posをジョイスティックの現在地に置き換える処理}を毎フレーム呼び出す
	//現在地が変わらなかったらアニメーターをidleへ移行させる
    //アニメーターにjoystickから渡ってきた方向を渡す[未実装]
	private void Update () 
	{
		//joystickを動かすためにvector3座標をpos変数として取り出すぞ
        Vector3 pos = transform.position;
        //ジョイスティックの入力座標をcont変数として取り出すぞ
        //この変数は必ず0に戻るから取り合いは注意だぞ
		Vector3 cont = _joystick.Position;

		//移動スピードがガバガバなのでなんとかするぞ
		//contのxyが0以上の時に、move変数のxyに1を入れるぞ
		Vector3 move = Vector3.zero;
			if (cont.x > 1)
        		{ 
        			cont.x = 1; 
        		}
    		if (cont.y > 1)
                {
                    cont.y = 1;
                }
    		if (cont.x < -1)
                {
                    cont.x = -1;
                }
            if (cont.y < -1)
                {
                    cont.y = -1;
                }
        
        //joystickの操作が行われたか（contの値が0か）どうか判定して移動させるぞ
		if (cont != Vector3.zero)
		{
			//posのxとzにそれぞれジョイスティックの移動量（nullから新しいxまで距離）を与えてSPEEDとTimeでposの移動をなだらかにする
            GetComponent<Animator>().SetBool("Idle", false);
			pos.x += cont.x * Time.deltaTime * SPEED;
			pos.z += cont.y * Time.deltaTime * SPEED;

            //Vector3座標にposを代入
            transform.position = pos;

			//Unityのアニメーターにcontのx(y)をDirectionのx(y)として返す
			GetComponent<Animator>().SetFloat("Direction_X", cont.x);
			GetComponent<Animator>().SetFloat("Direction_Y", cont.y);

		}

		else
        {
            //キャラを待機状態にする
            GetComponent<Animator>().SetBool("Idle", true);
        }
    }

}