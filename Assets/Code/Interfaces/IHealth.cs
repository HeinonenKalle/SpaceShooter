using System;

namespace SpaceShooter
{
    public class HealthChangedEventArgs : EventArgs
    {
        //The property which contains the amount of health the unit has
        public int CurrentHealth { get; private set; }

        public HealthChangedEventArgs(int currentHealth)
        {
            CurrentHealth = currentHealth;
        }
    }

    public delegate void HealthChangedDelegate(object sender, HealthChangedEventArgs args);

    public interface IHealth
    {
        int CurrentHealth { get; set; }

        /// <summary>
        /// Reduces health by the amount of damage taken
        /// </summary>
        /// <param name="damage">Amount of health reduced</param>
        /// <returns>True if health drops to 0, false otherwise</returns>
        bool TakeDamage(int damage);

        /// <summary>
        /// Fired every time health changes
        /// </summary>
        event HealthChangedDelegate HealthChanged;
    }
}
