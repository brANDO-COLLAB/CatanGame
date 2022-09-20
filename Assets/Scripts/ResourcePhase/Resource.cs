using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Catan.ResourcePhase
{
    public class Resource
    {
        public ResourceType type;
        public int amount;

        public enum ResourceType
        {
            Any,
            Wool,
            Grain,
            Wood,
            Brick,
            Ore
        }

        public Resource(ResourceType type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }
    }
}
