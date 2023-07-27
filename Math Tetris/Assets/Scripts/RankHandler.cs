using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RankHandler : MonoBehaviour
{
    // Start is called before the first frame update
    List<RankElement> rankElements = new List<RankElement>();
    [SerializeField] string filename; //Ver se não é melhor mudar para um nome padrão

    public delegate void OnRankListChanged(List <RankElement> list);//Não entendi bem pra que serve isso
    public static event OnRankListChanged onRankListChanged;

    private void Start()
    {
        LoadRanks();
    }
    private void LoadRanks()
    {
        rankElements = FileHandler.ReadFromJSON<RankElement>(filename);


        if(onRankListChanged != null)//Não entendi bem pra que serve isso
        {
            onRankListChanged.Invoke(rankElements);
        }

    }

    public void ClearRank()
    {
        FileHandler.ClearFile(filename);
        rankElements.Clear();
    }
    public void SaveRank()
    {
        FileHandler.SaveToJSON<RankElement>(rankElements,filename);
    }
    public int AddRankIfPossible(RankElement element) 
    {
        int aux = RemoveDuplicates(element);

        if(aux != 0)
        {
            return aux;
        }

        if(string.IsNullOrEmpty(element.playerName) && element.score>0) 
        {
            return -1;
        }

        for(int i = 0; i <= rankElements.Count; i++)
        {
            if(element.score>0 && !string.IsNullOrEmpty(element.playerName))
            {
                if (rankElements.Count < i && element.playerName.Equals(rankElements[i].playerName))
                {
                    Debug.Log("Entrou aqui????");
                    return (i+1);
                }
                
                if ( i >= rankElements.Count || element.score > rankElements[i].score)//Ver se é necessario colocar um >=
                {
                    //add new rank informations
                    rankElements.Insert(i, element);

                    SaveRank();

                    if (onRankListChanged != null)//Não entendi bem pra que serve isso
                    {
                        onRankListChanged.Invoke(rankElements);
                    }

                    return (i+1);
                }
            }
        }
        return 0;
    }

    /*private void RemoveDuplicates(RankElement element)
    {
        for (int i = 0; i < rankElements.Count; i++)
        {
            if (element.playerName.Equals(rankElements[i].playerName) && element.score > rankElements[i].score)
            {
                rankElements.RemoveAt(i);
                break;
            }
        }
    }*/

    private int RemoveDuplicates(RankElement element)
    {
        for (int i = 0; i < rankElements.Count; i++)
        {
            if (element.playerName.Equals(rankElements[i].playerName))
            {
                if (element.score > rankElements[i].score)
                {
                    rankElements.RemoveAt(i);
                    return 0;
                }
                else
                {
                    return (i + 1);
                    //não remove o placar anterior se o novo ficar menor
                }
            }
        }
        return 0;
    }

    }
