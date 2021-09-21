using System;

namespace XUtliPoolLib
{
	// Token: 0x020000DD RID: 221
	public class DragonNestTable : CVSReader
	{
		// Token: 0x060005F7 RID: 1527 RVA: 0x0001C258 File Offset: 0x0001A458
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonNestTable.RowData rowData = new DragonNestTable.RowData();
			base.Read<uint>(reader, ref rowData.DragonNestID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DragonNestType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DragonNestDifficulty, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.DragonNestWave, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DragonNestPosX, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DragonNestPosY, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.DragonNestIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.SuggestAttr, CVSReader.stringParse);
			this.columnno = 7;
			rowData.WeakInfo.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.WeakTip1, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<string>(reader, ref rowData.WeakTip2, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.WeakNotPassTip1, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.WeakNotPassTip2, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<int>(reader, ref rowData.WeakPercent, CVSReader.intParse);
			this.columnno = 13;
			base.ReadArray<uint>(reader, ref rowData.WeakCombat, CVSReader.uintParse);
			this.columnno = 14;
			rowData.WeakInfoEx.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.ReadArray<string>(reader, ref rowData.WeakTip1EX, CVSReader.stringParse);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.WeakTip2EX, CVSReader.stringParse);
			this.columnno = 17;
			base.ReadArray<int>(reader, ref rowData.WeakPercentEX, CVSReader.intParse);
			this.columnno = 18;
			base.ReadArray<uint>(reader, ref rowData.WeakCombatEX, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.DragonNestAtlas, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<int>(reader, ref rowData.MaxDragonDropLevel, CVSReader.intParse);
			this.columnno = 21;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0001C4CC File Offset: 0x0001A6CC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonNestTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000329 RID: 809
		public DragonNestTable.RowData[] Table = null;

		// Token: 0x020002DC RID: 732
		public class RowData
		{
			// Token: 0x04000A1A RID: 2586
			public uint DragonNestID;

			// Token: 0x04000A1B RID: 2587
			public uint DragonNestType;

			// Token: 0x04000A1C RID: 2588
			public uint DragonNestDifficulty;

			// Token: 0x04000A1D RID: 2589
			public uint DragonNestWave;

			// Token: 0x04000A1E RID: 2590
			public int DragonNestPosX;

			// Token: 0x04000A1F RID: 2591
			public int DragonNestPosY;

			// Token: 0x04000A20 RID: 2592
			public string DragonNestIcon;

			// Token: 0x04000A21 RID: 2593
			public string SuggestAttr;

			// Token: 0x04000A22 RID: 2594
			public SeqListRef<uint> WeakInfo;

			// Token: 0x04000A23 RID: 2595
			public string[] WeakTip1;

			// Token: 0x04000A24 RID: 2596
			public string[] WeakTip2;

			// Token: 0x04000A25 RID: 2597
			public string WeakNotPassTip1;

			// Token: 0x04000A26 RID: 2598
			public string WeakNotPassTip2;

			// Token: 0x04000A27 RID: 2599
			public int[] WeakPercent;

			// Token: 0x04000A28 RID: 2600
			public uint[] WeakCombat;

			// Token: 0x04000A29 RID: 2601
			public SeqListRef<uint> WeakInfoEx;

			// Token: 0x04000A2A RID: 2602
			public string[] WeakTip1EX;

			// Token: 0x04000A2B RID: 2603
			public string[] WeakTip2EX;

			// Token: 0x04000A2C RID: 2604
			public int[] WeakPercentEX;

			// Token: 0x04000A2D RID: 2605
			public uint[] WeakCombatEX;

			// Token: 0x04000A2E RID: 2606
			public string DragonNestAtlas;

			// Token: 0x04000A2F RID: 2607
			public int MaxDragonDropLevel;
		}
	}
}
