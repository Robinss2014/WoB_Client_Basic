using UnityEngine;
using System.Collections;

public class TestSceneScript2 : MonoBehaviour {
	
	private System.Random rand;
	private GameObject dummy;
	private string [] species;
	private Vector3 speciesPosition;
	
	// Use this for initialization
	void Start () {

		rand = new System.Random ();
		species = new string[] {
			"AardVark",
			"African Elephant",
			"Black Rhinoceros",
			"Buffalo",
			"Hippopotamus"
		};
		
		dummy = (GameObject)Resources.Load (Constants.PREFAB_RESOURCES_PATH + "Dummy");

		Debug.Log ("------------- Randomly create 5 species starts -------------");
		for (int i = 0; i<5; i++) {
			CreateAnimal (i);
		}
		Debug.Log ("------------- Randomly create 5 species is over -------------");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A) ){
			CreateAnimal(0);
		}
		if(Input.GetKeyDown(KeyCode.S) ){
			CreateAnimal(1);
		}
		if(Input.GetKeyDown(KeyCode.D) ){
			CreateAnimal(3);
		}
	}

	// create the animal by the index
	private void CreateAnimal(int i){
		Material speciesMaterial = (Material)GameObject.Instantiate (Resources.Load (Constants.TEXTURE_RESOURCES_PATH + "Species/Materials/" + species[i]));
		dummy.transform.GetChild (0).renderer.material = speciesMaterial;
		//Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
		speciesPosition = new Vector3(rand.Next(0,200),70,rand.Next(0,200));
		GameObject.Instantiate (dummy, speciesPosition, Quaternion.identity);
		dummy.name = species[i];
	}
}
