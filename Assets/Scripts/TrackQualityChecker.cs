using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    public class TrackQualityChecker : MonoBehaviour
    {
        // sequence of all tracks in a line
        public PatternData[] sequence;
        // quality of sequence, just in points I guess
        public int sequenceQuality;



        public int checkSequence()
        {
            PatternData prior = sequence[0];
            foreach (PatternData p in sequence)
            {
                if (p.KeySignature.Scale == prior.KeySignature.Scale)
                    sequenceQuality++;
                else
                    sequenceQuality--;

                if (p.Type == prior.Type)
                    sequenceQuality++;
                else
                    sequenceQuality--;

                prior = p;
            }
            return sequenceQuality;
        }

    }
}
