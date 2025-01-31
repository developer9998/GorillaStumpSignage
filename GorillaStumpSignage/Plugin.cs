using BepInEx;
using GorillaStumpSignage.Behaviours;
using UnityEngine;

namespace GorillaStumpSignage
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            GorillaTagger.OnPlayerSpawned(() => new GameObject(typeof(Main).FullName).AddComponent<Main>());
        }
    }
}
