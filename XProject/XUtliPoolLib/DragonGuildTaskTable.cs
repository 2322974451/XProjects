using System;

namespace XUtliPoolLib
{
	// Token: 0x0200024F RID: 591
	public class DragonGuildTaskTable : CVSReader
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x00043B3C File Offset: 0x00041D3C
		public DragonGuildTaskTable.RowData GetBytaskID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildTaskTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].taskID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x00043BA8 File Offset: 0x00041DA8
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildTaskTable.RowData rowData = new DragonGuildTaskTable.RowData();
			base.Read<uint>(reader, ref rowData.taskID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.taskType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			rowData.worldlevel.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.guildExp, CVSReader.uintParse);
			this.columnno = 7;
			rowData.viewabledrop.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.ReadArray<uint>(reader, ref rowData.dropID, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CE2 RID: 3298 RVA: 0x00043CF4 File Offset: 0x00041EF4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildTaskTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400079D RID: 1949
		public DragonGuildTaskTable.RowData[] Table = null;

		// Token: 0x020003DE RID: 990
		public class RowData
		{
			// Token: 0x0400116A RID: 4458
			public uint taskID;

			// Token: 0x0400116B RID: 4459
			public uint taskType;

			// Token: 0x0400116C RID: 4460
			public string name;

			// Token: 0x0400116D RID: 4461
			public uint SceneID;

			// Token: 0x0400116E RID: 4462
			public string icon;

			// Token: 0x0400116F RID: 4463
			public SeqRef<uint> worldlevel;

			// Token: 0x04001170 RID: 4464
			public uint count;

			// Token: 0x04001171 RID: 4465
			public uint guildExp;

			// Token: 0x04001172 RID: 4466
			public SeqListRef<uint> viewabledrop;

			// Token: 0x04001173 RID: 4467
			public uint[] dropID;

			// Token: 0x04001174 RID: 4468
			public uint value;
		}
	}
}
