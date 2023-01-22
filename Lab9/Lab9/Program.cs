using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Text;

namespace Lab9
{
  class Program
  {
    static void Main(string[] args)
    {
      var squad = new Squad("People", "999","World");
      var squadJson = JsonConvert.SerializeObject(squad);
      string pars;
      IFormatter formatter = new BinaryFormatter();
      
      using (Stream stream = new FileStream("Squad.json", FileMode.Create, FileAccess.Write, FileShare.None))
      {
        formatter.Serialize(stream, squadJson);
      }

      using (Stream stream = new FileStream("Squad.json", FileMode.Open, FileAccess.Read, FileShare.None))
      {
        pars = formatter.Deserialize(stream).ToString();
      }

      var squadDis = new Squad(pars);

      using (Stream stream = new FileStream("Squad.bin", FileMode.Create, FileAccess.Write, FileShare.None))
      {
        formatter.Serialize(stream, squadDis);
      }

      XmlSerializer xml = new XmlSerializer(typeof(Squad));
      using (Stream stream = new FileStream("Squad.xml", FileMode.Create))
      {
        xml.Serialize(stream, squadDis);
      }

    }
  }
}
