using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PairsPetInviteView : DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/DoublepetInvitation";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_ignoreBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickIgnoreAllBtn));
			base.uiBehaviour.m_tempRejectBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickTempRejectBtn));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			base.uiBehaviour.m_wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_wrapContent.gameObject.SetActive(false);
			this.m_doc.OnReqInviteList();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public void RefreshUi()
		{
			this.FillContent();
		}

		private void FillContent()
		{
			base.uiBehaviour.m_wrapContent.gameObject.SetActive(true);
			base.uiBehaviour.m_wrapContent.SetContentCount(this.m_doc.PetInviteInfolist.Count, false);
		}

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

		private bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnClickIgnoreAllBtn(IXUIButton btn)
		{
			this.SetVisible(false, true);
			this.m_doc.OnReqIgnoreAll();
			return true;
		}

		private bool OnClickTempRejectBtn(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnClickDrive(IXUIButton btn)
		{
			ulong id = btn.ID;
			this.m_doc.ReqPetPetOperationOther(PetOtherOp.AgreePetPairRide, id);
			return true;
		}

		private XPetDocument m_doc;
	}
}
