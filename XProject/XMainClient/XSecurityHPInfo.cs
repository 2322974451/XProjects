using System;

namespace XMainClient
{
	// Token: 0x02000B11 RID: 2833
	internal class XSecurityHPInfo
	{
		// Token: 0x0600A6CA RID: 42698 RVA: 0x001D5F94 File Offset: 0x001D4194
		public void Reset()
		{
			this._TotalValue = 0f;
			this._MaxValue = 0f;
			this._MinValue = float.MaxValue;
		}

		// Token: 0x0600A6CB RID: 42699 RVA: 0x001D5FB8 File Offset: 0x001D41B8
		public void Merge(float value)
		{
			this._TotalValue += value;
			this._MaxValue = Math.Max(this._MaxValue, value);
			this._MinValue = Math.Min(this._MinValue, value);
		}

		// Token: 0x0600A6CC RID: 42700 RVA: 0x001D5FF0 File Offset: 0x001D41F0
		public static void SendData(XSecurityHPInfo info, string keywords)
		{
			XStaticSecurityStatistics.Append(string.Format("{0}InitHPMax", keywords), info._MaxValue);
			XStaticSecurityStatistics.Append(string.Format("{0}InitHPMin", keywords), info._MinValue);
			XStaticSecurityStatistics.Append(string.Format("{0}InitHPTotal", keywords), info._TotalValue);
		}

		// Token: 0x04003D5B RID: 15707
		public float _TotalValue;

		// Token: 0x04003D5C RID: 15708
		public float _MaxValue;

		// Token: 0x04003D5D RID: 15709
		public float _MinValue;
	}
}
