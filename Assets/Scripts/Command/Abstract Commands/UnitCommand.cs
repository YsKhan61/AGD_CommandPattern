using Command.Player;

namespace Command.Commands
{
    public abstract class UnitCommand : ICommand
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;
        public CommandData CommandData;

        protected UnitController m_ActorUnit;
        protected UnitController m_TargetUnit;
        
        public abstract void Execute();

        public abstract bool WillHitTarget();

        public void SetActorUnit(UnitController actorUnit) => m_ActorUnit = actorUnit;
        public void SetTargetUnit(UnitController targetUnit) => m_TargetUnit = targetUnit;

    }

    public struct CommandData
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;

        public CommandData(int actorUnitID, int targetUnitID, int actorPlayerID, int targetPlayerID)
        {
            ActorUnitID = actorUnitID;
            TargetUnitID = targetUnitID;
            ActorPlayerID = actorPlayerID;
            TargetPlayerID = targetPlayerID;
        }
    }
}