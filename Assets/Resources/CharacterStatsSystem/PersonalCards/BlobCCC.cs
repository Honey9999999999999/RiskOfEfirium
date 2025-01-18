using Assets.Scripts.CharacterStatsSystem;

namespace Assets.Scripts.CraftSystem.PersonalCards
{
    public class BlobCCC : CharacterCharacteristicCard
    {
        public BlobCCC()
        {
            characteristicsMap[Characteristics.RateFirePerMin] = new(30, 15, 60);
        }
    }
}
