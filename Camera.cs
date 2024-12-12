using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class Camera : MonoBehaviour
    {
        public Transform target;
        private Vector3 initialPosition = new (159.778198f,72.3153915f,-75.25f);
        private Vector3  finalPosition = new(65.6052856f,27.5161285f,-25.1223221f);
        private float percentage = 1f;
        public float duration = 3f;
        private float time;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = initialPosition;
        }

        // Update is called once per frame
        void Update()
        {
            //Vector3(159.778198,72.3153915,-75.25)
            //Vector3(65.6052856,27.5161285,-25.1223221)

            if (Input.GetMouseButton(1))
            {
                time = Mathf.Min(time + Time.deltaTime,duration);
                percentage = time/duration;
                transform.position = Vector3.Lerp(initialPosition,finalPosition,Mathf.SmoothStep(0,1,percentage));
            }
            if (Input.GetMouseButton(0))
            {
                time = Mathf.Max(time - Time.deltaTime,0);
                percentage = time/duration;
                transform.position = Vector3.Lerp(initialPosition,finalPosition,Mathf.SmoothStep(0,1,percentage));
            }
            if (target != null)
                transform.LookAt(target);
        }
    }    
}

