public abstract class Archer : Unit, IAttack, ITakeDamage
{
    public abstract void Attack();

    public abstract void TakeDamage(float damage);
}
