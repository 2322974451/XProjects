using System;
using System.IO;

namespace XUtliPoolLib
{

	public class DataHandler
	{

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

		public T ReadValue<T>(CVSReader.ValueParse<T> parser, byte allSameMask, ushort startOffset, int index, int key)
		{
			T[] buffer = parser.GetBuffer(this);
			return (allSameMask == 1) ? buffer[(int)startOffset + key] : buffer[(int)this.indexBuffer[(int)startOffset + index] + key];
		}

		private bool m_hasStringSeq = false;

		public string[] stringBuffer = null;

		public int[] intBuffer;

		public uint[] uintBuffer;

		public long[] longBuffer;

		public float[] floatBuffer;

		public double[] doubleBuffer;

		public ushort[] indexBuffer;

		public static string[] defaultStringBuffer = new string[4];

		public static int[] defaultIntBuffer = new int[4];

		public static uint[] defaultUIntBuffer = new uint[4];

		public static long[] defaultLongBuffer = new long[4];

		public static float[] defaultFloatBuffer = new float[4];

		public static double[] defaultDoubleBuffe = new double[4];
	}
}
