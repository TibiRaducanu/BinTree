using UnityEngine;
using System.Collections;

namespace UnitedTAD {

	public class Dont_Destroy_On_Scene_Load : MonoBehaviour {

		void Awake () {
			DontDestroyOnLoad(gameObject);
		}
	}
}
