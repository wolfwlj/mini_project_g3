
namespace miniproj
{
    public class Weapon
    {
        public enum WeaponType
        {
            Sword,
            Axe,
            Bow,
        }

        public int AddedPower = 10;
        public bool IsEquipped;
        public WeaponType Type;

        public Weapon(int addedPower, bool isEquipped, WeaponType type)
        {
            AddedPower = addedPower;
            IsEquipped = isEquipped;
            Type = type;
        }
    }
}