using System;

namespace XUtliPoolLib
{
	// Token: 0x02000045 RID: 69
	internal class AssetBundleDataBinaryReader : AssetBundleDataReader
	{
		// Token: 0x06000231 RID: 561 RVA: 0x00012464 File Offset: 0x00010664
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
