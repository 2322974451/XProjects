using System;

namespace XUtliPoolLib
{
	// Token: 0x0200023A RID: 570
	public class MobaSignalTable : CVSReader
	{
		// Token: 0x06000C93 RID: 3219 RVA: 0x000422AC File Offset: 0x000404AC
		public MobaSignalTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaSignalTable.RowData result;
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

		// Token: 0x06000C94 RID: 3220 RVA: 0x00042318 File Offset: 0x00040518
		protected override void ReadLine(XBinaryReader reader)
		{
			MobaSignalTable.RowData rowData = new MobaSignalTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Audio, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x000423E0 File Offset: 0x000405E0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaSignalTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000788 RID: 1928
		public MobaSignalTable.RowData[] Table = null;

		// Token: 0x020003C9 RID: 969
		public class RowData
		{
			// Token: 0x04001110 RID: 4368
			public uint ID;

			// Token: 0x04001111 RID: 4369
			public string Text;

			// Token: 0x04001112 RID: 4370
			public string Icon;

			// Token: 0x04001113 RID: 4371
			public string Effect;

			// Token: 0x04001114 RID: 4372
			public string Audio;

			// Token: 0x04001115 RID: 4373
			public int[] SceneType;
		}
	}
}
