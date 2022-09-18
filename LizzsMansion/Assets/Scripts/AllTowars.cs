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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CheckCombination(GameObject currentTowar, GameObject element)
    {
        switch (currentTowar.GetType().Name)
        {
            case "ET":
                switch (element.GetType().Name)
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
            case "EET":
                switch (element.GetType().Name)
                {
                    case "ET":
                        return eeet;
                    default:
                        return null;
                }
            case "WT":
                switch (element.GetType().Name)
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
                switch (element.GetType().Name)
                {
                    case "WT":
                        return wwwt;
                    default:
                        return null;
                }
            case "FT":
                switch (element.GetType().Name)
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
                switch (element.GetType().Name)
                {
                    case "FT":
                        return ffft;
                    default:
                        return null;
                }
            case "AT":
                switch (element.GetType().Name)
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
                switch (element.GetType().Name)
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
}
