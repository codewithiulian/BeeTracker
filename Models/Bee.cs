using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeTracker.Models
{
    public class Bee
    {
        public Guid ID { get; set; }
        public float Health { get; private set; }
        public BeeType Type { get; set; }
        public bool IsDead { get; set; }
        public float HealthResistance { get; private set; }

        public Bee(BeeType beeType)
        {
            ID = Guid.NewGuid();
            Health = 100.0F;
            Type = beeType;
            IsDead = false;
            HealthResistance = GetHealthResistance(beeType);
        }

        /// <summary>
        /// This function applies damage to the bee.
        /// </summary>
        /// <param name="damagePercentage">The damage percentage the bee incurs.</param>
        public void Damage(int damagePercentage)
        {
            // Only affect if the bee is not dead.
            if (!IsDead)
            {
                Health -= (damagePercentage / Health) * 100;
                SetLifeStatus();
            }
        }

        /// <summary>
        /// This method is responsible for setting the IsDead flag
        /// based on the percentage of life left and the health
        /// resistance of the bee (computed from the type).
        /// </summary>
        private void SetLifeStatus()
        {
            // If the health is bellow the resistance.
            if (Health < HealthResistance)
            {
                // Declare the bee dead (switch the flag).
                IsDead = true;
            }
        }

        /// <summary>
        /// This method computes the bee resistance based on the bee type.
        /// </summary>
        /// <param name="beeType">The type of bee (woroker, queen, etc.)</param>
        /// <returns>Returns a float with the maximum bee health resistance.</returns>
        private float GetHealthResistance(BeeType beeType)
        {
            switch (beeType)
            {
                case BeeType.Worker:
                    return 70.0F;
                case BeeType.Queen:
                    return 20.0F;
                case BeeType.Drone:
                    return 50.0F;
                default:
                    return 0.0F;
            }
        }
    }
}