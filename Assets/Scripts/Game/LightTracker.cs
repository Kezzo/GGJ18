using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTracker : MonoBehaviour
{
	private readonly List<LightUpBlock> m_transmitters = new List<LightUpBlock>();
    public List<LightUpBlock> Transmitters { get { return m_transmitters; } }

    [Header("Starting transmitter")]
	[SerializeField] GameObject startTransmitter;
	[SerializeField] Text scoreCounter;
	[SerializeField] Text lightCounter;

	[Header("Start delay")]
	[SerializeField] float waitTime;
	private LightUpBlock m_lightUpBlock;
	private float lightvalue;
	private float lightcount;
	public bool isChecking;

	private GameController gc;

    public static LightTracker Instance { get; private set; }

	void Awake()
	{
	    Instance = this;

		gc = gameObject.GetComponent<GameController>();
		lightCounter.text = ""+lightcount.ToString("000");
	}


    void Update(){
		if(isChecking){ 
			CheckLights();
		}
	}

	void CheckLights(){
		lightcount = 0;
		foreach(LightUpBlock transmitter in m_transmitters)
        {
			m_lightUpBlock = transmitter;
			lightCounter.text = ""+lightcount.ToString("000");
			if(m_lightUpBlock.blockActive()){
				lightcount++;
			}
		}
		if(lightcount == 0){
			gc.GameOver = true;
		}
	}

	public void FirstLight()
    {
		startTransmitter.GetComponent<LightUpBlock>().Activate();
    }

	public IEnumerator StartChecking(){
		yield return new WaitForSeconds(0.5f);
		isChecking = true;
	}
}
