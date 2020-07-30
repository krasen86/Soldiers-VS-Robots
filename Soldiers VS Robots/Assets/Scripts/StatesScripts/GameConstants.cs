using System.Collections;
using System.Collections.Generic;

public class GameConstants
{
    //Game dificulty constants
    public static float easyDificulty = 0.5f; 
    public static float normalDificulty = 1f;
    public static float hardDificulty = 2f;
    //Game over scene messages
    public const string gameCompletedSuccess = "Mission Completed"; 
    public const string gameCompletedKilled = "Soldier was Killed\n Mission Failed";
    public const string gameCompletedTimeOver = "Time Finished\n Mission Failed";
    //Scene names
    public const string sceneGameOver = "GameEnded";
    public const string scenePrepareGame = "PrepareGame";
    public const string sceneScenarioSelection = "ScenarioSelection";
    public const string sceneMain = "MainMenu";
    public const string sceneScenarioOne = "Scenario1";
    public const string sceneScenarioTwo = "Scenario2";

    //Game tags
    public const string backgroundMusicTag = "BackgroundMusic";
    public const string volume = "Volume";
    public const string bulletTag = "bullet";
    public const string playerTag = "Player";
    public const string enemyGreenTag = "enemyGreen";
    public const string enemyBlueTag = "enemyBlue";
    public const string crystalTag = "Crystal";
    public const string weaponTag = "weapon";
    public const string healthItemTag = "health";
    public const string laserTag = "laser";
    
    //Animation parameters 
    public const string movementAnim = "moving";
    public const string movementPlayerAnim = "running";
    public const string moveXAnim = "moveX";
    public const string moveYAnim = "moveY";
    public const string deadAnim = "dead";
    public const string shootingAnim = "shooting";

    
    //In game UI
    public const string playerScoreText = "Score: ";
    public const string invalidNameMsg = "Invalid Name";
    public const string tableEntry = "Table Entry";
    public const string template = "Template";
    public const float tableRowHeight = 20f;
    public const string fullScreenToggle = "Full Screen toggle";
    public const string playerNameHeader = "Player: ";
    public const string playerScoreHeader = "Score: ";
    public const string playerBulletsHeader = "Bullets: ";
    public const string missionTimeHeader = "Bullets: ";

    //Resolutions
    public const string resolutionLow = "1280x720";
    public const int resolutionLowWidth = 1280;
    public const int resolutionLowHeight = 720;
    public const string resolutionMedium = "1366x768";
    public const int resolutionMediumWidth = 1366;
    public const int resolutionMediumHeight = 768;
    public const string resolutionRegular = "1920x1080";
    public const int resolutionRegularWidth = 1920;
    public const int resolutionRegularHeight = 1080;
    public const string resolutionHigh = "3840x2160";
    public const int resolutionHighWidth = 3840;
    public const int resolutionHighHeight = 2160;
    
    //UI Functionality
    public const float cameraZoomFactor = 5f;
    public const float cameraMovementFactor = 0.2f;
    public const float cameraZoomMin = 1f;
    public const float cameraZoomMax = 6f;
    public const int timeModifier = 10;
    public const int missionTimeLowerLimit = 60;
    
    //Buttons
    public const string mouseScroll = "Mouse ScrollWheel";
    public const string shootButton = "Shoot";
    public const string axisButtonHorizontal = "Horizontal";
    public const string axisButtonVertical = "Vertical";
    
    //Functionality game modifiers
    public const float defaultMisionTime = 300f; //time for completion a mission is 5 min
    public const int startHealth = 100;
    public const int startBulletsHard = 80;
    public const int startBullets = 60;
    public const int crystalPoints = 500;
    public const int endGamePointsModifier = 5;
    public const int weaponExtraBullets = 40;
    public const int healthExtraModifier = 30;
    public const int baseDamage = 10;
    public const int greenHealthDamage = 2; // modifier for green robot since green robot receives more damage than blue robot
    public const float robotFireDelay = 0.75f;
    public const int bossModifier = 2;
    public const float baseDelay = 3f;
    public const float shortDelay = 0.2f;
    public const float deathAnimationDelay = 0.5f;
    



}
