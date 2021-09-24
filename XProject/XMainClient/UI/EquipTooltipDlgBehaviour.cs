using System;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EquipTooltipDlgBehaviour : TooltipDlgBehaviour
	{

		protected override void Awake()
		{
			this.m_JadeItemPool.SetupPool(base.transform.FindChild("Bg/Bg").gameObject, base.transform.FindChild("Bg/Bg/ToolTip/JadeFrame/JadeTpl").gameObject, 2U, false);
			base.Awake();
		}

		public XUIPool m_JadeItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
