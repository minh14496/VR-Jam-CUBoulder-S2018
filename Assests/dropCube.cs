using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class dropCube : MonoBehaviour {
	
	public GameObject redCube;
	public GameObject blackCube;	
	public GameObject whiteCube;
	private float timeE = 0f; //time elapsed
	//add random number 
	private int index =-1;
	public int count = 0;
	private List<char> cubes = new List<char>();	
	//AddObject to list
	private void AddObjectToList(){
		for(int i = 0 ; i<54; i++){
			cubes.Add('r');
		}
		for (int i=0; i<56; i++){
			cubes.Add('b');
		}
		for (int i=0; i<24; i++){
			cubes.Add('w');
		}
		for(int i=0; i<cubes.Count; i++){
			int r = Random.Range(0,cubes.Count); 
			char color = cubes[r];
			cubes[r] = cubes[i];
			cubes[i] = color;
		}
	} 
	void DropCube()
	{
		char get = cubes[count];
		if(get == 'r'){
			GameObject newCube = (GameObject)Instantiate(redCube);
			newCube.transform.position = transform.position;
			//Debug.Log("red");
		}
		else if(get == 'b'){
			GameObject newCube = (GameObject)Instantiate(blackCube);
			newCube.transform.position = transform.position;
			//Debug.Log("black");
		}else{
			GameObject newCube = (GameObject)Instantiate(whiteCube);
			newCube.transform.position = transform.position;
			//Debug.Log("white");
		
		}
		count++;
	}
	// Use this for initialization
	void Start () {
			AddObjectToList();
			Debug.Log("start");
		}
		
	// Update is called once per frame
	void Update() {
			timeE += Time.deltaTime; // deltaTime is the time in second it took to complete last frame. 
			if (timeE >=3.5)
			{
				if(count<=cubes.Count)
				{
					DropCube();
					timeE = 0;
				}
			}
		}
}
