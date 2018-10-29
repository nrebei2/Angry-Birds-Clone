using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlingShot : MonoBehaviour
{
   public LineRenderer[] HandlesLineRenderers;
   public Transform[] HandleAnchorTrnsforms;
    [SerializeField]
   private GameObject DragHandle;
   public GameObject ProjectilePrefab;
   public float StartPower = 0;
   public GameObject Ball1;
   public GameObject Ball2;
   public GameObject Ball3;
   private float[] LineLengths;

   private void Start()
   {
        DragHandle = Ball1;
        LineLengths = new float[2];

      for (var i = 0; i < HandlesLineRenderers.Length; i++)
      {
         HandlesLineRenderers[i].SetPosition(0, HandleAnchorTrnsforms[i].position);
         HandlesLineRenderers[i].SetPosition(1, DragHandle.transform.position);
         HandlesLineRenderers[i].startWidth = 0.15f;
         HandlesLineRenderers[i].endWidth = 0.05f;
      }
   }



   private void Update()
   {
        StartCoroutine(UpdateLines());
     
   }

    IEnumerator UpdateLines()
   {
      if (Ball1.GetComponent<Ball>().released == true)
        {
            //for (var i = 0; i < HandlesLineRenderers.Length; i++)
            //Destroy(HandlesLineRenderers[i]);

            yield return new WaitForSeconds(1f);
            DragHandle = GameObject.Find("Ball (1)");
            //return;
        }  

      if (Ball2.GetComponent<Ball>().released == true)
        {
            yield return new WaitForSeconds(1f);
            DragHandle = GameObject.Find("Ball (2)");
        }

       if (Ball3.GetComponent<Ball>().released == true)
        {
            yield return new WaitForSeconds(20f);
           // DragHandle = GameObject.Find("Ball (3)");
        }

        for (var i = 0; i < HandlesLineRenderers.Length; i++)
      {
         HandlesLineRenderers[i].SetPosition(1, DragHandle.transform.position);
         HandlesLineRenderers[i].SetPosition(0, HandleAnchorTrnsforms[i].position);

         HandlesLineRenderers[i].GetComponent<LineRenderer>().startWidth = 0.15f / LineLengths[i];
         HandlesLineRenderers[i].GetComponent<LineRenderer>().endWidth = 0.05f / LineLengths[i];

         LineLengths[i] = Vector3.Distance(DragHandle.transform.position, HandleAnchorTrnsforms[i].position);

         if (LineLengths[i] <= 0.65f)
         {
            LineLengths[i] = 0.65f;
         }
      }

   }


}