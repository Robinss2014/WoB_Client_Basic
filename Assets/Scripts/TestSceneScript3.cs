using UnityEngine;
using System.Collections;

public class TestSceneScript3 : MonoBehaviour {
	
	private System.Random rand;
	private GameObject dummy;
	private string [] species;

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
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// create random animals by each click
			int i=0;
			if(Physics.Raycast(ray,out hit)){
				i = rand.Next(0,4);
				CreateAnimal(i,hit.point);
				Debug.Log ("Species name: " + species[i]);
				Debug.Log ("Dummy name: " + dummy.name);
			}
		}
		
	}

	// create the animal by the index
	private void CreateAnimal(int i,Vector3 position){
		Material speciesMaterial = (Material)GameObject.Instantiate (Resources.Load (Constants.TEXTURE_RESOURCES_PATH + "Species/Materials/" + species[i]));
		dummy.transform.GetChild (0).renderer.material = speciesMaterial;
		
		GameObject.Instantiate (dummy, position, Quaternion.identity);
		dummy.name = species[i];
	}
}

