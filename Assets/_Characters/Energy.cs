using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Characters
{
    public class Energy : MonoBehaviour
    {
        [SerializeField] Image energyBar = null;
        [SerializeField] float maxEnergyPoints = 100f;
        [SerializeField] float regenPointsPerSecond = 1f;

        float currentEnergyPoints;
        CameraUI.CameraRaycaster cameraRaycaster;

        // Use this for initialization
        void Start()
        {
            currentEnergyPoints = maxEnergyPoints;
        }

        void Update()
        {
            if (currentEnergyPoints < maxEnergyPoints)
            {
                AddEnergyPoints();
                UpdateEnergyBar();
            }
        }

        private void AddEnergyPoints()
        {
            var pointsToAdd = regenPointsPerSecond * Time.deltaTime;
            currentEnergyPoints = Mathf.Clamp(currentEnergyPoints + pointsToAdd, 0, maxEnergyPoints);
        }

        public bool IsEnergyAvailable(float amount)
        {
            return amount <= currentEnergyPoints;
        }

        public void ConsumeEnergy(float amount)
        {
            float newEnergyPoints = currentEnergyPoints - amount;
            currentEnergyPoints = Mathf.Clamp(newEnergyPoints, 0, maxEnergyPoints);
            UpdateEnergyBar();
        }

        private void UpdateEnergyBar()
        {
            // TODO remove magic numbers
            energyBar.fillAmount = EnergyAsPercent();
        }

        float EnergyAsPercent()
        {
            return currentEnergyPoints / maxEnergyPoints;
        }
    }
}