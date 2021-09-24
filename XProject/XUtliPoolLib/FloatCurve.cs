using System;

namespace XUtliPoolLib
{

	public class FloatCurve : IXCurve
	{

		public float Evaluate(float time)
		{
			bool flag = this.value == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				float num = time / FloatCurve.frameTime;
				int num2 = (int)Math.Ceiling((double)num);
				int num3 = (int)Math.Floor((double)num);
				bool flag2 = num2 >= this.value.Length;
				if (flag2)
				{
					num2 = this.value.Length - 1;
				}
				bool flag3 = num3 >= this.value.Length;
				if (flag3)
				{
					num3 = this.value.Length - 1;
				}
				result = (float)this.value[num3] * 0.01f + (float)(this.value[num2] - this.value[num3]) * 0.01f / FloatCurve.frameTime * (time - (float)num3 * FloatCurve.frameTime);
			}
			return result;
		}

		public int length
		{
			get
			{
				return (this.value == null) ? 0 : this.value.Length;
			}
		}

		public float GetValue(int index)
		{
			bool flag = this.value == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = (float)this.value[index] * 0.01f;
			}
			return result;
		}

		public float GetTime(int index)
		{
			return (float)index * FloatCurve.frameTime;
		}

		public float GetMaxValue()
		{
			return (float)this.maxValue * 0.01f;
		}

		public float GetLandValue()
		{
			return (float)this.landValue * 0.01f;
		}

		public static float frameTime = 0.033333335f;

		public uint namehash;

		public short maxValue;

		public short landValue;

		public short[] value = null;
	}
}
