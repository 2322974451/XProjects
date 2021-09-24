using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XDramaOperate
	{

		public XDramaOperate()
		{
			this.dramaDoc = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
		}

		protected void _FireEvent(XDramaOperateParam param)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetupOperate(param);
			param.Recycle();
		}

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

		public virtual void ShowNpc(XNpc npc)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(true, true);
		}

		protected XDramaDocument dramaDoc;
	}
}
