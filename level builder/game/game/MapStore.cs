using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace game
{
    class MapStore
    {
        String directory = "maps/";
        String fileName = "alone in the dark";
        String extention = ".map";

        String[] mapList;

        public MapStore() { 
            
        }


        public void loadMapNames() {
            string[] filePaths = Directory.GetFiles(directory, "*" + extention);
            for (int i = 0; i < filePaths.Length; i++) {
                String[] pathSplit = filePaths[i].Split(new char[] {'/', '.'});
                filePaths[i] = pathSplit[1];
            }
            mapList = filePaths;
        }

        public String[] getMapList() {
            if (mapList == null) {
                loadMapNames();
            }
            return mapList;
        }
        /*
        public Map loadMap()
        {
            //Open the file written above and read values from it.
            Stream stream = File.Open(directory + fileName + extention, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            Map map = (Map)bformatter.Deserialize(stream);
            stream.Close();
            return map;
        }
        */
        public Map getMap(String fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(directory + fileName + extention))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                    //Console.Out.WriteLine(line);
                }
            }
            Map map = new Map(sb.ToString());
            return map;
        }
    }
}
