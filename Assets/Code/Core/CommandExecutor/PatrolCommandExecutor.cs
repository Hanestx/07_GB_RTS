using UnityEngine;


namespace RTS
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log("Patrol");
        }
    }
}