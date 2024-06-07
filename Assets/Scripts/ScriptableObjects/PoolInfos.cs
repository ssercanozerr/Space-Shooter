using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new pool info", menuName = "self/create pool info")]
    public class PoolInfos : ScriptableObject
    {
        public List<PoolInfo> poolInfos;  
    }
    [Serializable] 
    public class PoolInfo
    {
        public EntityTypes entityType;
        public GameObject entityPrefab;
        public int startSize;
        public int increaseAmount;
        public Queue<GameObject> poolQueue;
    }
}