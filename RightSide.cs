using UnityEngine;

namespace Assets.Script
{
    public class RightSide : MonoBehaviour
    {
        private Vector3 bookStatus;
        private Vector3 initialStatus = new (-180f,0f,0f);
        private Vector3 finalStatus = Vector3.zero;
        private float percentage = 1f;

        public float duration = 3f;
        private float time;
        // Start is called before the first frame update
        void Start()
        {
            bookStatus =transform.rotation.eulerAngles;
            Debug.Log(bookStatus);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                time = Mathf.Max(time - Time.deltaTime,0);
                percentage = time/duration;
                bookStatus = Vector3.Lerp(initialStatus,finalStatus,Mathf.SmoothStep(0,1,percentage));
                transform.rotation = Quaternion.Euler(bookStatus);
            }
            if (Input.GetMouseButton(1))
            {
                time = Mathf.Min(time + Time.deltaTime,duration);
                percentage = Mathf.Min(time/duration,1);
                bookStatus = Vector3.Lerp(initialStatus,finalStatus,Mathf.SmoothStep(0,1,percentage));
                transform.rotation = Quaternion.Euler(bookStatus);
            }
        }
    } 
}