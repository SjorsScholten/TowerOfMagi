using System;
using UnityEngine;

[Serializable]
public class StatBlock {
    [SerializeField] private float
        vitality = 1,
        constitution = 1,
        dexterity = 1,
        agility = 1,
        strength = 1,
        talent = 1,
        intelligence = 1,
        magicPotency = 1;

    public float Vitality => vitality;

    public float Dexterity => dexterity;

    public float Agility => agility;
}