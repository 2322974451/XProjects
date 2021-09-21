using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001826 RID: 6182
	internal class FashionCollectionDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x060100D5 RID: 65749 RVA: 0x003D3994 File Offset: 0x003D1B94
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

		// Token: 0x04007255 RID: 29269
		public IXUIButton m_Close;

		// Token: 0x04007256 RID: 29270
		public GameObject m_CharacterInfoFrame;

		// Token: 0x04007257 RID: 29271
		public IXUILabel m_TotalCollection;

		// Token: 0x04007258 RID: 29272
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04007259 RID: 29273
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400725A RID: 29274
		public IXUILabel m_SuitName;

		// Token: 0x0400725B RID: 29275
		public IXUIButton m_ShopBtn;

		// Token: 0x0400725C RID: 29276
		public XUIPool FashionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400725D RID: 29277
		public XUIPool AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400725E RID: 29278
		public Vector3[] ShowPos = new Vector3[7];

		// Token: 0x0400725F RID: 29279
		public IUIDummy m_SnapShot = null;
	}
}
