using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StormDestruction
{
    public class TornadoDestruction : BuildingDestruction
    {
        protected override float GetDisasterMultiplier()
        {
            return 1.8f;
        }

        protected override void Update()
        {
            base.Update();
            // Additional tornado-specific behavior can be added here
        }
    }
}
