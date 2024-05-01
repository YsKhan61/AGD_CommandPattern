using Command.Actions;
using Command.Main;

namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool m_HasHitTarget;

        public ThirdEyeCommand(CommandData commandData)
        {
            CommandData = commandData;
            m_HasHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            IAction action = GameService.Instance.ActionService.GetActionByType(CommandType.ThirdEye);
            action.PerformAction(m_ActorUnit, m_TargetUnit, m_HasHitTarget);
        }

        public override bool WillHitTarget() => true;
    }
}