using System;
using System.Collections.Generic;

namespace UILib
{
	// Token: 0x02000042 RID: 66
	public interface IXUIPopupList : IXUIObject
	{
		// Token: 0x060001C6 RID: 454
		void SetOptionList(List<string> options);

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001C7 RID: 455
		// (set) Token: 0x060001C8 RID: 456
		string value { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001C9 RID: 457
		// (set) Token: 0x060001CA RID: 458
		int currentIndex { get; set; }
	}
}
