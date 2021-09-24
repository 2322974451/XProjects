using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactTooltipDlgBehaviour : TooltipDlgBehaviour
	{

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

		public XUIPool m_DesFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
