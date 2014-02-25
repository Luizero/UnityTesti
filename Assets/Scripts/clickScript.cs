using UnityEngine;
using System.Collections;

public class clickScript : MonoBehaviour {
	
	public float angle = 0f;
	public float resetting = 0f;
	public float days = 90f;	
	//MIKACHU!: Tää tarttee muuttaa? Koska hydro automatisoi ja tää kerroin ilmeisesti lisää kasvamisnopeutta?
	public float hydroConstant = 0f;
	public float sinceLastHydroTick;
	public float kerroin = 0.2f;
	public int hydroLevel = 0;
	public int valoTeho = 12;
	public GameObject chipSpawn;
	public GameObject chipSpawnPoint;
	public GameObject light;
	public GameObject chip;
	public GameObject growLight;
	public GameObject highlightcube;
	public Quaternion chipDefaultRotation;
	public Quaternion targetRotation;
	public Quaternion previousRotation;
	public cashScript cash;	
	public kauppaScript kauppa;	
	public kuumotusScript kuumotus;
	public weedScript weedScore;
	public Vector3 size;
	public Vector3 targetSize;
	
	//Instantiot
	public ParticleSystem hatsi;
	
	
	// Use this for initialization
	void Start () {
		cash = GameObject.Find("GuiCash").GetComponent("cashScript") as cashScript;
		kuumotus = GameObject.Find("kuumotusmittari").GetComponent("kuumotusScript") as kuumotusScript;
		//kauppa = GameObject.Find("kauppa").GetComponent("kauppaScript") as kauppaScript;
		light = GameObject.Find("growLight");
		
		if (chip)
		{
			chipDefaultRotation = chip.transform.localRotation;
			targetRotation = chip.transform.localRotation;
			size = chip.transform.localScale;
			targetSize = size;

		}
	}
	
	void OnMouseDown() {
		if (chip  && resetting <= 0f /*&& kauppa.kauppaEnabled == false*/) {
			tickCoin();			
		}
		/* WANHAAAA
		if(kauppa.kauppaEnabled == true) {	
			highlightcube.transform.position = this.transform.position - new Vector3(0,0,+0.1f);
			kauppa.saveActiveBlock(this.gameObject);	
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		if (chip) {
			chip.transform.localRotation = Quaternion.Slerp(chip.transform.localRotation, targetRotation, Time.deltaTime * 6.0f); 
			chip.transform.localScale = Vector3.Slerp(chip.transform.localScale, size,Time.deltaTime*10f);
		}
		if (resetting>0f){
			resetting-=Time.deltaTime;	
		}
		
		if (Input.GetMouseButtonDown(0)) {
			if (chip && resetting <= 0f) {
				chip.transform.RotateAround(Vector3.up, (Mathf.PI/days) * hydroConstant);
				angle += (Mathf.PI/days) * hydroConstant ;
				targetRotation = chip.transform.localRotation;
				if (hydroConstant > 0f) {
					chip.transform.localScale *= 1.3f;
				}
			}
		}
		
		// SCORE SUM POT
		if (angle>= Mathf.PI) {
			angle = 0f;
			//chip.transform.localRotation = chipDefaultRotation;
			Instantiate(hatsi, chip.transform.position + new Vector3(0,0,-1), Quaternion.Euler(-90,0,0));
			weedScore.addWeed(Mathf.RoundToInt(valoTeho*kerroin));			
			targetRotation = chipDefaultRotation;
			kuumotus.addKuumotus(5f);
			resetting = 0.5f;
			

		}
		
		if(hydroLevel > 0 && sinceLastHydroTick >= 1.1f - hydroLevel*0.1f && chip  && resetting <= 0f) {
			tickCoin();
			sinceLastHydroTick = 0;
		}
		sinceLastHydroTick += Time.deltaTime;
	}
	public void spawnCoin(int hinta){
		chip = Instantiate(chipSpawn, chipSpawnPoint.transform.position, Quaternion.identity) as GameObject;
		chip.transform.parent = this.transform;
		chip.transform.RotateAround(Vector3.down, Mathf.PI*3f);
		chip.transform.RotateAround(Vector3.right, Mathf.PI/2f);
		chip.transform.RotateAround(Vector3.forward, Mathf.PI);
		chipDefaultRotation = chip.transform.localRotation;
		targetRotation = chip.transform.localRotation;
		growLight = Instantiate(light, this.transform.position - new Vector3(0,0,3), Quaternion.identity) as GameObject;
		growLight.transform.parent = this.transform;
		cash.addCash (-hinta);
		size = chip.transform.localScale;
		targetSize = size;
	}
	public void purchaseHydro(int hinta){
		hydroLevel++;
		cash.addCash(-hinta);
	}
	void tickCoin() {
		chip.transform.RotateAround(Vector3.up, Mathf.PI/days);
		angle += Mathf.PI/days;
		targetRotation = chip.transform.localRotation;
		chip.transform.localScale *= 1.3f;	
	}
}
