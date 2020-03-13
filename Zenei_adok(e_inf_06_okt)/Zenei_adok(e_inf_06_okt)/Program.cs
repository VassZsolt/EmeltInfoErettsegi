using System;
using System.Collections.Generic;
using System.IO;

namespace Zenei_adok_e_inf_06_okt_
{
    struct Music
    {
        public int channel, min, sec;
        public string title;
        public Music(string s)
        {
            string[] split = s.Split(' ');
            channel = int.Parse(split[0]);
            min = int.Parse(split[1]);
            sec = int.Parse(split[2]);
            title = split[3];
            string title2;
            if (!title.Contains(":"))
            {
                title2 = split[4];
                title = title + " " + title2;
            }
           
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            #region _1.feladat

            List<Music> List = new List<Music>();
            StreamReader Input = new StreamReader("musor.txt");
            int index = 0;
            while (!Input.EndOfStream)
            {
                if (index == 0) Input.ReadLine();
                index++;
                List.Add(new Music(Input.ReadLine()));
            }
            #endregion
            #region _2.feladat
            int[] Adott_adon_jatszott_zenemennyiseg = new int[3];
            foreach (Music line in List)
            {
                if (line.channel == 1) Adott_adon_jatszott_zenemennyiseg[0] += 1;
                if (line.channel == 2) Adott_adon_jatszott_zenemennyiseg[1] += 1;
                if (line.channel == 3) Adott_adon_jatszott_zenemennyiseg[2] += 1;
            }
            Console.WriteLine("2. feladat:");
            Console.WriteLine("Az 1. csatornán ennyi zene szólt: " + Adott_adon_jatszott_zenemennyiseg[0]);
            Console.WriteLine("Az 2. csatornán ennyi zene szólt: " + Adott_adon_jatszott_zenemennyiseg[1]);
            Console.WriteLine("Az 3. csatornán ennyi zene szólt: " + Adott_adon_jatszott_zenemennyiseg[2]);
            #endregion
            #region _3.feladat
            int F_min = 0, F_sec = 0, F_hour = 0; //  'F' as First
            int L_min = 0, L_sec = 0, L_hour = 0; // 'L' as Last
            int F_start = 0, L_end = 0;
            foreach (Music line in List)
            {
                if (line.channel == 1)
                {
                    F_min += line.min;
                    F_sec += line.sec;
                }
                if (F_start == 0 && line.title.Contains("Eric") && line.channel == 1) F_start = F_min * 60 + F_sec; // Get first time in sec..
                if (line.title.Contains("Eric") && line.channel == 1)
                {
                    L_end = F_min * 60 + F_sec;    // Get last time in sec..                
                }

            }
            Console.WriteLine(F_min);

            F_hour = F_start / 3600;
            F_min = (F_start - (F_hour * 3600)) / 60;
            F_sec = F_start - ((F_hour * 3600) + (F_min * 60));
            L_hour = L_end / 3600;
            L_min = (L_end - (L_hour * 3600)) / 60;
            L_sec = L_end - ((L_hour * 3600) + (L_min * 60));
            Console.WriteLine("3. feladat:");
            int W_min= L_min - F_min; // 'W' as Write
            int W_sec=L_sec-F_sec;
            if (L_sec - F_sec < 0)
            {
                W_min--;
                W_sec = 60 - Math.Abs(W_sec);
            }
            Console.WriteLine("Az 1. adó-n először és utoljára bejátszott Eric Clapton szám között pontosan {0}:{1}:{2} telt el.", L_hour - F_hour,W_min, W_sec);
            #endregion
            #region _4.feladat
            string zene1 ="", zene2=""; index = 0;
            for(int i=0;i<List.Count;i++)
            {
                if (List[i].title.Contains("Omega:Legenda"))
                {
                    
                    index = i;               
                }
                if (List[i].channel == 1 && i > index && index==0) zene1 = List[i].title;
                if (List[i].channel == 2 && i > index && index==0) zene2 = List[i].title;
            }
            Console.WriteLine("4. feladat:");
            Console.WriteLine("Az Omega: Legenda a " + List[index].channel + " csatornán volt hallható.");
            Console.WriteLine("Az 1. csatornán " + zene1 + "a 2. csatornán " + zene2 + " szólt egyidejűleg az Omega-Legenda c. számmal.");
            #endregion
            #region _5.feladat
            Console.WriteLine("5. feladat:");
            Console.WriteLine("Kérem adja meg a felismerhető betűket: (pl gaoaf)");
            string SomeLetter = Console.ReadLine();
            StreamWriter Write = new StreamWriter("keres.txt");
            Write.Write(SomeLetter);
            for (int i = 0; i < List.Count; i++)
            {
                index = 0;
                for (int j = 0; j < SomeLetter.Length; j++)
                {
                    
                    if (List[i].title.Contains(SomeLetter[j])) index++;
                    if (index == SomeLetter.Length) Write.WriteLine(List[i].title);
                }
            }
            Write.Close();
            #endregion
            #region _6.feladat
            F_min = 1;
            F_sec = 0;
            F_hour=0;
            foreach (Music line in List)
            {
                if (line.channel == 1)
                {
                    F_min += line.min + 1;
                    F_sec += line.sec;
                }
            }
            F_start = F_min * 60 + F_sec; // Get the new time-intervall in sec..
            Console.WriteLine(F_start);
            F_hour = F_start / 3600;
            F_start += (F_hour * 3)*60; //+3 minuten/hour
            F_hour = F_start / 3600;
            F_min = (F_start - (F_hour * 3600)) / 60; 
            F_sec = F_start - ((F_hour * 3600) + (F_min * 60));                        
            if (F_sec < 0)
            {
                F_sec = Math.Abs(F_sec);   
            }
            Console.WriteLine("6. feladat:");
            Console.WriteLine("Az adás vége az új időbeosztással: " + F_hour + ":" + F_min + ":" + F_sec);
            #endregion
            Console.ReadKey();
        }
    }
}