
namespace miniproj
public class Weapon
{
    public int AddedPower = 10;
    public bool IsEquipped;

    public Weapon(int addedPower, bool isEquipped)
    {
        AddedPower = addedPower;
        IsEquipped = isEquipped;
    }
}