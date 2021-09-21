using System;

namespace XUtliPoolLib
{
	// Token: 0x02000179 RID: 377
	public class SystemAnnounce : CVSReader
	{
		// Token: 0x0600083C RID: 2108 RVA: 0x0002B2DC File Offset: 0x000294DC
		public SystemAnnounce.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SystemAnnounce.RowData result;
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

		// Token: 0x0600083D RID: 2109 RVA: 0x0002B348 File Offset: 0x00029548
		protected override void ReadLine(XBinaryReader reader)
		{
			SystemAnnounce.RowData rowData = new SystemAnnounce.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.OpenAnnounceLevel, CVSReader.intParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.AnnounceDesc, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.AnnounceIcon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TextSpriteName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0002B444 File Offset: 0x00029644
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SystemAnnounce.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C5 RID: 965
		public SystemAnnounce.RowData[] Table = null;

		// Token: 0x02000378 RID: 888
		public class RowData
		{
			// Token: 0x04000EB9 RID: 3769
			public int ID;

			// Token: 0x04000EBA RID: 3770
			public int SystemID;

			// Token: 0x04000EBB RID: 3771
			public string SystemDescription;

			// Token: 0x04000EBC RID: 3772
			public int OpenAnnounceLevel;

			// Token: 0x04000EBD RID: 3773
			public string[] AnnounceDesc;

			// Token: 0x04000EBE RID: 3774
			public string AnnounceIcon;

			// Token: 0x04000EBF RID: 3775
			public string TextSpriteName;

			// Token: 0x04000EC0 RID: 3776
			public string IconName;
		}
	}
}
