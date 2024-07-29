using System;
using System.Collections.Generic;

public class Area
{
    public int ID { get; set; }
    public string? Description { get; set; }
    public int? ParentID { get; set; }
}

public class Program
{
    public static void Main()
    {
        var areas = new List<Area>
        {
            new Area { ID = 1, Description = "Continent", ParentID = null },
            new Area { ID = 2, Description = "Country", ParentID = 1 },
            new Area { ID = 3, Description = "Province", ParentID = 2 },
            new Area { ID = 4, Description = "City1", ParentID = 3 },
            new Area { ID = 5, Description = "Suburb1", ParentID = 6 },
            new Area { ID = 6, Description = "City2", ParentID = 3 },
            new Area { ID = 7, Description = "Suburb2", ParentID = 6 },
            new Area { ID = 8, Description = "Suburb3", ParentID = 3 },
            new Area { ID = 9, Description = "Suburb4", ParentID = 4 },
            new Area { ID = 10, Description = "House1", ParentID = 7 },
            new Area { ID = 11, Description = "House3", ParentID = 9 },
            new Area { ID = 12, Description = "House4", ParentID = 8 },
            new Area { ID = 13, Description = "House5", ParentID = 8 },
            new Area { ID = 14, Description = "House6", ParentID = 7 }
        };

        PrintHierarchy(areas, null, 0);
    }

    public static void PrintHierarchy(List<Area> areas, int? parentId, int level)
    {
        foreach (var area in areas)
        {
            if (area.ParentID == parentId)
            {
                Console.WriteLine(new string('-', level * 2) + area.Description);
                PrintHierarchy(areas, area.ID, level + 1);
            }
        }
    }
}
