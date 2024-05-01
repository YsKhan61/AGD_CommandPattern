using Command.Actions;
using Command.Main;

namespace Command.Commands
{
    public class  AttackStanceCommand : UnitCommand
    {
        private bool m_HasHitTarget;

        public AttackStanceCommand(CommandData commandData)
        {
            CommandData = commandData;
            m_HasHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            IAction action = GameService.Instance.ActionService.GetActionByType(CommandType.AttackStance);
            action.PerformAction(m_ActorUnit, m_TargetUnit, m_HasHitTarget);
        }

        public override bool WillHitTarget() => true;
    }
}