using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D8 RID: 216
	public class DanceConfig : CVSReader
	{
		// Token: 0x060005E1 RID: 1505 RVA: 0x0001B560 File Offset: 0x00019760
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

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001B598 File Offset: 0x00019798
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

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001B674 File Offset: 0x00019874
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

		// Token: 0x060005E4 RID: 1508 RVA: 0x0001B860 File Offset: 0x00019A60
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

		// Token: 0x04000324 RID: 804
		public DanceConfig.RowData[] Table = null;

		// Token: 0x020002D7 RID: 727
		public class RowData
		{
			// Token: 0x040009D4 RID: 2516
			public uint MotionID;

			// Token: 0x040009D5 RID: 2517
			public string MotionName;

			// Token: 0x040009D6 RID: 2518
			public int PresentID;

			// Token: 0x040009D7 RID: 2519
			public string Motion;

			// Token: 0x040009D8 RID: 2520
			public string Music;

			// Token: 0x040009D9 RID: 2521
			public int LoopCount;

			// Token: 0x040009DA RID: 2522
			public string EffectPath;

			// Token: 0x040009DB RID: 2523
			public float EffectTime;

			// Token: 0x040009DC RID: 2524
			public int Type;

			// Token: 0x040009DD RID: 2525
			public string HallBtnIcon;

			// Token: 0x040009DE RID: 2526
			public bool LoverMotion;

			// Token: 0x040009DF RID: 2527
			public SeqListRef<uint> Condition;

			// Token: 0x040009E0 RID: 2528
			public string[] ConditionDesc;

			// Token: 0x040009E1 RID: 2529
			public string[] GoText;

			// Token: 0x040009E2 RID: 2530
			public int[] GoSystemID;

			// Token: 0x040009E3 RID: 2531
			public uint MotionType;

			// Token: 0x040009E4 RID: 2532
			public string IconAtlas;
		}
	}
}
