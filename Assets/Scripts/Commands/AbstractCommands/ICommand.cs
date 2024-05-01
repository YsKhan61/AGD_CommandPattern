namespace Command.Commands
{
    /// <summary>
    /// An interface representing signature of a command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// This method defines the contract for executing a command. 
        /// Must be implemented by concrete sub classes
        /// </summary>
        public void Execute();
    }

    /// <summary>
    /// An abstract class representing a unit-related command
    /// </summary>
    public abstract class UnitCommand : ICommand
    {
        /// <summary>
        /// Stores the ID of the unit that is the actor of the command
        /// </summary>
        public int ActorUnitID;

        /// <summary>
        /// Stores the ID of the unit that is the target of the command
        /// </summary>
        public int TargetUnitID;

        /// <summary>
        /// Stores the ID of the player that is the actor of the command
        /// </summary>
        public int ActorPlayerID;

        /// <summary>
        /// Stores the ID of the player that is the target of the command
        /// </summary>
        public int TargetPlayerID;

        /// <summary>
        /// Abstract method to execute the unit command. 
        /// Must be implemented by concrete sub classes
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Abstract method to determine whether the command will successfully hit its target.
        /// Must be implemented by concrete sub classes
        /// </summary>
        public abstract bool WillHitTarget();
    }
}