using System;
using System.Linq;
using System.Collections.Generic;

public class GetLatestdate
{
    private int[] savedateweight = new int[7];

    private int[] months = new int[7]; //0-6 index
    private int[] days = new int[7]; //0-6 index
    private int[] years = new int[7]; //0-6 index
    private int[] hours = new int[7]; //0-6 index
    private int[] minutes = new int[7]; //0-6 index
    private int[] seconds = new int[7]; //0-6 index

    private int latestyear;
    private int latestmonth;
    private int latestday;
    private int latesthour;
    private int latestmintue;
    private int latestsecond;

    private int latestdatearrayindex;
    private string latestdate;
    public static int amountoffile;

    public static Vector3 toshiposition;
    public static Vector3 neraposition;
    public static Vector3 balderposition;

    public static bool continued;

    public static List<string> datacollection;
    public static List<System.DateTime> datetime;


    // Use this for initialization
    void main()
    {
        //to collect raw date, you can use serilization to deserialize text file object into an array container
        //It is recommended to use 2d array for each row that is going to write in one text value or any kind of datatype

        //the list of datacollection can inheritate to any of class if you want use add method to add date
        //and the formate can also be adjust if needed
        //or use inpute box to let the user define the formate
        //Although excel and many database tools such as hadoop,mango,oracle,and sqlsever has the ability to find the latest date
        //you can still use this function to get latest date in the log file such as XML or Notpade, this would be also useful
        //when you need to find the latest date from the webpage that contains large amount of info.

        //date time conversion if needed
        for (int fx = 0; fx < datetime.Count; fx++)
        {
            datacollection[fx] = datetime[fx].ToString();//the formate can be adjust in the () of .ToString, e.g, "MM/dd/yyyy hh/mm/ss", please note that MM is months and mm is minutes.
        }

        //date collection
        for (int i = 0; i < datacollection.Count; i++)
        {
            string[] date = datacollection[i].Split(' ');
            string[] MDY = date[0].Split('/');
            string[] HMS = date[1].Split(':');


            //date container
            //MM/DD/YYYY

            months[i - 1] = int.Parse(MDY[0]);
            days[i - 1] = int.Parse(MDY[1]);
            years[i - 1] = int.Parse(MDY[2]);

            //HH:MM:SS
            hours[i - 1] = int.Parse(HMS[0]);
            minutes[i - 1] = int.Parse(HMS[1]);
            seconds[i - 1] = int.Parse(HMS[2]);
        }

        //end

        //standard and descision tree filter

        //if the date is not equal to years.max(); then the next node of months would be the end
        // which means months equal to zero
        // and so on for the days, hours, minutes and finally get the seconds
        latestyear = years.Max();
        for (int x = 0; x < datacollection.Count; x++)
        {
            if (years[x] != latestyear)
            {
                months[x] = 0;
            }
        }

        latestmonth = months.Max();
        for (int x = 0; x < datacollection.Count; x++)
        {
            if (months[x] != latestmonth)
            {
                days[x] = 0;
            }
        }

        latestday = days.Max();
        for (int x = 0; x < datacollection.Count; x++)
        {
            if (days[x] != latestday)
            {
                hours[x] = 0;
            }
        }

        latesthour = hours.Max();
        for (int x = 0; x < datacollection.Count; x++)
        {
            if (hours[x] != latesthour)
            {
                minutes[x] = 0;
            }
        }

        latestmintue = minutes.Max();
        for (int x = 0; x < datacollection.Count; x++)
        {
            if (minutes[x] != latestmintue)
            {
                seconds[x] = 0;
            }
        }

        //final node
        latestsecond = seconds.Max();


        //end

        //start going to the final node of datefinding decision tree
        for (int t = 0; t < datacollection.Count; t++)
        {
            if (years[t] == latestyear)
            {
                savedateweight[t] += 1;
            }

            if (months[t] == latestmonth)
            {
                savedateweight[t] += 1;
            }

            if (days[t] == latestday)
            {
                savedateweight[t] += 1;
            }

            if (hours[t] == latesthour)
            {
                savedateweight[t] += 1;
            }

            if (minutes[t] == latestmintue)
            {
                savedateweight[t] += 1;
            }

            if (seconds[t] == latestsecond)
            {
                savedateweight[t] += 1;
            }
        }

        //finally we arrive the node and get the latest datetime
        for (int q = 0; q < datacollection.Count; q++)
        {
            if (savedateweight[q] == savedateweight.Max())
            {
                latestdatearrayindex = q;
                latestdate = datacollection[q];
            }
        }
    }
}
