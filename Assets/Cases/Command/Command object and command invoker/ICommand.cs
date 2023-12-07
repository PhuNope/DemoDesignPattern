namespace Command_object_and_command_invoker {
    public interface ICommand {
        void Execute();
        void Undo();
    }
}