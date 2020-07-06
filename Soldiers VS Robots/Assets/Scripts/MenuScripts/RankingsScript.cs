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
			
                playerScores = DataIOStream.GetPlayerController().playersList.OrderByDescending( i => i.score).ToList();
		
				tableEntry = transform.Find("Table Entry");
				template = tableEntry.Find("Template");
				
                float height = 20f;
                for (int i = 1; i < 10; i++)
                {
                        Transform tableRow = Instantiate(template, tableEntry);
						RectTransform rectTransform = tableRow.GetComponent<RectTransform>();
						rectTransform.anchoredPosition = new Vector2(0, -height * i);
						tableRow.GetComponent<PlayerScoreScript>().SetPlayerRank((i+1) +"");
						if(i < playerScores.Count)
						{
                        	tableRow.GetComponent<PlayerScoreScript>().SetPlayerName(playerScores[i].name);
                        	tableRow.GetComponent<PlayerScoreScript>().SetPlayerScore(playerScores[i].score + "");
						}

                }					
				RectTransform templateTransform = template.GetComponent<RectTransform>();
                templateTransform.anchoredPosition = new Vector2(0, -height * 0);
                template.GetComponent<PlayerScoreScript>().SetPlayerRank((1) +"");
				if(playerScores[0] != null)
				{
					template.GetComponent<PlayerScoreScript>().SetPlayerName(playerScores[0].name);
                    template.GetComponent<PlayerScoreScript>().SetPlayerScore(playerScores[0].score + "");
				}
				
        }
		
		private void SortScores()
		{
			DataIOStream.GetPlayerController().playersList.OrderByDescending( i => i.score);
			
		}

        private void Start()
        {

        }

}
