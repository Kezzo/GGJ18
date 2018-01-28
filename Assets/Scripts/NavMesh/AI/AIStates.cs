using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public static class AIStates
{
    public interface State
    {
        IEnumerator Enter();
        void Exit();
    }

    [Serializable]
    public class WanderingState : State
    {
        public Vector3 aroundPosition;
        private float wanderingDirectionChangePeriod;
        private float wanderingDistance;
        private float wanderingSpeed;
        private NavMeshAgent agent;

        public WanderingState(
            Vector3 aroundPosition,
            float wanderingDirectionChangePeriod,
            float wanderingDistance,
            float wanderingSpeed,
            NavMeshAgent agent)
        {
            this.aroundPosition = aroundPosition;
            this.wanderingDirectionChangePeriod = wanderingDirectionChangePeriod;
            this.wanderingDistance = wanderingDistance;
            this.wanderingSpeed = wanderingSpeed;
            this.agent = agent;
        }

        public IEnumerator Enter()
        {
            agent.destination = aroundPosition;

            float lastTime = Time.time;

            while (true)
            {
                // One it reaches the previous destination, search for another randome place wehre to go
                if (Mathf.Abs(Time.time - lastTime) > wanderingDirectionChangePeriod)
                {
                    lastTime = Time.time;

                    var delta = UnityEngine.Random.rotation * Vector3.right * wanderingDistance;

                    agent.speed = wanderingSpeed;
                    agent.destination = aroundPosition + delta;
                }

                yield return null;
            }
        }

        public void Exit()
        {
        }
    }

    [Serializable]
    public class BlockState : State
    {
        public Transform target;
        private float distanceThreadshold;
        private NavMeshAgent agent;

        private float m_lastPushBackTime = 0f;
        private float m_pushBackCooldown = 0.2f;
        private float m_force = 100f;

        public BlockState(
            float distanceThreadshold,
            Transform target,
            NavMeshAgent agent
        )
        {
            this.distanceThreadshold = distanceThreadshold;
            this.target = target;
            this.agent = agent;
        }

        public IEnumerator Enter()
        {
            agent.updateRotation = false;

            var playerAgent = PlayerAgent.instance;

            // Set the animator of the character as blocking
            var animator = agent.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                //animator.SetBool("Blocking", true);
            }

            while (true)
            {
                var distance =
                    (target.transform.position - playerAgent.transform.position).sqrMagnitude;

                // Rotate facing the player
                var relativePos = playerAgent.transform.position - agent.transform.position;
                var rotation = Quaternion.LookRotation(relativePos);
                agent.transform.rotation = rotation;

                // Pushback player
                if ((Time.time - m_lastPushBackTime) >= m_pushBackCooldown)
                {
                    m_lastPushBackTime = Time.time;

                    Rigidbody rigidbody = playerAgent.gameObject.GetComponent<Rigidbody>();

                    if (rigidbody != null)
                    {
                        yield return new WaitForFixedUpdate();
                        rigidbody.drag = 1;
                        rigidbody.AddForce(relativePos.normalized * m_force, ForceMode.Impulse);
                       
                        Debug.Log("Pushback");
                    }
                }

                // Tries to get in between the target and the player
                if (distance < distanceThreadshold * distanceThreadshold)
                {
                    agent.destination = Vector3.Lerp(
                        target.transform.position,
                        playerAgent.transform.position, 0.5f);
                }
                else
                {
                    var direction = playerAgent.transform.position - target.transform.position;

                    agent.destination =
                        target.transform.position + direction.normalized * distanceThreadshold;
                }

                if (animator != null)
                {
                    animator.SetBool("Blocking", distance < distanceThreadshold * distanceThreadshold * 2);
                }

                yield return null;
            }
        }

        public void Exit()
        {
            agent.updateRotation = true;

            // Set the animator of the character as blocking
            var animator = agent.GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.SetBool("Blocking", false);
            }
        }
    }

    public class NextLightState : State
    {
        public MapItem light;
        private AIAgent aiagent;
        private NavMeshAgent agent;
        private AIManager aimanager;

        public NextLightState(
            AIAgent aiagent,
            NavMeshAgent agent,
            AIManager aimanager
        )
        {
            this.aiagent = aiagent;
            this.agent = agent;
            this.aimanager = aimanager;
        }

        public IEnumerator Enter()
        {
            agent.destination = agent.transform.position;

            while (true)
            {
                light = aimanager.AssignMeALight(aiagent);
                if (light != null)
                {
                    agent.destination = light.transform.position;

                    while (agent.destination.XZ() != agent.transform.position.XZ())
                    {
                        yield return null;
                    }
                }

                yield return new WaitForSeconds(.5f);

                aimanager.ReturnALight(aiagent);
            }
        }

        public void Exit()
        {
            aimanager.ReturnALight(aiagent);
        }
    }
}
