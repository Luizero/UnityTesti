using UnityEngine;
using System.Collections;

public class kauppaSoluScript : MonoBehaviour {
	

	public kauppaScript kauppa;
	public clickScript click;
	
	// Use this for initialization
	void Start () {
		kauppa = GameObject.Find("kauppa").GetComponent("kauppaScript") as kauppaScript;
		//click = GameObject.Find("block").GetComponent("clickScript") as clickScript;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		click = kauppa.activeBlock.GetComponent("clickScript") as clickScript;
		if (!click.chip && click.cash.cash >= 200)
		click.spawnCoin();
	}
	void OnMouseEnter () {
		this.transform.localScale += new Vector3(0.1f,0.1f,0f);
		this.transform.localPosition += new Vector3(0f,0f,0.5f);
		//this.transform.localScale = new Vector3(0.01f,0.01f,0f);
		//this.transform.localPosition = new Vector3(0f,0f,0.1f);
	}
	void OnMouseExit () {
		this.transform.localScale -= new Vector3(0.1f,0.1f,0f);
		this.transform.localPosition -= new Vector3(0f,0f,0.5f);
		//this.transform.localScale = new Vector3(0f,0f,0f);
		//this.transform.localPosition = new Vector3(0f,0f,0f);
	}
}
