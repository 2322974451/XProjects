using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpriteSkillTipDlg : DlgBase<XSpriteSkillTipDlg, XSpriteSkillTipBehaviour>
	{

		public XItemSelector ItemSelector
		{
			get
			{
				return this._ItemSelector;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteSkillTipDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		public void ShowSpriteSkill(uint skillID, bool mainSkill, uint level)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this.SetSkillInfo(skillID, mainSkill, level);
		}

		private void SetSkillInfo(uint skillID, bool mainSkill, uint level)
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteSkill.RowData spriteSkillData = specificDocument.GetSpriteSkillData((short)skillID, mainSkill, level);
			bool flag = spriteSkillData == null;
			if (!flag)
			{
				base.uiBehaviour.m_MainSkill.SetVisible(mainSkill);
				base.uiBehaviour.m_NormalSkill.SetVisible(!mainSkill);
				if (mainSkill)
				{
					base.uiBehaviour.m_MainIcon.SetSprite(spriteSkillData.Icon, spriteSkillData.Atlas, false);
					base.uiBehaviour.m_MainSkillName.SetText(spriteSkillData.SkillName);
					base.uiBehaviour.m_MainSkillLevel.SetText(XSingleton<XCommon>.singleton.StringCombine("Lv.", (level + 1U).ToString()));
					base.uiBehaviour.m_MainSkillType.SetText(XSingleton<XStringTable>.singleton.GetString("SpriteSkill_Type1"));
					base.uiBehaviour.m_MainSkillDuration.SetText(string.Format("{0}s", spriteSkillData.Duration));
					base.uiBehaviour.m_MainDesc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(spriteSkillData.Tips));
					base.uiBehaviour.m_MainCurrEffect.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(spriteSkillData.Detail));
					base.uiBehaviour.m_MainMiddleFrame.spriteHeight = base.uiBehaviour.m_MainDesc.spriteHeight + 50;
					base.uiBehaviour.m_MainBottomFrame.spriteHeight = base.uiBehaviour.m_MainCurrEffect.spriteHeight + 41;
					base.uiBehaviour.m_MainSkill.spriteHeight = base.uiBehaviour.m_MainBottomFrame.spriteHeight + base.uiBehaviour.m_MainMiddleFrame.spriteHeight + base.uiBehaviour.m_MainTopFrame.spriteHeight + 40;
					Vector3 localPosition = base.uiBehaviour.m_MainTopFrame.gameObject.transform.localPosition;
					base.uiBehaviour.m_MainTopFrame.gameObject.transform.localPosition = new Vector3(localPosition.x, (float)(base.uiBehaviour.m_MainSkill.spriteHeight / 2 - 18), localPosition.z);
					localPosition = base.uiBehaviour.m_MainTopFrame.gameObject.transform.localPosition;
					Vector3 localPosition2 = base.uiBehaviour.m_MainMiddleFrame.gameObject.transform.localPosition;
					base.uiBehaviour.m_MainMiddleFrame.gameObject.transform.localPosition = new Vector3(localPosition2.x, localPosition.y - (float)base.uiBehaviour.m_MainTopFrame.spriteHeight, localPosition2.z);
					localPosition2 = base.uiBehaviour.m_MainMiddleFrame.gameObject.transform.localPosition;
					Vector3 localPosition3 = base.uiBehaviour.m_MainBottomFrame.gameObject.transform.localPosition;
					base.uiBehaviour.m_MainBottomFrame.gameObject.transform.localPosition = new Vector3(localPosition3.x, localPosition2.y - (float)base.uiBehaviour.m_MainMiddleFrame.spriteHeight, localPosition3.z);
				}
				else
				{
					base.uiBehaviour.m_NormalIcon.SetSprite(spriteSkillData.Icon, spriteSkillData.Atlas, false);
					base.uiBehaviour.m_NormalIconQuality.SetSprite(string.Format("kuang_zq0{0}", spriteSkillData.SkillQuality));
					base.uiBehaviour.m_NormalSkillName.SetText(spriteSkillData.SkillName);
					base.uiBehaviour.m_NormalCurrEffect.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(spriteSkillData.Detail));
					base.uiBehaviour.m_NormalSkillType.SetText(XSingleton<XStringTable>.singleton.GetString("SpriteSkill_Type2"));
					IXUILabel normalSkillQuality = base.uiBehaviour.m_NormalSkillQuality;
					SpriteQuality skillQuality = (SpriteQuality)spriteSkillData.SkillQuality;
					normalSkillQuality.SetText(skillQuality.ToString());
					base.uiBehaviour.m_NormalMiddleFrame.spriteHeight = base.uiBehaviour.m_NormalCurrEffect.spriteHeight + 30;
					base.uiBehaviour.m_NormalSkill.spriteHeight = base.uiBehaviour.m_NormalTopFrame.spriteHeight + base.uiBehaviour.m_NormalMiddleFrame.spriteHeight + 50;
				}
			}
		}

		public void OnCloseClicked(IXUISprite sp)
		{
			this._ItemSelector.Hide();
			this.SetVisibleWithAnimation(false, null);
		}

		private XItemSelector _ItemSelector = new XItemSelector(XSingleton<XGlobalConfig>.singleton.DefaultIconWidth);
	}
}
