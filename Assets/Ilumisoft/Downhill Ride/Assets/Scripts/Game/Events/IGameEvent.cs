using UnityEngine.Events;

namespace ADH.Game
{
    public interface IGameEvent
    {
        void AddListener(UnityAction call);
        void RemoveListener(UnityAction call);
        void Invoke();
    }
}