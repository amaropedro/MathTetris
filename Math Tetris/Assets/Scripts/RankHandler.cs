using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RankHandler : MonoBehaviour
{
    // Start is called before the first frame update
    List<RankElement> rankElements = new List<RankElement>();
    [SerializeField] int maxCount = 8;
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

        while (rankElements.Count > maxCount)//Necessario mudar isso posteriormente
        {
            rankElements.RemoveAt(maxCount);
        }
        if(onRankListChanged != null)//Não entendi bem pra que serve isso
        {
            onRankListChanged.Invoke(rankElements);
        }

    }
    private void SaveRank()
    {
        FileHandler.SaveToJSON<RankElement>(rankElements,filename);
    }
    public void AddRankIfPossible(RankElement element) //Ver se aqui é possivel sobrescrever a pontuação de uma pessoa
    {
        for (int i = 0; i < maxCount; i++) 
        {
            if( i >= rankElements.Count || element.score > rankElements[i].score)//Ver se é necessario colocar um >=
            {
                //add new rank informations
                rankElements.Insert(i, element);

                while(rankElements.Count > maxCount)
                {
                    rankElements.RemoveAt(maxCount);
                }

                SaveRank();

                if (onRankListChanged != null)//Não entendi bem pra que serve isso
                {
                    onRankListChanged.Invoke(rankElements);
                }

                break;
            }
        }
    }
}
