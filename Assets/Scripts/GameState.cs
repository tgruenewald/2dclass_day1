using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets._2D;

public static class GameState
{
    private static GameObject droplet = null;
	private static GameObject camera = null;
    public static GameObject introMusic = null;

	public static void SetCamera(GameObject camera){
		GameState.camera = camera;
	}

	public static Camera2DFollow GetCamera(){
		if(camera == null){
			camera = GameObject.FindGameObjectWithTag("MainCamera");
			if(camera == null) {
				Debug.Log("Getting camera but it is null");
				return null;
			}

		}

		return camera.GetComponent<Camera2DFollow>();
	}

	public static void SetPlayerDroplet(GameObject droplet){
		GameState.droplet = droplet;
	}

	public static Player GetPlayerDroplet(){
		if(droplet == null){
			droplet = GameObject.FindGameObjectWithTag("Player");
			if(droplet == null) {
                Debug.Log("Getting player droplet but it is null");
                return null;
            }
				
		}

		return droplet.GetComponent<Player>();
	}
}