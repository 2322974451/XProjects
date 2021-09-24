using System;

namespace XUtliPoolLib
{

	public class WXGroupInfo
	{

		public int apiId;

		public WXGroupInfo.Data data;

		public struct Data
		{

			public string flag;

			public int errorCode;

			public string count;

			public string openIdList;
		}
	}
}
