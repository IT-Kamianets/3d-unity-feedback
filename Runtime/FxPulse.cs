using UnityEngine;

namespace ITKamianets.Engine.Feedback
{
	/// <summary>Scales its object from one size to another over its life, then destroys it.</summary>
	public sealed class FxPulse : MonoBehaviour
	{
		public Vector3 From;
		public Vector3 To;
		public float Life = 0.3f;

		float _age;

		void Update()
		{
			_age += Time.deltaTime;
			var t = Mathf.Clamp01(_age / Mathf.Max(0.01f, Life));
			transform.localScale = Vector3.Lerp(From, To, t);
			if (t >= 1f) Destroy(gameObject);
		}
	}
}
