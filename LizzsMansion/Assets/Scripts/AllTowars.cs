using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTowars : MonoBehaviour
{
    public GameObject eet;
    public GameObject eft;
    public GameObject eeet;
    public GameObject ewt;
    public GameObject eat;
    public GameObject wwt;
    public GameObject wwwt;
    public GameObject wat;
    public GameObject wft;
    public GameObject fft;
    public GameObject ffft;
    public GameObject aft; //fat
    public GameObject aat;
    public GameObject aaat;
    public GameObject et;
    public GameObject ft;
    public GameObject at;
    public GameObject wt;

    // Start is called before the first frame update
    void Start()
    {
        AllTowers.eet = eet;
        AllTowers.eft = eft;
        AllTowers.eeet = eeet;
        AllTowers.ewt = ewt;
        AllTowers.eat = eat;
        AllTowers.wwt = wwt;
        AllTowers.wwwt = wwwt;
        AllTowers.wat = wat;
        AllTowers.wft = wft;
        AllTowers.fft = fft;
        AllTowers.ffft = ffft;
        AllTowers.aft = aft;
        AllTowers.aat = aat;
        AllTowers.aaat = aaat;
        AllTowers.et = et;
        AllTowers.ft = ft;
        AllTowers.at = at;
        AllTowers.wt = wt;


        AllTowers.towerDict = new Dictionary<string, GameObject>()
        {
            {"eet", eet }, {"eft", eft }, {"eeet", eeet}, {"ewt", ewt}, {"eat", eat},
            {"wwt", wwt }, {"wwwt", wwwt}, {"wat", wat}, {"wft", wft}, {"fft", fft},
            {"ffft", ffft }, {"aft", aft}, {"aat", aat}, {"aaat", aaat},
            {"et", et }, {"ft", ft}, {"at", at}, {"wt", wt}
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class AllTowers
{
    public static GameObject eet;
    public static GameObject eft;
    public static GameObject eeet;
    public static GameObject ewt;
    public static GameObject eat;
    public static GameObject wwt;
    public static GameObject wwwt;
    public static GameObject wat;
    public static GameObject wft;
    public static GameObject fft;
    public static GameObject ffft;
    public static GameObject aft; //fat
    public static GameObject aat;
    public static GameObject aaat;
    public static GameObject et;
    public static GameObject ft;
    public static GameObject at;
    public static GameObject wt;

    public static Dictionary<string, GameObject> towerDict;

    public static GameObject CheckCombination(GameObject currentTowar, GameObject element)
    {
        string current = currentTowar.name;
        if (current.IndexOf("(C") != -1)
        {
            current = current.Remove(currentTowar.name.IndexOf("(C"));
        }
        string el = element.name;
        if (el.IndexOf("(C") != -1)
        {
            el = el.Remove(currentTowar.name.IndexOf("(C"));
        }
        
        switch (current)
        {
            case "ET":
                switch (el)
                {
                    case "ET":
                        return eet;
                    case "FT":
                        return eft;
                    case "WT":
                        return ewt;
                    case "AT":
                        return eat;
                    default:
                        return null;
                }
                /*Debug.Log("CHECKING " + el + "\t" + CompareString(el, "ET"));
                if (CompareString(el, "ET"))
                {
                    Debug.Log("Found ET");
                    return eet;
                }

                else if (CompareString(el, "FT"))
                    return eft;
                else if (CompareString(el, "WT"))
                    return ewt;
                else if (CompareString(el, "AT"))
                    return eat;
                else
                    return null;*/
            case "EET":
                switch (el)
                {
                    case "ET":
                        return eeet;
                    default:
                        return null;
                }
            case "WT":
                switch (el)
                {
                    case "ET":
                        return ewt;
                    case "FT":
                        return wft;
                    case "WT":
                        return wwt;
                    case "AT":
                        return wat;
                    default:
                        return null;
                }
                break;
            case "WWT":
                switch (el)
                {
                    case "WT":
                        return wwwt;
                    default:
                        return null;
                }
            case "FT":
                switch (el)
                {
                    case "ET":
                        return eft;
                    case "FT":
                        return fft;
                    case "WT":
                        return wft;
                    case "AT":
                        return aft;
                    default:
                        return null;
                }
            case "FFT":
                switch (el)
                {
                    case "FT":
                        return ffft;
                    default:
                        return null;
                }
            case "AT":
                switch (el)
                {
                    case "ET":
                        return eat;
                    case "FT":
                        return aft;
                    case "WT":
                        return wat;
                    case "AT":
                        return aat;
                    default:
                        return null;
                }
            case "AAT":
                switch (el)
                {
                    case "AT":
                        return aaat;
                    default:
                        return null;
                }
            default:
                return null;
        }

    }

    public static bool CompareString(string string1, string string2)
    {
        return string.Equals(string1, string2, System.StringComparison.InvariantCultureIgnoreCase);
    }
}
