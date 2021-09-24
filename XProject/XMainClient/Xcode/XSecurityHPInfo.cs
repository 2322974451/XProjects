using System;

namespace XMainClient
{

	internal class XSecurityHPInfo
	{

		public void Reset()
		{
			this._TotalValue = 0f;
			this._MaxValue = 0f;
			this._MinValue = float.MaxValue;
		}

		public void Merge(float value)
		{
			this._TotalValue += value;
			this._MaxValue = Math.Max(this._MaxValue, value);
			this._MinValue = Math.Min(this._MinValue, value);
		}

		public static void SendData(XSecurityHPInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("{0}InitHPMax", keywords), info._MaxValue);
			XStaticSecurityStatistics.Append(string.Format("{0}InitHPMin", keywords), info._MinValue);
			XStaticSecurityStatistics.Append(string.Format("{0}InitHPTotal", keywords), info._TotalValue);
		}

		public float _TotalValue;

		public float _MaxValue;

		public float _MinValue;
	}
}
