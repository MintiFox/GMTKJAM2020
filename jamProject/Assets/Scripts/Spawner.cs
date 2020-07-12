using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] objects;
    public Vector3 offset = new Vector2(0.0F, -2.0F);

    [Header("Spawn Block")]
    public float blockTime;
    public float blockRange;

    [Header("Velocity Settings/Horizontal")]
    public AnimationCurve minHorizontalVelocity;
    public AnimationCurve maxHorizontalVelocity;
    public bool flipHorizontal;

    [Header("Velocity Settings/Vertical")]
    public AnimationCurve minVerticalVelocity;
    public AnimationCurve maxVerticalVelocity;
    public bool flipVertical;

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
            UnityEngine.Debug.DrawRay(transform.TransformPoint(new Vector2(rf.start - 0.5F, 0.0F)), transform.right * blockRange, Color.red, rf.length);
        }
    }

    public IEnumerator Spawn(float testDifficulty)
    {
        // GET RANGE SIZE
        float possibleRange = getRangeSize();

        // GET POSSIBLE RANGES
        if (possibleRange > 0.0F)
        {
            float nextPositionInRange = UnityEngine.Random.Range(0.0F, possibleRange);
            
            // INSTANTIATE
            if (getPosition(nextPositionInRange, getPossibleRanges(), out float position, out RangeFloat range))
            {
                GameObject obj = objects[UnityEngine.Random.Range(0, objects.Length)];
                GameObject iobj = Instantiate(obj, transform.TransformPoint(offset + new Vector3(position - 0.5F, 0.0F)) * Vector2.one, obj.transform.rotation);

                ApplyVelocity(iobj);
                
                blocked.Add(range);
                yield return new WaitForSeconds(blockTime);
                blocked.Remove(range);
            }        
        }
        
    }

    private float getRangeSize()
    {
        float possibleRange = 1.0F;
        foreach (RangeFloat rf in blocked)
        {
            possibleRange -= rf.length;
        }
        return possibleRange;
    }

    private List<RangeFloat> getPossibleRanges()
    {
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
        return ranges;
    }

    private bool getPosition(float where, List<RangeFloat> possible, out float position, out RangeFloat range)
    {
        float localBlockRange = blockRange / transform.localScale.x;
        foreach (RangeFloat rf in possible)
        {
            if (where <= rf.length)
            {
                position = rf.start + where;
                range = new RangeFloat(position - (localBlockRange / 2.0F), localBlockRange);
                range = new RangeFloat(position - (localBlockRange / 2.0F), localBlockRange);
                return true;
            }
        }
        position = 0;
        range = RangeFloat.zero;
        return false;
    }

    [Serializable]
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

        public float RandomFloat()
        {
            return UnityEngine.Random.Range(clean.start, clean.end);
        }
    }

    public void ApplyVelocity(GameObject obj, float testDifficulty)
    {
        SetVelocity sv = obj.GetComponent<SetVelocity>();
        float currentTime = testDifficulty == 0 ? Time.time : testDifficulty;
        Vector2 hVelocity = UnityEngine.Random.Range(minHorizontalVelocity.Evaluate(currentTime), maxHorizontalVelocity.Evaluate(currentTime)) * (flipHorizontal ? -1.0F : 1.0F) * transform.right;
        Vector2 vVelocity = UnityEngine.Random.Range(minVerticalVelocity.Evaluate(currentTime), maxVerticalVelocity.Evaluate(currentTime)) * (flipVertical ? -1.0F : 1.0F) * transform.up;
        Vector3 velocity = hVelocity + vVelocity;
        if (sv != null)
        {
            sv.initialVelocity = velocity;
        }

        if (obj.GetComponent<SetRotation>() != null)
        {
            Vector2 dir = velocity - obj.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            obj.transform.rotation = Quaternion.AngleAxis(angle - 90.0F, Vector3.forward);
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
