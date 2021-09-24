using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPetSkillHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._PetDoc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			this.m_SkillTpl = base.PanelObject.transform.Find("SkillTpl");
			this.m_SkillPool.SetupPool(null, this.m_SkillTpl.gameObject, XPetSkillHandler.SKILL_MAX, false);
			int num = 0;
			while ((long)num < (long)((ulong)XPetSkillHandler.SKILL_MAX))
			{
				GameObject gameObject = this.m_SkillPool.FetchGameObject(false);
				gameObject.name = string.Format("Skill{0}", num);
				num++;
			}
			Transform transform = base.PanelObject.transform.Find("Tips");
			bool flag = transform != null;
			if (flag)
			{
				this.m_SkillTips = (transform.GetComponent("XUISprite") as IXUISprite);
				this.m_SkillTips.gameObject.SetActive(false);
			}
			this.m_NewSkill = base.PanelObject.transform.Find("NewSkill");
			bool flag2 = this.m_NewSkill != null;
			if (flag2)
			{
				this.m_NewSkillText = (this.m_NewSkill.Find("level").GetComponent("XUILabel") as IXUILabel);
				this.m_NewSkillIcon = this.m_NewSkill.Find("NewSkilllIcon");
				this.m_NewSkillClose = (this.m_NewSkill.Find("Close").GetComponent("XUISprite") as IXUISprite);
				this.m_NewSkillClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnNewSkillCloseClick));
				this.m_NewSkill.gameObject.SetActive(false);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		public override void OnUnload()
		{
			this._PetDoc = null;
			base.OnUnload();
		}

		public void Refresh(XPet pet)
		{
			this.CurPet = pet;
			bool flag = this.CurPet == null;
			if (!flag)
			{
				PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(this.CurPet.ID);
				uint num = petInfo.randSkillMax + XPet.FIX_SKILL_COUNT_MAX;
				this.m_SkillPool.ReturnAll(false);
				int num2 = 0;
				while ((long)num2 < (long)((ulong)XPetSkillHandler.SKILL_VERTICAL_NUM_MAX))
				{
					int num3 = 0;
					while ((long)num3 < (long)((ulong)XPetSkillHandler.SKILL_HORIZONTAL_NUM_MAX))
					{
						GameObject gameObject = this.m_SkillPool.FetchGameObject(false);
						IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
						int spriteWidth = ixuisprite.spriteWidth;
						int spriteHeight = ixuisprite.spriteHeight;
						gameObject.transform.localPosition = new Vector3((float)(spriteWidth * num3), (float)(-(float)spriteHeight * num2), 0f);
						int num4 = (int)((long)num2 * (long)((ulong)XPetSkillHandler.SKILL_HORIZONTAL_NUM_MAX) + (long)num3);
						XPet.Skill skillInfo = null;
						bool flag2 = num4 < this.CurPet.ShowSkillList.Count;
						if (flag2)
						{
							skillInfo = this.CurPet.ShowSkillList[num4];
						}
						bool flag3 = !this._DrawSkillIcon(gameObject, skillInfo, num4, (ulong)num <= (ulong)((long)num4));
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
							{
								"PetSkillCount Error!\n PetID:",
								this.CurPet.ID,
								" CurSKill-SkillNumMAX:",
								this.CurPet.ShowSkillList.Count,
								"-",
								num
							}), null, null, null, null, null);
						}
						ixuisprite.ID = (ulong)((long)num4);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSkillClicked));
						num3++;
					}
					num2++;
				}
			}
		}

		private bool _DrawSkillIcon(GameObject go, XPet.Skill skillInfo, int index = -1, bool isCover = false)
		{
			IXUISprite ixuisprite = null;
			IXUILabel ixuilabel = null;
			IXUISprite ixuisprite2 = null;
			Transform transform = null;
			Transform transform2 = go.transform.Find("SkillIcon");
			bool flag = transform2 != null;
			if (flag)
			{
				ixuisprite = (transform2.GetComponent("XUISprite") as IXUISprite);
			}
			transform2 = go.transform.Find("level");
			bool flag2 = transform2 != null;
			if (flag2)
			{
				ixuilabel = (transform2.GetComponent("XUILabel") as IXUILabel);
			}
			transform2 = go.transform.Find("Quality");
			bool flag3 = transform2 != null;
			if (flag3)
			{
				ixuisprite2 = (transform2.GetComponent("XUISprite") as IXUISprite);
			}
			transform2 = go.transform.Find("Cover");
			bool flag4 = transform2 != null;
			if (flag4)
			{
				transform = transform2;
			}
			bool flag5 = ixuisprite != null;
			if (flag5)
			{
				ixuisprite.SetSprite("");
			}
			bool flag6 = ixuilabel != null;
			if (flag6)
			{
				ixuilabel.gameObject.SetActive(false);
			}
			bool flag7 = ixuisprite2 != null;
			if (flag7)
			{
				ixuisprite2.SetSprite("kuang_zq");
			}
			bool flag8 = transform != null;
			if (flag8)
			{
				transform.gameObject.SetActive(isCover);
			}
			bool flag9 = skillInfo == null;
			bool result;
			if (flag9)
			{
				result = true;
			}
			else if (isCover)
			{
				result = false;
			}
			else
			{
				PetPassiveSkillTable.RowData petSkill = XPetDocument.GetPetSkill(skillInfo.id);
				bool flag10 = petSkill == null;
				if (flag10)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("PetSkill Id:" + skillInfo.id + " No Find!", null, null, null, null, null);
				}
				bool flag11 = ixuisprite != null;
				if (flag11)
				{
					ixuisprite.SetSprite(petSkill.Icon);
				}
				bool flag12 = ixuisprite != null;
				if (flag12)
				{
					ixuisprite.SetColor(Color.white);
				}
				bool flag13 = !skillInfo.open;
				if (flag13)
				{
					PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(this.CurPet.ID);
					bool flag14 = ixuilabel != null;
					if (flag14)
					{
						ixuilabel.gameObject.SetActive(true);
						ixuilabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PET_LEVEL_OPEN"), petInfo.LvRequire[index]));
					}
					bool flag15 = ixuisprite != null;
					if (flag15)
					{
						ixuisprite.SetColor(Color.black);
					}
				}
				bool flag16 = ixuisprite2 != null;
				if (flag16)
				{
					ixuisprite2.SetSprite(string.Format("kuang_zq0{0}", petSkill.quality));
				}
				result = true;
			}
			return result;
		}

		private void _OnSkillClicked(IXUISprite iSp)
		{
			bool flag = this.CurPet == null;
			if (!flag)
			{
				int num = (int)iSp.ID;
				bool flag2 = num >= this.CurPet.ShowSkillList.Count;
				if (!flag2)
				{
					XPet.Skill skill = this.CurPet.ShowSkillList[num];
					PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(this.CurPet.ID);
					uint id = skill.id;
					this.m_SkillTips.SetVisible(true);
					Transform transform = this.m_SkillTips.gameObject.transform;
					Transform parent = base.PanelObject.transform.Find(string.Format("Skill{0}", num));
					Vector3 localPosition = transform.localPosition;
					XSingleton<UiUtility>.singleton.AddChild(parent, transform);
					transform.localPosition = localPosition;
					bool flag3 = this.uiSkillTipsClose == null;
					if (flag3)
					{
						this.uiSkillTipsClose = (transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
						this.uiIcon = (transform.Find("uiIcon").GetComponent("XUISprite") as IXUISprite);
						this.uiQuality = (transform.Find("Quality").GetComponent("XUISprite") as IXUISprite);
						this.uiName = (transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
						this.uiExplanation = (transform.Find("Explanation").GetComponent("XUILabel") as IXUILabel);
						this.uiOpenCondition = (transform.Find("OpenCondition").GetComponent("XUILabel") as IXUILabel);
					}
					this.uiSkillTipsClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnSkillClose));
					PetPassiveSkillTable.RowData petSkill = XPetDocument.GetPetSkill(id);
					this.uiIcon.SetSprite(petSkill.Icon);
					this.uiQuality.SetSprite(string.Format("kuang_zq0{0}", petSkill.quality));
					this.uiName.SetText(petSkill.name);
					this.uiExplanation.SetText(petSkill.Detail);
					bool open = skill.open;
					if (open)
					{
						this.uiOpenCondition.SetText("");
					}
					else
					{
						uint num2 = petInfo.LvRequire[num];
						this.uiOpenCondition.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("PET_OPEN_SKILL"), num2));
					}
				}
			}
		}

		public void PlayNewSkillTip(int newSkillIndex, uint lostSkillId = 0U)
		{
			bool flag = !DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = this.CurPet == null || newSkillIndex >= this.CurPet.ShowSkillList.Count || newSkillIndex < 0;
				if (!flag2)
				{
					XPet.Skill skill = this.CurPet.ShowSkillList[newSkillIndex];
					this.m_NewSkill.gameObject.SetActive(true);
					this.HasGetSkillUI = true;
					PetPassiveSkillTable.RowData petSkill = XPetDocument.GetPetSkill(skill.id);
					string text = string.Format(XSingleton<XStringTable>.singleton.GetString("PET_NEW_SKILL"), this.CurPet.Name, petSkill.name);
					bool flag3 = lostSkillId == 0U;
					if (flag3)
					{
						text = string.Format(XSingleton<XStringTable>.singleton.GetString("PET_NEW_SKILL"), this.CurPet.Name, petSkill.name);
					}
					else
					{
						PetPassiveSkillTable.RowData petSkill2 = XPetDocument.GetPetSkill(lostSkillId);
						text = string.Format(XSingleton<XStringTable>.singleton.GetString("PET_REPLACE_SKILL"), this.CurPet.Name, petSkill.name, petSkill2.name);
					}
					this.m_NewSkillText.SetText(text);
					this._DrawSkillIcon(this.m_NewSkillIcon.gameObject, skill, -1, false);
					this.m_NewSkillClose.ID = (ulong)((long)newSkillIndex);
					this.Refresh(this.CurPet);
				}
			}
		}

		private void _OnSkillClose(IXUISprite iSp)
		{
			this.m_SkillTips.SetVisible(false);
		}

		private void _OnNewSkillCloseClick(IXUISprite iSp)
		{
			this.m_NewSkill.gameObject.SetActive(false);
			this.HasGetSkillUI = false;
			Transform parent = base.PanelObject.transform.Find(string.Format("Skill{0}", iSp.ID));
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/VehicleFX/Vehicle_jnjh", parent, Vector3.zero, Vector3.one, 1f, false, 3f, true);
		}

		private XPetDocument _PetDoc;

		public XPet CurPet = null;

		public bool HasGetSkillUI = false;

		private static readonly uint SKILL_HORIZONTAL_NUM_MAX = 4U;

		private static readonly uint SKILL_VERTICAL_NUM_MAX = 2U;

		public static readonly uint SKILL_MAX = 8U;

		private Transform m_SkillTpl;

		private IXUISprite m_SkillTips;

		private XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_NewSkill;

		private IXUILabel m_NewSkillText;

		private Transform m_NewSkillIcon;

		private IXUISprite m_NewSkillClose;

		private IXUISprite uiSkillTipsClose;

		private IXUISprite uiIcon;

		private IXUISprite uiQuality;

		private IXUILabel uiName;

		private IXUILabel uiExplanation;

		private IXUILabel uiOpenCondition;
	}
}
