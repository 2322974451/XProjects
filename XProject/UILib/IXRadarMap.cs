using System;

namespace UILib
{
	// Token: 0x02000003 RID: 3
	public interface IXRadarMap
	{
		// Token: 0x06000016 RID: 22
		void Refresh();

		// Token: 0x06000017 RID: 23
		void SetSite(int pos, float value);
	}
}
