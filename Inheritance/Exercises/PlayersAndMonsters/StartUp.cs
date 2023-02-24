using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = System.Console.ReadLine();
            int level = int.Parse(System.Console.ReadLine());

            Hero hero = new Hero(username, level);
            Elf elf = new Elf(username, level);
            Wizard wizard = new Wizard(username, level);
            Knight knight = new Knight(username, level);
            MuseElf museElf = new MuseElf(username, level);
            DarkWizard darkWizard = new DarkWizard(username, level);
            DarkKnight darkKnight = new DarkKnight(username, level);
            SoulMaster soulMaster = new SoulMaster(username, level);
            BladeKnight bladeKnight = new BladeKnight(username, level);

            Console.WriteLine(hero);
            Console.WriteLine(elf);
            Console.WriteLine(wizard);
            Console.WriteLine(knight);
            Console.WriteLine(museElf);
            Console.WriteLine(darkWizard);
            Console.WriteLine(darkKnight);
            Console.WriteLine(soulMaster);
            Console.WriteLine(bladeKnight);
        }
    }
}