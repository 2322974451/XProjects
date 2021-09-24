using System;

namespace XUtliPoolLib
{

	public class ShareBgTexture : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ShareBgTexture.RowData rowData = new ShareBgTexture.RowData();
			base.Read<int>(reader, ref rowData.ShareBgType, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.SubBgIDList, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.TexturePathList, CVSReader.stringParse);
			this.columnno = 2;
			base.ReadArray<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ShareBgTexture.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ShareBgTexture.RowData[] Table = null;

		public class RowData
		{

			public int ShareBgType;

			public uint[] SubBgIDList;

			public string[] TexturePathList;

			public string[] Text;
		}
	}
}
