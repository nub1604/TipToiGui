using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipToyGui
{
    public static class TTGRegistry
    {
       static readonly RegistryKey reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TipToyGui");

        public static void SetRecentProject(string path)
        {
            List<string> l = GetRecentProjectPath().ToList();

            l.Insert(0, path);
            ClearRecent();

            var d = l.Distinct().ToList();
            for (int i = 0; i < Math.Min(d.Count, 5); i++)
            {
                Write($"recent{i}", d[i]);
            }
        }

        public static void ClearRecent()
        {
            foreach (var item in GetRecentProjectKeys())
            {
                Delete(item);
            }
        }

        public static string[] GetRecentProjectPath()
        {
            List<string> l = new List<string>();
            var recent = reg.GetValueNames().Where(x => x.Contains("recent"));
            foreach (var item in recent)
            {
                 l.Add(Read(item));
            }
            return l.ToArray(); 
        }
        public static string[] GetRecentProjectKeys()
        {
            return reg.GetValueNames().Where(x => x.Contains("recent")).ToArray();
        }





        public static void Write(string name, string value)
        {
            reg.SetValue(name, value);
        }
        public static string Read(string name)
        {
            if (reg != null)
            {
                return (string)reg.GetValue(name);
            }
            return null;
        }
        public static void Delete(string key)
        {
            if (reg != null)
            {
                reg.DeleteValue(key);
            }
           
        }
    }
}
