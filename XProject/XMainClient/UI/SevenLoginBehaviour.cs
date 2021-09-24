using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SevenLoginBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Close;

		public IXUILabel m_LoginDayLabel;

		public IXUIScrollView m_WrapContentScrollView;

		public Transform m_WrapContentTemp;

		public Transform m_WrapContentRewardTemp;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_MessageLabel;

		public IXUITexture m_shardTexture;

		public IXUITexture m_dialogTexture;

		public Transform m_dialogTransform;

		public IXUIButton m_dialogClose;
	}
}
