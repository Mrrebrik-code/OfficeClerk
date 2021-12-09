using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievement 
{
    [CreateAssetMenu(fileName = "Achievement", menuName = "SO/Achievement")]
    public class Achievement : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private int _reward;
        [SerializeField] private int _level;

        public string Name { get{ return _name; } }
        public string Description { get { return _description; } }
        public int Reward { get { return _reward; } }
        public int Level { get { return _level; } }
    }
}


