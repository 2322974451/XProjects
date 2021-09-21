using System;

namespace XUtliPoolLib
{
	// Token: 0x02000246 RID: 582
	public class TaJieHelpTab : CVSReader
	{
		// Token: 0x06000CBF RID: 3263 RVA: 0x000430F8 File Offset: 0x000412F8
		public TaJieHelpTab.RowData GetByIndex(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			TaJieHelpTab.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Index == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000CC0 RID: 3264 RVA: 0x00043164 File Offset: 0x00041364
		protected override void ReadLine(XBinaryReader reader)
		{
			TaJieHelpTab.RowData rowData = new TaJieHelpTab.RowData();
			base.Read<uint>(reader, ref rowData.Index, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Des, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CC1 RID: 3265 RVA: 0x0004322C File Offset: 0x0004142C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TaJieHelpTab.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000794 RID: 1940
		public TaJieHelpTab.RowData[] Table = null;

		// Token: 0x020003D5 RID: 981
		public class RowData
		{
			// Token: 0x04001143 RID: 4419
			public uint Index;

			// Token: 0x04001144 RID: 4420
			public uint[] Type;

			// Token: 0x04001145 RID: 4421
			public uint SysID;

			// Token: 0x04001146 RID: 4422
			public string IconName;

			// Token: 0x04001147 RID: 4423
			public string Des;

			// Token: 0x04001148 RID: 4424
			public string Name;
		}
	}
}
