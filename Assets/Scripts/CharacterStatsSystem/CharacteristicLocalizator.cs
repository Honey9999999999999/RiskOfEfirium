using Assets.Scripts.Localization;
using System.Collections.Generic;

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

                [Characteristics.Movespeed] = "Скорость передвижения"
            }
        };

        public static string GetLocalWord(Characteristics characteristicName) => localizationMap[Abbreviations.RU][characteristicName];
    }
}
