using System;

namespace XUtliPoolLib
{

	public class DragonExpList : CVSReader
	{

		public DragonExpList.RowData GetBySceneID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonExpList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneID == key;
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
			DragonExpList.RowData rowData = new DragonExpList.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 1;
			rowData.WinReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ResName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BuffDes, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.SealLevel, CVSReader.uintParse);
			this.columnno = 9;
			rowData.ChapterID.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.WinHit, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<float>(reader, ref rowData.LimitPos, CVSReader.floatParse);
			this.columnno = 13;
			base.ReadArray<float>(reader, ref rowData.SnapPos, CVSReader.floatParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonExpList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonExpList.RowData[] Table = null;

		public class RowData
		{

			public uint SceneID;

			public string Description;

			public SeqListRef<uint> WinReward;

			public string ResName;

			public string BuffIcon;

			public string BuffDes;

			public uint BossID;

			public uint SealLevel;

			public SeqRef<uint> ChapterID;

			public string WinHit;

			public float LimitPos;

			public float[] SnapPos;
		}
	}
}
