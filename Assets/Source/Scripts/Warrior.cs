using UnityEngine;

public abstract class Warrior : Unit, IAttack, ITakeDamage
{


    public abstract void Attack();

    public abstract void TakeDamage(float damage);
}
