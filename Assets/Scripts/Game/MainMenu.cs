using UnityEngine;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
    private GameObject menu;

    [SerializeField] 
    private GameObject about;

    [SerializeField] 
    private GameObject main;

    [SerializeField]
    private Animator m_animator;

	public VideoPlayer vid;
	private SceneControl scene;

    [SerializeField] AudioClip select;
    [SerializeField] AudioClip pick;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicSource;

    private bool m_inputActive;
    private bool m_aboutIsActive;

    private float m_lastAboutSwitch = 0f;

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
            musicSource.Play();
		}
	}

    private void Update()
    {
        if (!m_inputActive)
        {
            return;
        }

        if (!m_aboutIsActive)
        {
            if (Input.GetAxis("Horizontal") > 0 && !m_animator.GetBool("IsRightActive"))
            {
                PlaySound(select);
                m_animator.SetBool("IsRightActive", true);
            }
            else if (Input.GetAxis("Horizontal") < 0 && m_animator.GetBool("IsRightActive"))
            {
                PlaySound(select);
                m_animator.SetBool("IsRightActive", false);
            }
        }

        if (Input.GetButton("Fire1") && (Time.time - m_lastAboutSwitch) >= 1)
        {
            if (m_aboutIsActive)
            {
                Back();
                m_aboutIsActive = false;
                m_lastAboutSwitch = Time.time;
            }
            else
            {
                if (!m_animator.GetBool("IsRightActive"))
                {
                    PlayGame();
                    m_inputActive = false;
                }
                else
                {
                    AboutMenu();
                    m_lastAboutSwitch = Time.time;
                }
            }
        }
    }

	public void PlayGame(){
		StartCoroutine(scene.LoadScene(1.0f, "playerTest"));
        PlaySound(pick);
	}

	public void AboutMenu(){
        PlaySound(pick);
        main.SetActive(false);
        about.SetActive(true);

	    m_aboutIsActive = true;
	}

	public void Back(){
        PlaySound(pick);
        main.SetActive(true);
        about.SetActive(false);
	}

    void PlaySound(AudioClip sound){
        if(!audioSource.isPlaying){
            audioSource.PlayOneShot(sound);
        }
    }

}
