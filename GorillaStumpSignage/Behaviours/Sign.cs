using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GorillaStumpSignage.Behaviours
{
    public abstract class Sign : MonoBehaviour
    {
        public MeshRenderer Background;
        public Transform Canvas;

        public void Awake()
        {
            Background = transform.Find("Sign/Background").GetComponent<MeshRenderer>();
            Canvas = transform.Find("Sign/Canvas");

            Initialize();
        }

        public abstract void Initialize();
    }
}
