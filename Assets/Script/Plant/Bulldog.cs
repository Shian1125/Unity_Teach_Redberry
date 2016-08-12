using UnityEngine;
using System.Collections;

public class Bulldog : MonoBehaviour {

	public float rSpeed;

	void Start () {
	
	}
	//sdfsdscdcscdrgvgvwvdw
	void Update () {
		this.transform.Rotate (new Vector3(0, 0, 8) * rSpeed * Time.deltaTime);
	}
}
