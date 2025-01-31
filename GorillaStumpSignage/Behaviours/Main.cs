using GorillaStumpSignage.Models;
using GorillaStumpSignage.Tools;
using UnityEngine;

namespace GorillaStumpSignage.Behaviours
{
    internal class Main : MonoBehaviour
    {
        private SignCollection signCollection;

        public async void Awake()
        {
            signCollection = await AssetLoader.LoadAsset<SignCollection>("SignCollection");
            signCollection.SignageParent = gameObject;
            signCollection.Collection.ForEach(sign => sign.Initialize(signCollection));
        }
    }
}
