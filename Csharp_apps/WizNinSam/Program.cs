using System;

namespace WizNinSam
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Humie = new Human("Hue");
            Wizard wizo = new Wizard("WizWiz");
            Ninja ninj = new Ninja("NinNin");
            ninj.Steal(wizo);
            Samurai samu = new Samurai("SamSam");
            samu.death_blow(ninj);
        }
    }
}
