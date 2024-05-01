using System.Collections.Generic;

namespace Command.Commands
{
    /// <summary>
    /// This class is responsible for managing the registration/execution/deregistration of commands
    /// </summary>
    public class CommandInvoker
    {
        private Stack<ICommand> m_CommandRegistry = new Stack<ICommand>();

        /// <summary>
        /// Registers the specified command in the registry
        /// </summary>
        /// <param name="commandToRegister">command that need to be registered</param>
        public void RegisterCommand(ICommand commandToRegister) => m_CommandRegistry.Push(commandToRegister);

        /// <summary>
        /// Executes the specified command
        /// </summary>
        /// <param name="commandToExecute">the command to be executed</param>
        public void ExecuteCommand(ICommand commandToExecute)
        {
            commandToExecute.Execute();
        }

        /// <summary>
        /// Processes the specified command, which involves executing it and registering it
        /// </summary>
        /// <param name="commandToProcess">command to process</param>
        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }
    }
}