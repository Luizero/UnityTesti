using UnityEngine;
using System.Collections;

public class tooltipScript : MonoBehaviour {
	public float width = 200.0f;
	public float height= 100.0f;
	public bool enabled = false;
	public float positionX;
	public float positionY;
	public float prevPositionX;
	public float prevPositionY;
	public GameObject[] tooltipVariables;
	public GameObject text;

	public GameObject backGround;
	
	// Use this for initialization
	void Start () {
		tooltipVariables = GameObject.FindGameObjectsWithTag("toolTip");
	}
	
	// Update is called once per frame
	void Update () {
		if(enabled == true) {
			
			positionX = Input.mousePosition.x;
			positionY = Input.mousePosition.y;
			
			foreach(GameObject tooltipVariable in tooltipVariables){
					tooltipVariable.gameObject.guiText.pixelOffset += new Vector2(positionX - prevPositionX, positionY - prevPositionY );
			}
			
			text.gameObject.guiText.pixelOffset = new Vector2(positionX - width + 5, positionY - 40 );
			backGround.guiTexture.pixelInset = new Rect(positionX - width, positionY - (height + 10), width, height);
			
		
			
			prevPositionX = positionX;
			prevPositionY = positionY;
			
		
		}	
	}
	
	public void setEnabled(bool status) {
		enabled = status;
		backGround.guiTexture.enabled = status;
		text.guiText.enabled = status;
		foreach(GameObject tooltipVariable in tooltipVariables){
				tooltipVariable.gameObject.guiText.enabled = status;
		}
	}
	
	public void updateGuiPrice(int price) {
			
	}
}
