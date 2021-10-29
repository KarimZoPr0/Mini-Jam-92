using UnityEngine;

namespace MiniJam.Control
{
	public class LineController : MonoBehaviour
	{
		private LineRenderer _lineRenderer;
		private Transform[]  _points;

		private void Awake() => _lineRenderer = GetComponent<LineRenderer>();

		public void SetUpLine(Transform[] points)
		{
			_lineRenderer.positionCount = points.Length;
			_points                 = points;
		}
		
	}
}