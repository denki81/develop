using UnityEngine;
using System.Collections;

public class MovingCube : MonoBehaviour {

  //先ほど作成したJoystick
  [SerializeField]
  private Joystick _joystick = null;

  //移動速度
  [SerializeField]
  private float SPEED = 0.1f;
  
  private void Update () {
    Vector3 pos = transform.position;

    pos.x += _joystick.Position.x * Time.deltaTime * SPEED;
    pos.z += _joystick.Position.y * Time.deltaTime * SPEED;

    transform.position = pos;

	GetComponent<Animator>().SetFloat("Direction_X", _joystick.Position.x);
    GetComponent<Animator>().SetFloat("Direction_Y", _joystick.Position.y);

  }

}