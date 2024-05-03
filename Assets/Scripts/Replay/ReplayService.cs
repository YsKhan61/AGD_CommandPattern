using Command.Commands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Command.Replay
{
    public enum ReplayState
    {
        Active,
        Deactive
    }

    public class ReplayService
    {
        private const int REPLAY_DELAY = 1;

        /// <summary>
        /// Property to get the current replay state.
        /// </summary>
        public ReplayState ReplayState { get; private set; }

        private Stack<ICommand> replayCommandStack;
        private Coroutine replayRoutine;

        /// <summary>
        /// A constructor to initialize the ReplayService with a Deactive state.
        /// </summary>
        public ReplayService() => SetReplayState(ReplayState.Deactive);

        /// <summary>
        /// Method to set the replay state
        /// </summary>
        /// <param name="state">state to set</param>
        public void SetReplayState(ReplayState state) => ReplayState = state;

        /// <summary>
        /// Set the command stack to replay, providing a collection of commands to replay.
        /// </summary>
        /// <param name="commandsToSet"></param>
        public void SetCommandStack(Stack<ICommand> commandsToSet) => replayCommandStack = new Stack<ICommand>(commandsToSet);
    
        /// <summary>
        /// Start the replay of gameplays.
        /// </summary>
        public void StartReplay()
        {
            if (replayCommandStack == null || replayCommandStack.Count == 0)
            {
                Debug.LogWarning("No commands to replay.");
                return;
            }

            ReplayState = ReplayState.Active;

            replayRoutine = GameService.Instance.StartCoroutine(ReplayRoutine());
        }

        /// <summary>
        /// Stop the replay of gameplays.
        /// </summary>
        public void StopReplay()
        {
            if (replayRoutine != null)
            {
                GameService.Instance.StopCoroutine(replayRoutine);
            }
            ReplayState = ReplayState.Deactive;
        }

        void ExecuteNext()
        {
            if (replayCommandStack.Count > 0)
            {
                GameService.Instance.ProcessUnitCommand(replayCommandStack.Pop());
            }
        }

        IEnumerator ReplayRoutine()
        {
            while (replayCommandStack.Count > 0)
            {
                yield return new WaitForSeconds(REPLAY_DELAY);            
                ExecuteNext();
            }

            replayRoutine = null;
            ReplayState = ReplayState.Deactive;
        }
    }

}