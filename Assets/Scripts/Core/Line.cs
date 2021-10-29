using MiniJam.Control;
using UnityEngine;

namespace MiniJam.Core
{
    public class Line : MonoBehaviour
    {
        [SerializeField] private Transform[]    points;
        [SerializeField] private LineController lineController;

        private void Start() => lineController.SetUpLine(points);
    }
}
