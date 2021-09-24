using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FriendsWeddingLevelUpView : DlgBase<FriendsWeddingLevelUpView, FriendsWeddingLevelUpBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingLoverLevelUpDlg";
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = XWeddingDocument.Doc.MarriageLevelUp > 0;
			if (flag)
			{
				base.uiBehaviour.m_LevelTip.SetText(XStringDefineProxy.GetString("WeddingLoverLevelUpTip", new object[]
				{
					XWeddingDocument.Doc.MarriageLevelUp
				}));
				MarriageLevel.RowData byLevel = XWeddingDocument.MarriageLevelTable.GetByLevel(XWeddingDocument.Doc.MarriageLevelUp);
				bool flag2 = byLevel != null;
				if (flag2)
				{
					bool flag3 = byLevel.PrerogativeID > 0U;
					if (flag3)
					{
						base.uiBehaviour.m_Skill.SetActive(false);
						base.uiBehaviour.m_Item.SetActive(true);
						base.uiBehaviour.m_ItemDesc.SetActive(true);
						PrerogativeContent.RowData prerogativeByID = XPrerogativeDocument.GetPrerogativeByID(byLevel.PrerogativeID);
						PreSettingNodeHandler.SetupPrerogativeTpl(base.uiBehaviour.m_ItemIconTran, prerogativeByID);
						string @string = XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("PRE_TYPE_NAME", prerogativeByID.Type.ToString()));
						base.uiBehaviour.m_ItemName.SetText(@string);
					}
					else
					{
						bool flag4 = byLevel.PrivilegeBuffs[0] > 0U;
						if (flag4)
						{
							base.uiBehaviour.m_Skill.SetActive(true);
							base.uiBehaviour.m_Item.SetActive(false);
							base.uiBehaviour.m_ItemDesc.SetActive(false);
							BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)byLevel.PrivilegeBuffs[0], (int)byLevel.PrivilegeBuffs[1]);
							bool flag5 = buffData != null;
							if (flag5)
							{
								base.uiBehaviour.m_SkillName.SetText(buffData.BuffName);
							}
							string[] array = byLevel.BuffIcon.Split(new char[]
							{
								'='
							});
							base.uiBehaviour.m_SkillIcon.SetSprite(array[1], array[0], false);
						}
					}
				}
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_GetBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClicked));
		}

		private bool OnCloseBtnClicked(IXUIButton btn)
		{
			XWeddingDocument specificDocument = XDocuments.GetSpecificDocument<XWeddingDocument>(XWeddingDocument.uuID);
			specificDocument.GetMarriagePrivilege();
			this.SetVisibleWithAnimation(false, null);
			return false;
		}
	}
}
