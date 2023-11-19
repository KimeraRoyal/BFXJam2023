using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    struct sequence
    {
        public GameObject[] sequenceObjs;
        public int score;
    }

    public class GridHolderIThink : MonoBehaviour
    {
       
        public SnapPoint[][] snapPoints;
        private sequence[] sequences;
        public int totalScore;
        public void getSequencePoints()
        {
            TrackQualityChecker tqc = new TrackQualityChecker();
            int i = 0;
            foreach (sequence seq in sequences)
            {
                tqc.sequence[i] = seq.sequenceObjs[i].GetComponent<PatternData>();
                i++;
            }
        }


        public void fillSequencesWithSnapPoints()
        {
            int sequenceNum = 0;
            foreach (SnapPoint[] points in snapPoints)
            {
                int gameObjNum = 0;
                foreach (SnapPoint point in points)
                {
                    if (point.snappedObject.GetComponentInChildren<PatternData>() != null)
                    {
                        sequences[sequenceNum].sequenceObjs[gameObjNum] = point.snappedObject.gameObject;
                    }
                    gameObjNum++;

                }
                sequenceNum++;
            }
        }
    }
}
