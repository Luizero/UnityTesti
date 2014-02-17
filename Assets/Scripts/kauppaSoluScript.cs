using UnityEngine;
using System.Collections;

public class kauppaSoluScript : MonoBehaviour {
	
	public int taso = 0;
	public kauppaScript kauppa;
	public clickScript click;
	public infoScript info;
	public GameObject selostus;
	
	// Use this for initialization
	void Start () {
		kauppa = GameObject.Find("kauppa").GetComponent("kauppaScript") as kauppaScript;
		info = GameObject.Find("infoRuutu").GetComponent("infoScript") as infoScript;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown () {
		click = kauppa.activeBlock.GetComponent("clickScript") as clickScript;
		//if (!click.chip && click.cash.cash >= 200)
		//click.spawnCoin();
	}
	void OnMouseEnter () {
		this.transform.localScale += new Vector3(0.1f,0.1f,0f);
		this.transform.localPosition += new Vector3(0f,0f,0.5f);
		info.setMaterial( this.renderer.material );
		
		foreach(GameObject kauppaInfo in GameObject.FindGameObjectsWithTag("kauppaInfo"))
		{
        	kauppaInfo.renderer.enabled = true;
		}
		info.infoSelostus.GetComponent<TextMesh>().text = selostus.GetComponent<TextMesh>().text;
	}
	void OnMouseExit () {
		this.transform.localScale -= new Vector3(0.1f,0.1f,0f);
		this.transform.localPosition -= new Vector3(0f,0f,0.5f);
		info.setMaterial( info.defaultMaterial );
		
		foreach(GameObject kauppaInfo in GameObject.FindGameObjectsWithTag("kauppaInfo"))
		{
        	kauppaInfo.renderer.enabled = false;
		}
	}
}
