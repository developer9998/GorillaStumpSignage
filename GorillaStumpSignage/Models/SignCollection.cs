using UnityEngine;

namespace GorillaStumpSignage.Models
{
    [CreateAssetMenu(fileName = "SignCollection", menuName = "StumpSignage/SignCollection")]
    public class SignCollection : ScriptableObject
    {
        public SignProperties[] Collection = [];

#if PLUGIN
        public GameObject SignageParent;
#endif
    }
}
