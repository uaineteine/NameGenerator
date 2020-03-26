using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using csvf;

namespace Namelists
{
    public static class Names
    {
        static Random rndm = new Random();
        static string[] MaleFirstNames;
        static string[] FemaleFirstNames;
        static string[] LastNames;
        static string[] TownNB;
        static string[] TownNE;
        static string[] ProvinceNE;
        static object[,] TitleData;

        public static void Load()
        {
            string filename = "namelist/LastNameList.csv";
            LastNames = CSV.ReadAllSC(filename).Cast<string>().ToArray();
            filename = "namelist/MaleFirstNames.csv";
            MaleFirstNames = CSV.ReadAllSC(filename).Cast<string>().ToArray();
            filename = "namelist/FemaleFirstNames.csv";
            FemaleFirstNames = CSV.ReadAllSC(filename).Cast<string>().ToArray();
            filename = "namelist/TownNameBeggining.csv";
            TownNB = CSV.ReadAllSC(filename).Cast<string>().ToArray();
            filename = "namelist/TownNameEnding.csv";
            TownNE = CSV.ReadAllSC(filename).Cast<string>().ToArray();
            filename = "namelist/ProvinceNameEnding.csv";
            ProvinceNE = CSV.ReadAllSC(filename).Cast<string>().ToArray();
            filename = "namelist/Titles.csv";
            TitleData = CSV.ReadAllMC(filename);
        }
        public static bool TitlePassesDown(int type)
        {
            if (Convert.ToInt32(TitleData[type, 4]) != -1)
                return true;
            return false; //else
        }
        public static int GetChildType(int currentType)
        {
            return Convert.ToInt32(TitleData[currentType, 4]);
        }
        public static string GetFirstName(int Gender)//0 m 1 f
        {
            if (Gender == 1)
                return FemaleFirstNames[rndm.Next() % FemaleFirstNames.Count()];
            //else
            return MaleFirstNames[rndm.Next() % MaleFirstNames.Count()];
        }
        public static float GetTitlePower(int type)
        {
            return Convert.ToSingle(TitleData[type, 3]);
        }
        public static string GetTitleName(int type, int MorF)
        {
            int morf = 1;
            if (MorF == 1)
                morf = 2;
            return (string)TitleData[type, morf];
        }
        public static string GetLastName()
        {
            return LastNames[rndm.Next() % LastNames.Count()]; 
        }
        public static string GetTownName(string basename, int type)
        {
            switch (type)
            {
                case 0:
                    return "The Town of " + basename;
                    break;
                case 1:
                    return "The Village of " + basename;
                    break;
                case 2:
                    return "The City of " + basename;
                    break;
                case 3:
                    return "Barony of " + basename;
                    break;
                case 4:
                    return "Fort " + basename;
            }
            return "Townname";
        }
        public static string GetProvinceName(string basename, int type)
        {
            switch (type)
            {
                case 1:
                    return "State of " + basename;
                case 2:
                    return "Duchy of " + basename;
            }
            //default
            return basename;
        }
        public static string GetNationName(string basename, int type)
        {
            switch (type)
            {
                case 0:
                    return "The Kingdom of " + basename;
                    break;
                case 1:
                    return "The adjective " + basename;
                    break;
                case 3:
                    return "The " + basename + " Republic";
                    break;
                case 4:
                    return "The Principality of " + basename;
                    break;
                case 5:
                    return "The " + basename + " Confederacy";
                    break;
                case 6:
                    return "The State of " + basename;
                    break;
                case 7:
                    return "The Sultanate of " + basename;
                    break;
                case 8:
                    return "The Commonwealth of " + basename;
                    break;
            }
            return basename;
        }
        public static string GenerateProvinceName()
        {
            string fullname = "";
            string forname = "";
            int one = rndm.Next() % 10;
            if (one == 1)
            {
                //use first names
                int gen = rndm.Next() % 2;
                forname = GetFirstName(gen);
            }
            else
            {
                //use extra town names
                int nameNo = rndm.Next() % TownNB.Length;
                forname = TownNB[nameNo];
            }
            int LastNameNo = rndm.Next() % ProvinceNE.Length;
            fullname = forname + ProvinceNE[LastNameNo];
            return fullname;
        }
        public static string GenerateTownName()
        {
            string fullname = "";
            string forname = "";
            int one = rndm.Next() % 10;
            if (one == 1)
            {
                //use first names
                int gen = rndm.Next() % 2;
                forname = GetFirstName(gen);
            }
            else
            {
                //use extra town names
                int nameNo = rndm.Next() % TownNB.Length;
                forname = TownNB[nameNo];
            }
            int LastNameNo = rndm.Next() % TownNE.Length;
            fullname = forname + TownNE[LastNameNo];
            return fullname;
        }
    }
}
