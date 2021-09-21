using System;

namespace XUtliPoolLib
{
	// Token: 0x02000251 RID: 593
	public class DragonGuildConfigTable : CVSReader
	{
		// Token: 0x06000CE8 RID: 3304 RVA: 0x00043F44 File Offset: 0x00042144
		public DragonGuildConfigTable.RowData GetByDragonGuildLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].DragonGuildLevel == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00043FB0 File Offset: 0x000421B0
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildConfigTable.RowData rowData = new DragonGuildConfigTable.RowData();
			base.Read<uint>(reader, ref rowData.DragonGuildLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DragonGuildExpNeed, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DragonGuildNumber, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.PresidentNum, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.VicePresidentNum, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0004405C File Offset: 0x0004225C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400079F RID: 1951
		public DragonGuildConfigTable.RowData[] Table = null;

		// Token: 0x020003E0 RID: 992
		public class RowData
		{
			// Token: 0x04001181 RID: 4481
			public uint DragonGuildLevel;

			// Token: 0x04001182 RID: 4482
			public uint DragonGuildExpNeed;

			// Token: 0x04001183 RID: 4483
			public uint DragonGuildNumber;

			// Token: 0x04001184 RID: 4484
			public uint PresidentNum;

			// Token: 0x04001185 RID: 4485
			public uint VicePresidentNum;
		}
	}
}
