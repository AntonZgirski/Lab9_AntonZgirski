using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
  [Serializable]
  public class Squad
  {
    public string NameSquad { get; set; }
    public string CountSquad { get; set; }
    public string PlaceSquad { get; set; }
    public Squad()
    {
    }
    public Squad(string name, string count, string place)
    {
      this.NameSquad = name;
      this.CountSquad = count;
      this.PlaceSquad = place;
    }
  }

  public class ParsJSon
  {
    public Squad Pars(string pars)
    {      
      pars = pars.Trim('{', '}');

      string[] one = pars.Split(',', ':');

      StringBuilder str = new StringBuilder();

      for (int i = 0; i < one.Length; i++)
      {
        if (i % 2 != 0)
        {
          str.Append(one[i].Trim('"'));
          if (i != one.Length - 1) str.Append(",");
        }
      }

      string finish = str.ToString();
      string[] fin = finish.Split(',');

      return new Squad(fin[0],fin[1],fin[2]);
    }
  }
}
