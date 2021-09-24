using System;

namespace XUtliPoolLib
{

	public class HeroBattleMapCenter : CVSReader
	{

		public HeroBattleMapCenter.RowData GetBySceneID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleMapCenter.RowData result;
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
			HeroBattleMapCenter.RowData rowData = new HeroBattleMapCenter.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.CenterType, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Center.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.ReadArray<float>(reader, ref rowData.Param, CVSReader.floatParse);
			this.columnno = 3;
			base.Read<float>(reader, ref rowData.ClientFxScalse, CVSReader.floatParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.OccupantFx, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.MiniMapFx, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OccSuccessFx, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.OccWinFx, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.MVPCutScene, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<float>(reader, ref rowData.MVPPos, CVSReader.floatParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleMapCenter.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public HeroBattleMapCenter.RowData[] Table = null;

		public class RowData
		{

			public uint SceneID;

			public uint CenterType;

			public SeqRef<float> Center;

			public float[] Param;

			public float ClientFxScalse;

			public string[] OccupantFx;

			public string[] MiniMapFx;

			public string[] OccSuccessFx;

			public string[] OccWinFx;

			public string MVPCutScene;

			public float[] MVPPos;
		}
	}
}
