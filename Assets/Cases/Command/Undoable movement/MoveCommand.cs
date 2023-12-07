using Command_object_and_command_invoker;
using UnityEngine;

namespace Undoable_movement {
    public class MoveCommand : ICommand {
        PlayerMover playerMover;
        Vector3 movement;

        public MoveCommand(PlayerMover player, Vector3 moveVector) {
            this.playerMover = player;
            this.movement = moveVector;
        }

        public void Execute() {
            playerMover.Move(movement);
        }

        public void Undo() {
            playerMover.Move(-movement);
        }
    }
}