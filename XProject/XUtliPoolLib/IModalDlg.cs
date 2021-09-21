using System;
using UILib;

namespace XUtliPoolLib
{
	// Token: 0x0200006A RID: 106
	public interface IModalDlg : IXInterface
	{
		// Token: 0x0600035A RID: 858
		void LuaShow(string content, ButtonClickEventHandler handler, ButtonClickEventHandler handler2);
	}
}
