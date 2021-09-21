using System;

namespace XUtliPoolLib
{
	// Token: 0x02000140 RID: 320
	public class PetInfoTable : CVSReader
	{
		// Token: 0x06000768 RID: 1896 RVA: 0x00025660 File Offset: 0x00023860
		public PetInfoTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PetInfoTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x000256CC File Offset: 0x000238CC
		protected override void ReadLine(XBinaryReader reader)
		{
			PetInfoTable.RowData rowData = new PetInfoTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.quality, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.LvRequire, CVSReader.uintParse);
			this.columnno = 10;
			rowData.skill1.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.skill2.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.skill3.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.SpeedBuff, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.randSkillMax, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.maxHungry, CVSReader.uintParse);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.presentID, CVSReader.uintParse);
			this.columnno = 24;
			base.Read<uint>(reader, ref rowData.PetType, CVSReader.uintParse);
			this.columnno = 28;
			base.Read<uint>(reader, ref rowData.WithWings, CVSReader.uintParse);
			this.columnno = 29;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 30;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00025888 File Offset: 0x00023A88
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PetInfoTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400038C RID: 908
		public PetInfoTable.RowData[] Table = null;

		// Token: 0x0200033F RID: 831
		public class RowData
		{
			// Token: 0x04000CDB RID: 3291
			public uint id;

			// Token: 0x04000CDC RID: 3292
			public string name;

			// Token: 0x04000CDD RID: 3293
			public uint quality;

			// Token: 0x04000CDE RID: 3294
			public uint[] LvRequire;

			// Token: 0x04000CDF RID: 3295
			public SeqListRef<uint> skill1;

			// Token: 0x04000CE0 RID: 3296
			public SeqListRef<uint> skill2;

			// Token: 0x04000CE1 RID: 3297
			public SeqListRef<uint> skill3;

			// Token: 0x04000CE2 RID: 3298
			public uint SpeedBuff;

			// Token: 0x04000CE3 RID: 3299
			public string icon;

			// Token: 0x04000CE4 RID: 3300
			public uint randSkillMax;

			// Token: 0x04000CE5 RID: 3301
			public uint maxHungry;

			// Token: 0x04000CE6 RID: 3302
			public uint presentID;

			// Token: 0x04000CE7 RID: 3303
			public uint PetType;

			// Token: 0x04000CE8 RID: 3304
			public uint WithWings;

			// Token: 0x04000CE9 RID: 3305
			public string Atlas;
		}
	}
}
