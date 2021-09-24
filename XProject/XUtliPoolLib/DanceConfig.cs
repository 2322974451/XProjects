using System;

namespace XUtliPoolLib
{

	public class DanceConfig : CVSReader
	{

		public DanceConfig.RowData GetByMotionID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DanceConfig.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchMotionID(key);
			}
			return result;
		}

		private DanceConfig.RowData BinarySearchMotionID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			DanceConfig.RowData rowData;
			DanceConfig.RowData rowData2;
			DanceConfig.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.MotionID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.MotionID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.MotionID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.MotionID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			DanceConfig.RowData rowData = new DanceConfig.RowData();
			base.Read<uint>(reader, ref rowData.MotionID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.MotionName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.PresentID, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Motion, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Music, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.LoopCount, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.EffectPath, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<float>(reader, ref rowData.EffectTime, CVSReader.floatParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.HallBtnIcon, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<bool>(reader, ref rowData.LoverMotion, CVSReader.boolParse);
			this.columnno = 10;
			rowData.Condition.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			base.ReadArray<string>(reader, ref rowData.ConditionDesc, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<string>(reader, ref rowData.GoText, CVSReader.stringParse);
			this.columnno = 13;
			base.ReadArray<int>(reader, ref rowData.GoSystemID, CVSReader.intParse);
			this.columnno = 14;
			base.Read<uint>(reader, ref rowData.MotionType, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.IconAtlas, CVSReader.stringParse);
			this.columnno = 16;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DanceConfig.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DanceConfig.RowData[] Table = null;

		public class RowData
		{

			public uint MotionID;

			public string MotionName;

			public int PresentID;

			public string Motion;

			public string Music;

			public int LoopCount;

			public string EffectPath;

			public float EffectTime;

			public int Type;

			public string HallBtnIcon;

			public bool LoverMotion;

			public SeqListRef<uint> Condition;

			public string[] ConditionDesc;

			public string[] GoText;

			public int[] GoSystemID;

			public uint MotionType;

			public string IconAtlas;
		}
	}
}
