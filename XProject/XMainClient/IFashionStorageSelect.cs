using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x020008DB RID: 2267
	internal interface IFashionStorageSelect
	{
		// Token: 0x0600897D RID: 35197
		int GetID();

		// Token: 0x0600897E RID: 35198
		int GetCount();

		// Token: 0x0600897F RID: 35199
		void SetCount(uint count);

		// Token: 0x06008980 RID: 35200
		string GetName();

		// Token: 0x17002ADA RID: 10970
		// (get) Token: 0x06008981 RID: 35201
		bool Active { get; }

		// Token: 0x06008982 RID: 35202
		string GetLabel();

		// Token: 0x17002ADB RID: 10971
		// (get) Token: 0x06008984 RID: 35204
		// (set) Token: 0x06008983 RID: 35203
		bool Select { get; set; }

		// Token: 0x06008985 RID: 35205
		List<uint> GetItems();

		// Token: 0x17002ADC RID: 10972
		// (get) Token: 0x06008986 RID: 35206
		bool ActivateAll { get; }

		// Token: 0x06008987 RID: 35207
		uint[] GetFashionList();

		// Token: 0x06008988 RID: 35208
		List<AttributeCharm> GetAttributeCharm();

		// Token: 0x17002ADD RID: 10973
		// (get) Token: 0x06008989 RID: 35209
		bool RedPoint { get; }

		// Token: 0x0600898A RID: 35210
		void Refresh();
	}
}
