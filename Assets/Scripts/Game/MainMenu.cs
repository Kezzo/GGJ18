using UnityEngine;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
    private GameObject menu;

    [SerializeField]
    private Animator m_animator;

	public VideoPlayer vid;
	private SceneControl scene;


    private bool m_inputActive;

	void Start(){
		menu.SetActive(false);
		vid.GetComponent<VideoPlayer>().Play();
		scene = gameObject.GetComponent<SceneControl>();
		InvokeRepeating("checkOver", .1f,.1f);
	}

	private void checkOver(){
		long playerCurrentFrame = vid.GetComponent<VideoPlayer>().frame;
		long playerFrameCount = System.Convert.ToInt64(vid.GetComponent<VideoPlayer>().frameCount);
		
		if(playerCurrentFrame < playerFrameCount)
		{
			print ("VIDEO IS PLAYING");
		}
		else
		{
			print ("VIDEO IS OVER");
			CancelInvoke("checkOver");
			menu.SetActive(true);
            m_animator.SetTrigger("Show");
		    m_inputActive = true;
		}
	}

    private void Update()
    {
        if (!m_inputActive)
        {
            return;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            m_animator.SetBool("IsRightActive", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            m_animator.SetBool("IsRightActive", false);
        }

        if (Input.GetButton("Fire1"))
        {
            if (!m_animator.GetBool("IsRightActive"))
            {
                PlayGame();
                m_inputActive = false;
            }
            else
            {
                AboutMenu();
            }
        }
    }

	public void PlayGame(){
		StartCoroutine(scene.LoadScene(0.0f, "playerTest"));
	}

	public void AboutMenu(){

	}

	public void ExitGame(){

	}

}
