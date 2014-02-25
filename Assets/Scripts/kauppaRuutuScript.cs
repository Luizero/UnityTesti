using UnityEngine;
using System.Collections;

public class kauppaRuutuScript : MonoBehaviour {
	
	public tooltipScript tooltip;
	public clickScript click;
	public string nimi = "";
	public GameObject tooltipText;
	public int level;
	public int hinta;
	public cashScript cash;
	
	// Use this for initialization
	void Start () {
		tooltip = GameObject.Find("tooltip").GetComponent("tooltipScript") as tooltipScript;
		cash = GameObject.Find("GuiCash").GetComponent("cashScript") as cashScript;
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
		if(cash.cash >= hinta){	
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
				case "hydroRuutu":					
					foreach(GameObject block in GameObject.FindGameObjectsWithTag("block"))
					{
	        			click = block.GetComponent("clickScript") as clickScript;
						if(level < 8){
							click.hydroLevel++;												
						}					
					}
					cash.addCash(-hinta);
					hinta = hinta * 2;
					updatePrice();
					level++;
					break;
				case "valoRuutu":
					foreach(GameObject block in GameObject.FindGameObjectsWithTag("block"))
					{
	        			click = block.GetComponent("clickScript") as clickScript;
						switch(click.valoTeho)
						{
							case 12:
								click.valoTeho = 36;
								break;
							case 36:
								click.valoTeho = 50;
								break;
							case 125:
								click.valoTeho = 250;
								break;
							case 250:
								click.valoTeho = 400;
								break;
							case 400:
								click.valoTeho = 600;
								break;
							case 600:
								click.valoTeho = 1000;
								break;
						}
						if(click.chip){
							click.growLight.GetComponent<Light>().intensity += 0.1f;
							click.growLight.GetComponent<Light>().spotAngle += 2;
						}
					}
					cash.addCash(-hinta);
					hinta = hinta * 2;
					updatePrice();
					break;
				case "kilkeRuutu":
					foreach(GameObject block in GameObject.FindGameObjectsWithTag("block"))
					{
	        			click = block.GetComponent("clickScript") as clickScript;
						if(click.kerroin <= 2.0f)
							click.kerroin += 0.1f; 				
					}
					cash.addCash(-hinta);
					hinta = hinta * 2;
					updatePrice();
					break;
			}
		}
	}
	
	void OnMouseExit () {
		tooltip.setEnabled(false);
	}
	void updatePrice () {
		GameObject.Find("tooltipHintaText").guiText.text = "Hinta:" + hinta + "€";
	}
}
