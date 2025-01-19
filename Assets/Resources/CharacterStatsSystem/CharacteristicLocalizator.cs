using System.Collections.Generic;
using Assets.Scripts.Localization;

namespace Assets.Scripts.CharacterStatsSystem
{
    public class CharacteristicLocalizator
    {
        private static readonly Dictionary<Abbreviations, Dictionary<Characteristics, string>> localizationMap = new()
        {
            [Abbreviations.RU] = new()
            {
                [Characteristics.RateFirePerMin] = "Скорострельность",
                [Characteristics.MaxAmmo] = "Вместительность обоймы",
                [Characteristics.ReloadTime] = "Скорость перезарядки",

                [Characteristics.Movespeed] = "Скорость передвижения",
                [Characteristics.Damage] = "Урон"
            }
        };

        public static string GetLocalWord(Characteristics characteristicName) => localizationMap[Abbreviations.RU][characteristicName];
    }
}
