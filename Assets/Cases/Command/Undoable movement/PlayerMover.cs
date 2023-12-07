using UnityEngine;

namespace Undoable_movement {
    public class PlayerMover : MonoBehaviour {
        [SerializeField] private LayerMask obstacleLayer;
        private const float boardSpacing = 1f;

        public void Move(Vector3 movement) {
            transform.position = transform.position + movement;
        }

        public bool IsValidMove(Vector3 movement) {
            return !Physics.Raycast(transform.position, movement, boardSpacing, obstacleLayer);
        }
    }
}