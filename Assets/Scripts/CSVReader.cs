using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CSVReader
{
    public static List<Dictionary<string, string>> FetchData(TextAsset file)
    {
        string[] lines = file.text.Split(new string[] {"\r\n"}, System.StringSplitOptions.None);
        string[] headers = lines[0].Split(new string[] {"\t"}, System.StringSplitOptions.None);
        for (int i = 0 ; i < headers.Length ; i++)
        {
            headers[i] = headers[i].Trim('\"');
        }

        List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
        for(int i = 1 ; i < lines.Length ; i++)
        {
            string[] properties = lines[i].Split(new string[] {"\t"}, System.StringSplitOptions.None);
            for (int j = 0 ; j < properties.Length ; j++)
            {
                properties[j] = properties[j].Trim('\"');
            }

            if(properties.Length != headers.Length)
            {
                continue;
            }

            Dictionary<string, string> element = new Dictionary<string, string>();
            for(int j = 0 ; j < properties.Length ; j++)
            {
                element.Add(headers[j], properties[j]);
            }
            data.Add(element);
        }
        return data;
    }
}
