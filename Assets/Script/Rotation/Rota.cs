using UnityEngine;
using System.Collections;

public class Rota : MonoBehaviour {

	public float sensitive;
	public bool xOn = true;
	public bool yOn = true;
	//mouse
	public Vector2 firstPosi;
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			firstPosi = Input.mousePosition;
			Debug.Log(firstPosi);
		}
		//
	}
	public void Drag(){
		Vector2 delta;
		//mouse mode or touch mode
		if(Input.touchCount > 0){
			delta = Input.GetTouch(0).deltaPosition;
		}else{
			delta = firstPosi - (Vector2)Input.mousePosition;
		}

		if(!xOn){	delta.x = 0;	}
		if(!yOn){	delta.y = 0;	}
		Vector3 delta2 = new Vector3(delta.y, delta.x * -1, 0);
		this.transform.Rotate(delta2 * Time.deltaTime * sensitive, Space.World);
		Debug.Log(delta2);

	}
	public void Xais(){
		xOn = !xOn;
	}
	public void Yais(){
		yOn = !yOn;
	}
}
