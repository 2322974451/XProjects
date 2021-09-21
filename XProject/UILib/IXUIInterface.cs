using System;

namespace UILib
{
	// Token: 0x02000012 RID: 18
	public interface IXUIInterface
	{
		// Token: 0x06000082 RID: 130
		void ShowUI(string name);

		// Token: 0x06000083 RID: 131
		void HideUI(string name);

		// Token: 0x06000084 RID: 132
		void SetCustomId(string dlgName, string widgetName, uint ID);
	}
}
