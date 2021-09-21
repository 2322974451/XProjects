using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017FB RID: 6139
	internal class FashionStorageBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FEAC RID: 65196 RVA: 0x003BEBB0 File Offset: 0x003BCDB0
		private void Awake()
		{
			this.m_close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_avatarSprite = (base.transform.Find("Bg/Bg3").GetComponent("XUISprite") as IXUISprite);
			this.m_outLook = (base.transform.Find("Navigation/OutLook").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_outLook.ID = 0UL;
			this.m_outLookRedPoint = (base.transform.Find("Navigation/OutLook/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_equipRecord = (base.transform.Find("Navigation/EquipRecord").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_equipRecord.ID = 2UL;
			this.m_equipCharmRedPoint = (base.transform.Find("Navigation/EquipRecord/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_fashionRecord = (base.transform.Find("Navigation/FashionRecord").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_fashionRecord.ID = 1UL;
			this.m_fashionCharmRedPoint = (base.transform.Find("Navigation/FashionRecord/RedPoint").GetComponent("XUISprite") as IXUISprite);
			this.m_Snapshot = (base.transform.Find("Snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_scrollView = (base.transform.Find("Select/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_wrapContent = (base.transform.Find("Select/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_effectContainer = base.transform.Find("Bg/Bg2");
			this.m_fashionList = base.transform.Find("FashionList").gameObject;
			this.m_attributeInfo = base.transform.Find("Attribute").gameObject;
			this.m_hairFrame = base.transform.Find("HairFrame").gameObject;
			this.m_effectFrame = base.transform.Find("EffectFrame").gameObject;
			int num = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_START);
			int num2 = XBagDocument.BodyPosition<FashionPosition>(FashionPosition.FASHION_ALL_END);
			bool flag = this.m_partList == null;
			if (flag)
			{
				this.m_partList = new Transform[num2];
			}
			for (int i = num; i < num2; i++)
			{
				this.m_partList[i] = base.transform.Find(string.Format("EquipFrame/Part{0}", i));
			}
			this.m_effectIcon = (base.transform.Find("EffectSprite/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_effectSprite = (base.transform.Find("EffectSprite").GetComponent("XUISprite") as IXUISprite);
			this.m_colorSprite = (base.transform.Find(string.Format("EquipFrame/Part{0}/Icon/Color", XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.Hair))).GetComponent("XUISprite") as IXUISprite);
			this.m_effectRedPoint = (base.transform.Find("EffectSprite/RedPoint").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04007085 RID: 28805
		public IXUIButton m_close;

		// Token: 0x04007086 RID: 28806
		public IXUICheckBox m_outLook;

		// Token: 0x04007087 RID: 28807
		public IXUICheckBox m_equipRecord;

		// Token: 0x04007088 RID: 28808
		public IXUICheckBox m_fashionRecord;

		// Token: 0x04007089 RID: 28809
		public IXUIScrollView m_scrollView;

		// Token: 0x0400708A RID: 28810
		public IXUIWrapContent m_wrapContent;

		// Token: 0x0400708B RID: 28811
		public Transform m_effectContainer;

		// Token: 0x0400708C RID: 28812
		public IXUISprite m_outLookRedPoint;

		// Token: 0x0400708D RID: 28813
		public IXUISprite m_fashionCharmRedPoint;

		// Token: 0x0400708E RID: 28814
		public IXUISprite m_equipCharmRedPoint;

		// Token: 0x0400708F RID: 28815
		public IXUISprite m_avatarSprite;

		// Token: 0x04007090 RID: 28816
		public IUIDummy m_Snapshot;

		// Token: 0x04007091 RID: 28817
		public GameObject m_fashionList;

		// Token: 0x04007092 RID: 28818
		public GameObject m_attributeInfo;

		// Token: 0x04007093 RID: 28819
		public GameObject m_hairFrame;

		// Token: 0x04007094 RID: 28820
		public GameObject m_effectFrame;

		// Token: 0x04007095 RID: 28821
		public IXUISprite m_colorSprite;

		// Token: 0x04007096 RID: 28822
		public IXUISprite m_effectIcon;

		// Token: 0x04007097 RID: 28823
		public IXUISprite m_effectSprite;

		// Token: 0x04007098 RID: 28824
		public IXUISprite m_effectRedPoint;

		// Token: 0x04007099 RID: 28825
		public Transform[] m_partList;
	}
}
