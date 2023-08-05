using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatData
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int attack;
    [SerializeField]
    private int range;

    public static StatData operator +(StatData a, StatData b)
    {
        StatData result = new StatData();
        result.health = a.health + b.health;
        result.speed = a.speed + b.speed;
        result.attack = a.attack + b.attack;
        result.range = a.range + b.range;
        return result;
    }

    public static StatData operator -(StatData a, StatData b)
    {
        StatData result = new StatData();
        result.health = a.health - b.health;
        result.speed = a.speed - b.speed;
        result.attack = a.attack - b.attack;
        result.range = a.range - b.range;
        return result;
    }
}
