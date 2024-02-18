using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using Unity.VisualScripting;

public class UILeaderboardLevel : MonoBehaviour
{
   
    [SerializeField] PoolUILeaderboardEntry poolUILeaderboardEntry;

    List<UILeaderboardEntry> existingEntry = new List<UILeaderboardEntry>();

    void OnEnable(){
        //UserProfile.OnLeaderboardHighscoreUpdated.AddListener(LeaderboardLevelUpdate);
    }
    void OnDisable(){
        //UserProfile.OnLeaderboardHighscoreUpdated.RemoveListener(LeaderboardLevelUpdate);
    }



    void LeaderboardLevelUpdate(List<PlayerLeaderboardEntry> leaderboardEntries){

        if(existingEntry.Count >0 ){

            for(int i = existingEntry.Count; i>= 0; i--){
                poolUILeaderboardEntry.ReturnToObjectPool (existingEntry[i]);
            }

        }

        existingEntry.Clear();

        for(var i=0; i<leaderboardEntries.Count;i++){
            UILeaderboardEntry entry = poolUILeaderboardEntry.GetFromObjectPool();
            entry.SetLeaderboardEntry (leaderboardEntries[i]);
            existingEntry.Add(entry);
        }




    }



}
