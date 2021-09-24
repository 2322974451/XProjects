using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FashionStorageBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_close;

		public IXUICheckBox m_outLook;

		public IXUICheckBox m_equipRecord;

		public IXUICheckBox m_fashionRecord;

		public IXUIScrollView m_scrollView;

		public IXUIWrapContent m_wrapContent;

		public Transform m_effectContainer;

		public IXUISprite m_outLookRedPoint;

		public IXUISprite m_fashionCharmRedPoint;

		public IXUISprite m_equipCharmRedPoint;

		public IXUISprite m_avatarSprite;

		public IUIDummy m_Snapshot;

		public GameObject m_fashionList;

		public GameObject m_attributeInfo;

		public GameObject m_hairFrame;

		public GameObject m_effectFrame;

		public IXUISprite m_colorSprite;

		public IXUISprite m_effectIcon;

		public IXUISprite m_effectSprite;

		public IXUISprite m_effectRedPoint;

		public Transform[] m_partList;
	}
}
