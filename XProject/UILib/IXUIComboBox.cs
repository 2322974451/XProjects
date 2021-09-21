using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000010 RID: 16
	public interface IXUIComboBox : IXUIObject
	{
		// Token: 0x0600005F RID: 95
		void ModuleInit();

		// Token: 0x06000060 RID: 96
		void AddItem(string text, int value);

		// Token: 0x06000061 RID: 97
		GameObject GetItem(int value);

		// Token: 0x06000062 RID: 98
		void ClearItems();

		// Token: 0x06000063 RID: 99
		bool SelectItem(int value, bool withCallback);

		// Token: 0x06000064 RID: 100
		void RegisterSpriteClickEventHandler(ComboboxClickEventHandler eventHandler);

		// Token: 0x06000065 RID: 101
		void ResetState();
	}
}
