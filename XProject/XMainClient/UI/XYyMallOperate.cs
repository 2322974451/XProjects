using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001789 RID: 6025
	internal class XYyMallOperate : XDramaOperate
	{
		// Token: 0x0600F898 RID: 63640 RVA: 0x0038D51C File Offset: 0x0038B71C
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

		// Token: 0x0600F899 RID: 63641 RVA: 0x0038D594 File Offset: 0x0038B794
		private bool _OnOKClicked(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_YyMall, 0UL);
			return true;
		}
	}
}
