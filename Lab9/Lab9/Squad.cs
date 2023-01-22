using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
  [Serializable]
  public class Squad
  {
    public string nameSquad { get; set; }
    public string countSquad { get; set; }
    public string placeSquad { get; set; }
    public Squad()
    {
    }
    public Squad(string name, string count, string place)
    {
      this.nameSquad = name;
      this.countSquad = count;
      this.placeSquad = place;
    }

    public Squad(string pars)
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

      this.nameSquad = fin[0];
      this.countSquad = fin[1];
      this.placeSquad = fin[2];
    }
  }
}
