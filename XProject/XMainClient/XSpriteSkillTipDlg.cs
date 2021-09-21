using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB9 RID: 3257
	internal class XSpriteSkillTipDlg : DlgBase<XSpriteSkillTipDlg, XSpriteSkillTipBehaviour>
	{
		// Token: 0x17003264 RID: 12900
		// (get) Token: 0x0600B72D RID: 46893 RVA: 0x00246C34 File Offset: 0x00244E34
		public XItemSelector ItemSelector
		{
			get
			{
				return this._ItemSelector;
			}
		}

		// Token: 0x17003265 RID: 12901
		// (get) Token: 0x0600B72E RID: 46894 RVA: 0x00246C4C File Offset: 0x00244E4C
		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteSkillTipDlg";
			}
		}

		// Token: 0x17003266 RID: 12902
		// (get) Token: 0x0600B72F RID: 46895 RVA: 0x00246C64 File Offset: 0x00244E64
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B730 RID: 46896 RVA: 0x00246C77 File Offset: 0x00244E77
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B731 RID: 46897 RVA: 0x00246CA0 File Offset: 0x00244EA0
		public void ShowSpriteSkill(uint skillID, bool mainSkill, uint level)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this.SetSkillInfo(skillID, mainSkill, level);
		}

		// Token: 0x0600B732 RID: 46898 RVA: 0x00246CD0 File Offset: 0x00244ED0
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

		// Token: 0x0600B733 RID: 46899 RVA: 0x00247129 File Offset: 0x00245329
		public void OnCloseClicked(IXUISprite sp)
		{
			this._ItemSelector.Hide();
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x040047E6 RID: 18406
		private XItemSelector _ItemSelector = new XItemSelector(XSingleton<XGlobalConfig>.singleton.DefaultIconWidth);
	}
}
