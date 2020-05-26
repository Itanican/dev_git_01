using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learningcurve : MonoBehaviour
{


    public string thisFloat ;
    public int characterLevel;

    private Transform camTransform;

    public GameObject directionLight;
    private Transform lightTransform;


    // Start is called before the first frame update
    void Start()
    {



        camTransform = this.GetComponent<Transform>();
        // Debug.Log(camTransform.localPosition);

        //easier to read
        //directionLight = GameObject.Find("Directional Light");
        //lightTransform = directionLight.GetComponent<Transform>();

        //but can be compressed down to this
        lightTransform = GameObject.Find("Directional Light").GetComponent<Transform>();


        Debug.Log(lightTransform.localPosition);

        Character hero = new Character();
        Character hero2 = new Character();
        hero2.name = "Sir Krane the Brave";
        hero2.exp = 399;

        
        /*
        // Debug.LogFormat("Hero: {0} - {1} EXP", hero.name, hero.exp);
        hero.PrintStatsInfo();
        hero2.PrintStatsInfo();
        hero2.Reset();
        hero2.PrintStatsInfo();
        */
        Character heroine = new Character("Agatha");
        //Debug.LogFormat("Hero: {0} - {1} EXP", heroine.name, heroine.exp);
       // heroine.PrintStatsInfo();

        Weapon huntingBow = new Weapon("Hunting Bow", 105);
        Weapon warBow = huntingBow;
        
        warBow.name = "War Bow";
        warBow.damage = 155;


        huntingBow.PrintWeaponStats();
        warBow.PrintWeaponStats();


        Paladin knight = new Paladin("Sir Arthur", huntingBow);
        knight.PrintStatsInfo();


        //int nextSkillLevel = GenerateCharacter("Spike", characterLevel);

        // Debug.Log("Skill level is " + thisFloat + " " + nextSkillLevel);
        //Debug.Log(aSecondScript.apple);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GenerateCharacter(string char_name, int level)
    {
       // Debug.LogFormat("Character: {0} - Level: {1}", name, level);
        return level + 5;
    }




}
