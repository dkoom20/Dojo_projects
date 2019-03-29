namespace human_csharp {
    public class Human {
        // set defaults for the new human constructor
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        // pass name for the new human constructor
        public Human(string n) {
            name = n;
        }

        // pass all attributes for the new human constructor
        public Human(string n, int str, int intl, int dex, int hp){
            name = n;
            strength = str;
            intelligence = intl;
            dexterity = dex;
            health = hp;
        }

        // public void Attack(Human enemy){
        public void Attack(object target){
            Human enemy = target as Human;
            if(enemy != null) {
                enemy.health -= 5 * strength;
            }
        }
    }
}