using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;


    public Character() //constructor
    {
        name = "Not assigned";
    }

    public Character(string name) //another, different constructor. Useful!
    {
        this.name = name;
    }

    public virtual void PrintStatsInfo() //method
    {
        Debug.LogFormat("Hero: {0} - {1} EXP", name, exp);
    }

    public void Reset()
    {
        this.name = "Not Assigned";
        this.exp = 0;
    }

}

public class Paladin : Character
{

    public Weapon weapon;

    public Paladin(string name, Weapon weapon) : base(name)
    {
        this.weapon = weapon;
    }

    public override void PrintStatsInfo()
    {
        Debug.LogFormat("Hail {0} - take up your {1}!", name, weapon.name);
    }

}

public struct Weapon
{
    public string name;
    public int damage;

    public Weapon(string name, int damage) //constructor
    {
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponStats() //method
    {
        Debug.LogFormat("Weapon: {0} - {1} EXP", name, damage);
    }

}