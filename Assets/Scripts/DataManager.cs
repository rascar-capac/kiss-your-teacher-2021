using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    public List<Action> Actions => actions;
    public List<Task> Tasks => tasks;
    public static DataManager Instance => instance;

    [SerializeField] private TextAsset actionsData = null;
    [SerializeField] private TextAsset tasksData = null;
    private List<Action> actions;
    private List<Task> tasks;
    private static DataManager instance;



    // public bool TryGetPlowerByIdOrName(string id, out Plower plower)
    // {
    //     plower = plowers.Find(x => x.Id == id || x.Name == id);
    //     return plower != null;
    // }

    // public void UnlockPlower(string plowerName)
    // {
    //     if (!TryGetPlowerByIdOrName(plowerName, out Plower plower)) return;

    //     UnlockPlower(plower);
    // }

    // public void UnlockPlower(Plower plower)
    // {
    //     if (plower.IsUnlocked) return;

    //     plower.IsUnlocked = true;
    //     AddNewlyUnlockedItem(plower);
    //     Notification notification = new Notification(plower.Name + "débloqué", new UIEncyclopediaWindowProperties(0, new UIEncyclopediaToolsTabProperties(plower)));
    //     notificationsManager.AddEntry(notification);
    // }



    private void Awake()
    {
        instance = this;

        actions = new List<Action>();
        if (actionsData)
        {
            foreach (var rawEntry in CSVReader.FetchData(actionsData))
            {
                rawEntry.TryGetValue("type", out string type);
                int value = GetIntValue("value", rawEntry);
                rawEntry.TryGetValue("color", out string color);

                Action action = new Action(
                    type,
                    value,
                    color
                );
                actions.Add(action);
            }
        }

        tasks = new List<Task>();
        if (tasksData)
        {
            foreach (var rawEntry in CSVReader.FetchData(tasksData))
            {
                rawEntry.TryGetValue("type", out string type);
                int value = GetIntValue("value", rawEntry);
                rawEntry.TryGetValue("color", out string color);
                int gain = GetIntValue("gain", rawEntry);

                Task task = new Task(
                    type,
                    value,
                    color,
                    gain
                );
                tasks.Add(task);
            }
        }
    }

    private float GetFloatValue(string key, Dictionary<string, string> entry)
    {
        System.Globalization.NumberStyles numberStyle = System.Globalization.NumberStyles.AllowDecimalPoint;
        System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.InvariantCulture;

        float value = -1f;
        if (entry.TryGetValue(key, out string result))
        {
            if (result != "")
            {
                System.Single.TryParse(result, numberStyle, cultureInfo, out value);
            }
        }
        return value;
    }

    private int GetIntValue(string key, Dictionary<string, string> entry)
    {
        int value = -1;
        if (entry.TryGetValue(key, out string result))
        {
            if (result != "")
            {
                int.TryParse(result, out value);
            }
        }
        return value;
    }

    private bool GetBoolValue(string key, Dictionary<string, string> entry)
    {
        bool value = false;
        if (entry.TryGetValue(key, out string result))
        {
            bool.TryParse(result, out value);
        }
        return value;
    }

    private float[] GetMinMaxFloatValue(string minKey, string maxKey, Dictionary<string, string> entry)
    {
        System.Globalization.NumberStyles numberStyle = System.Globalization.NumberStyles.AllowDecimalPoint;
        System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.InvariantCulture;

        float[] values = new float[2];
        if (entry.TryGetValue(minKey, out string result))
        {
            System.Single.TryParse(result, numberStyle, cultureInfo, out values[0]);
        }
        if (entry.TryGetValue(maxKey, out result))
        {
            System.Single.TryParse(result, numberStyle, cultureInfo, out values[1]);
        }
        return values;
    }

    private int[] GetIntArray(string key, Dictionary<string, string> entry)
    {
        int[] values = null;
        if (entry.TryGetValue(key, out string result))
        {
            string[] rawValues = result.Split(',');
            values = new int[rawValues.Length];

            for (int i = 0 ; i < rawValues.Length ; i++)
            {
                int.TryParse(rawValues[i], out values[i]);
            }
        }
        return values;
    }

    private string GetTexId(string id)
    {
        string texId = id.Substring(0, 1).ToUpper();
        for (int i = 1 ; i < id.Length ; i++)
        {
            if (id[i] == '_' && i < id.Length - 1)
            {
                texId += id[++i].ToString().ToUpper();
            }
            else
            {
                texId += id[i];
            }
        }
        return texId;
    }
}
