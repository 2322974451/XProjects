using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionCollectionDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_CharacterInfoFrame = base.transform.FindChild("Bg/CharacterInfoFrame").gameObject;
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TotalCollection = (base.transform.FindChild("Bg/ListFrame/Bg/P/CollectNum/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ScrollView = (base.transform.FindChild("Bg/ListFrame/ListPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/ListFrame/ListPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_SuitName = (base.transform.FindChild("Bg/InfoFrame/SuitName").GetComponent("XUILabel") as IXUILabel);
			this.m_ShopBtn = (base.transform.FindChild("Bg/InfoFrame/BtnShop").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 7; i++)
			{
				Transform transform = base.transform.FindChild("Bg/InfoFrame/ItemLocation" + (i + 1));
				this.ShowPos[i] = transform.localPosition;
			}
			Transform transform2 = base.transform.FindChild("Bg/InfoFrame/ItemTpl");
			this.FashionPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 7U, false);
			transform2 = base.transform.FindChild("Bg/InfoFrame/AttrFrame/AttrTpl");
			this.AttrPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 3U, false);
			this.m_SnapShot = (this.m_CharacterInfoFrame.transform.FindChild("CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		public IXUIButton m_Close;

		public GameObject m_CharacterInfoFrame;

		public IXUILabel m_TotalCollection;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public IXUILabel m_SuitName;

		public IXUIButton m_ShopBtn;

		public XUIPool FashionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Vector3[] ShowPos = new Vector3[7];

		public IUIDummy m_SnapShot = null;
	}
}
