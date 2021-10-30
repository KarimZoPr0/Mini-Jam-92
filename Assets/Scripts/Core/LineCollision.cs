using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiniJam.Core
{
    [RequireComponent(typeof(LineController), typeof(PolygonCollider2D))]
    public class LineCollision : MonoBehaviour {

        private LineController    _lineController;
        private PolygonCollider2D _polygonCollider2D;
        private List<Vector2>     _colliderPoints = new List<Vector2>();

        private void Awake() {
            _lineController    = GetComponent<LineController>();
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
        }


        private void LateUpdate() {
            
            //Get all the positions from the line renderer
            Vector3[] positions = _lineController.GetPositions();

        
            //If we have enough points to draw a line
            if (positions.Count() >= 2) {

                //Get the number of line between two points
                int numberOfLines = positions.Length - 1;

                //Make as many paths for each different line as we have lines
                _polygonCollider2D.pathCount = numberOfLines;

                //Get Collider points between two consecutive points
                for (int i = 0; i < numberOfLines; i++) 
                    GetTwoNextPoints(positions, i);
            }
            else
                _polygonCollider2D.pathCount = 0;
        }

        private void GetTwoNextPoints(Vector3[] positions, int i)
        {
            List<Vector2> currentPositions = new List<Vector2>
            {
                positions[i],
                positions[i + 1],
            };

            List<Vector2> currentColliderPoints = CalculateColliderPoints(currentPositions);
            _polygonCollider2D.SetPath(i, currentColliderPoints.ConvertAll(p => (Vector2) transform.InverseTransformPoint(p)));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            if(_colliderPoints != null) 
                _colliderPoints.ForEach(p => Gizmos.DrawSphere(p, 0.1f));
        }

        private List<Vector2> CalculateColliderPoints(List<Vector2> positions) {
            
            //Get The Width of the Line
            float width = _lineController.GetWidth();

            // m = (y2 - y1) / (x2 - x1)
            float m      = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
            float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
            float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

            //Calculate Vertex Offset from Line Point
            Vector2[] offsets = new Vector2[2];
            offsets[0] = new Vector2(-deltaX, deltaY);
            offsets[1] = new Vector2(deltaX, -deltaY);

            List<Vector2> colliderPoints = new List<Vector2> {
                positions[0] + offsets[0],
                positions[1] + offsets[0],
                positions[1] + offsets[1],
                positions[0] + offsets[1]
            };

            return colliderPoints;
        }
    }
}
