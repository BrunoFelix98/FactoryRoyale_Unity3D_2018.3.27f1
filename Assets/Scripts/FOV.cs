using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FOV : MonoBehaviour
{
    public GameObject enemy;
    public GameObject canvas;

    private Timer timer;

    public float distance;
    //Calling the player Position , Rotation and Scale
    public Transform player;
    //Calling the Patrol Class
    private Patrol patrol;
    //UnUsed

    public WebRequests webRequests;

    //values recieved form the FactoryUI
    public int factoryID;
    public int attackerID;
    public int victimID;

    public bool Following;

    public bool hasUpdated;
    //Determines the Size of the sphere
    public int viewRadios;
    // the max number the viewAngle can go
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask TargetMask;
    public LayerMask ObstacleMask;
    public List<Transform> VisibleTargets = new List<Transform>();

    public float meshResolution;
    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    void Start()
    {
        //This is used so the line is not always red , since the guards have a collider and the line is drawn from them , it would detect his own collider and return always red
        Physics2D.queriesStartInColliders = false;
        //Calling the game object with the tag player so i can later use it to check if the raycast hits the player 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //When you call a function, it runs to completion before returning.
        //This effectively means that any action taking place in a function must happen within a single frame update
        StartCoroutine("FindTargetsWithDelay", 0.2f);

        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;

        canvas = GameObject.Find("Lose_Canvas");

        timer = FindObjectOfType<Timer>();

        factoryID = GameManager.facID;
        attackerID = GameManager.sabotagerID;
        victimID = GameManager.sabotagedID;
        Debug.Log("Gay ass piece of fucking retarded ass shit" + attackerID + ", " + factoryID + ", " + victimID);
        hasUpdated = false;
    }
    IEnumerator FindTargetsWithDelay(float delay)
    {

        while (true)
        {
            //  Yielding waits until the coroutine has finished execution.
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();

        }
    }
    void FindVisibleTarget()
    {
        Following = false;

        //clears the list
        VisibleTargets.Clear();
        //creates a shpere around the guards with the view radius and every time it touches the Target Mask it adds to the array
        Collider2D[] TargetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadios, TargetMask);

        //for loop to run the array list
        for (int i = 0; i < TargetsInViewRadius.Length; i++)
        {
            //creates a Target that gets the position from the current reading from the array list
            Transform target = TargetsInViewRadius[i].transform;
            //creates a vector to get the direction of the target 
            //.normalized returns the vector with a reading of 1
            Vector3 DirToTarget = (target.position - transform.position).normalized;
            //checks if the target is in the FOV angle
            if (Vector3.Angle(transform.up, DirToTarget) < viewAngle / 2)
            {

                //chekcs the distance from the target
                float DisToTarget = Vector3.Distance(transform.position, target.position);
                //if the raytracer hits the target it adds the target to the list
                if (!Physics2D.Raycast(transform.position, DirToTarget, DisToTarget, ObstacleMask))
                {
                    if (hasUpdated == false)
                    {
                        //Adds targets to a List
                        VisibleTargets.Add(target);
                        if (target.CompareTag("Player"))
                        {
                            Following = true;

                            canvas.transform.GetChild(0).gameObject.SetActive(true);
                            canvas.transform.GetChild(1).gameObject.SetActive(true);
                            canvas.transform.GetChild(2).gameObject.SetActive(true);
                            canvas.transform.GetChild(3).gameObject.SetActive(true);

                            player.GetComponent<PlayerMovement>().speed = 0;

                            timer.currentTime = 0;

                            enemy.GetComponent<Patrol>().speed = 0;

                        
                                webRequests.postLossSabotage(attackerID, factoryID, victimID);
                                hasUpdated = true;
                        
                            Debug.Log("Gay ass piece of fucking retarded ass shit2" + attackerID + ", " + factoryID + ", " + victimID + ", " + hasUpdated);
                        }
                    }
                }
            }       
        }
    }
    void DrawFieldOfView()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);

        float stepAngleSize = viewAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i <= stepCount; i++)
        {

            float angle = -transform.localEulerAngles.z - viewAngle / 2 + stepAngleSize * i;
            ViewCastInfo  newViewCast = viewCast(angle);
            viewPoints.Add(newViewCast.Point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];
        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }
        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }
    ViewCastInfo viewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle , true);
        RaycastHit hit;
        if(Physics.Raycast(transform.position , dir , out hit , viewRadios , ObstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }else
        {
            return new ViewCastInfo(false , transform.position + dir * viewRadios , viewRadios , globalAngle);
        }
    }
    //Draws on the SCENE view 
    void OnDrawGizmos()
    {
        //The color the Gizmos will have
        Gizmos.color = Color.yellow;
        //Draws a transparent Sphere, it takes 2 arguments , center of the sphere and radius
        Gizmos.DrawWireSphere(transform.position, viewRadios);

        //coordinates for the drawLine so it makes a cone 
        Vector3 viewangleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewangleB = DirFromAngle(viewAngle / 2, false);
        //Uses the above methods to create a Cone 
        Gizmos.DrawLine(transform.position, transform.position + (viewangleA * viewRadios));
        Gizmos.DrawLine(transform.position, transform.position + (viewangleB * viewRadios));


        foreach (Transform VisibleTargets in VisibleTargets)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, VisibleTargets.position);
        }

    }

    //Takes an angle and shows its direction 
    //SIN(90-X ) == COS(X)
    //When using angle of and object in unity just swap around sin and cos
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            //Makes the viewAngle cone rotate 
            angleInDegrees -= transform.eulerAngles.z;
        }
        //math stuff for the angles :)
        //This is returning the public vector from above 
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
    private void Awake()
    {
        // calling the class patrol 
        // i use this so i can later use the speed 
        patrol = FindObjectOfType<Patrol>();
    }
    public struct ViewCastInfo
    {
        public bool hit;
        public Vector3 Point ;
        public float dst;
        public float angle;
        public ViewCastInfo(bool _hit , Vector3 _point , float _dst , float _angle)
        {
            hit = _hit;
            Point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
    // Update is called once per frame
    void Update()
    {
        DrawFieldOfView();

        /*
                //Draws a line from the Enemy position , Only visible from the "Scene view"
                RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance);

                //checks if Line hit any collider
                if (hitinfo.collider != null)
                {

                    //if the line hits any collider draws a line from the guards , with the color red .
                    Debug.DrawLine(transform.position, hitinfo.point, Color.red);
                    //checks if the Line hit the GameObject with the TAG:Player

                else
                {
                    // if the line does not hit any collider it draws a line with the color green 
                    Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
                    Following = false;

                }
                */
    }
}