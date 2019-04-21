using UnityEngine;
using System.Collections;

namespace UnitedTAD {

	/// <summary>
	/// Interface for anything that can take damage.
	/// </summary>
	public interface Can_Attack {
		void Attack (string animationNameValue, AudioClip clip);
	}
}
