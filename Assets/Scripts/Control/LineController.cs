using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJam.Core
{
	public class LineController : MonoBehaviour
	{

		private                  LineRenderer    lineRenderer;
		[SerializeField] private List<Transform> nodes;
		private                  Vector3[]       positionsOfPoints;

		public GameObject dotParent;
		private void Awake() => lineRenderer = GetComponent<LineRenderer>();

		private void Start()
		{
			for (int i = 0; i < dotParent.transform.childCount; i++)
			{
				nodes.Add(dotParent.transform.GetChild(i));
			}
			
		}

		private void Update()
		{
			List<Vector3> temp = new List<Vector3>();
			foreach(Transform t in nodes)
			{
				temp.Add(t.position);
			}
 
			positionsOfPoints = temp.ToArray();
			lineRenderer.SetVertexCount(positionsOfPoints.Length);
			lineRenderer.SetPositions(positionsOfPoints);
		}
	

		public float GetWidth() => lineRenderer.startWidth;
	
		public Vector3[] GetPositions() {
		
			Vector3[] positions = new Vector3[lineRenderer.positionCount];
			lineRenderer.GetPositions(positions);
			return positions;
		}
	}
}
