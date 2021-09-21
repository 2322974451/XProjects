using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001908 RID: 6408
	internal class AttrTooltipDlgBehaviour : TooltipDlgBehaviour
	{
		// Token: 0x06010BB5 RID: 68533 RVA: 0x0042D038 File Offset: 0x0042B238
		protected override void Awake()
		{
			this.m_EmblemPartPool.SetupPool(base.transform.FindChild("Bg/Bg").gameObject, base.transform.FindChild("Bg/Bg/ToolTip/TopFrame/EmblemPart").gameObject, 2U, false);
			this.m_JadePartPool.SetupPool(base.transform.FindChild("Bg/Bg").gameObject, base.transform.FindChild("Bg/Bg/ToolTip/TopFrame/JadePart").gameObject, 2U, false);
			base.Awake();
		}

		// Token: 0x04007A4E RID: 31310
		public XUIPool m_EmblemPartPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007A4F RID: 31311
		public XUIPool m_JadePartPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
