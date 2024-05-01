using Command.Main;
using System.Collections.Generic;

namespace Command.Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void Undo()
        {
            if (!IsRegistryEmpty() && DoesCommandBelongsToActivePlayer())
                commandRegistry.Pop().Undo();
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);

        private bool IsRegistryEmpty() => commandRegistry.Count <= 0;

        private bool DoesCommandBelongsToActivePlayer() =>
            (commandRegistry.Peek() as UnitCommand).commandData.ActorPlayerID
            == GameService.Instance.PlayerService.ActivePlayerID;
    }
}