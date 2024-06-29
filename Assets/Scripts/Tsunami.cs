using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StormDestruction
{
    public class TsunamiDestruction : BuildingDestruction
    {
        protected override float GetDisasterMultiplier()
        {
            return 1.0f;
        }

        protected override void Update()
        {
            base.Update();
            // Additional tsunami-specific behavior can be added here
        }
    }
}
