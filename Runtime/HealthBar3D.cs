using ITKamianets.Engine.Combat;
using UnityEngine;

namespace ITKamianets.Engine.Feedback
{
	/// <summary>A small bar above a monster showing its health; it always faces the camera.</summary>
	[RequireComponent(typeof(Health))]
	public sealed class HealthBar3D : MonoBehaviour
	{
		public float Height = 2.4f;
		public float Width = 1.2f;

		Health _health;
		Transform _bar;
		Transform _fill;

		void Awake()
		{
			_health = GetComponent<Health>();
			_bar = new GameObject("HealthBar").transform;
			_bar.SetParent(transform, false);
			_bar.localPosition = new Vector3(0f, Height, 0f);

			Piece("Back", new Color(0.1f, 0.05f, 0.05f), new Vector3(Width, 0.14f, 0.02f), 0f);
			_fill = Piece("Fill", new Color(0.85f, 0.15f, 0.12f), new Vector3(Width, 0.1f, 0.02f), -0.012f);
		}

		Transform Piece(string name, Color colour, Vector3 scale, float z)
		{
			var piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
			piece.name = name;
			Destroy(piece.GetComponent<Collider>());
			piece.transform.SetParent(_bar, false);
			piece.transform.localPosition = new Vector3(0f, 0f, z);
			piece.transform.localScale = scale;
			piece.GetComponent<Renderer>().sharedMaterial = Fx.Material(colour);
			return piece.transform;
		}

		void LateUpdate()
		{
			var camera = Camera.main;
			if (camera != null) _bar.rotation = camera.transform.rotation;

			var fraction = Mathf.Clamp01(_health.Fraction);
			_fill.localScale = new Vector3(Mathf.Max(0.001f, Width * fraction), 0.1f, 0.02f);
			_fill.localPosition = new Vector3(-Width * (1f - fraction) * 0.5f, 0f, -0.012f);
			_bar.gameObject.SetActive(_health.IsAlive);
		}
	}
}
