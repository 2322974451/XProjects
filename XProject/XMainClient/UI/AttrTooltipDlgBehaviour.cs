using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AttrTooltipDlgBehaviour : TooltipDlgBehaviour
	{

		protected override void Awake()
		{
			this.m_EmblemPartPool.SetupPool(base.transform.FindChild("Bg/Bg").gameObject, base.transform.FindChild("Bg/Bg/ToolTip/TopFrame/EmblemPart").gameObject, 2U, false);
			this.m_JadePartPool.SetupPool(base.transform.FindChild("Bg/Bg").gameObject, base.transform.FindChild("Bg/Bg/ToolTip/TopFrame/JadePart").gameObject, 2U, false);
			base.Awake();
		}

		public XUIPool m_EmblemPartPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_JadePartPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
