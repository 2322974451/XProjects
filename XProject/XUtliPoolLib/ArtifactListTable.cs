using System;

namespace XUtliPoolLib
{
	// Token: 0x020000B0 RID: 176
	public class ArtifactListTable : CVSReader
	{
		// Token: 0x06000535 RID: 1333 RVA: 0x00016E64 File Offset: 0x00015064
		public ArtifactListTable.RowData GetByArtifactID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ArtifactListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ArtifactID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00016ED0 File Offset: 0x000150D0
		protected override void ReadLine(XBinaryReader reader)
		{
			ArtifactListTable.RowData rowData = new ArtifactListTable.RowData();
			base.Read<uint>(reader, ref rowData.ArtifactID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ArtifactPos, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ArtifactSuit, CVSReader.uintParse);
			this.columnno = 2;
			rowData.Attributes1.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.Attributes2.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.Attributes3.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.EffectNum, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.EffectDes, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.AttrType, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.IsCanRecast, CVSReader.uintParse);
			this.columnno = 11;
			rowData.RecastMaterials.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.IsCanFuse, CVSReader.uintParse);
			this.columnno = 13;
			rowData.FuseMaterials.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			rowData.FuseSucRate.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.FuseSucRateUseStone, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<byte>(reader, ref rowData.IsCanRefined, CVSReader.byteParse);
			this.columnno = 20;
			rowData.RefinedMaterials.Read(reader, this.m_DataHandler);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.ElementType, CVSReader.uintParse);
			this.columnno = 22;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x000170D8 File Offset: 0x000152D8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ArtifactListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D6 RID: 726
		public ArtifactListTable.RowData[] Table = null;

		// Token: 0x020002AE RID: 686
		public class RowData
		{
			// Token: 0x040008E3 RID: 2275
			public uint ArtifactID;

			// Token: 0x040008E4 RID: 2276
			public uint ArtifactPos;

			// Token: 0x040008E5 RID: 2277
			public uint ArtifactSuit;

			// Token: 0x040008E6 RID: 2278
			public SeqListRef<uint> Attributes1;

			// Token: 0x040008E7 RID: 2279
			public SeqListRef<uint> Attributes2;

			// Token: 0x040008E8 RID: 2280
			public SeqListRef<uint> Attributes3;

			// Token: 0x040008E9 RID: 2281
			public uint EffectNum;

			// Token: 0x040008EA RID: 2282
			public string EffectDes;

			// Token: 0x040008EB RID: 2283
			public uint AttrType;

			// Token: 0x040008EC RID: 2284
			public uint IsCanRecast;

			// Token: 0x040008ED RID: 2285
			public SeqListRef<uint> RecastMaterials;

			// Token: 0x040008EE RID: 2286
			public uint IsCanFuse;

			// Token: 0x040008EF RID: 2287
			public SeqListRef<uint> FuseMaterials;

			// Token: 0x040008F0 RID: 2288
			public SeqRef<uint> FuseSucRate;

			// Token: 0x040008F1 RID: 2289
			public uint FuseSucRateUseStone;

			// Token: 0x040008F2 RID: 2290
			public byte IsCanRefined;

			// Token: 0x040008F3 RID: 2291
			public SeqListRef<uint> RefinedMaterials;

			// Token: 0x040008F4 RID: 2292
			public uint ElementType;
		}
	}
}
