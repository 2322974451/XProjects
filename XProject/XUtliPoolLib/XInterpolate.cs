

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
    public class XInterpolate
    {
        private static Vector3 Identity(Vector3 v) => v;

        private static Vector3 TransformDotPosition(Transform t) => t.position;

        private static IEnumerable<float> NewTimer(float duration)
        {
            float elapsedTime = 0.0f;
            while ((double)elapsedTime < (double)duration)
            {
                yield return elapsedTime;
                elapsedTime += Time.deltaTime;
                if ((double)elapsedTime >= (double)duration)
                    yield return elapsedTime;
            }
        }

        private static IEnumerable<float> NewCounter(int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
                yield return (float)i;
        }

        public static IEnumerator NewEase(
          XInterpolate.Function ease,
          Vector3 start,
          Vector3 end,
          float duration)
        {
            IEnumerable<float> driver = XInterpolate.NewTimer(duration);
            return XInterpolate.NewEase(ease, start, end, duration, driver);
        }

        public static IEnumerator NewEase(
          XInterpolate.Function ease,
          Vector3 start,
          Vector3 end,
          int slices)
        {
            IEnumerable<float> driver = XInterpolate.NewCounter(0, slices + 1, 1);
            return XInterpolate.NewEase(ease, start, end, (float)(slices + 1), driver);
        }

        private static IEnumerator NewEase(
          XInterpolate.Function ease,
          Vector3 start,
          Vector3 end,
          float total,
          IEnumerable<float> driver)
        {
            Vector3 distance = end - start;
            foreach (float i in driver)
                yield return (object)XInterpolate.Ease(ease, start, distance, i, total);
        }

        private static Vector3 Ease(
          XInterpolate.Function ease,
          Vector3 start,
          Vector3 distance,
          float elapsedTime,
          float duration)
        {
            start.x = ease(start.x, distance.x, elapsedTime, duration);
            start.y = ease(start.y, distance.y, elapsedTime, duration);
            start.z = ease(start.z, distance.z, elapsedTime, duration);
            return start;
        }

        public static XInterpolate.Function Ease(XInterpolate.EaseType type)
        {
            XInterpolate.Function function = (XInterpolate.Function)null;
            switch (type)
            {
                case XInterpolate.EaseType.Linear:
                    function = new XInterpolate.Function(XInterpolate.Linear);
                    break;
                case XInterpolate.EaseType.EaseInQuad:
                    function = new XInterpolate.Function(XInterpolate.EaseInQuad);
                    break;
                case XInterpolate.EaseType.EaseOutQuad:
                    function = new XInterpolate.Function(XInterpolate.EaseOutQuad);
                    break;
                case XInterpolate.EaseType.EaseInOutQuad:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutQuad);
                    break;
                case XInterpolate.EaseType.EaseInCubic:
                    function = new XInterpolate.Function(XInterpolate.EaseInCubic);
                    break;
                case XInterpolate.EaseType.EaseOutCubic:
                    function = new XInterpolate.Function(XInterpolate.EaseOutCubic);
                    break;
                case XInterpolate.EaseType.EaseInOutCubic:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutCubic);
                    break;
                case XInterpolate.EaseType.EaseInQuart:
                    function = new XInterpolate.Function(XInterpolate.EaseInQuart);
                    break;
                case XInterpolate.EaseType.EaseOutQuart:
                    function = new XInterpolate.Function(XInterpolate.EaseOutQuart);
                    break;
                case XInterpolate.EaseType.EaseInOutQuart:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutQuart);
                    break;
                case XInterpolate.EaseType.EaseInQuint:
                    function = new XInterpolate.Function(XInterpolate.EaseInQuint);
                    break;
                case XInterpolate.EaseType.EaseOutQuint:
                    function = new XInterpolate.Function(XInterpolate.EaseOutQuint);
                    break;
                case XInterpolate.EaseType.EaseInOutQuint:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutQuint);
                    break;
                case XInterpolate.EaseType.EaseInSine:
                    function = new XInterpolate.Function(XInterpolate.EaseInSine);
                    break;
                case XInterpolate.EaseType.EaseOutSine:
                    function = new XInterpolate.Function(XInterpolate.EaseOutSine);
                    break;
                case XInterpolate.EaseType.EaseInOutSine:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutSine);
                    break;
                case XInterpolate.EaseType.EaseInExpo:
                    function = new XInterpolate.Function(XInterpolate.EaseInExpo);
                    break;
                case XInterpolate.EaseType.EaseOutExpo:
                    function = new XInterpolate.Function(XInterpolate.EaseOutExpo);
                    break;
                case XInterpolate.EaseType.EaseInOutExpo:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutExpo);
                    break;
                case XInterpolate.EaseType.EaseInCirc:
                    function = new XInterpolate.Function(XInterpolate.EaseInCirc);
                    break;
                case XInterpolate.EaseType.EaseOutCirc:
                    function = new XInterpolate.Function(XInterpolate.EaseOutCirc);
                    break;
                case XInterpolate.EaseType.EaseInOutCirc:
                    function = new XInterpolate.Function(XInterpolate.EaseInOutCirc);
                    break;
            }
            return function;
        }

        public static IEnumerable<Vector3> NewBezier(
          XInterpolate.Function ease,
          Transform[] nodes,
          float duration)
        {
            IEnumerable<float> steps = XInterpolate.NewTimer(duration);
            return XInterpolate.NewBezier<Transform>(ease, (IList)nodes, new XInterpolate.ToVector3<Transform>(XInterpolate.TransformDotPosition), duration, steps);
        }

        public static IEnumerable<Vector3> NewBezier(
          XInterpolate.Function ease,
          Transform[] nodes,
          int slices)
        {
            IEnumerable<float> steps = XInterpolate.NewCounter(0, slices + 1, 1);
            return XInterpolate.NewBezier<Transform>(ease, (IList)nodes, new XInterpolate.ToVector3<Transform>(XInterpolate.TransformDotPosition), (float)(slices + 1), steps);
        }

        public static IEnumerable<Vector3> NewBezier(
          XInterpolate.Function ease,
          Vector3[] points,
          float duration)
        {
            IEnumerable<float> steps = XInterpolate.NewTimer(duration);
            return XInterpolate.NewBezier<Vector3>(ease, (IList)points, new XInterpolate.ToVector3<Vector3>(XInterpolate.Identity), duration, steps);
        }

        public static IEnumerable<Vector3> NewBezier(
          XInterpolate.Function ease,
          Vector3[] points,
          int slices)
        {
            IEnumerable<float> steps = XInterpolate.NewCounter(0, slices + 1, 1);
            return XInterpolate.NewBezier<Vector3>(ease, (IList)points, new XInterpolate.ToVector3<Vector3>(XInterpolate.Identity), (float)(slices + 1), steps);
        }

        private static IEnumerable<Vector3> NewBezier<T>(
          XInterpolate.Function ease,
          IList nodes,
          XInterpolate.ToVector3<T> toVector3,
          float maxStep,
          IEnumerable<float> steps)
        {
            if (nodes.Count >= 2)
            {
                Vector3[] points = new Vector3[nodes.Count];
                foreach (float step in steps)
                {
                    for (int i = 0; i < nodes.Count; ++i)
                        points[i] = toVector3((T)nodes[i]);
                    yield return XInterpolate.Bezier(ease, points, step, maxStep);
                }
                points = (Vector3[])null;
            }
        }

        private static Vector3 Bezier(
          XInterpolate.Function ease,
          Vector3[] points,
          float elapsedTime,
          float duration)
        {
            for (int index1 = points.Length - 1; index1 > 0; --index1)
            {
                for (int index2 = 0; index2 < index1; ++index2)
                {
                    points[index2].x = ease(points[index2].x, points[index2 + 1].x - points[index2].x, elapsedTime, duration);
                    points[index2].y = ease(points[index2].y, points[index2 + 1].y - points[index2].y, elapsedTime, duration);
                    points[index2].z = ease(points[index2].z, points[index2 + 1].z - points[index2].z, elapsedTime, duration);
                }
            }
            return points[0];
        }

        public static IEnumerable<Vector3> NewCatmullRom(
          Transform[] nodes,
          int slices,
          bool loop)
        {
            return XInterpolate.NewCatmullRom<Transform>((IList)nodes, new XInterpolate.ToVector3<Transform>(XInterpolate.TransformDotPosition), slices, loop);
        }

        public static IEnumerable<Vector3> NewCatmullRom(
          Vector3[] points,
          int slices,
          bool loop)
        {
            return XInterpolate.NewCatmullRom<Vector3>((IList)points, new XInterpolate.ToVector3<Vector3>(XInterpolate.Identity), slices, loop);
        }

        private static IEnumerable<Vector3> NewCatmullRom<T>(
          IList nodes,
          XInterpolate.ToVector3<T> toVector3,
          int slices,
          bool loop)
        {
            if (nodes.Count >= 2)
            {
                yield return toVector3((T)nodes[0]);
                int last = nodes.Count - 1;
                for (int current = 0; loop || current < last; ++current)
                {
                    if (loop && current > last)
                        current = 0;
                    int previous = current == 0 ? (loop ? last : current) : current - 1;
                    int start = current;
                    int end = current == last ? (loop ? 0 : current) : current + 1;
                    int next = end == last ? (loop ? 0 : end) : end + 1;
                    int stepCount = slices + 1;
                    for (int step = 1; step <= stepCount; ++step)
                        yield return XInterpolate.CatmullRom(toVector3((T)nodes[previous]), toVector3((T)nodes[start]), toVector3((T)nodes[end]), toVector3((T)nodes[next]), (float)step, (float)stepCount);
                }
            }
        }

        private static Vector3 CatmullRom(
          Vector3 previous,
          Vector3 start,
          Vector3 end,
          Vector3 next,
          float elapsedTime,
          float duration)
        {
            float num1 = elapsedTime / duration;
            float num2 = num1 * num1;
            float num3 = num2 * num1;
            return previous * (float)(-0.5 * (double)num3 + (double)num2 - 0.5 * (double)num1) + start * (float)(1.5 * (double)num3 + -2.5 * (double)num2 + 1.0) + end * (float)(-1.5 * (double)num3 + 2.0 * (double)num2 + 0.5 * (double)num1) + next * (float)(0.5 * (double)num3 - 0.5 * (double)num2);
        }

        private static float Linear(float start, float distance, float elapsedTime, float duration)
        {
            if ((double)elapsedTime > (double)duration)
                elapsedTime = duration;
            return distance * (elapsedTime / duration) + start;
        }

        private static float EaseInQuad(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            return distance * elapsedTime * elapsedTime + start;
        }

        private static float EaseOutQuad(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            return (float)(-(double)distance * (double)elapsedTime * ((double)elapsedTime - 2.0)) + start;
        }

        private static float EaseInOutQuad(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 2f : elapsedTime / (duration / 2f);
            if ((double)elapsedTime < 1.0)
                return distance / 2f * elapsedTime * elapsedTime + start;
            --elapsedTime;
            return (float)(-(double)distance / 2.0 * ((double)elapsedTime * ((double)elapsedTime - 2.0) - 1.0)) + start;
        }

        private static float EaseInCubic(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            return distance * elapsedTime * elapsedTime * elapsedTime + start;
        }

        private static float EaseOutCubic(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            --elapsedTime;
            return distance * (float)((double)elapsedTime * (double)elapsedTime * (double)elapsedTime + 1.0) + start;
        }

        private static float EaseInOutCubic(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 2f : elapsedTime / (duration / 2f);
            if ((double)elapsedTime < 1.0)
                return distance / 2f * elapsedTime * elapsedTime * elapsedTime + start;
            elapsedTime -= 2f;
            return (float)((double)distance / 2.0 * ((double)elapsedTime * (double)elapsedTime * (double)elapsedTime + 2.0)) + start;
        }

        private static float EaseInQuart(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            return distance * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
        }

        private static float EaseOutQuart(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            --elapsedTime;
            return (float)(-(double)distance * ((double)elapsedTime * (double)elapsedTime * (double)elapsedTime * (double)elapsedTime - 1.0)) + start;
        }

        private static float EaseInOutQuart(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 2f : elapsedTime / (duration / 2f);
            if ((double)elapsedTime < 1.0)
                return distance / 2f * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
            elapsedTime -= 2f;
            return (float)(-(double)distance / 2.0 * ((double)elapsedTime * (double)elapsedTime * (double)elapsedTime * (double)elapsedTime - 2.0)) + start;
        }

        private static float EaseInQuint(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            return distance * elapsedTime * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
        }

        private static float EaseOutQuint(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            --elapsedTime;
            return distance * (float)((double)elapsedTime * (double)elapsedTime * (double)elapsedTime * (double)elapsedTime * (double)elapsedTime + 1.0) + start;
        }

        private static float EaseInOutQuint(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 2f : elapsedTime / (duration / 2f);
            if ((double)elapsedTime < 1.0)
                return distance / 2f * elapsedTime * elapsedTime * elapsedTime * elapsedTime * elapsedTime + start;
            elapsedTime -= 2f;
            return (float)((double)distance / 2.0 * ((double)elapsedTime * (double)elapsedTime * (double)elapsedTime * (double)elapsedTime * (double)elapsedTime + 2.0)) + start;
        }

        private static float EaseInSine(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            if ((double)elapsedTime > (double)duration)
                elapsedTime = duration;
            return -distance * Mathf.Cos((float)((double)elapsedTime / (double)duration * 1.57079637050629)) + distance + start;
        }

        private static float EaseOutSine(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            if ((double)elapsedTime > (double)duration)
                elapsedTime = duration;
            return distance * Mathf.Sin((float)((double)elapsedTime / (double)duration * 1.57079637050629)) + start;
        }

        private static float EaseInOutSine(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            if ((double)elapsedTime > (double)duration)
                elapsedTime = duration;
            return (float)(-(double)distance / 2.0 * ((double)Mathf.Cos(3.141593f * elapsedTime / duration) - 1.0)) + start;
        }

        private static float EaseInExpo(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            if ((double)elapsedTime > (double)duration)
                elapsedTime = duration;
            return distance * Mathf.Pow(2f, (float)(10.0 * ((double)elapsedTime / (double)duration - 1.0))) + start;
        }

        private static float EaseOutExpo(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            if ((double)elapsedTime > (double)duration)
                elapsedTime = duration;
            return distance * (float)(-(double)Mathf.Pow(2f, -10f * elapsedTime / duration) + 1.0) + start;
        }

        private static float EaseInOutExpo(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 2f : elapsedTime / (duration / 2f);
            if ((double)elapsedTime < 1.0)
                return distance / 2f * Mathf.Pow(2f, (float)(10.0 * ((double)elapsedTime - 1.0))) + start;
            --elapsedTime;
            return (float)((double)distance / 2.0 * (-(double)Mathf.Pow(2f, -10f * elapsedTime) + 2.0)) + start;
        }

        private static float EaseInCirc(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            return (float)(-(double)distance * ((double)Mathf.Sqrt((float)(1.0 - (double)elapsedTime * (double)elapsedTime)) - 1.0)) + start;
        }

        private static float EaseOutCirc(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 1f : elapsedTime / duration;
            --elapsedTime;
            return distance * Mathf.Sqrt((float)(1.0 - (double)elapsedTime * (double)elapsedTime)) + start;
        }

        private static float EaseInOutCirc(
          float start,
          float distance,
          float elapsedTime,
          float duration)
        {
            elapsedTime = (double)elapsedTime > (double)duration ? 2f : elapsedTime / (duration / 2f);
            if ((double)elapsedTime < 1.0)
                return (float)(-(double)distance / 2.0 * ((double)Mathf.Sqrt((float)(1.0 - (double)elapsedTime * (double)elapsedTime)) - 1.0)) + start;
            elapsedTime -= 2f;
            return (float)((double)distance / 2.0 * ((double)Mathf.Sqrt((float)(1.0 - (double)elapsedTime * (double)elapsedTime)) + 1.0)) + start;
        }

        public enum EaseType
        {
            Linear,
            EaseInQuad,
            EaseOutQuad,
            EaseInOutQuad,
            EaseInCubic,
            EaseOutCubic,
            EaseInOutCubic,
            EaseInQuart,
            EaseOutQuart,
            EaseInOutQuart,
            EaseInQuint,
            EaseOutQuint,
            EaseInOutQuint,
            EaseInSine,
            EaseOutSine,
            EaseInOutSine,
            EaseInExpo,
            EaseOutExpo,
            EaseInOutExpo,
            EaseInCirc,
            EaseOutCirc,
            EaseInOutCirc,
        }

        public delegate Vector3 ToVector3<T>(T v);

        public delegate float Function(float a, float b, float c, float d);
    }
}
