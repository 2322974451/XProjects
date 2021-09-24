using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildCollectRewardBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Title/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_LeftTime = (base.transform.Find("Bg/LeftTime").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Panel/Tpl");
			this.m_CollectPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			transform = base.transform.Find("Bg/Panel/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 30U, false);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUILabel m_LeftTime;

		public XUIPool m_CollectPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
