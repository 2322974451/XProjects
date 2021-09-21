using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001884 RID: 6276
	internal class BattleDebugHandler : DlgHandlerBase
	{
		// Token: 0x0601053B RID: 66875 RVA: 0x003F4C44 File Offset: 0x003F2E44
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("template");
			this.m_EnmityListPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		// Token: 0x0601053C RID: 66876 RVA: 0x003F4C8F File Offset: 0x003F2E8F
		protected override void OnShow()
		{
			base.OnShow();
			this.m_EnmityListPool.ReturnAll(false);
		}

		// Token: 0x0601053D RID: 66877 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x0601053E RID: 66878 RVA: 0x003F4CA8 File Offset: 0x003F2EA8
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

		// Token: 0x04007597 RID: 30103
		public XUIPool m_EnmityListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
