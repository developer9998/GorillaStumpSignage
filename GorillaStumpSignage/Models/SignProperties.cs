using UnityEngine;

#if PLUGIN
using GorillaStumpSignage.Behaviours;
#endif

namespace GorillaStumpSignage.Models
{
    [CreateAssetMenu(fileName = "SignProperties", menuName = "StumpSignage/SignProperties")]
    public class SignProperties : ScriptableObject
    {
        [Tooltip("What the sign is referred to, with the asset name being more fitting of an identifer")]
        public string DisplayName;

        [Tooltip("Asset/object of the sign")]
        public GameObject Asset;

        [Tooltip("Type name of the script/component added to the sign to give it functionality")]
        public string ScriptName;

        [Tooltip("Coordinates for where the sign should be positioned in stump")]
        public Vector3 Position, Rotation, Scale;

#if PLUGIN
        public void Initialize(SignCollection signage)
        {
            var asset = Instantiate(Asset);
            asset.transform.SetParent(signage.SignageParent.transform);
            asset.transform.position = Position;
            asset.transform.eulerAngles = Rotation;
            asset.name = DisplayName;

            if (!string.IsNullOrEmpty(ScriptName) && !string.IsNullOrWhiteSpace(ScriptName))
            {
                string type = $"GorillaStumpSignage.Signs.{ScriptName}";
                asset.AddComponent(typeof(Main).Assembly.GetType(type));
            }
        }
#endif
    }
}
