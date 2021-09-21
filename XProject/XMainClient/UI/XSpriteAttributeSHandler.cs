using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001812 RID: 6162
	internal class XSpriteAttributeSHandler : DlgHandlerBase
	{
		// Token: 0x17003900 RID: 14592
		// (get) Token: 0x0600FFA2 RID: 65442 RVA: 0x003C7518 File Offset: 0x003C5718
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteSkill";
			}
		}

		// Token: 0x0600FFA3 RID: 65443 RVA: 0x003C7530 File Offset: 0x003C5730
		protected override void Init()
		{
			base.Init();
			this.m_SkillList = (base.PanelObject.transform.Find("OtherSkill").GetComponent("XUIList") as IXUIList);
			Transform transform = base.PanelObject.transform.Find("OtherSkill/Tpl");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_MainSkill = base.PanelObject.transform.Find("MainSkill").gameObject;
			this.m_MainSkill.SetActive(false);
		}

		// Token: 0x0600FFA4 RID: 65444 RVA: 0x003C75D4 File Offset: 0x003C57D4
		private void CreateSpriteSkill(List<uint> passiveSkillID, uint skillID, uint evolutionLevel)
		{
			this.m_passiveSkillID = passiveSkillID;
			this.m_mainSkillID = skillID;
			this.m_mainSkillLevel = evolutionLevel;
			this.m_SkillPool.FakeReturnAll();
			for (int i = 0; i < passiveSkillID.Count; i++)
			{
				GameObject go = this.m_SkillPool.FetchGameObject(false);
				this.SetSkillIcon(go, passiveSkillID[i], false, 0U);
			}
			this.m_SkillList.Refresh();
			this.m_SkillPool.ActualReturnAll(false);
			this.m_MainSkill.SetActive(true);
			this.SetSkillIcon(this.m_MainSkill, skillID, true, evolutionLevel);
		}

		// Token: 0x0600FFA5 RID: 65445 RVA: 0x003C7670 File Offset: 0x003C5870
		private void SetSkillIcon(GameObject go, uint skillID, bool mainSkill = false, uint evolutionLevel = 0U)
		{
			IXUISprite ixuisprite = go.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.FindChild("Zhu").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = go.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = go.transform.FindChild("Frame").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)skillID;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSkillIconClicked));
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteSkill.RowData spriteSkillData = specificDocument.GetSpriteSkillData((short)skillID, mainSkill, evolutionLevel);
			bool flag = spriteSkillData != null;
			if (flag)
			{
				ixuisprite.SetSprite(spriteSkillData.Icon, spriteSkillData.Atlas, false);
			}
			ixuilabel.SetVisible(mainSkill);
			ixuisprite2.SetVisible(!mainSkill);
			bool flag2 = !mainSkill;
			if (flag2)
			{
				ixuisprite2.SetSprite(string.Format("kuang_zq0{0}", spriteSkillData.SkillQuality));
			}
			ixuilabel2.SetText(string.Format("[b]Lv.{0}[-]", evolutionLevel + 1U));
			ixuilabel2.SetVisible(mainSkill);
		}

		// Token: 0x0600FFA6 RID: 65446 RVA: 0x003C77B4 File Offset: 0x003C59B4
		private void OnSkillIconClicked(IXUISprite obj)
		{
			uint num = (uint)obj.ID;
			bool flag = num == this.m_mainSkillID;
			DlgBase<XSpriteSkillTipDlg, XSpriteSkillTipBehaviour>.singleton.ItemSelector.Select(obj);
			DlgBase<XSpriteSkillTipDlg, XSpriteSkillTipBehaviour>.singleton.ShowSpriteSkill(num, flag, flag ? this.m_mainSkillLevel : 0U);
		}

		// Token: 0x0600FFA7 RID: 65447 RVA: 0x003C7800 File Offset: 0x003C5A00
		public void SetSpriteAttributeInfo(SpriteInfo spriteData, SpriteInfo compareData = null)
		{
			bool flag = spriteData == null;
			if (flag)
			{
				this.m_SkillPool.ReturnAll(false);
				this.m_MainSkill.SetActive(false);
			}
			else
			{
				this.CreateSpriteSkill(spriteData.PassiveSkillID, spriteData.SkillID, spriteData.EvolutionLevel);
			}
		}

		// Token: 0x0600FFA8 RID: 65448 RVA: 0x003C784C File Offset: 0x003C5A4C
		public void SetSpriteAttributeInfo(uint spriteID)
		{
			this.attrCompareData.Clear();
			this.aptitudeCompareData.Clear();
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			SpriteTable.RowData bySpriteID = specificDocument._SpriteTable.GetBySpriteID(spriteID);
			bool flag = bySpriteID == null;
			if (!flag)
			{
				List<uint> passiveSkillID = new List<uint>();
				this.CreateSpriteSkill(passiveSkillID, bySpriteID.SpriteSkillID, 0U);
			}
		}

		// Token: 0x0400712D RID: 28973
		private XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400712E RID: 28974
		private IXUIList m_SkillList;

		// Token: 0x0400712F RID: 28975
		private GameObject m_MainSkill;

		// Token: 0x04007130 RID: 28976
		private Dictionary<uint, double> attrCompareData = new Dictionary<uint, double>();

		// Token: 0x04007131 RID: 28977
		private Dictionary<uint, double> aptitudeCompareData = new Dictionary<uint, double>();

		// Token: 0x04007132 RID: 28978
		private List<uint> m_passiveSkillID = new List<uint>();

		// Token: 0x04007133 RID: 28979
		private uint m_mainSkillID;

		// Token: 0x04007134 RID: 28980
		private uint m_mainSkillLevel;
	}
}
