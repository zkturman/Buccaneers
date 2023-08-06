using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatData
{
    [SerializeField]
    private int health;
    public int Health { get => health; }
    [SerializeField]
    private int speed;
    public int Speed { get => speed; }
    [SerializeField]
    private int attack;
    public int Attack { get => attack; }
    [SerializeField]
    private int range;
    public int Range { get => range; }

    public StatData() { }
    public StatData(StatType bonusType, int bonusAmount)
    {
        health = 0;
        speed = 0;
        attack = 0;
        range = 0;
        switch (bonusType)
        {
            case StatType.Health:
                health = bonusAmount;
                break;
            case StatType.Speed:
                speed = bonusAmount;
                break;
            case StatType.Strength:
                attack = bonusAmount;
                break;
            case StatType.Range:
                range = bonusAmount;
                break;
            default:
                break;
        }
    }

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
