using System;

namespace XUtliPoolLib
{
	// Token: 0x0200012A RID: 298
	public class MultiActivityList : CVSReader
	{
		// Token: 0x06000719 RID: 1817 RVA: 0x00023664 File Offset: 0x00021864
		public MultiActivityList.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MultiActivityList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x000236D0 File Offset: 0x000218D0
		protected override void ReadLine(XBinaryReader reader)
		{
			MultiActivityList.RowData rowData = new MultiActivityList.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			rowData.OpenDayTime.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DayCountMax, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.RewardTips, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.OpenDayTips, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<bool>(reader, ref rowData.NeedOpenAgain, CVSReader.boolParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.OpenServerWeek, CVSReader.uintParse);
			this.columnno = 12;
			rowData.DropItems.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			base.Read<bool>(reader, ref rowData.HadShop, CVSReader.boolParse);
			this.columnno = 15;
			base.Read<string>(reader, ref rowData.AtlasPath, CVSReader.stringParse);
			this.columnno = 17;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0002386C File Offset: 0x00021A6C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MultiActivityList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000376 RID: 886
		public MultiActivityList.RowData[] Table = null;

		// Token: 0x02000329 RID: 809
		public class RowData
		{
			// Token: 0x04000C37 RID: 3127
			public int ID;

			// Token: 0x04000C38 RID: 3128
			public string Name;

			// Token: 0x04000C39 RID: 3129
			public SeqListRef<uint> OpenDayTime;

			// Token: 0x04000C3A RID: 3130
			public uint GuildLevel;

			// Token: 0x04000C3B RID: 3131
			public int DayCountMax;

			// Token: 0x04000C3C RID: 3132
			public int SystemID;

			// Token: 0x04000C3D RID: 3133
			public string RewardTips;

			// Token: 0x04000C3E RID: 3134
			public string OpenDayTips;

			// Token: 0x04000C3F RID: 3135
			public string Icon;

			// Token: 0x04000C40 RID: 3136
			public bool NeedOpenAgain;

			// Token: 0x04000C41 RID: 3137
			public uint OpenServerWeek;

			// Token: 0x04000C42 RID: 3138
			public SeqListRef<uint> DropItems;

			// Token: 0x04000C43 RID: 3139
			public bool HadShop;

			// Token: 0x04000C44 RID: 3140
			public string AtlasPath;
		}
	}
}
