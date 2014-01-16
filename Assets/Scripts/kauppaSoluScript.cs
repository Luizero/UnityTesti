using UnityEngine;
using System.Collections;

public class kauppaSoluScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
	Debug.Log("asd");
	}
	void OnMouseOver () {
		this.transform.localScale = new Vector3(0.01f,0.01f,0f);
		this.transform.localPosition = new Vector3(0f,0f,0.1f);
	}
	void OnMouseExit () {
		this.transform.localScale = new Vector3(0f,0f,0f);
		this.transform.localPosition = new Vector3(0f,0f,0f);
	}
}
