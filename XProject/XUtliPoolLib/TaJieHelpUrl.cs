using System;

namespace XUtliPoolLib
{

	public class TaJieHelpUrl : CVSReader
	{

		public TaJieHelpUrl.RowData GetBySceneId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			TaJieHelpUrl.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneId == key;
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
			TaJieHelpUrl.RowData rowData = new TaJieHelpUrl.RowData();
			base.Read<uint>(reader, ref rowData.SceneId, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Url, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TaJieHelpUrl.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TaJieHelpUrl.RowData[] Table = null;

		public class RowData
		{

			public uint SceneId;

			public string Url;

			public string Name;
		}
	}
}
