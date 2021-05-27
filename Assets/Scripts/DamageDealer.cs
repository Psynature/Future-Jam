using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private int damageDealt;

    public void SetDamage(int damage) {damageDealt = damage;}

    public int GetDamage() {return damageDealt;}
}
