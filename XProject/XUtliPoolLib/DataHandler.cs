using System;
using System.IO;

namespace XUtliPoolLib
{
	// Token: 0x020000CC RID: 204
	public class DataHandler
	{
		// Token: 0x060005B1 RID: 1457 RVA: 0x0001A238 File Offset: 0x00018438
		public void Init(XBinaryReader br)
		{
			this.m_hasStringSeq = br.ReadBoolean();
			ushort num = br.ReadUInt16();
			bool flag = num > 0;
			if (flag)
			{
				this.stringBuffer = new string[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					this.stringBuffer[i] = br.ReadString(-1);
				}
			}
			else
			{
				this.stringBuffer = DataHandler.defaultStringBuffer;
			}
			ushort num2 = br.ReadUInt16();
			bool flag2 = num2 > 0;
			if (flag2)
			{
				this.intBuffer = new int[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					this.intBuffer[j] = br.ReadInt32();
				}
			}
			else
			{
				this.intBuffer = DataHandler.defaultIntBuffer;
			}
			ushort num3 = br.ReadUInt16();
			bool flag3 = num3 > 0;
			if (flag3)
			{
				this.uintBuffer = new uint[(int)num3];
				for (int k = 0; k < (int)num3; k++)
				{
					this.uintBuffer[k] = br.ReadUInt32();
				}
			}
			else
			{
				this.uintBuffer = DataHandler.defaultUIntBuffer;
			}
			ushort num4 = br.ReadUInt16();
			bool flag4 = num4 > 0;
			if (flag4)
			{
				this.longBuffer = new long[(int)num4];
				for (int l = 0; l < (int)num4; l++)
				{
					this.longBuffer[l] = br.ReadInt64();
				}
			}
			else
			{
				this.longBuffer = DataHandler.defaultLongBuffer;
			}
			ushort num5 = br.ReadUInt16();
			bool flag5 = num5 > 0;
			if (flag5)
			{
				this.floatBuffer = new float[(int)num5];
				for (int m = 0; m < (int)num5; m++)
				{
					this.floatBuffer[m] = br.ReadSingle();
				}
			}
			else
			{
				this.floatBuffer = DataHandler.defaultFloatBuffer;
			}
			ushort num6 = br.ReadUInt16();
			bool flag6 = num6 > 0;
			if (flag6)
			{
				this.doubleBuffer = new double[(int)num6];
				for (int n = 0; n < (int)num6; n++)
				{
					this.doubleBuffer[n] = br.ReadDouble();
				}
			}
			else
			{
				this.doubleBuffer = DataHandler.defaultDoubleBuffe;
			}
			ushort num7 = br.ReadUInt16();
			bool flag7 = num7 > 0;
			if (flag7)
			{
				this.indexBuffer = new ushort[(int)num7];
				for (int num8 = 0; num8 < (int)num7; num8++)
				{
					this.indexBuffer[num8] = br.ReadUInt16();
				}
			}
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0001A4A4 File Offset: 0x000186A4
		public void Init(BinaryReader br)
		{
			this.m_hasStringSeq = br.ReadBoolean();
			ushort num = br.ReadUInt16();
			bool flag = num > 0;
			if (flag)
			{
				this.stringBuffer = new string[(int)num];
				for (int i = 0; i < (int)num; i++)
				{
					this.stringBuffer[i] = br.ReadString();
				}
			}
			ushort num2 = br.ReadUInt16();
			bool flag2 = num2 > 0;
			if (flag2)
			{
				this.intBuffer = new int[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					this.intBuffer[j] = br.ReadInt32();
				}
			}
			ushort num3 = br.ReadUInt16();
			bool flag3 = num3 > 0;
			if (flag3)
			{
				this.uintBuffer = new uint[(int)num3];
				for (int k = 0; k < (int)num3; k++)
				{
					this.uintBuffer[k] = br.ReadUInt32();
				}
			}
			ushort num4 = br.ReadUInt16();
			bool flag4 = num4 > 0;
			if (flag4)
			{
				this.longBuffer = new long[(int)num4];
				for (int l = 0; l < (int)num4; l++)
				{
					this.longBuffer[l] = br.ReadInt64();
				}
			}
			ushort num5 = br.ReadUInt16();
			bool flag5 = num5 > 0;
			if (flag5)
			{
				this.floatBuffer = new float[(int)num5];
				for (int m = 0; m < (int)num5; m++)
				{
					this.floatBuffer[m] = br.ReadSingle();
				}
			}
			ushort num6 = br.ReadUInt16();
			bool flag6 = num6 > 0;
			if (flag6)
			{
				this.doubleBuffer = new double[(int)num6];
				for (int n = 0; n < (int)num6; n++)
				{
					this.doubleBuffer[n] = br.ReadDouble();
				}
			}
			ushort num7 = br.ReadUInt16();
			bool flag7 = num7 > 0;
			if (flag7)
			{
				this.indexBuffer = new ushort[(int)num7];
				for (int num8 = 0; num8 < (int)num7; num8++)
				{
					this.indexBuffer[num8] = br.ReadUInt16();
				}
			}
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001A6B4 File Offset: 0x000188B4
		public void UnInit(bool forceClean = false)
		{
			bool flag = !this.m_hasStringSeq;
			if (flag)
			{
				this.stringBuffer = null;
			}
			if (forceClean)
			{
				this.stringBuffer = null;
				this.intBuffer = null;
				this.uintBuffer = null;
				this.longBuffer = null;
				this.floatBuffer = null;
				this.doubleBuffer = null;
				this.indexBuffer = null;
			}
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0001A710 File Offset: 0x00018910
		public string ReadString(XBinaryReader br)
		{
			ushort num = br.ReadUInt16();
			bool flag = this.stringBuffer != null;
			if (flag)
			{
				bool flag2 = num >= 0 && (int)num < this.stringBuffer.Length;
				if (flag2)
				{
					return this.stringBuffer[(int)num];
				}
			}
			return string.Empty;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0001A760 File Offset: 0x00018960
		public string ReadString(BinaryReader br)
		{
			int num = (int)br.ReadUInt16();
			bool flag = this.stringBuffer != null;
			if (flag)
			{
				bool flag2 = num >= 0 && num < this.stringBuffer.Length;
				if (flag2)
				{
					return this.stringBuffer[num];
				}
			}
			return string.Empty;
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0001A7B0 File Offset: 0x000189B0
		public T ReadValue<T>(CVSReader.ValueParse<T> parser, byte allSameMask, ushort startOffset, int index, int key)
		{
			T[] buffer = parser.GetBuffer(this);
			return (allSameMask == 1) ? buffer[(int)startOffset + key] : buffer[(int)this.indexBuffer[(int)startOffset + index] + key];
		}

		// Token: 0x040002FB RID: 763
		private bool m_hasStringSeq = false;

		// Token: 0x040002FC RID: 764
		public string[] stringBuffer = null;

		// Token: 0x040002FD RID: 765
		public int[] intBuffer;

		// Token: 0x040002FE RID: 766
		public uint[] uintBuffer;

		// Token: 0x040002FF RID: 767
		public long[] longBuffer;

		// Token: 0x04000300 RID: 768
		public float[] floatBuffer;

		// Token: 0x04000301 RID: 769
		public double[] doubleBuffer;

		// Token: 0x04000302 RID: 770
		public ushort[] indexBuffer;

		// Token: 0x04000303 RID: 771
		public static string[] defaultStringBuffer = new string[4];

		// Token: 0x04000304 RID: 772
		public static int[] defaultIntBuffer = new int[4];

		// Token: 0x04000305 RID: 773
		public static uint[] defaultUIntBuffer = new uint[4];

		// Token: 0x04000306 RID: 774
		public static long[] defaultLongBuffer = new long[4];

		// Token: 0x04000307 RID: 775
		public static float[] defaultFloatBuffer = new float[4];

		// Token: 0x04000308 RID: 776
		public static double[] defaultDoubleBuffe = new double[4];
	}
}
