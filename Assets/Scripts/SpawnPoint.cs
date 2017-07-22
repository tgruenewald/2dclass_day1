using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	void Start () {
		var playerDroplet = GameState.GetPlayerDroplet();
		if (playerDroplet != null)
		{
			Debug.Log("player is not null");
			//Debug.Log("Setting droplet start pos: " + GetComponent<Transform>().position);
			// playerDroplet.StopAllAudio();
			// playerDroplet.PlayAudio(LevelAmbientSound);
			
			playerDroplet.SpawnAt(playerDroplet.gameObject);

			var otherPlayers = GameObject.FindObjectsOfType<Player>();
			Debug.Log(string.Format("Amount of droplets in scene: {0}", otherPlayers.Length));
			// for(int i = 0; i < otherPlayers.Length; ++i){
			// 	var otherPlayer = otherPlayers[i];
			// 	if(otherPlayer != playerDroplet){
			// 		Debug.Log(string.Format("Destroying object: {0} because it's not object: {1}", otherPlayer.gameObject.name, playerDroplet.gameObject.name));
			// 		Destroy(otherPlayer.gameObject);
			// 	}
			// }
		}
		else
		{
			Debug.Log("First time creating droplet");
			var gObj = (GameObject)Instantiate(Resources.Load("prefab/Droplet"), GetComponent<Transform>().position, GetComponent<Transform>().rotation) ;
			Debug.Log("Droplet is " + gObj);
			gObj.GetComponent<Player>().SpawnAt(gObj);
		}
	}

	public static void SwitchToLevel(GameObject playerObject)
	{
		playerObject.GetComponent<Transform>().position = GameObject.FindObjectsOfType<SpawnPoint>()[0].GetComponent<Transform>().position;
		GameState.SetPlayerDroplet(playerObject);
		//GameState.GetPlayerDroplet().StopAllAudio();
		//SceneManager.LoadScene(level);
	}	
}
