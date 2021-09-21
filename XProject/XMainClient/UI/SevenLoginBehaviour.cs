using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001854 RID: 6228
	internal class SevenLoginBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601031B RID: 66331 RVA: 0x003E4224 File Offset: 0x003E2424
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_LoginDayLabel = (base.transform.FindChild("Bg/LoginDay").GetComponent("XUILabel") as IXUILabel);
			this.m_WrapContentScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContentTemp = base.transform.FindChild("Bg/ScrollView/ItemTpl");
			this.m_WrapContentTemp.gameObject.SetActive(false);
			this.m_WrapContentRewardTemp = base.transform.FindChild("Bg/RewardTemp");
			this.m_RewardPool.SetupPool(this.m_WrapContentRewardTemp.parent.gameObject, this.m_WrapContentRewardTemp.gameObject, 30U, false);
			this.m_WrapContentRewardTemp.gameObject.SetActive(false);
			this.m_MessageLabel = (base.transform.FindChild("Bg/Message").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/Show");
			this.m_shardTexture = (base.transform.FindChild("Bg/Show/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_dialogClose = (base.transform.FindChild("Bg/Dialog/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_dialogTexture = (base.transform.FindChild("Bg/Dialog/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_dialogTransform = base.transform.FindChild("Bg/Dialog");
		}

		// Token: 0x04007401 RID: 29697
		public IXUIButton m_Close;

		// Token: 0x04007402 RID: 29698
		public IXUILabel m_LoginDayLabel;

		// Token: 0x04007403 RID: 29699
		public IXUIScrollView m_WrapContentScrollView;

		// Token: 0x04007404 RID: 29700
		public Transform m_WrapContentTemp;

		// Token: 0x04007405 RID: 29701
		public Transform m_WrapContentRewardTemp;

		// Token: 0x04007406 RID: 29702
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007407 RID: 29703
		public IXUILabel m_MessageLabel;

		// Token: 0x04007408 RID: 29704
		public IXUITexture m_shardTexture;

		// Token: 0x04007409 RID: 29705
		public IXUITexture m_dialogTexture;

		// Token: 0x0400740A RID: 29706
		public Transform m_dialogTransform;

		// Token: 0x0400740B RID: 29707
		public IXUIButton m_dialogClose;
	}
}
