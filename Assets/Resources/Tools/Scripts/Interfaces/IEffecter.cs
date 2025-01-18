using Assets.Scripts.CharacterStatsSystem;

namespace Interfaces
{
    public interface IEffecter
    {
        public void Effect(CharacterCharacteristicCard personalCCC);
        public void ReverseEffect(CharacterCharacteristicCard personalCCC);
    }
}
