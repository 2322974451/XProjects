

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace XUtliPoolLib
{
    public class XCommon : XSingleton<XCommon>
    {
        public readonly float FrameStep = 0.03333334f;
        private static readonly float _eps = 0.0001f;
        private System.Random _random = new System.Random(DateTime.Now.Millisecond);
        private int _idx = 0;
        private uint[] _seeds = new uint[4]
        {
      17U,
      33U,
      65U,
      129U
        };
        private int _new_id = 0;
        public StringBuilder shareSB = new StringBuilder();
        public static List<Renderer> tmpRender = new List<Renderer>();
        public static List<ParticleSystem> tmpParticle = new List<ParticleSystem>();
        public static List<SkinnedMeshRenderer> tmpSkinRender = new List<SkinnedMeshRenderer>();
        public static List<MeshRenderer> tmpMeshRender = new List<MeshRenderer>();

        public XCommon() => this._idx = 5;

        public static float XEps => XCommon._eps;

        public int New_id => ++this._new_id;

        public long UniqueToken => DateTime.Now.Ticks + (long)this.New_id;

        public uint XHash(string str)
        {
            if (str == null)
                return 0;
            uint num = 0;
            for (int index = 0; index < str.Length; ++index)
                num = (num << this._idx) + num + (uint)str[index];
            return num;
        }

        public uint XHashLowerRelpaceDot(uint hash, string str)
        {
            if (str == null)
                return hash;
            for (int index = 0; index < str.Length; ++index)
            {
                char ch = char.ToLower(str[index]);
                if (ch == '/' || ch == '\\')
                    ch = '.';
                hash = (hash << this._idx) + hash + (uint)ch;
            }
            return hash;
        }

        public uint XHash(uint hash, string str)
        {
            if (str == null)
                return hash;
            for (int index = 0; index < str.Length; ++index)
            {
                char ch = str[index];
                hash = (hash << this._idx) + hash + (uint)ch;
            }
            return hash;
        }

        public uint XHash(StringBuilder str)
        {
            if (str == null)
                return 0;
            uint num = 0;
            for (int index = 0; index < str.Length; ++index)
                num = (num << this._idx) + num + (uint)str[index];
            return num;
        }

        public bool IsEqual(float a, float b) => (double)a == (double)b;

        public bool IsLess(float a, float b) => (double)a < (double)b;

        public int Range(int value, int min, int max)
        {
            value = Math.Max(value, min);
            return Math.Min(value, max);
        }

        public bool IsGreater(float a, float b) => (double)a > (double)b;

        public bool IsEqualLess(float a, float b) => (double)a <= (double)b;

        public bool IsEqualGreater(float a, float b) => (double)a >= (double)b;

        public uint GetToken() => (uint)DateTime.Now.Millisecond;

        public void ProcessValueDamp(ref float values, float target, ref float factor, float deltaT)
        {
            if (XSingleton<XCommon>.singleton.IsEqual(values, target))
            {
                values = target;
                factor = 0.0f;
            }
            else
                values += (target - values) * Mathf.Min(1f, deltaT * factor);
        }

        public void ProcessValueEvenPace(ref float value, float target, float speed, float deltaT)
        {
            float num1 = target - value;
            float num2 = target - (num1 - speed * deltaT);
            if (XSingleton<XCommon>.singleton.IsGreater((target - num2) * num1, 0.0f))
                value = num2;
            else
                value = target;
        }

        public bool IsRectCycleCross(float rectw, float recth, Vector3 c, float r) => (double)new Vector3(Mathf.Max(Mathf.Abs(c.x) - rectw, 0.0f), 0.0f, Mathf.Max(Mathf.Abs(c.z) - recth, 0.0f)).sqrMagnitude < (double)r * (double)r;

        public bool Intersection(
          Vector2 begin,
          Vector2 end,
          Vector2 center,
          float radius,
          out float t)
        {
            t = 0.0f;
            float num1 = radius * radius;
            Vector2 from = center - begin;
            float sqrMagnitude = from.sqrMagnitude;
            if ((double)sqrMagnitude < (double)num1)
                return true;
            Vector2 to = end - begin;
            if ((double)to.sqrMagnitude > 0.0)
            {
                float num2 = Mathf.Sqrt(sqrMagnitude) * Mathf.Cos(Vector2.Angle(from, to));
                if ((double)num2 >= 0.0)
                {
                    float num3 = sqrMagnitude - num2 * num2;
                    if ((double)num3 < (double)num1)
                    {
                        float f = num1 - num3;
                        t = num2 - Mathf.Sqrt(f);
                        return true;
                    }
                }
            }
            return false;
        }

        private float CrossProduct(float x1, float z1, float x2, float z2) => (float)((double)x1 * (double)z2 - (double)x2 * (double)z1);

        public bool IsLineSegmentCross(Vector3 p1, Vector3 p2, Vector3 q1, Vector3 q2)
        {
            if ((double)Mathf.Min(p1.x, p2.x) <= (double)Mathf.Max(q1.x, q2.x) && (double)Mathf.Min(q1.x, q2.x) <= (double)Mathf.Max(p1.x, p2.x) && (double)Mathf.Min(p1.z, p2.z) <= (double)Mathf.Max(q1.z, q2.z) && (double)Mathf.Min(q1.z, q2.z) <= (double)Mathf.Max(p1.z, p2.z))
            {
                float num1 = this.CrossProduct(p1.x - q1.x, p1.z - q1.z, q2.x - q1.x, q2.z - q1.z);
                float num2 = this.CrossProduct(p2.x - q1.x, p2.z - q1.z, q2.x - q1.x, q2.z - q1.z);
                float num3 = this.CrossProduct(q1.x - p1.x, q1.z - p1.z, p2.x - p1.x, p2.z - p1.z);
                float num4 = this.CrossProduct(q2.x - p1.x, q2.z - p1.z, p2.x - p1.x, p2.z - p1.z);
                return (double)num1 * (double)num2 <= 0.0 && (double)num3 * (double)num4 <= 0.0;
            }
            Vector3.Project(p1, Vector3.up);
            return false;
        }

        public Vector3 Horizontal(Vector3 v)
        {
            v.y = 0.0f;
            return v.normalized;
        }

        public void Horizontal(ref Vector3 v)
        {
            v.y = 0.0f;
            v.Normalize();
        }

        public float AngleNormalize(float basic, float degree)
        {
            Vector3 angle1 = this.FloatToAngle(basic);
            Vector3 angle2 = this.FloatToAngle(degree);
            float num = Vector3.Angle(angle1, angle2);
            return this.Clockwise(angle1, angle2) ? basic + num : basic - num;
        }

        public Vector2 HorizontalRotateVetor2(Vector2 v, float degree, bool normalized = true)
        {
            degree = -degree;
            float f = degree * ((float)Math.PI / 180f);
            float num1 = Mathf.Sin(f);
            float num2 = Mathf.Cos(f);
            float num3 = (float)((double)v.x * (double)num2 - (double)v.y * (double)num1);
            float num4 = (float)((double)v.x * (double)num1 + (double)v.y * (double)num2);
            v.x = num3;
            v.y = num4;
            return normalized ? v.normalized : v;
        }

        public Vector3 HorizontalRotateVetor3(Vector3 v, float degree, bool normalized = true)
        {
            degree = -degree;
            float f = degree * ((float)Math.PI / 180f);
            float num1 = Mathf.Sin(f);
            float num2 = Mathf.Cos(f);
            float num3 = (float)((double)v.x * (double)num2 - (double)v.z * (double)num1);
            float num4 = (float)((double)v.x * (double)num1 + (double)v.z * (double)num2);
            v.x = num3;
            v.z = num4;
            return normalized ? v.normalized : v;
        }

        public float TicksToSeconds(long tick) => (float)(tick / 10000L) / 1000f;

        public long SecondsToTicks(float time) => (long)((double)time * 1000.0) * 10000L;

        public float AngleToFloat(Vector3 dir)
        {
            float num = Vector3.Angle(Vector3.forward, dir);
            return XSingleton<XCommon>.singleton.Clockwise(Vector3.forward, dir) ? num : -num;
        }

        public float AngleWithSign(Vector3 from, Vector3 to)
        {
            float num = Vector3.Angle(from, to);
            return this.Clockwise(from, to) ? num : -num;
        }

        public Vector3 FloatToAngle(float angle) => Quaternion.Euler(0.0f, angle, 0.0f) * Vector3.forward;

        public Quaternion VectorToQuaternion(Vector3 v) => XSingleton<XCommon>.singleton.FloatToQuaternion(XSingleton<XCommon>.singleton.AngleWithSign(Vector3.forward, v));

        public Quaternion FloatToQuaternion(float angle) => Quaternion.Euler(0.0f, angle, 0.0f);

        public Quaternion RotateToGround(Vector3 pos, Vector3 forward)
        {
            RaycastHit hitInfo;
            if (!Physics.Raycast(new Ray(pos + Vector3.up, Vector3.down), out hitInfo, 5f, 513))
                return Quaternion.identity;
            Vector3 normal = hitInfo.normal;
            Vector3 tangent = forward;
            Vector3.OrthoNormalize(ref normal, ref tangent);
            return Quaternion.LookRotation(tangent, normal);
        }

        public bool Clockwise(Vector3 fiduciary, Vector3 relativity) => (double)fiduciary.z * (double)relativity.x - (double)fiduciary.x * (double)relativity.z > 0.0;

        public bool Clockwise(Vector2 fiduciary, Vector2 relativity) => (double)fiduciary.y * (double)relativity.x - (double)fiduciary.x * (double)relativity.y > 0.0;

        public bool IsInRect(Vector3 point, Rect rect, Vector3 center, Quaternion rotation)
        {
            float num = (float)(-((double)rotation.eulerAngles.y % 360.0) / 180.0 * 3.14159274101257);
            Quaternion identity = Quaternion.identity;
            identity.w = Mathf.Cos(num / 2f);
            identity.x = 0.0f;
            identity.y = Mathf.Sin(num / 2f);
            identity.z = 0.0f;
            point = identity * (point - center);
            return (double)point.x > (double)rect.xMin && (double)point.x < (double)rect.xMax && (double)point.z > (double)rect.yMin && (double)point.z < (double)rect.yMax;
        }

        public float RandomPercentage() => (float)this._random.NextDouble();

        public float RandomPercentage(float min)
        {
            if (this.IsEqualGreater(min, 1f))
                return 1f;
            float a = (float)this._random.NextDouble();
            return this.IsGreater(a, min) ? a : (float)((double)a / (double)min * (1.0 - (double)min)) + min;
        }

        public float RandomFloat(float max) => this.RandomPercentage() * max;

        public float RandomFloat(float min, float max) => min + this.RandomFloat(max - min);

        public int RandomInt(int min, int max) => this._random.Next(min, max);

        public int RandomInt(int max) => this._random.Next(max);

        public int RandomInt() => this._random.Next();

        public bool IsInteger(float n) => (double)Mathf.Abs(n - (float)(int)n) < (double)XCommon._eps || (double)Mathf.Abs(n - (float)(int)n) > 1.0 - (double)XCommon._eps;

        public float GetFloatingValue(float value, float floating)
        {
            if (this.IsEqualLess(floating, 0.0f) || this.IsEqualGreater(floating, 1f))
                return value;
            float num = this.IsLess(this.RandomPercentage(), 0.5f) ? 1f - floating : 1f + floating;
            return value * num;
        }

        public float GetSmoothFactor(float distance, float timespan, float nearenough)
        {
            float num1 = 0.0f;
            distance = Mathf.Abs(distance);
            if ((double)distance > (double)XCommon.XEps)
            {
                float smoothDeltaTime = Time.smoothDeltaTime;
                float f = nearenough / distance;
                float num2 = timespan / smoothDeltaTime;
                num1 = (double)num2 <= 1.0 ? float.PositiveInfinity : (1f - Mathf.Pow(f, 1f / num2)) / smoothDeltaTime;
            }
            return num1;
        }

        public float GetJumpForce(float airTime, float g) => 0.0f;

        public string SecondsToString(int time) => string.Format("{0:D2}:{1}", (object)(time / 60), (object)(time % 60));

        public double Clamp(double value, double min, double max) => Math.Min(Math.Max(min, value), max);

        public Transform FindChildRecursively(Transform t, string name)
        {
            if (t.name == name)
                return t;
            for (int index = 0; index < t.childCount; ++index)
            {
                Transform childRecursively = this.FindChildRecursively(t.GetChild(index), name);
                if ((UnityEngine.Object)childRecursively != (UnityEngine.Object)null)
                    return childRecursively;
            }
            return (Transform)null;
        }

        public void CleanStringCombine() => this.shareSB.Length = 0;

        public StringBuilder GetSharedStringBuilder() => this.shareSB;

        public string GetString() => this.shareSB.ToString();

        public XCommon AppendString(string s)
        {
            this.shareSB.Append(s);
            return this;
        }

        public XCommon AppendString(string s0, string s1)
        {
            this.shareSB.Append(s0);
            this.shareSB.Append(s1);
            return this;
        }

        public XCommon AppendString(string s0, string s1, string s2)
        {
            this.shareSB.Append(s0);
            this.shareSB.Append(s1);
            this.shareSB.Append(s2);
            return this;
        }

        public string StringCombine(string s0, string s1)
        {
            this.shareSB.Length = 0;
            this.shareSB.Append(s0);
            this.shareSB.Append(s1);
            return this.shareSB.ToString();
        }

        public string StringCombine(string s0, string s1, string s2)
        {
            this.shareSB.Length = 0;
            this.shareSB.Append(s0);
            this.shareSB.Append(s1);
            this.shareSB.Append(s2);
            return this.shareSB.ToString();
        }

        public string StringCombine(string s0, string s1, string s2, string s3)
        {
            this.shareSB.Length = 0;
            this.shareSB.Append(s0);
            this.shareSB.Append(s1);
            this.shareSB.Append(s2);
            this.shareSB.Append(s3);
            return this.shareSB.ToString();
        }

        public uint CombineAdd(uint value, int heigh, int low) => (uint)((int)(value >> 16) + heigh << 16 | ((int)value & (int)ushort.MaxValue) + low);

        public void CombineSetHeigh(ref uint value, uint heigh) => value = (uint)((int)heigh << 16 | (int)value & (int)ushort.MaxValue);

        public ushort CombineGetHeigh(uint value) => (ushort)(value >> 16);

        public void CombineSetLow(ref uint value, uint low) => value = (uint)((int)value & -65536 | (int)low & (int)ushort.MaxValue);

        public ushort CombineGetLow(uint value) => (ushort)(value & (uint)ushort.MaxValue);

        public void EnableParticleRenderer(GameObject go, bool enable)
        {
            Animator componentInChildren = go.GetComponentInChildren<Animator>();
            if (!((UnityEngine.Object)componentInChildren != (UnityEngine.Object)null))
                return;
            componentInChildren.enabled = enable;
        }

        public void EnableParticle(GameObject go, bool enable)
        {
            go.GetComponentsInChildren<ParticleSystem>(XCommon.tmpParticle);
            int index = 0;
            for (int count = XCommon.tmpParticle.Count; index < count; ++index)
            {
                ParticleSystem particleSystem = XCommon.tmpParticle[index];
                if (enable)
                    particleSystem.Play();
                else
                    particleSystem.Stop();
            }
            XCommon.tmpParticle.Clear();
        }

        public static UnityEngine.Object Instantiate(UnityEngine.Object prefab) => UnityEngine.Object.Instantiate(prefab, (Transform)null);

        public static T Instantiate<T>(T original) where T : UnityEngine.Object => UnityEngine.Object.Instantiate<T>(original, (Transform)null);

        public override bool Init() => true;

        public override void Uninit()
        {
        }
    }
}
