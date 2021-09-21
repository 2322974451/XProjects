using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C82 RID: 3202
	internal class PetSkillLearnHandler : DlgHandlerBase
	{
		// Token: 0x0600B4F6 RID: 46326 RVA: 0x0023902C File Offset: 0x0023722C
		protected override void Init()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Init", null, null, null, null, null);
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.FindChild("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_PetListScrollView = (base.transform.Find("Bg/SkillBookPanel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.Find("Bg/SkillBookPanel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_BtnGetSkillBook = (base.transform.FindChild("Bg/BtnGetSkillBook").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x1700320B RID: 12811
		// (get) Token: 0x0600B4F7 RID: 46327 RVA: 0x00239120 File Offset: 0x00237320
		protected override string FileName
		{
			get
			{
				return "GameSystem/PetSkillLearn";
			}
		}

		// Token: 0x0600B4F8 RID: 46328 RVA: 0x00239138 File Offset: 0x00237338
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnSkillBookListUpdated));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_BtnGetSkillBook.ID = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetGoBuySkillBook"));
			this.m_BtnGetSkillBook.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoClick));
		}

		// Token: 0x0600B4F9 RID: 46329 RVA: 0x002391D0 File Offset: 0x002373D0
		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600B4FA RID: 46330 RVA: 0x002391EC File Offset: 0x002373EC
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Horse_LearnSkill);
			return true;
		}

		// Token: 0x0600B4FB RID: 46331 RVA: 0x0023920F File Offset: 0x0023740F
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshList(true);
			XSingleton<XDebug>.singleton.AddGreenLog("OnShow", null, null, null, null, null);
		}

		// Token: 0x0600B4FC RID: 46332 RVA: 0x00239236 File Offset: 0x00237436
		protected override void OnHide()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnHide", null, null, null, null, null);
			base.OnHide();
		}

		// Token: 0x0600B4FD RID: 46333 RVA: 0x00239255 File Offset: 0x00237455
		public override void OnUnload()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnUnload", null, null, null, null, null);
			this.doc = null;
			base.OnUnload();
		}

		// Token: 0x0600B4FE RID: 46334 RVA: 0x0023927C File Offset: 0x0023747C
		public void RefreshList(bool bResetPosition = true)
		{
			int count = this.doc.GetSkillBook().Count;
			this.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				this.m_PetListScrollView.ResetPosition();
			}
			else
			{
				this.m_WrapContent.RefreshAllVisibleContents();
			}
		}

		// Token: 0x0600B4FF RID: 46335 RVA: 0x002392C8 File Offset: 0x002374C8
		private void OnSkillBookListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this.doc.SkillBookList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index:" + index, null, null, null, null, null);
			}
			else
			{
				Transform transform = t.FindChild("Item");
				IXUISprite ixuisprite = transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUIButton ixuibutton = t.FindChild("BtnLearn").GetComponent("XUIButton") as IXUIButton;
				XItem xitem = this.doc.SkillBookList[index];
				XSingleton<XItemDrawerMgr>.singleton.DrawItem(transform.gameObject, xitem);
				ixuisprite.ID = (ulong)((long)xitem.itemID);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
				ixuibutton.ID = xitem.uid;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnLearnSkillClick));
				PetSkillBook.RowData petSkillBook = XPetDocument.GetPetSkillBook((uint)xitem.itemID);
				IXUILabel ixuilabel = t.FindChild("Description").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(petSkillBook.Description);
			}
		}

		// Token: 0x0600B500 RID: 46336 RVA: 0x001EECC3 File Offset: 0x001ECEC3
		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		// Token: 0x0600B501 RID: 46337 RVA: 0x00239400 File Offset: 0x00237600
		private bool _OnLearnSkillClick(IXUIButton btn)
		{
			this.ReqRecentMount(btn.ID, this.doc.CurSelectedPet.UID);
			return true;
		}

		// Token: 0x0600B502 RID: 46338 RVA: 0x00239430 File Offset: 0x00237630
		private bool OnGoClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)btn.ID, 0UL);
			return true;
		}

		// Token: 0x0600B503 RID: 46339 RVA: 0x00239458 File Offset: 0x00237658
		public void ReqRecentMount(ulong itemuid, ulong petuid)
		{
			RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
			rpcC2G_UseItem.oArg.uid = itemuid;
			rpcC2G_UseItem.oArg.petid = petuid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
		}

		// Token: 0x0400468B RID: 18059
		private XPetDocument doc;

		// Token: 0x0400468C RID: 18060
		private IXUIButton m_Close;

		// Token: 0x0400468D RID: 18061
		private IXUIButton m_Help;

		// Token: 0x0400468E RID: 18062
		private IXUIButton m_BtnGetSkillBook;

		// Token: 0x0400468F RID: 18063
		private IXUIScrollView m_PetListScrollView;

		// Token: 0x04004690 RID: 18064
		private IXUIWrapContent m_WrapContent;
	}
}
