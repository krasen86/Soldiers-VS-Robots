using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataIOStream
{
        private static string filePath = "Save.json";
        private static PlayerController playerController;

        private static void InitializePlayerContoller()
        {
                playerController = new PlayerController{playersList = new List<Player>()};
        }

        public static PlayerController GetPlayerController()
        {
                if (playerController == null)
                {
                        InitializePlayerContoller();
                }
                return playerController;
        }

        public static void AddPlayer(string playerName, int playerScore)
        {
                if (playerController == null)
                {
                        InitializePlayerContoller();
                }
                int index = playerController.playersList.FindIndex(item => item.name == playerName);
                if (index >= 0) 
                {
                        Player player = playerController.playersList[index];
                        if(player.score < playerScore)
                        {
                                player.score = playerScore;
                        }
                }
                else
                {
                        Player player = new Player { name = playerName, score = playerScore };

                        playerController.playersList.Add(player);
                }
        }

        public static void LoadPlayers()
        {
                playerController = JsonUtility.FromJson<PlayerController>(LoadJSONString());

        }

        private static string LoadJSONString()
        {
                string path = Application.persistentDataPath + Path.DirectorySeparatorChar + filePath;
                if (!File.Exists(path))
                {
                        return null;
                }
                StreamReader reader = new StreamReader(path);
      
                string response = "";
                while (!reader.EndOfStream)
                {
                        response += reader.ReadLine();
                }

                return response;
        }

        public static void SavePlayers()
        {
                string json = JsonUtility.ToJson(playerController);
                SaveJSONString(json);
        }

        private static void SaveJSONString( string json)
        {
                string path = Application.persistentDataPath +  Path.DirectorySeparatorChar +filePath;
                FileStream stream = File.Create(path);
                byte[] bytesFile = new UTF8Encoding(true).GetBytes(json);
                stream.Write(bytesFile, 0,bytesFile.Length);
                stream.Close();
        }

}
