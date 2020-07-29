using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingsScript : MonoBehaviour
{


        private Transform template;
        private Transform tableEntry;

        private List<Player> playerScores;

        private void Awake()
        {		
				//Get the players and sort the list
                playerScores = DataIOStream.GetPlayerController().playersList.OrderByDescending( i => i.score).ToList();
		
				tableEntry = transform.Find(GameConstants.tableEntry);
				template = tableEntry.Find(GameConstants.template);
				
                
                // start from one since the first row is the template, initialize the table for top 10 player scores
                for (int i = 1; i < 10; i++)
                {
                        Transform tableRow = Instantiate(template, tableEntry);
						RectTransform rectTransform = tableRow.GetComponent<RectTransform>();
						rectTransform.anchoredPosition = new Vector2(0, -GameConstants.tableRowHeight * i);
						tableRow.GetComponent<PlayerScoreScript>().SetPlayerRank((i+1) +""); //since row 1 is template we start from i+1
						//initialize row with data from the list
						if(i < playerScores.Count)
						{
                        	tableRow.GetComponent<PlayerScoreScript>().SetPlayerName(playerScores[i].name);
                        	tableRow.GetComponent<PlayerScoreScript>().SetPlayerScore(playerScores[i].score + "");
						}

                }					
				RectTransform templateTransform = template.GetComponent<RectTransform>();
                templateTransform.anchoredPosition = new Vector2(0,0);
                template.GetComponent<PlayerScoreScript>().SetPlayerRank((1) +"");//first row is the template => first element in the list position zero
				if(playerScores.Any())
				{
					template.GetComponent<PlayerScoreScript>().SetPlayerName(playerScores[0].name);
                    template.GetComponent<PlayerScoreScript>().SetPlayerScore(playerScores[0].score + "");
				}
				
        }
        

}
