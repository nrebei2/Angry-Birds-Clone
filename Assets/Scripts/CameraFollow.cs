using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

    public bool ViewingScene = true;

    public bool ViewingEnemies = false;

    public GameObject[] targets;

    public int targetnumber = 1;

    public int ballnumber = 1;

    public bool IncreaseBallNumber = false;

    private void Start()
    {
        Invoke("StopViewingScene", 3f);
    }

    void FixedUpdate ()
	{
        if (ViewingScene == false)
        {
            Vector3 desiredPosition = targets[targetnumber].transform.position;
            desiredPosition.z = -10;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        if (targetnumber != 0 && ViewingEnemies == false && targets[targetnumber].GetComponent<Ball>().FirstHit == true)
        {
            Invoke("ViewEnemies", 2f);
        }

        if (ViewingEnemies == true)
        {
            Invoke("ViewNextBall", 3f);
        }

	}

    public void ViewNextBall()
    {
        if (IncreaseBallNumber == true)
        {
            targetnumber += ballnumber;
            IncreaseBallNumber = false;
            ViewingEnemies = false;
        }

    }

    public void ViewEnemies ()
    {
        if (IncreaseBallNumber == false)
        {
            targetnumber = 0;
            ViewingEnemies = true;
            ballnumber++;
            IncreaseBallNumber = true;
        }
    }

    public void StopViewingScene()
    {
        ViewingScene = false;
    }

}
