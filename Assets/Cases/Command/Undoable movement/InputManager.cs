using Command_object_and_command_invoker;
using UnityEngine;

namespace Undoable_movement {
    public class InputManager : MonoBehaviour {
        private void RunPlayerCommand(PlayerMover playerMover, Vector3 movement) {
            if (playerMover == null) return;

            if (playerMover.IsValidMove(movement)) {
                ICommand command = new MoveCommand(playerMover, movement);
                CommandInvoler.ExecuteCommand(command);
            }
        }

    }
}