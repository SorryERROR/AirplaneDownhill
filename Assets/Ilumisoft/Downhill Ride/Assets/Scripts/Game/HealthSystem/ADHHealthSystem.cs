using UnityEngine;
using UnityEngine.Events;

namespace ADH.Game
{
    public class ADHHealthSystem : MonoBehaviour, IHealthSystem
    {
        [SerializeField] private int health = 1;

        [SerializeField] private UnityEvent onHealthEmpty = new UnityEvent();

        [SerializeField] private HealthChangedEvent onHealthChanged = new HealthChangedEvent();

        public UnityEvent OnHealthEmpty => onHealthEmpty;

        public HealthChangedEvent OnHealthChanged => onHealthChanged;

        public void ModifyHealth(int amount)
        {
            health += amount;

            OnHealthChanged.Invoke(amount);

            if (health <= 0)
            {
                onHealthEmpty.Invoke();
            }
        }
    }
}