using System;
using System.IO;

namespace XUtliPoolLib
{

	public abstract class CVSReader
	{

		public string error
		{
			get
			{
				return " line: " + this.lineno.ToString() + " column: " + this.columnno.ToString();
			}
		}

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

		public CVSReader()
		{
			this.lineno = 1;
		}

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

		public void Clear()
		{
			this.OnClear(0);
		}

		protected bool Read<T>(XBinaryReader stream, ref T v, CVSReader.ValueParse<T> parse)
		{
			parse.Read(stream, ref v, this);
			return true;
		}

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

		protected abstract void OnClear(int lineCount);

		protected virtual void ReadLine(XBinaryReader reader)
		{
		}

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

		protected static CVSReader.FloatParse floatParse = new CVSReader.FloatParse();

		protected static CVSReader.DoubleParse doubleParse = new CVSReader.DoubleParse();

		protected static CVSReader.UIntParse uintParse = new CVSReader.UIntParse();

		protected static CVSReader.IntParse intParse = new CVSReader.IntParse();

		protected static CVSReader.LongParse longParse = new CVSReader.LongParse();

		protected static CVSReader.StringParse stringParse = new CVSReader.StringParse();

		protected static CVSReader.BoolParse boolParse = new CVSReader.BoolParse();

		protected static CVSReader.ByteParse byteParse = new CVSReader.ByteParse();

		protected static CVSReader.ShortParse shortParse = new CVSReader.ShortParse();

		public int lineno = -1;

		public int columnno = -1;

		protected DataHandler m_DataHandler = null;

		public abstract class ValueParse<T>
		{

			public abstract T[] GetBuffer(DataHandler dh);

			public abstract void Read(XBinaryReader stream, ref T t, CVSReader reader);
		}

		public sealed class UIntParse : CVSReader.ValueParse<uint>
		{

			public override uint[] GetBuffer(DataHandler dh)
			{
				return dh.uintBuffer;
			}

			public override void Read(XBinaryReader stream, ref uint t, CVSReader reader)
			{
				t = stream.ReadUInt32();
			}
		}

		public sealed class IntParse : CVSReader.ValueParse<int>
		{

			public override int[] GetBuffer(DataHandler dh)
			{
				return dh.intBuffer;
			}

			public override void Read(XBinaryReader stream, ref int t, CVSReader reader)
			{
				t = stream.ReadInt32();
			}
		}

		public sealed class LongParse : CVSReader.ValueParse<long>
		{

			public override long[] GetBuffer(DataHandler dh)
			{
				return dh.longBuffer;
			}

			public override void Read(XBinaryReader stream, ref long t, CVSReader reader)
			{
				t = stream.ReadInt64();
			}
		}

		public sealed class FloatParse : CVSReader.ValueParse<float>
		{

			public override float[] GetBuffer(DataHandler dh)
			{
				return dh.floatBuffer;
			}

			public override void Read(XBinaryReader stream, ref float t, CVSReader reader)
			{
				t = stream.ReadSingle();
			}
		}

		public sealed class DoubleParse : CVSReader.ValueParse<double>
		{

			public override double[] GetBuffer(DataHandler dh)
			{
				return dh.doubleBuffer;
			}

			public override void Read(XBinaryReader stream, ref double t, CVSReader reader)
			{
				t = stream.ReadDouble();
			}
		}

		public sealed class StringParse : CVSReader.ValueParse<string>
		{

			public override string[] GetBuffer(DataHandler dh)
			{
				return dh.stringBuffer;
			}

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

		public sealed class BoolParse : CVSReader.ValueParse<bool>
		{

			public override bool[] GetBuffer(DataHandler dh)
			{
				return null;
			}

			public override void Read(XBinaryReader stream, ref bool t, CVSReader reader)
			{
				t = stream.ReadBoolean();
			}
		}

		public sealed class ByteParse : CVSReader.ValueParse<byte>
		{

			public override byte[] GetBuffer(DataHandler dh)
			{
				return null;
			}

			public override void Read(XBinaryReader stream, ref byte t, CVSReader reader)
			{
				t = stream.ReadByte();
			}
		}

		public sealed class ShortParse : CVSReader.ValueParse<short>
		{

			public override short[] GetBuffer(DataHandler dh)
			{
				return null;
			}

			public override void Read(XBinaryReader stream, ref short t, CVSReader reader)
			{
				t = stream.ReadInt16();
			}

			public short[] buffer = null;
		}

		public delegate int RowDataCompare<Trowdata, Ttype>(Trowdata rowData, Ttype key);
	}
}
