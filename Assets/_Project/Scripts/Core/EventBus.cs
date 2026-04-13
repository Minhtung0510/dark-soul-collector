using System;
using System.Collections.Generic;

namespace IdleSoulSurvivor.Core
{
    /// <summary>
    /// Global event bus for decoupled communication between systems.
    /// Supports subscribe, unsubscribe, and publish pattern.
    /// Events: OnSoulCollected, OnEnemyKilled, OnBossDefeated, OnAreaUnlocked, etc.
    /// </summary>
    public static class EventBus
    {
        private static readonly Dictionary<Type, Delegate> _events = new();

        public static void Subscribe<T>(Action<T> handler) where T : struct
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
                _events[type] = Delegate.Combine(_events[type], handler);
            else
                _events[type] = handler;
        }

        public static void Unsubscribe<T>(Action<T> handler) where T : struct
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
                _events[type] = Delegate.Remove(_events[type], handler);
        }

        public static void Publish<T>(T eventData) where T : struct
        {
            if (_events.TryGetValue(typeof(T), out var handler))
                (handler as Action<T>)?.Invoke(eventData);
        }

        public static void Clear() => _events.Clear();
    }
}
