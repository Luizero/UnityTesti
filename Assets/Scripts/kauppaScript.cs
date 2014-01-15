using UnityEngine;
using System.Collections;

public class kauppaScript : MonoBehaviour {
	
	public GameObject activeBlock;
	public bool kauppaEnabled = false;
	public bool blockSelected = false;
	public clickScript click;
	
	// Use this for initialization
	void Start () {
		click = GameObject.Find("block").GetComponent("clickScript") as clickScript;
	}
	
	void OnMouseDown() {
		if( kauppaEnabled == false ) {
			click.highlightcube.renderer.enabled = true;
			kauppaEnabled = true;
		}			
		else {
			kauppaEnabled = false;
			click.highlightcube.renderer.enabled =false;
		}		
	}
	
	public void saveActiveBlock (GameObject block) {
		activeBlock = block;
		Debug.Log(activeBlock.transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
