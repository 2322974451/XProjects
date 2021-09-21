using System;
using System.IO;

namespace XUtliPoolLib
{
	// Token: 0x020000CD RID: 205
	public abstract class CVSReader
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0001A858 File Offset: 0x00018A58
		public string error
		{
			get
			{
				return " line: " + this.lineno.ToString() + " column: " + this.columnno.ToString();
			}
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0001A890 File Offset: 0x00018A90
		public static void Init()
		{
			SeqRef<string>.parser = CVSReader.stringParse;
			SeqRef<int>.parser = CVSReader.intParse;
			SeqRef<uint>.parser = CVSReader.uintParse;
			SeqRef<long>.parser = CVSReader.longParse;
			SeqRef<float>.parser = CVSReader.floatParse;
			SeqRef<double>.parser = CVSReader.doubleParse;
			SeqListRef<string>.parser = CVSReader.stringParse;
			SeqListRef<int>.parser = CVSReader.intParse;
			SeqListRef<uint>.parser = CVSReader.uintParse;
			SeqListRef<long>.parser = CVSReader.longParse;
			SeqListRef<float>.parser = CVSReader.floatParse;
			SeqListRef<double>.parser = CVSReader.doubleParse;
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0001A916 File Offset: 0x00018B16
		public CVSReader()
		{
			this.lineno = 1;
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x0001A93C File Offset: 0x00018B3C
		public bool ReadFile(XBinaryReader reader)
		{
			this.lineno = 0;
			this.columnno = -1;
			int num = reader.ReadInt32();
			int num2 = reader.ReadInt32();
			this.OnClear(num2);
			this.m_DataHandler = new DataHandler();
			this.m_DataHandler.Init(reader);
			byte b = reader.ReadByte();
			for (int i = 0; i < (int)b; i++)
			{
				byte b2 = reader.ReadByte();
				byte b3 = reader.ReadByte();
			}
			for (int j = 0; j < num2; j++)
			{
				int num3 = reader.ReadInt32();
				int position = reader.GetPosition();
				this.ReadLine(reader);
				int position2 = reader.GetPosition();
				int num4 = position2 - position;
				bool flag = num3 > num4;
				if (flag)
				{
					reader.Seek(num3 - num4, SeekOrigin.Current);
				}
				else
				{
					bool flag2 = num3 < num4;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog2("read table error:{0} line:{1} column:{2}", new object[]
						{
							base.GetType().Name,
							this.lineno + 1,
							this.columnno
						});
						break;
					}
				}
				this.lineno++;
				bool flag3 = this.columnno > 0;
				if (flag3)
				{
					break;
				}
			}
			int position3 = reader.GetPosition();
			bool flag4 = position3 != num;
			if (flag4)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("read table error:{0} size:{1} read size:{2}", new object[]
				{
					base.GetType().Name,
					num,
					position3
				});
			}
			this.m_DataHandler.UnInit(false);
			return this.columnno == -1;
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001AAF1 File Offset: 0x00018CF1
		public void Clear()
		{
			this.OnClear(0);
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001AAFC File Offset: 0x00018CFC
		protected bool Read<T>(XBinaryReader stream, ref T v, CVSReader.ValueParse<T> parse)
		{
			parse.Read(stream, ref v, this);
			return true;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001AB1C File Offset: 0x00018D1C
		protected bool ReadArray<T>(XBinaryReader stream, ref T[] v, CVSReader.ValueParse<T> parse)
		{
			byte b = stream.ReadByte();
			bool flag = b > 0;
			if (flag)
			{
				v = new T[(int)b];
				for (byte b2 = 0; b2 < b; b2 += 1)
				{
					parse.Read(stream, ref v[(int)b2], this);
				}
			}
			else
			{
				v = null;
			}
			return true;
		}

		// Token: 0x060005C0 RID: 1472
		protected abstract void OnClear(int lineCount);

		// Token: 0x060005C1 RID: 1473 RVA: 0x00003284 File Offset: 0x00001484
		protected virtual void ReadLine(XBinaryReader reader)
		{
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x0001AB78 File Offset: 0x00018D78
		public static void GetRowDataListByField<Trowdata, Ttype>(Trowdata[] table, Ttype field, out int startIndex, out int endIndex, CVSReader.RowDataCompare<Trowdata, Ttype> comp) where Ttype : IComparable
		{
			startIndex = -1;
			endIndex = -1;
			int num = 0;
			int num2 = table.Length - 1;
			int num3 = -1;
			int num4;
			for (;;)
			{
				Trowdata rowData = table[num];
				bool flag = comp(rowData, field) == 0;
				if (flag)
				{
					break;
				}
				Trowdata rowData2 = table[num2];
				bool flag2 = comp(rowData2, field) == 0;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				num4 = num + (num2 - num) / 2;
				Trowdata rowData3 = table[num4];
				bool flag4 = comp(rowData3, field) < 0;
				if (flag4)
				{
					num2 = num4;
				}
				else
				{
					bool flag5 = comp(rowData3, field) > 0;
					if (!flag5)
					{
						goto IL_AE;
					}
					num = num4;
				}
				if (num >= num2)
				{
					goto IL_C2;
				}
			}
			num3 = num;
			goto IL_C2;
			Block_2:
			num3 = num2;
			Block_3:
			goto IL_C2;
			IL_AE:
			num3 = num4;
			IL_C2:
			bool flag6 = num3 >= 0;
			if (flag6)
			{
				startIndex = num3;
				endIndex = num3;
				bool flag7 = num3 > 0;
				if (flag7)
				{
					for (int i = num3 - 1; i >= 0; i--)
					{
						Trowdata rowData4 = table[i];
						bool flag8 = comp(rowData4, field) != 0;
						if (flag8)
						{
							break;
						}
						startIndex = i;
					}
				}
				bool flag9 = num3 < table.Length - 1;
				if (flag9)
				{
					for (int j = num3 + 1; j < table.Length; j++)
					{
						Trowdata rowData5 = table[j];
						bool flag10 = comp(rowData5, field) != 0;
						if (flag10)
						{
							break;
						}
						endIndex = j;
					}
				}
			}
		}

		// Token: 0x04000309 RID: 777
		protected static CVSReader.FloatParse floatParse = new CVSReader.FloatParse();

		// Token: 0x0400030A RID: 778
		protected static CVSReader.DoubleParse doubleParse = new CVSReader.DoubleParse();

		// Token: 0x0400030B RID: 779
		protected static CVSReader.UIntParse uintParse = new CVSReader.UIntParse();

		// Token: 0x0400030C RID: 780
		protected static CVSReader.IntParse intParse = new CVSReader.IntParse();

		// Token: 0x0400030D RID: 781
		protected static CVSReader.LongParse longParse = new CVSReader.LongParse();

		// Token: 0x0400030E RID: 782
		protected static CVSReader.StringParse stringParse = new CVSReader.StringParse();

		// Token: 0x0400030F RID: 783
		protected static CVSReader.BoolParse boolParse = new CVSReader.BoolParse();

		// Token: 0x04000310 RID: 784
		protected static CVSReader.ByteParse byteParse = new CVSReader.ByteParse();

		// Token: 0x04000311 RID: 785
		protected static CVSReader.ShortParse shortParse = new CVSReader.ShortParse();

		// Token: 0x04000312 RID: 786
		public int lineno = -1;

		// Token: 0x04000313 RID: 787
		public int columnno = -1;

		// Token: 0x04000314 RID: 788
		protected DataHandler m_DataHandler = null;

		// Token: 0x020002CA RID: 714
		public abstract class ValueParse<T>
		{
			// Token: 0x06000E3F RID: 3647
			public abstract T[] GetBuffer(DataHandler dh);

			// Token: 0x06000E40 RID: 3648
			public abstract void Read(XBinaryReader stream, ref T t, CVSReader reader);
		}

		// Token: 0x020002CB RID: 715
		public sealed class UIntParse : CVSReader.ValueParse<uint>
		{
			// Token: 0x06000E42 RID: 3650 RVA: 0x0004A2AC File Offset: 0x000484AC
			public override uint[] GetBuffer(DataHandler dh)
			{
				return dh.uintBuffer;
			}

			// Token: 0x06000E43 RID: 3651 RVA: 0x0004A2C4 File Offset: 0x000484C4
			public override void Read(XBinaryReader stream, ref uint t, CVSReader reader)
			{
				t = stream.ReadUInt32();
			}
		}

		// Token: 0x020002CC RID: 716
		public sealed class IntParse : CVSReader.ValueParse<int>
		{
			// Token: 0x06000E45 RID: 3653 RVA: 0x0004A2D8 File Offset: 0x000484D8
			public override int[] GetBuffer(DataHandler dh)
			{
				return dh.intBuffer;
			}

			// Token: 0x06000E46 RID: 3654 RVA: 0x0004A2F0 File Offset: 0x000484F0
			public override void Read(XBinaryReader stream, ref int t, CVSReader reader)
			{
				t = stream.ReadInt32();
			}
		}

		// Token: 0x020002CD RID: 717
		public sealed class LongParse : CVSReader.ValueParse<long>
		{
			// Token: 0x06000E48 RID: 3656 RVA: 0x0004A304 File Offset: 0x00048504
			public override long[] GetBuffer(DataHandler dh)
			{
				return dh.longBuffer;
			}

			// Token: 0x06000E49 RID: 3657 RVA: 0x0004A31C File Offset: 0x0004851C
			public override void Read(XBinaryReader stream, ref long t, CVSReader reader)
			{
				t = stream.ReadInt64();
			}
		}

		// Token: 0x020002CE RID: 718
		public sealed class FloatParse : CVSReader.ValueParse<float>
		{
			// Token: 0x06000E4B RID: 3659 RVA: 0x0004A330 File Offset: 0x00048530
			public override float[] GetBuffer(DataHandler dh)
			{
				return dh.floatBuffer;
			}

			// Token: 0x06000E4C RID: 3660 RVA: 0x0004A348 File Offset: 0x00048548
			public override void Read(XBinaryReader stream, ref float t, CVSReader reader)
			{
				t = stream.ReadSingle();
			}
		}

		// Token: 0x020002CF RID: 719
		public sealed class DoubleParse : CVSReader.ValueParse<double>
		{
			// Token: 0x06000E4E RID: 3662 RVA: 0x0004A35C File Offset: 0x0004855C
			public override double[] GetBuffer(DataHandler dh)
			{
				return dh.doubleBuffer;
			}

			// Token: 0x06000E4F RID: 3663 RVA: 0x0004A374 File Offset: 0x00048574
			public override void Read(XBinaryReader stream, ref double t, CVSReader reader)
			{
				t = stream.ReadDouble();
			}
		}

		// Token: 0x020002D0 RID: 720
		public sealed class StringParse : CVSReader.ValueParse<string>
		{
			// Token: 0x06000E51 RID: 3665 RVA: 0x0004A388 File Offset: 0x00048588
			public override string[] GetBuffer(DataHandler dh)
			{
				return dh.stringBuffer;
			}

			// Token: 0x06000E52 RID: 3666 RVA: 0x0004A3A0 File Offset: 0x000485A0
			public override void Read(XBinaryReader stream, ref string t, CVSReader reader)
			{
				bool flag = reader.m_DataHandler != null;
				if (flag)
				{
					t = reader.m_DataHandler.ReadString(stream);
				}
				else
				{
					t = string.Intern(stream.ReadString(-1));
				}
			}
		}

		// Token: 0x020002D1 RID: 721
		public sealed class BoolParse : CVSReader.ValueParse<bool>
		{
			// Token: 0x06000E54 RID: 3668 RVA: 0x0004A3E8 File Offset: 0x000485E8
			public override bool[] GetBuffer(DataHandler dh)
			{
				return null;
			}

			// Token: 0x06000E55 RID: 3669 RVA: 0x0004A3FB File Offset: 0x000485FB
			public override void Read(XBinaryReader stream, ref bool t, CVSReader reader)
			{
				t = stream.ReadBoolean();
			}
		}

		// Token: 0x020002D2 RID: 722
		public sealed class ByteParse : CVSReader.ValueParse<byte>
		{
			// Token: 0x06000E57 RID: 3671 RVA: 0x0004A410 File Offset: 0x00048610
			public override byte[] GetBuffer(DataHandler dh)
			{
				return null;
			}

			// Token: 0x06000E58 RID: 3672 RVA: 0x0004A423 File Offset: 0x00048623
			public override void Read(XBinaryReader stream, ref byte t, CVSReader reader)
			{
				t = stream.ReadByte();
			}
		}

		// Token: 0x020002D3 RID: 723
		public sealed class ShortParse : CVSReader.ValueParse<short>
		{
			// Token: 0x06000E5A RID: 3674 RVA: 0x0004A438 File Offset: 0x00048638
			public override short[] GetBuffer(DataHandler dh)
			{
				return null;
			}

			// Token: 0x06000E5B RID: 3675 RVA: 0x0004A44B File Offset: 0x0004864B
			public override void Read(XBinaryReader stream, ref short t, CVSReader reader)
			{
				t = stream.ReadInt16();
			}

			// Token: 0x040009B7 RID: 2487
			public short[] buffer = null;
		}

		// Token: 0x020002D4 RID: 724
		// (Invoke) Token: 0x06000E5E RID: 3678
		public delegate int RowDataCompare<Trowdata, Ttype>(Trowdata rowData, Ttype key);
	}
}
