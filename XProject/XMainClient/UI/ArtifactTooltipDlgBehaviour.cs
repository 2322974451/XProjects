using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B8 RID: 6072
	internal class ArtifactTooltipDlgBehaviour : TooltipDlgBehaviour
	{
		// Token: 0x0600FB53 RID: 64339 RVA: 0x003A52B4 File Offset: 0x003A34B4
		protected override void Awake()
		{
			GameObject gameObject = base.transform.Find("Bg/Bg").gameObject;
			Transform transform = gameObject.transform.Find("ToolTip/ScrollPanel/BasicAttr/DesTpl");
			bool flag = transform != null;
			if (flag)
			{
				this.m_DesFramePool.SetupPool(gameObject, transform.gameObject, 2U, false);
			}
			base.Awake();
		}

		// Token: 0x04006E48 RID: 28232
		public XUIPool m_DesFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
