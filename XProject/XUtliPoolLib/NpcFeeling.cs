using System;

namespace XUtliPoolLib
{

	public class NpcFeeling : CVSReader
	{

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

		public NpcFeeling.RowData[] Table = null;

		public class RowData
		{

			public uint npcId;

			public string name;

			public string introduction;

			public uint openLevel;

			public SeqRef<uint> feelingLevel;

			public SeqListRef<uint> likeItem;

			public SeqListRef<uint> randomItem;

			public SeqListRef<uint> favorItem;

			public SeqListRef<uint> clientItem;

			public SeqListRef<uint> exchangeGive;

			public SeqListRef<uint> exchangeGet;

			public SeqListRef<uint> npcReturn;

			public string[] giveWords;

			public string[] giveSuccessWords;

			public string[] exchangeWords;

			public string[] exchangeSuccessWords;

			public uint npcReturnMailConf;

			public string icon;

			public uint unionId;

			public string relicsName;

			public string relicsIcon;

			public string relicsDesc;

			public uint xnpclistid;
		}
	}
}
