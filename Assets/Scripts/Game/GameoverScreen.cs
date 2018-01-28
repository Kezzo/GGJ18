using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScreen : MonoBehaviour
{

    [SerializeField] GameController gc;

    [SerializeField] Text bestScore;

    [SerializeField] Text endScore;

    [SerializeField] private Transform m_playAgainButton;

    [SerializeField] private Transform m_quitGameButton;

    private bool m_quitGameIsSelected;

    public static GameoverScreen Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        this.m_playAgainButton.localScale = new Vector3(1.25f, 1.25f, 1.5f);
        this.m_quitGameButton.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void Update()
    {
		bestScore.text = ""+PlayerPrefs.GetFloat("highscore", gc.bestScore).ToString("000");
		endScore.text = ""+gc.endScore.ToString("000");

	    if (Input.GetAxis("Vertical") > 0 && m_quitGameIsSelected)
	    {
            this.m_playAgainButton.localScale = new Vector3(1.25f, 1.25f, 1.5f);
            this.m_quitGameButton.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            m_quitGameIsSelected = false;
	    }
        else if (Input.GetAxis("Vertical") < 0 && !m_quitGameIsSelected)
        {
            this.m_quitGameButton.localScale = new Vector3(1.25f, 1.25f, 1.5f);
            this.m_playAgainButton.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            m_quitGameIsSelected = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (m_quitGameIsSelected)
            {
                Exit();
            }
            else
            {
                Restart();
            }
        }
    }

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Exit(){
		Application.Quit();
	}

}
