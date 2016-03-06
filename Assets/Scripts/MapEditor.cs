using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEditor : MonoBehaviour {

	public GameObject[] bullies;
	List<Enemy> enemies;

	public GameObject noteObj;
		
	void initNotes() {
		SpawnPoint spawningTool = new SpawnPoint (false);
		GameObject notesContent = new GameObject ("Notes");
		notesContent.transform.parent = transform;

		for (int i = 0; i < GameManager.instance.NotesMax; i++) {
			int patateSP = Random.Range (0, spawningTool.SpawnPoints.Count);
			int rand = Random.Range (0, 5);

			Vector2 randomSP = spawningTool.SpawnPoints[patateSP];
			spawningTool.SpawnPoints.RemoveAt (patateSP);

			GameObject note = Instantiate (noteObj, randomSP, Quaternion.identity) as GameObject;
			note.name = "Note_" + (i+1);
			note.transform.parent = notesContent.transform;
			Debug.Log (note.name + " at " + randomSP.ToString());
		}
	}

	void initEnemies() {
		enemies = new List<Enemy> ();
		GameObject enemiesContent = new GameObject ("Enemies");
		enemiesContent.transform.parent = transform;

		SpawnPoint spawningTool = new SpawnPoint (true);
		for (int i = 0; i < GameManager.instance.EnemiesMax; i++) {
			int patateSP = Random.Range (0, spawningTool.SpawnPoints.Count);
			int rand = Random.Range (0, 5);

			Vector2 randomSP = spawningTool.SpawnPoints [patateSP];
			spawningTool.SpawnPoints.RemoveAt (patateSP);

			GameObject bully = (GameObject) Instantiate (bullies [rand], randomSP, Quaternion.identity);
			bully.transform.parent = enemiesContent.transform;
			bully.GetComponent<Enemy> ().DamagePower = GameManager.instance.EnemiesMaxDamages;
			enemies.Add(bully.GetComponent<Enemy>());
			Debug.Log (bully.name);
		}
	}

	public void InitializeMap() {
		//gameObject.SetActive (true);

		initNotes();
		initEnemies ();
	}
		
}

