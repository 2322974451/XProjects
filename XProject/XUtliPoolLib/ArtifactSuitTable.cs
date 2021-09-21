using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B1 RID: 177
	public class ArtifactSuitTable : CVSReader
	{
		// Token: 0x06000539 RID: 1337 RVA: 0x00017118 File Offset: 0x00015318
		public ArtifactSuitTable.RowData GetByArtifactSuitID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ArtifactSuitTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ArtifactSuitID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00017184 File Offset: 0x00015384
		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactSuitTable.RowData rowData = new ArtifactSuitTable.RowData();
			base.Read<uint>(reader, ref rowData.ArtifactSuitID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			rowData.Effect2.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Effect3.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Effect4.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Effect5.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.Effect6.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<byte>(reader, ref rowData.IsCreateShow, CVSReader.byteParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.ElementType, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<byte>(reader, ref rowData.SuitQuality, CVSReader.byteParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x000172D0 File Offset: 0x000154D0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactSuitTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D7 RID: 727
		public ArtifactSuitTable.RowData[] Table = null;

		// Token: 0x020002AF RID: 687
		public class RowData
		{
			// Token: 0x040008F5 RID: 2293
			public uint ArtifactSuitID;

			// Token: 0x040008F6 RID: 2294
			public uint Level;

			// Token: 0x040008F7 RID: 2295
			public string Name;

			// Token: 0x040008F8 RID: 2296
			public SeqListRef<uint> Effect2;

			// Token: 0x040008F9 RID: 2297
			public SeqListRef<uint> Effect3;

			// Token: 0x040008FA RID: 2298
			public SeqListRef<uint> Effect4;

			// Token: 0x040008FB RID: 2299
			public SeqListRef<uint> Effect5;

			// Token: 0x040008FC RID: 2300
			public SeqListRef<uint> Effect6;

			// Token: 0x040008FD RID: 2301
			public byte IsCreateShow;

			// Token: 0x040008FE RID: 2302
			public uint ElementType;

			// Token: 0x040008FF RID: 2303
			public byte SuitQuality;
		}
	}
}
