using System;
using System.Collections.Generic;

public class GameState
{
    public static bool isFpv { get; set; }
    public static bool isNight { get; set; }
    public static float flashCharge { get; set; }
    public static Dictionary<string, bool> collectedKeys { get; } = new Dictionary<string, bool>();

    private static float _effectsVolume = 1.0f;

    public static float effectsVolume
    {
        get => _effectsVolume;
        set
        {
            if (_effectsVolume != value)
            {
                _effectsVolume = value;
                NotifySubscribers(nameof(effectsVolume));
            }
        }
    }

    private static readonly Dictionary<string, List<Action>> subscribers =
        new Dictionary<string, List<Action>>();

    private static void NotifySubscribers(String propertyName)
    {
        if (subscribers.ContainsKey(propertyName))
        {
            foreach (var action in subscribers[propertyName])
            {
                action();
            }
        }
    }
    public static void Subscribe(string propertyName, Action action)
    {
        if (!subscribers.ContainsKey(propertyName))
        {
            subscribers[propertyName] = new List<Action>();
        }
        subscribers[propertyName].Add(action);
    }
    public static void UnSubscribe(string propertyName, Action action)
    {
        if (!subscribers.ContainsKey(propertyName))
        {
            subscribers[propertyName].Remove(action);

        }
    }

}