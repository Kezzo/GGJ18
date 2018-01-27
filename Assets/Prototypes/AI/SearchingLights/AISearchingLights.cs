using System.Collections;

public class AISearchingLights : AIAgent 
{
    IEnumerator Start ()
    {
        var state = new AIStates.NextLightState(
            this,
            agent,
            aIManager
        );

        StartCoroutine(state.Enter());

        yield break;
    }
}
