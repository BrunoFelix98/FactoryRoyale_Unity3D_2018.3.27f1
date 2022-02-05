using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCheckPoints : MonoBehaviour
{

    public Vector2 WallSize = new Vector2(1,1);

    private void OnDrawGizmos()
    {
        if (this.transform.childCount < 2 )
            return;

        for(int i = 0; i< this.transform.childCount - 1; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(this.transform.GetChild(i).position , this.transform.GetChild(i + 1).position);
        }
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.GetChild(this.transform.childCount - 1).position , this.transform.GetChild(0).position);
    }
    public void AnglesSizeCheckpointWalls()
    {
        Transform currCheckpoint;
        Transform nextCheckpoint;
        Transform prevCheckpoint;
        int next;
        int prev;
        Quaternion currRotation;
        Quaternion prevRotation;
        for(int  i = 0; i< this.transform.childCount; i++)
        {
            next = idxNextCheckpoint(i);
            prev = idxPrevCheckpoint(i);

            currCheckpoint = this.transform.GetChild(i);
            nextCheckpoint = this.transform.GetChild(next);
            prevCheckpoint = this.transform.GetChild(prev);

            currCheckpoint.localScale = WallSize;

            currCheckpoint.LookAt(nextCheckpoint);
            currRotation = new Quaternion(currCheckpoint.transform.rotation.x, currCheckpoint.transform.rotation.y , currCheckpoint.transform.rotation.z , currCheckpoint.transform.rotation.w);
            currCheckpoint.LookAt(prevCheckpoint);
            prevRotation = new Quaternion(prevCheckpoint.transform.rotation.x, prevCheckpoint.transform.rotation.y, prevCheckpoint.transform.rotation.z, prevCheckpoint.transform.rotation.w);

            currCheckpoint.transform.rotation = Quaternion.Lerp(currRotation, prevRotation , 0.5f);
        }

    }
    private int idxNextCheckpoint(int i)
    {
        if (i < this.transform.childCount - 1)
        {
            return i + 1;
        } else
            return 0;
    }
    private int idxPrevCheckpoint(int i)
    {
        if (i == 0)
        {
            return this.transform.childCount - 1;
        }
        else
            return i - 1;
    }
}
