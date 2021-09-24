using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleDebugHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("template");
			this.m_EnmityListPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_EnmityListPool.ReturnAll(false);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		public void UpdateEnmityList(List<Enmity> enmity)
		{
			this.m_EnmityListPool.ReturnAll(false);
			for (int i = 0; i < enmity.Count; i++)
			{
				GameObject gameObject = this.m_EnmityListPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(this.m_EnmityListPool.TplPos.x, this.m_EnmityListPool.TplPos.y - (float)(i * this.m_EnmityListPool.TplHeight), this.m_EnmityListPool.TplPos.z);
				IXUILabel ixuilabel = gameObject.transform.FindChild("name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(enmity[i].entity.Name + ":" + enmity[i].value.ToString());
			}
		}

		public XUIPool m_EnmityListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
