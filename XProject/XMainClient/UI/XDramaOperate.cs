using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001784 RID: 6020
	internal class XDramaOperate
	{
		// Token: 0x0600F86F RID: 63599 RVA: 0x0038C40B File Offset: 0x0038A60B
		public XDramaOperate()
		{
			this.dramaDoc = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
		}

		// Token: 0x0600F870 RID: 63600 RVA: 0x0038C425 File Offset: 0x0038A625
		protected void _FireEvent(XDramaOperateParam param)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetupOperate(param);
			param.Recycle();
		}

		// Token: 0x0600F871 RID: 63601 RVA: 0x0038C43C File Offset: 0x0038A63C
		protected string _GetRandomNpcText(XNpc npc)
		{
			bool flag = npc == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string[] content = (npc.Attributes as XNpcAttributes).Content;
				bool flag2 = content != null && content.Length != 0;
				if (flag2)
				{
					result = content[XSingleton<XCommon>.singleton.RandomInt(content.Length)];
				}
				else
				{
					result = string.Empty;
				}
			}
			return result;
		}

		// Token: 0x0600F872 RID: 63602 RVA: 0x0038C491 File Offset: 0x0038A691
		public virtual void ShowNpc(XNpc npc)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(true, true);
		}

		// Token: 0x04006C73 RID: 27763
		protected XDramaDocument dramaDoc;
	}
}
