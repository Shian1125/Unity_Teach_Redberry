using UnityEngine;
using System.Collections;
public class Cat : MonoBehaviour {

	public float rSpeed;
	public float r_x;
	public float r_y;
	public float r_z;

	float ori_r_y;
	public bool clock;

	void Start () {
		ori_r_y = r_y;
	}

	void Update () {
		if(clock){
			r_y = Mathf.Abs(r_y);
		}else if(r_y > 0){
			r_y *= -1;
		}
		this.transform.Rotate (new Vector3 (r_x, r_y, r_z) * rSpeed * Time.deltaTime);
	}
	/*public void ClickRocket(){
		if (r_y == 0) {
			r_y = ori_r_y;
		} else {
			r_y = 0;
		}

	}
	*/
}
