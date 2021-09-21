using System;

namespace XUtliPoolLib
{
	// Token: 0x02000257 RID: 599
	public class NpcFeeling : CVSReader
	{
		// Token: 0x06000D00 RID: 3328 RVA: 0x00044858 File Offset: 0x00042A58
		protected override void ReadLine(XBinaryReader reader)
		{
			NpcFeeling.RowData rowData = new NpcFeeling.RowData();
			base.Read<uint>(reader, ref rowData.npcId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.introduction, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.openLevel, CVSReader.uintParse);
			this.columnno = 3;
			rowData.feelingLevel.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.likeItem.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.randomItem.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.favorItem.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			rowData.clientItem.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.exchangeGive.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.exchangeGet.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			rowData.npcReturn.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			base.ReadArray<string>(reader, ref rowData.giveWords, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<string>(reader, ref rowData.giveSuccessWords, CVSReader.stringParse);
			this.columnno = 13;
			base.ReadArray<string>(reader, ref rowData.exchangeWords, CVSReader.stringParse);
			this.columnno = 14;
			base.ReadArray<string>(reader, ref rowData.exchangeSuccessWords, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.npcReturnMailConf, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.unionId, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.relicsName, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.relicsIcon, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.relicsDesc, CVSReader.stringParse);
			this.columnno = 21;
			base.Read<uint>(reader, ref rowData.xnpclistid, CVSReader.uintParse);
			this.columnno = 22;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D01 RID: 3329 RVA: 0x00044AE8 File Offset: 0x00042CE8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NpcFeeling.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A5 RID: 1957
		public NpcFeeling.RowData[] Table = null;

		// Token: 0x020003E6 RID: 998
		public class RowData
		{
			// Token: 0x040011A4 RID: 4516
			public uint npcId;

			// Token: 0x040011A5 RID: 4517
			public string name;

			// Token: 0x040011A6 RID: 4518
			public string introduction;

			// Token: 0x040011A7 RID: 4519
			public uint openLevel;

			// Token: 0x040011A8 RID: 4520
			public SeqRef<uint> feelingLevel;

			// Token: 0x040011A9 RID: 4521
			public SeqListRef<uint> likeItem;

			// Token: 0x040011AA RID: 4522
			public SeqListRef<uint> randomItem;

			// Token: 0x040011AB RID: 4523
			public SeqListRef<uint> favorItem;

			// Token: 0x040011AC RID: 4524
			public SeqListRef<uint> clientItem;

			// Token: 0x040011AD RID: 4525
			public SeqListRef<uint> exchangeGive;

			// Token: 0x040011AE RID: 4526
			public SeqListRef<uint> exchangeGet;

			// Token: 0x040011AF RID: 4527
			public SeqListRef<uint> npcReturn;

			// Token: 0x040011B0 RID: 4528
			public string[] giveWords;

			// Token: 0x040011B1 RID: 4529
			public string[] giveSuccessWords;

			// Token: 0x040011B2 RID: 4530
			public string[] exchangeWords;

			// Token: 0x040011B3 RID: 4531
			public string[] exchangeSuccessWords;

			// Token: 0x040011B4 RID: 4532
			public uint npcReturnMailConf;

			// Token: 0x040011B5 RID: 4533
			public string icon;

			// Token: 0x040011B6 RID: 4534
			public uint unionId;

			// Token: 0x040011B7 RID: 4535
			public string relicsName;

			// Token: 0x040011B8 RID: 4536
			public string relicsIcon;

			// Token: 0x040011B9 RID: 4537
			public string relicsDesc;

			// Token: 0x040011BA RID: 4538
			public uint xnpclistid;
		}
	}
}
