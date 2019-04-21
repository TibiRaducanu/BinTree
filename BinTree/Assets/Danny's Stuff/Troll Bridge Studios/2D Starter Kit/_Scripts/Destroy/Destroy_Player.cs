using UnityEngine;
using System.Collections;

namespace UnitedTAD {
	
	public class Destroy_Player : MonoBehaviour {

		void Awake()
		{
			GameObject player = Character_Manager.GetPlayerManager ();
			if (player != null) {
				Destroy (player);
			}
		}
	}
}
