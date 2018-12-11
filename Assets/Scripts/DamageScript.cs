using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {
	
	public Transform player;
	public Vector3 spawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          GameManager gameManager = FindObjectOfType<GameManager>();
          gameManager.RemoveHearts(1);
          if (gameManager.GetHearts() == 0) {
            gameManager.RemoveOneUp();
            if (gameManager.GetOneUp() == 0) {
              CloseGame();
            }
            gameManager.AddHearts(3);
            player.position = spawn;
          }
            gameManager.ShowDialog("hahahaha! I am Foxtail and you are a stupid tiger for trying to come out in my jungle!");
        }
    }
	
	private void CloseGame() {
		#if UNITY_EDITOR
			// Application.Quit() does not work in the editor
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
