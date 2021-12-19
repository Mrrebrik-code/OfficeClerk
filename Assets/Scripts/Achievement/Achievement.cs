using UnityEngine;

namespace Achievement 
{
    [CreateAssetMenu(fileName = "Achievement", menuName = "SO/Achievement")]
    public class Achievement : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private string _rewardInfo;
        [SerializeField] private TypeAchievement _type;
        [SerializeField] private int _target;
        [SerializeField] private int _reward;
        [SerializeField] private int _level;

        public string Name { get{ return _name; } }
        public string Description { get { return _description; } }
        public string RewardInfo { get{ return _rewardInfo; } }
        public TypeAchievement Type { get{ return _type; } }
        public int Target { get { return _target; } }
        public int Reward { get { return _reward; } }
        public int Level { get { return _level; } }
        public bool IsDone { get; set; }
    }
}


