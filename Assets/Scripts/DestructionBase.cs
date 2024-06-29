using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StormDestruction
{
    public class BuildingDestruction : MonoBehaviour
    {
        public GameObject[] buildingStates; // Array of building prefabs representing different damage states
        public float destructionSpeed = 1f; // Speed of destruction
        protected float buildingHealth = 100f; // Total health of the building
        private int currentState = 0;

        void Start()
        {
            if (buildingStates.Length == 0)
            {
                Debug.LogError("No building states assigned.");
                return;
            }
            // Initialize the building state to the first prefab (undamaged)
            Instantiate(buildingStates[currentState], transform.position, transform.rotation, transform);
        }

        protected virtual void Update()
        {
            if (buildingHealth > 0)
            {
                buildingHealth -= Time.deltaTime * destructionSpeed * GetDisasterMultiplier();
                UpdateBuildingState();
            }
        }

        protected virtual float GetDisasterMultiplier()
        {
            return 1.0f;
        }

        void UpdateBuildingState()
        {
            int newState = Mathf.FloorToInt((1 - buildingHealth / 100f) * (buildingStates.Length - 1));
            if (newState != currentState)
            {
                // Destroy the old state and instantiate the new state
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                Instantiate(buildingStates[newState], transform.position, transform.rotation, transform);
                currentState = newState;
            }
        }
    }
}
