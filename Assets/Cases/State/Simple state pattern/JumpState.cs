namespace Simple_state {
    public class JumpState : IState {
        private PlayerController player;

        public JumpState(PlayerController player) {
            this.player = player;
        }

        public void Enter() {
            throw new System.NotImplementedException();
        }

        public void Exit() {
            throw new System.NotImplementedException();
        }

        public void Update() {
            throw new System.NotImplementedException();
        }
    }
}