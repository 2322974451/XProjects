using System;

namespace XUtliPoolLib
{

	internal class AssetBundleDataBinaryReader : AssetBundleDataReader
	{

		public override void Read(XBinaryReader reader)
		{
			for (;;)
			{
				bool isEof = reader.IsEof;
				if (isEof)
				{
					break;
				}
				uint num = reader.ReadUInt32();
				uint key = reader.ReadUInt32();
				byte compositeType = reader.ReadByte();
				byte b = reader.ReadByte();
				uint[] array = null;
				bool flag = b > 0;
				if (flag)
				{
					array = new uint[(int)b];
				}
				bool flag2 = !this.shortName2FullName.ContainsKey(key);
				if (flag2)
				{
					this.shortName2FullName.Add(key, num);
				}
				for (int i = 0; i < (int)b; i++)
				{
					array[i] = reader.ReadUInt32();
				}
				AssetBundleData assetBundleData = new AssetBundleData();
				assetBundleData.fullName = num;
				assetBundleData.dependencies = array;
				assetBundleData.compositeType = (AssetBundleExportType)compositeType;
				this.infoMap[num] = assetBundleData;
			}
		}
	}
}
