using System;

namespace XUtliPoolLib
{
	// Token: 0x02000190 RID: 400
	public class FloatCurve : IXCurve
	{
		// Token: 0x060008AE RID: 2222 RVA: 0x0002EE08 File Offset: 0x0002D008
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

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060008AF RID: 2223 RVA: 0x0002EEC8 File Offset: 0x0002D0C8
		public int length
		{
			get
			{
				return (this.value == null) ? 0 : this.value.Length;
			}
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0002EEF0 File Offset: 0x0002D0F0
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

		// Token: 0x060008B1 RID: 2225 RVA: 0x0002EF28 File Offset: 0x0002D128
		public float GetTime(int index)
		{
			return (float)index * FloatCurve.frameTime;
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x0002EF44 File Offset: 0x0002D144
		public float GetMaxValue()
		{
			return (float)this.maxValue * 0.01f;
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0002EF64 File Offset: 0x0002D164
		public float GetLandValue()
		{
			return (float)this.landValue * 0.01f;
		}

		// Token: 0x040003F3 RID: 1011
		public static float frameTime = 0.033333335f;

		// Token: 0x040003F4 RID: 1012
		public uint namehash;

		// Token: 0x040003F5 RID: 1013
		public short maxValue;

		// Token: 0x040003F6 RID: 1014
		public short landValue;

		// Token: 0x040003F7 RID: 1015
		public short[] value = null;
	}
}
