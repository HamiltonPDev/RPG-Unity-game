using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header ("Character Stats")]
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp, hpLevels, strengthLevels, defenseLevels;

    private HealthManager healthManager;

    void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        if(currentLevel >= expToLevelUp.Length) return;

        if(currentExp >= expToLevelUp[currentLevel]) {
            currentLevel++;
            healthManager.UpdateMaxHealth(hpLevels[currentLevel]);
        }
    }
    public void AddExperience(int exp)
    {
        currentExp += exp;
    }
}
