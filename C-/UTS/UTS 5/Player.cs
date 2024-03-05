namespace UTS_5_Safrin_Nada_Ramdani;

class Program
{
    class Player
    {
        public int Health { get; set; }

        public string? Name { get; set; }

        public int attackPower { get; set; }
        
        public float Exp { get; set; }

        public bool isDead { get; set; }

        public bool isRunningAway { get; set; }

        public Player()
        {
            Health = 150;
            attackPower = 1;
            Exp = 0.0f;
        }

        public virtual void Skill(Musuh musuh)
        {
            Console.WriteLine("Skill : Berserk");
            attackPower *= 2;
        }

        public virtual void Defend()
        {
            Console.WriteLine("Defend");
        }

        public void GetHit(int hitValue)
        {
            Console.WriteLine(Name + " get hit by "+hitValue);
            Health -= hitValue;

            if(Health<=0)
            {
                Health = 0;
                Die();
            }
        }

        public void Die()
        {
            Console.WriteLine("You're Dead, Game over");
            isDead = true;
        }
    }
}
