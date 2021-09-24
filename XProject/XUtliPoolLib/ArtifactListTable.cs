using System;

namespace XUtliPoolLib
{

	public class ArtifactListTable : CVSReader
	{

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

		public ArtifactListTable.RowData[] Table = null;

		public class RowData
		{

			public uint ArtifactID;

			public uint ArtifactPos;

			public uint ArtifactSuit;

			public SeqListRef<uint> Attributes1;

			public SeqListRef<uint> Attributes2;

			public SeqListRef<uint> Attributes3;

			public uint EffectNum;

			public string EffectDes;

			public uint AttrType;

			public uint IsCanRecast;

			public SeqListRef<uint> RecastMaterials;

			public uint IsCanFuse;

			public SeqListRef<uint> FuseMaterials;

			public SeqRef<uint> FuseSucRate;

			public uint FuseSucRateUseStone;

			public byte IsCanRefined;

			public SeqListRef<uint> RefinedMaterials;

			public uint ElementType;
		}
	}
}
