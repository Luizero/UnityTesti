using UnityEngine;
using System.Collections;

public class infoScript : MonoBehaviour {
	
	public Material defaultMaterial;
	public GameObject infoSelostus;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setMaterial(Material materiaali) {
		renderer.material = materiaali;	
	}
}
