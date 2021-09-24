using System;

namespace XUtliPoolLib
{

	public class AssetBundleData
	{

		public uint fullName;

		public string debugName;

		public AssetBundleExportType compositeType;

		public uint[] dependencies;

		public bool isAnalyzed;

		public AssetBundleData[] dependList;
	}
}
