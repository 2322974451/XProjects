using System;

namespace XUtliPoolLib
{
	// Token: 0x02000235 RID: 565
	public class WeekEnd4v4List : CVSReader
	{
		// Token: 0x06000C80 RID: 3200 RVA: 0x00041BB0 File Offset: 0x0003FDB0
		protected override void ReadLine(XBinaryReader reader)
		{
			WeekEnd4v4List.RowData rowData = new WeekEnd4v4List.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Index, CVSReader.uintParse);
			this.columnno = 1;
			rowData.DropItems.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Rule, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TexturePath, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.ReviveSeconds, CVSReader.uintParse);
			this.columnno = 7;
			rowData.RankPoint.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.LoseDrop.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.MaxTime, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.RewardTimes, CVSReader.uintParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00041D18 File Offset: 0x0003FF18
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WeekEnd4v4List.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000783 RID: 1923
		public WeekEnd4v4List.RowData[] Table = null;

		// Token: 0x020003C4 RID: 964
		public class RowData
		{
			// Token: 0x040010F3 RID: 4339
			public uint ID;

			// Token: 0x040010F4 RID: 4340
			public uint Index;

			// Token: 0x040010F5 RID: 4341
			public SeqListRef<uint> DropItems;

			// Token: 0x040010F6 RID: 4342
			public string Name;

			// Token: 0x040010F7 RID: 4343
			public string Rule;

			// Token: 0x040010F8 RID: 4344
			public uint SceneID;

			// Token: 0x040010F9 RID: 4345
			public string TexturePath;

			// Token: 0x040010FA RID: 4346
			public uint ReviveSeconds;

			// Token: 0x040010FB RID: 4347
			public SeqListRef<uint> RankPoint;

			// Token: 0x040010FC RID: 4348
			public SeqListRef<uint> LoseDrop;

			// Token: 0x040010FD RID: 4349
			public uint MaxTime;

			// Token: 0x040010FE RID: 4350
			public uint RewardTimes;
		}
	}
}
