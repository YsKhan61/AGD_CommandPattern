using System.Collections.Generic;
using UnityEngine;

namespace Command.Battle
{
    [CreateAssetMenu(fileName = "BattleDataContainer", menuName = "ScriptableObjects/BattleDataContainerSO")]
    public class BattleDataContainerSO : ScriptableObject
    {
        public List<BattleScriptableObject> BattleDatas;
    }
}