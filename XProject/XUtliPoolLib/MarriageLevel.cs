using System;

namespace XUtliPoolLib
{
	// Token: 0x0200026F RID: 623
	public class MarriageLevel : CVSReader
	{
		// Token: 0x06000D4E RID: 3406 RVA: 0x000463EC File Offset: 0x000445EC
		public MarriageLevel.RowData GetByLevel(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MarriageLevel.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Level == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x00046458 File Offset: 0x00044658
		protected override void ReadLine(XBinaryReader reader)
		{
			MarriageLevel.RowData rowData = new MarriageLevel.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.NeedIntimacyValue, CVSReader.intParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.PrerogativeID, CVSReader.uintParse);
			this.columnno = 2;
			rowData.PrerogativeItems.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.PrivilegeBuffs.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x00046538 File Offset: 0x00044738
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MarriageLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007BD RID: 1981
		public MarriageLevel.RowData[] Table = null;

		// Token: 0x020003FE RID: 1022
		public class RowData
		{
			// Token: 0x04001235 RID: 4661
			public int Level;

			// Token: 0x04001236 RID: 4662
			public int NeedIntimacyValue;

			// Token: 0x04001237 RID: 4663
			public uint PrerogativeID;

			// Token: 0x04001238 RID: 4664
			public SeqRef<uint> PrerogativeItems;

			// Token: 0x04001239 RID: 4665
			public SeqRef<uint> PrivilegeBuffs;

			// Token: 0x0400123A RID: 4666
			public string BuffIcon;

			// Token: 0x0400123B RID: 4667
			public string Desc;
		}
	}
}
