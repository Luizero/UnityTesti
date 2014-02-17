using UnityEngine;
using System.Collections;

public class kauppaRuutuScript : MonoBehaviour {
	
	public tooltipScript tooltip;
	public clickScript click;
	public string nimi = "";
	public GameObject tooltipText;
	public int level;
	public int hinta = 40;
	
	// Use this for initialization
	void Start () {
		tooltip = GameObject.Find("tooltip").GetComponent("tooltipScript") as tooltipScript;
		level = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter () {
		tooltip.setEnabled(true);
		
		foreach(GameObject tooltipVariable in tooltip.tooltipVariables) {
			switch ( tooltipVariable.name )
			{
				case "tooltipHintaText":
					tooltipVariable.guiText.text = "Hinta:" + hinta + "€";
					break;
				case "tooltipNimiText":
					tooltipVariable.guiText.text = nimi;
					break;
			}
		}
		
		tooltip.text.guiText.text = tooltipText.GetComponent<TextMesh>().text;
	}
	
	void OnMouseDown () {
		switch( this.gameObject.name )
		{
			case "kukkaRuutu":
				click = GameObject.Find( level + "_block" ).GetComponent("clickScript") as clickScript;

				if(click.cash.cash >= hinta) {
					click.spawnCoin(hinta);
					level++;
					hinta = hinta * 2;
					updatePrice();
				}
				break;
		}
	}
	
	void OnMouseExit () {
		tooltip.setEnabled(false);
	}
	void updatePrice () {
		GameObject.Find("tooltipHintaText").guiText.text = "Hinta:" + hinta + "€";
	}
}
