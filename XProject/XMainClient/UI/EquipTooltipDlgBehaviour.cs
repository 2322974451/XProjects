using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001904 RID: 6404
	internal class EquipTooltipDlgBehaviour : TooltipDlgBehaviour
	{
		// Token: 0x06010B84 RID: 68484 RVA: 0x0042C664 File Offset: 0x0042A864
		protected override void Awake()
		{
			this.m_JadeItemPool.SetupPool(base.transform.FindChild("Bg/Bg").gameObject, base.transform.FindChild("Bg/Bg/ToolTip/JadeFrame/JadeTpl").gameObject, 2U, false);
			base.Awake();
		}

		// Token: 0x04007A40 RID: 31296
		public XUIPool m_JadeItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
