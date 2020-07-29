using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoldierScript : MonoBehaviour
{

	[SerializeField] private float soldierSpeed;
    private Rigidbody2D soldierBody;
	private Vector3 movement;
	private Animator soldierAnimator;
	[SerializeField] private GameObject bulletTemplate;
	private PlayerState playerState;
	private GameState gameState;
	[SerializeField] private Boundary boundary;
	[SerializeField] private AudioSource crystalAudio;
	[SerializeField] private AudioSource healthAudio;
	[SerializeField] private AudioSource bulletsAudio;
	[SerializeField] private AudioSource deathAudio;
	private GameObject item;
	
	
    void Start()
    {
		gameState = GameState.Instance;
	    playerState = PlayerState.Instance;
	    soldierBody = GetComponent<Rigidbody2D>();
        soldierAnimator = GetComponent<Animator>();
    }

    void Update(){

	    if (!playerState.PlayerDead)
	    {
		    if (Input.GetKeyDown(KeyCode.E) && item != null) 
		    {
			    AddItemContent(item);
		    }
            
		    if(Input.GetButtonDown(GameConstants.shootButton) && playerState.PlayerBullets > 0 && playerState.PlayerHealth >= 0 && !PauseScript.Paused)
		    {
			    FireBullet();
			    StartCoroutine(FireCo());
		    }
		    transform.position = new Vector3(Mathf.Clamp(soldierBody.position.x, boundary.xMin, boundary.xMax),
											Mathf.Clamp(soldierBody.position.y, boundary.yMin, boundary.yMax), 
											transform.position.z);
		    if( playerState.PlayerHealth <= 0) 
		    {
			    deathAudio.Play();
			    StartCoroutine(DieCo());
		    }
	    }

	}
    void FixedUpdate()
    {
	    if (!playerState.PlayerDead)
	    {
		    		if( playerState.PlayerHealth >= 0)
            		{
            			movement = Vector3.zero;
                    	movement.x = Input.GetAxisRaw(GameConstants.axisButtonHorizontal);
                    	movement.y = Input.GetAxisRaw(GameConstants.axisButtonVertical);
					
            
            			if(movement != Vector3.zero)
            			{
            				MoveSoldier();		
            				soldierAnimator.SetFloat(GameConstants.moveXAnim, movement.x);            		
            				soldierAnimator.SetFloat(GameConstants.moveYAnim, movement.y);	
            				soldierAnimator.SetBool(GameConstants.movementPlayerAnim, true);		
            			}
            			else
            			{
            				soldierAnimator.SetBool(GameConstants.movementPlayerAnim, false);		
            			}
            		}
	    }

    }

    //Update player parameters depending of the type and value of the picked up object
	private void AddItemContent(GameObject itemObject)
	{
		if(itemObject.tag == GameConstants.crystalTag)
		{
			playerState.PlayerScore =(int) (playerState.PlayerScore + ((GameConstants.endGamePointsModifier * gameState.MissionTime * gameState.GameDifficulty) + GameConstants.crystalPoints));
			crystalAudio.Play();
			Destroy(itemObject);
			GameEndedScript.Completed = true;
		}
		else if(itemObject.tag == GameConstants.weaponTag)
		{
			
			playerState.PlayerBullets += (int) (GameConstants.weaponExtraBullets * gameState.GameDifficulty);
			bulletsAudio.Play();
			Destroy(itemObject);
		}
		else if(itemObject.tag == GameConstants.healthItemTag)
		{
			playerState.PlayerHealth += (int) (GameConstants.healthExtraModifier/gameState.GameDifficulty);

			healthAudio.Play();
			Destroy(itemObject);
		}
	}

	private IEnumerator FireCo()
	{
		soldierAnimator.SetBool(GameConstants.shootingAnim, true);
		yield return null;
		soldierAnimator.SetBool(GameConstants.shootingAnim, false);
		yield return new WaitForSeconds(GameConstants.shortDelay);
	}

	private IEnumerator DieCo()
	{
		playerState.PlayerDead = true;
		soldierAnimator.SetBool(GameConstants.deadAnim, true);
		yield return new WaitForSeconds(GameConstants.shortDelay);
		soldierAnimator.SetBool(GameConstants.deadAnim, false);
	}

	void FireBullet()
	{
		playerState.PlayerBullets -= 1;
		Vector2 direction = new Vector2(soldierAnimator.GetFloat(GameConstants.moveXAnim),soldierAnimator.GetFloat(GameConstants.moveYAnim));
		BulletScript bullet = Instantiate(bulletTemplate, transform.position, Quaternion.identity).GetComponent<BulletScript>();
		bullet.FireBullet(direction, Vector3.zero);
		
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if(collision.gameObject.tag == GameConstants.laserTag )
		{			
			if(gameState.GameDifficulty == GameConstants.normalDificulty)
			{
				playerState.PlayerHealth -= GameConstants.baseDamage;
			}
			else	
			{
				// Balance the game for hard and easy levels so that the player reseives less damage doesn't get killed easaly
				playerState.PlayerHealth -= (int) (GameConstants.baseDamage/GameConstants.hardDificulty); 
			}
		}	
	}

	private void MoveSoldier()
	{
		
		transform.position += movement * soldierSpeed * Time.fixedDeltaTime;

	}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == GameConstants.crystalTag  || collider2D.gameObject.tag == GameConstants.healthItemTag || collider2D.gameObject.tag == GameConstants.weaponTag)
		{
			playerState.ItemInRange = true;
			item = collider2D.gameObject;
		}
        
        
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {

        if(collider2D.gameObject.tag == GameConstants.crystalTag || collider2D.gameObject.tag == GameConstants.healthItemTag || collider2D.gameObject.tag == GameConstants.weaponTag )
		{
			playerState.ItemInRange = false;
			item = null;
		}

        
    }

}
[System.Serializable]
public class Boundary {
		
	public float xMin;
	public float yMin;
	public float yMax;
	public float xMax;

}
