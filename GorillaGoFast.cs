using BepInEx;
using UnityEngine;
using Utilla;

namespace GorillaGoFast
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.kongo.gorillatag.gorillagofast", "GorillaGoFast", "1.0.0")]
    public class GorillaGoFast : BaseUnityPlugin
    {
        bool inRoom;
        void OnEnable()
        {
            if (!inRoom)
                return;
            {
                Time.timeScale = 1.5f;
                Physics.gravity = new Vector3(0f, -6.54f, 0f);
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
                GorillaLocomotion.Player.Instance.jumpMultiplier = 1.3f;
            }
        }

        void OnDisable()
        {
            Time.timeScale = 1f;
            Physics.gravity = new Vector3(0f, -9.81f, 0f);
            GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
            GorillaLocomotion.Player.Instance.jumpMultiplier = 1.1f;
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
            OnDisable();
        }
    }
}