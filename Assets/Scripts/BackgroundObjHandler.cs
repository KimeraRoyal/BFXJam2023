using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    public class BackgroundObjHandler : MonoBehaviour
    {
        public Vector2 offset;
        public Vector2 startPos;
        public GameObject bkgObject;
        private GameObject[] objects = new GameObject[10];
        

        void Start()
        {
            StartCoroutine(objHandler());
        }

        private void Update()
        {
            foreach(GameObject obj in objects)
            {
                obj.transform.position += new Vector3(offset.x, offset.y, 0);   
            }
        }

        IEnumerator objHandler()
        {
            int i = 0;

            while (true)
            {
                if (objects[i] == null)
                {
                    objects[i] = Instantiate(bkgObject, new Vector3(0,0,2), Quaternion.identity);
                    objects[i].transform.position = startPos;
                    objects[i].transform.position += new Vector3(0, Random.value * 5, 0);
                    float ranScale = Random.value + 1 * 2;
                    objects[i].transform.localScale = new Vector3(ranScale, ranScale, 0);
                }

                if (i >= 5) i = 0; else i++;
                yield return new WaitForSeconds(5);
            }
        }
    }
}
