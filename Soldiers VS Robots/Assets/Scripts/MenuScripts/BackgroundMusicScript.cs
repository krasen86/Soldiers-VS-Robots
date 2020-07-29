using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
		void Awake(){
		 	GameObject[] objects = GameObject.FindGameObjectsWithTag(GameConstants.backgroundMusicTag);
				if(objects.Length > 1)
				{
					Destroy(this.gameObject);
				}
			DontDestroyOnLoad(this.gameObject);
		}

}
