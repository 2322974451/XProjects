using System;
using System.Collections.Generic;
using System.IO;

namespace XUtliPoolLib
{

	public class AssetBundleDataReader
	{

		public virtual void Read(XBinaryReader reader)
		{
			MemoryStream stream = new MemoryStream(reader.GetBuffer());
			StreamReader streamReader = new StreamReader(stream);
			char[] array = new char[6];
			streamReader.Read(array, 0, array.Length);
			bool flag = array[0] != 'A' || array[1] != 'B' || array[2] != 'D' || array[3] != 'T';
			if (!flag)
			{
				for (;;)
				{
					string text = streamReader.ReadLine();
					bool flag2 = string.IsNullOrEmpty(text);
					if (flag2)
					{
						break;
					}
					uint num = uint.Parse(streamReader.ReadLine().Replace(".ab", ""));
					string str = streamReader.ReadLine();
					uint key = XSingleton<XCommon>.singleton.XHash(str);
					string text2 = streamReader.ReadLine();
					int compositeType = Convert.ToInt32(streamReader.ReadLine());
					int num2 = Convert.ToInt32(streamReader.ReadLine());
					uint[] array2 = new uint[num2];
					bool flag3 = !this.shortName2FullName.ContainsKey(key);
					if (flag3)
					{
						this.shortName2FullName.Add(key, num);
					}
					for (int i = 0; i < num2; i++)
					{
						array2[i] = uint.Parse(streamReader.ReadLine().Replace(".ab", ""));
					}
					streamReader.ReadLine();
					AssetBundleData assetBundleData = new AssetBundleData();
					assetBundleData.debugName = text;
					assetBundleData.fullName = num;
					assetBundleData.dependencies = array2;
					assetBundleData.compositeType = (AssetBundleExportType)compositeType;
					this.infoMap[num] = assetBundleData;
				}
				streamReader.Close();
			}
		}

		public void Analyze()
		{
			foreach (KeyValuePair<uint, AssetBundleData> keyValuePair in this.infoMap)
			{
				this.Analyze(keyValuePair.Value);
			}
		}

		private void Analyze(AssetBundleData abd)
		{
			bool flag = !abd.isAnalyzed;
			if (flag)
			{
				abd.isAnalyzed = true;
				bool flag2 = abd.dependencies != null;
				if (flag2)
				{
					abd.dependList = new AssetBundleData[abd.dependencies.Length];
					for (int i = 0; i < abd.dependencies.Length; i++)
					{
						AssetBundleData assetBundleInfo = this.GetAssetBundleInfo(abd.dependencies[i]);
						abd.dependList[i] = assetBundleInfo;
						this.Analyze(assetBundleInfo);
					}
				}
			}
		}

		public uint GetFullName(uint shortName)
		{
			uint result = 0U;
			this.shortName2FullName.TryGetValue(shortName, out result);
			return result;
		}

		public AssetBundleData GetAssetBundleInfoByShortName(uint shortName)
		{
			uint fullName = this.GetFullName(shortName);
			bool flag = fullName != 0U && this.infoMap.ContainsKey(fullName);
			AssetBundleData result;
			if (flag)
			{
				result = this.infoMap[fullName];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public AssetBundleData GetAssetBundleInfo(uint fullName)
		{
			bool flag = fullName > 0U;
			if (flag)
			{
				bool flag2 = this.infoMap.ContainsKey(fullName);
				if (flag2)
				{
					return this.infoMap[fullName];
				}
			}
			return null;
		}

		public Dictionary<uint, AssetBundleData> infoMap = new Dictionary<uint, AssetBundleData>();

		protected Dictionary<uint, uint> shortName2FullName = new Dictionary<uint, uint>();
	}
}
