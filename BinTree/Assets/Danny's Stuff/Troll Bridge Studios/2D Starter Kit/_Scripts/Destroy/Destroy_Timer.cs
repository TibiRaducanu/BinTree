using UnityEngine;
using System.Collections;

namespace UnitedTAD {

	public class Destroy_Timer : MonoBehaviour {

		[Tooltip("How long this GameObject last for and then it will be destroyed.")]
		public float time = 0.1f;

		void Start () {
			Destroy (gameObject, time);
		}
	}
}
