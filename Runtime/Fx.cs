using System.Collections.Generic;
using UnityEngine;

namespace ITKamianets.Engine.Feedback
{
	/// <summary>Short-lived primitive effects: a slash, a shockwave ring, a warning on the floor.</summary>
	public static class Fx
	{
		static readonly Dictionary<Color, Material> Materials = new Dictionary<Color, Material>();

		/// <summary>A plain lit material of one colour, made once and reused.</summary>
		public static Material Material(Color colour)
		{
			if (Materials.TryGetValue(colour, out var material) && material != null) return material;
			var shader = Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard");
			material = new Material(shader);
			material.SetColor("_BaseColor", colour);
			material.color = colour;
			Materials[colour] = material;
			return material;
		}

		/// <summary>
		/// A primitive that grows from one size to another and disappears after <paramref name="life"/> seconds.
		/// A flat cylinder growing from small to large is a ring on the floor; a cube growing along one axis is a slash.
		/// </summary>
		public static GameObject Pulse(PrimitiveType type, Vector3 position, Quaternion rotation, Vector3 from, Vector3 to, Color colour, float life)
		{
			var go = GameObject.CreatePrimitive(type);
			Object.Destroy(go.GetComponent<Collider>());
			go.transform.SetPositionAndRotation(position, rotation);
			go.transform.localScale = from;
			go.GetComponent<Renderer>().sharedMaterial = Material(colour);
			var pulse = go.AddComponent<FxPulse>();
			pulse.From = from;
			pulse.To = to;
			pulse.Life = life;
			return go;
		}
	}
}
