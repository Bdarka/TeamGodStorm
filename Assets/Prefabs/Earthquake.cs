using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StormDestruction
{
    public class EarthquakeDestruction : BuildingDestruction
    {
        protected override float GetDisasterMultiplier()
        {
            return 1.2f;
        }

        protected override void Update()
        {
            base.Update();
            // Additional earthquake-specific behavior can be added here
        }
    }
}
