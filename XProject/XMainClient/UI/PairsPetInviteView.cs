using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F7 RID: 6135
	internal class PairsPetInviteView : DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>
	{
		// Token: 0x170038DB RID: 14555
		// (get) Token: 0x0600FE64 RID: 65124 RVA: 0x003BD154 File Offset: 0x003BB354
		public override string fileName
		{
			get
			{
				return "GameSystem/DoublepetInvitation";
			}
		}

		// Token: 0x170038DC RID: 14556
		// (get) Token: 0x0600FE65 RID: 65125 RVA: 0x003BD16C File Offset: 0x003BB36C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038DD RID: 14557
		// (get) Token: 0x0600FE66 RID: 65126 RVA: 0x003BD180 File Offset: 0x003BB380
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038DE RID: 14558
		// (get) Token: 0x0600FE67 RID: 65127 RVA: 0x003BD194 File Offset: 0x003BB394
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038DF RID: 14559
		// (get) Token: 0x0600FE68 RID: 65128 RVA: 0x003BD1A8 File Offset: 0x003BB3A8
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600FE69 RID: 65129 RVA: 0x003BD1BB File Offset: 0x003BB3BB
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600FE6A RID: 65130 RVA: 0x003BD1C8 File Offset: 0x003BB3C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_ignoreBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickIgnoreAllBtn));
			base.uiBehaviour.m_tempRejectBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickTempRejectBtn));
		}

		// Token: 0x0600FE6B RID: 65131 RVA: 0x003BD234 File Offset: 0x003BB434
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FE6C RID: 65132 RVA: 0x003BD23E File Offset: 0x003BB43E
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600FE6D RID: 65133 RVA: 0x003BD275 File Offset: 0x003BB475
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FE6E RID: 65134 RVA: 0x003BD27F File Offset: 0x003BB47F
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_wrapContent.gameObject.SetActive(false);
			this.m_doc.OnReqInviteList();
		}

		// Token: 0x0600FE6F RID: 65135 RVA: 0x003BD2AC File Offset: 0x003BB4AC
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FE70 RID: 65136 RVA: 0x003BD2B6 File Offset: 0x003BB4B6
		public void RefreshUi()
		{
			this.FillContent();
		}

		// Token: 0x0600FE71 RID: 65137 RVA: 0x003BD2C0 File Offset: 0x003BB4C0
		private void FillContent()
		{
			base.uiBehaviour.m_wrapContent.gameObject.SetActive(true);
			base.uiBehaviour.m_wrapContent.SetContentCount(this.m_doc.PetInviteInfolist.Count, false);
		}

		// Token: 0x0600FE72 RID: 65138 RVA: 0x003BD2FC File Offset: 0x003BB4FC
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index >= this.m_doc.PetInviteInfolist.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index >= PetInviteInfolist.Count", null, null, null, null, null);
			}
			else
			{
				PetInviteInfo petInviteInfo = this.m_doc.PetInviteInfolist[index];
				IXUISprite ixuisprite = t.FindChild("head").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetSuperRiskAvatar(petInviteInfo.profession % 10U);
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				ixuilabelSymbol.InputText = petInviteInfo.rolename;
				IXUILabel ixuilabel = t.FindChild("PPT").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(petInviteInfo.ppt.ToString());
				PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(petInviteInfo.petconfigid);
				ixuisprite = (t.FindChild("Item/Quality").GetComponent("XUISprite") as IXUISprite);
				bool flag2 = petInfo != null;
				if (flag2)
				{
					ixuisprite.SetSprite(XSingleton<UiUtility>.singleton.GetItemQualityFrame((int)petInfo.quality, 0));
				}
				else
				{
					ixuisprite.SetSprite("");
				}
				ixuisprite = (t.FindChild("Item/PetIcon").GetComponent("XUISprite") as IXUISprite);
				bool flag3 = petInfo != null;
				if (flag3)
				{
					ixuisprite.SetSprite(petInfo.icon, petInfo.Atlas, false);
				}
				else
				{
					ixuisprite.SetSprite("");
				}
				ixuilabel = (t.FindChild("PetName").GetComponent("XUILabel") as IXUILabel);
				bool flag4 = petInfo != null;
				if (flag4)
				{
					ixuilabel.SetText(petInfo.name);
				}
				else
				{
					ixuilabel.SetText("");
				}
				ixuilabel = (t.FindChild("PetPPT").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(petInviteInfo.petppt.ToString());
				ixuilabel = (t.FindChild("SpeedUp").GetComponent("XUILabel") as IXUILabel);
				bool flag5 = petInfo != null;
				if (flag5)
				{
					BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)petInfo.SpeedBuff, 1);
					bool flag6 = buffData != null;
					if (flag6)
					{
						ixuilabel.SetText(string.Format("{0}%", (buffData.BuffChangeAttribute[0, 1] + 100f).ToString()));
					}
				}
				else
				{
					ixuilabel.SetText("");
				}
				IXUIButton ixuibutton = t.FindChild("Mentorship").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = petInviteInfo.roleid;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDrive));
			}
		}

		// Token: 0x0600FE73 RID: 65139 RVA: 0x003BD5BC File Offset: 0x003BB7BC
		private bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FE74 RID: 65140 RVA: 0x003BD5D8 File Offset: 0x003BB7D8
		private bool OnClickIgnoreAllBtn(IXUIButton btn)
		{
			this.SetVisible(false, true);
			this.m_doc.OnReqIgnoreAll();
			return true;
		}

		// Token: 0x0600FE75 RID: 65141 RVA: 0x003BD600 File Offset: 0x003BB800
		private bool OnClickTempRejectBtn(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600FE76 RID: 65142 RVA: 0x003BD61C File Offset: 0x003BB81C
		private bool OnClickDrive(IXUIButton btn)
		{
			ulong id = btn.ID;
			this.m_doc.ReqPetPetOperationOther(PetOtherOp.AgreePetPairRide, id);
			return true;
		}

		// Token: 0x04007065 RID: 28773
		private XPetDocument m_doc;
	}
}
