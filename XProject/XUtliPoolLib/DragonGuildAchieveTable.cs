using System;

namespace XUtliPoolLib
{
	// Token: 0x02000250 RID: 592
	public class DragonGuildAchieveTable : CVSReader
	{
		// Token: 0x06000CE4 RID: 3300 RVA: 0x00043D34 File Offset: 0x00041F34
		public DragonGuildAchieveTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildAchieveTable.RowData result;
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

		// Token: 0x06000CE5 RID: 3301 RVA: 0x00043DA0 File Offset: 0x00041FA0
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildAchieveTable.RowData rowData = new DragonGuildAchieveTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.guildExp, CVSReader.uintParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.dropID, CVSReader.uintParse);
			this.columnno = 8;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.chestCount, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x00043F04 File Offset: 0x00042104
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildAchieveTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400079E RID: 1950
		public DragonGuildAchieveTable.RowData[] Table = null;

		// Token: 0x020003DF RID: 991
		public class RowData
		{
			// Token: 0x04001175 RID: 4469
			public uint ID;

			// Token: 0x04001176 RID: 4470
			public uint Type;

			// Token: 0x04001177 RID: 4471
			public string name;

			// Token: 0x04001178 RID: 4472
			public string description;

			// Token: 0x04001179 RID: 4473
			public string icon;

			// Token: 0x0400117A RID: 4474
			public uint SceneID;

			// Token: 0x0400117B RID: 4475
			public uint count;

			// Token: 0x0400117C RID: 4476
			public uint guildExp;

			// Token: 0x0400117D RID: 4477
			public uint[] dropID;

			// Token: 0x0400117E RID: 4478
			public SeqListRef<uint> viewabledrop;

			// Token: 0x0400117F RID: 4479
			public uint chestCount;

			// Token: 0x04001180 RID: 4480
			public uint value;
		}
	}
}
