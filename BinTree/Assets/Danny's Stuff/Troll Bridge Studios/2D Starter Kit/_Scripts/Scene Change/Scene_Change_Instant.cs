using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UnitedTAD {
	
	public class Scene_Change_Instant : MonoBehaviour {

		public string sceneName;

		void Update () {
			SceneManager.LoadScene (sceneName);
		}
	}
}
