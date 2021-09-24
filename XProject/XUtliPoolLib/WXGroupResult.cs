using System;

namespace XUtliPoolLib
{

	public class WXGroupResult
	{

		public int apiId;

		public WXGroupResult.Data data;

		public struct Data
		{

			public int errorCode;

			public string flag;
		}
	}
}
