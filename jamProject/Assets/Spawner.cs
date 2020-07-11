using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    public Vector3 offset = new Vector2(0.0F, -2.0F);
    public float blockTime;
    public float blockRange;

    private List<RangeFloat> blocked = new List<RangeFloat>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RangeFloat rf in blocked)
        {
            Debug.DrawRay(transform.TransformPoint(new Vector2(rf.start - 0.5F, 0.0F)), transform.right * blockRange, Color.red, rf.length);
        }
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0F);
        // POSITION
        float possibleRange = 1.0F;
        foreach (RangeFloat rf in blocked)
        {
            possibleRange -= rf.length;
        }

        if (possibleRange > 0.0F)
        {
            float nextPositionInRange = Random.Range(0.0F, possibleRange);
            List<RangeFloat> ranges = new List<RangeFloat>();
            blocked.Sort(new RangeFloatComparer());
            float start = 0.0F;
            if (blocked.Count > 0)
            {
                foreach (RangeFloat rf in blocked)
                {
                    RangeFloat crf = rf.clean;
                    if (start < crf.start)
                    {
                        ranges.Add(new RangeFloat(start, crf.start));
                    }
                    start = crf.end;
                }
                RangeFloat last = blocked[blocked.Count - 1];
                if (last.end < 1.0F)
                {
                    ranges.Add(new RangeFloat(last.end, 1.0F - last.end));
                }
            }
            else
            {
                ranges.Add(new RangeFloat(0.0F, 1.0F));
            }
            float localBlockRange = blockRange / transform.localScale.x;
            float position = 0.0F;
            RangeFloat range = RangeFloat.zero;
            foreach (RangeFloat rf in ranges)
            {
                if (nextPositionInRange <= rf.length)
                {
                    position = rf.start + nextPositionInRange;
                    range.start = position - (localBlockRange / 2.0F);
                    range.length = localBlockRange;

                    break;
                }
            }

            if (!range.Equals(RangeFloat.zero))
            {
                // SPAWN
                GameObject obj = objects[Random.Range(0, objects.Length)];
                Instantiate(obj, transform.TransformPoint(offset + new Vector3(position - 0.5F, 0.0F)) * Vector2.one, obj.transform.rotation);

                blocked.Add(range);
                yield return new WaitForSeconds(blockTime);
                blocked.Remove(range);
            }        
        }
        
    }

    public struct RangeFloat
    {
        public float start, length;
        public float end
        {
            get
            {
                return start + length;
            }

            set
            {
                length = value - start;
            }
        }

        public RangeFloat clean
        {
            get
            {
                return length < 0.0F ? new RangeFloat(end, -length) : this;
            }
        }

        public static RangeFloat zero
        {
            get
            {
                return new RangeFloat(0.0F, 0.0F);
            }
        }

        public RangeFloat(float start, float length)
        {
            this.start = start;
            this.length = length;
        }

        public void Clean()
        {
            if (length < 0.0F)
            {
                start = end;
                length = -length;
            }
        }

        public bool Equals(RangeFloat other)
        {
            return start == other.start && length == other.length;
        }
    }

    public class RangeFloatComparer : IComparer<RangeFloat>
    {
        public int Compare(RangeFloat x, RangeFloat y)
        {
            return x.clean.start.CompareTo(y.clean.start);
        }
    }
}
