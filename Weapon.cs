using System;
    public class Weapon
    {

        public int ID;
        public bool IsEquipped;
        public string WeaponType;
        public int AddedDamage;

        public Weapon(int id, string weaponType, int addedDamage)
        {
            ID = id;
            WeaponType = weaponType;
            AddedDamage = addedDamage;
        }
    }