using System;

namespace XUtliPoolLib
{
	// Token: 0x020000A6 RID: 166
	public interface IXTutorial : IXInterface
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x0600050D RID: 1293
		bool NoforceClick { get; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600050E RID: 1294
		bool Exculsive { get; }

		// Token: 0x0600050F RID: 1295
		void OnTutorialClicked();
	}
}
