using DG.Tweening;
using UnityEngine;

namespace MiniJam.Control
{
	public class CameraController : MonoBehaviour
	{
		public static void ShakeCamera(float strength = 0.1f, float duration = 0.1f)
		{
			Camera.main.DOShakePosition(duration, strength, 10, 90);
		}
	}
}
