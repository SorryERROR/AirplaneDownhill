using UnityEngine.Events;

namespace ADH.Game
{
    public interface IHealthSystem
    {
        HealthChangedEvent OnHealthChanged { get; }

        UnityEvent OnHealthEmpty { get; }

        void ModifyHealth(int amount);
    }
}