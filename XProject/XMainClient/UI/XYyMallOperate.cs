using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XYyMallOperate : XDramaOperate
	{

		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			XDramaOperateParam data = XDataPool<XDramaOperateParam>.GetData();
			data.Text = base._GetRandomNpcText(npc);
			data.Npc = npc;
			data.AppendButton(XSingleton<XStringTable>.singleton.GetString("PartnerNpcOk"), new ButtonClickEventHandler(this._OnOKClicked), 0UL);
			data.AppendButton(XSingleton<XStringTable>.singleton.GetString("PartnerNpcCancel"), null, 0UL);
			base._FireEvent(data);
		}

		private bool _OnOKClicked(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_YyMall, 0UL);
			return true;
		}
	}
}
