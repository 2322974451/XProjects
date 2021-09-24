using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FriendsWeddingPrivilegeHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_CurrLevel = (base.PanelObject.transform.Find("Bg/Curr/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_NextLevel = (base.PanelObject.transform.Find("Bg/Next/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_MaxLevelText = base.PanelObject.transform.Find("Bg/Next/MaxLevel").gameObject;
			this.m_MaxLevelText.SetActive(false);
			this.m_CurrEmpty = base.PanelObject.transform.Find("T2").gameObject;
			this.m_CurrEmpty.SetActive(false);
			this.m_CurrWrapContent = (base.PanelObject.transform.Find("Bg/Curr/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_CurrScrollView = (base.PanelObject.transform.Find("Bg/Curr/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_NextOnlyOne = base.PanelObject.transform.Find("Bg/Next/OnlyOne").gameObject;
			this.m_NextOnlyOne.SetActive(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CurrWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.CurrPrivilegeWrapListUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_PrivilegeList.Clear();
			bool flag = this.m_doc.MarriageLevel != null;
			if (flag)
			{
				this.m_CurrLevel.SetText(this.m_doc.MarriageLevel.marriageLevel.ToString());
				int key = this.m_doc.MarriageLevel.marriageLevel + 1;
				MarriageLevel.RowData byLevel = XWeddingDocument.MarriageLevelTable.GetByLevel(key);
				bool flag2 = byLevel != null;
				if (flag2)
				{
					this.m_NextLevel.SetText(key.ToString());
					this.SetNextPrivilegeInfo(byLevel);
				}
				this.m_NextLevel.gameObject.SetActive(byLevel != null);
				this.m_MaxLevelText.gameObject.SetActive(byLevel == null);
				this.m_NextOnlyOne.SetActive(byLevel != null);
				for (int i = 1; i <= this.m_doc.MarriageLevel.marriageLevel; i++)
				{
					MarriageLevel.RowData byLevel2 = XWeddingDocument.MarriageLevelTable.GetByLevel(i);
					bool flag3 = byLevel2.PrerogativeID != 0U || byLevel2.PrivilegeBuffs[0] > 0U;
					if (flag3)
					{
						this.m_PrivilegeList.Add(byLevel2);
					}
				}
				this.m_CurrEmpty.SetActive(this.m_PrivilegeList.Count == 0);
				this.m_CurrWrapContent.SetContentCount(this.m_PrivilegeList.Count, false);
				this.m_CurrScrollView.ResetPosition();
			}
		}

		private void SetNextPrivilegeInfo(MarriageLevel.RowData rowData)
		{
			IXUILabel ixuilabel = this.m_NextOnlyOne.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = this.m_NextOnlyOne.transform.Find("Desc").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = this.m_NextOnlyOne.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.SetColor(Color.white);
			bool flag = rowData.PrerogativeID > 0U;
			if (flag)
			{
				PrerogativeContent.RowData prerogativeByID = XPrerogativeDocument.GetPrerogativeByID(rowData.PrerogativeID);
				PreSettingNodeHandler.SetupPrerogativeTpl(this.m_NextOnlyOne.transform, prerogativeByID);
				string @string = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", prerogativeByID.Type.ToString()));
				ixuilabel.SetText(@string);
			}
			else
			{
				bool flag2 = rowData.PrivilegeBuffs[0] > 0U;
				if (flag2)
				{
					ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("WeddingBuffDesc"));
					string[] array = rowData.BuffIcon.Split(new char[]
					{
						'='
					});
					ixuisprite.SetSprite(array[1], array[0], false);
				}
			}
			ixuilabel2.SetText(rowData.Desc);
		}

		private void CurrPrivilegeWrapListUpdated(Transform item, int index)
		{
			bool flag = index >= this.m_PrivilegeList.Count;
			if (!flag)
			{
				IXUILabel ixuilabel = item.Find("Desc").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = item.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetColor(Color.white);
				MarriageLevel.RowData rowData = this.m_PrivilegeList[index];
				bool flag2 = rowData.PrerogativeID > 0U;
				if (flag2)
				{
					PrerogativeContent.RowData prerogativeByID = XPrerogativeDocument.GetPrerogativeByID(rowData.PrerogativeID);
					PreSettingNodeHandler.SetupPrerogativeTpl(item, prerogativeByID);
					string @string = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", prerogativeByID.Type.ToString()));
					ixuilabel.SetText(@string);
				}
				else
				{
					bool flag3 = rowData.PrivilegeBuffs[0] > 0U;
					if (flag3)
					{
						BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)rowData.PrivilegeBuffs[0], (int)rowData.PrivilegeBuffs[1]);
						bool flag4 = buffData != null;
						if (flag4)
						{
							ixuilabel.SetText(buffData.BuffName);
						}
						string[] array = rowData.BuffIcon.Split(new char[]
						{
							'='
						});
						ixuisprite.SetSprite(array[1], array[0], false);
					}
				}
			}
		}

		private XWeddingDocument m_doc = XWeddingDocument.Doc;

		private IXUILabel m_CurrLevel;

		private IXUILabel m_NextLevel;

		private IXUIWrapContent m_CurrWrapContent;

		private IXUIScrollView m_CurrScrollView;

		private GameObject m_NextOnlyOne;

		private GameObject m_MaxLevelText;

		private GameObject m_CurrEmpty;

		private List<MarriageLevel.RowData> m_PrivilegeList = new List<MarriageLevel.RowData>();
	}
}
