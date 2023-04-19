﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat_Secret
{
    internal class Generics
    {

        public static void MySerialize<T>(T nechto, string Filename)
        {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string json = JsonConvert.SerializeObject(nechto);
                File.WriteAllText(desktop + "\\" + Filename, json);
        }
        public static T MyDeserialize<T>(string Filename)
        {
            string desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desctop + "\\" + Filename);
            T nechto = JsonConvert.DeserializeObject<T>(json);
            return nechto;
        }


    }
}
