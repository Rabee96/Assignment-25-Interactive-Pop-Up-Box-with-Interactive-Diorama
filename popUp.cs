using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class popUp : MonoBehaviour
    {
        private Vector3 bookStatus;
        private Vector3 bookClosed = new (-180f,0f,0f);
        private Vector3 bookOpened = Vector3.zero;
        private float percentage = 1;
        public float duration = 3f;
        private float time;
        private Vector3 originalScale;
        // Start is called before the first frame update
        void Start()
        {
            originalScale = transform.localScale;
            transform.localScale = Vector3.zero;
        }
    
        // Update is called once per frame
        void Update()
        {
             if (Input.GetMouseButton(1))
            {
                time = Mathf.Min(time + Time.deltaTime,duration);
                percentage = Mathf.Min(time/duration,1);
                // bookStatus = Vector3.Lerp(bookOpened,bookClosed,Mathf.SmoothStep(0,1,percentage));
                transform.localScale = originalScale * percentage;
            }
            if (Input.GetMouseButton(0))
            {
                time = Mathf.Max(time - Time.deltaTime,0);
                percentage = time/duration;
                transform.localScale = originalScale * percentage;
            }
        }
    }   
}
