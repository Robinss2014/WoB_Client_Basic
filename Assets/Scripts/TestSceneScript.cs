using UnityEngine;
using System.Collections;

public class TestSceneScript : MonoBehaviour {
	private Vector3 myPosition;
	private GameObject currTerrain;
	private GameObject myTerrain;

	// Use this for initialization
	void Start () {
		currTerrain = GameObject.Find ("MaasaiMara");
		myPosition = currTerrain.transform.position;

		myTerrain = (GameObject)Instantiate (currTerrain, myPosition, Quaternion.identity);
		myTerrain.name = currTerrain.name + "2";
		Destroy (currTerrain);
		
		Debug.Log ("New terrian name: " + myTerrain.name);
		Debug.Log ("New terrain position: " + myTerrain.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width/2-50, Screen.height-50,100,30), "Jump to Login")){
			SwitchScene();
		}
	}

	private void SwitchScene(){
		Application.LoadLevel("Login");
	}

}
