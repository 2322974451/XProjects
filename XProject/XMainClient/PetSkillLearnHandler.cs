using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class PetSkillLearnHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "GameSystem/PetSkillLearn";
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnSkillBookListUpdated));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
			this.m_BtnGetSkillBook.ID = ulong.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetGoBuySkillBook"));
			this.m_BtnGetSkillBook.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoClick));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			base.SetVisible(false);
			return true;
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Horse_LearnSkill);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshList(true);
			XSingleton<XDebug>.singleton.AddGreenLog("OnShow", null, null, null, null, null);
		}

		protected override void OnHide()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnHide", null, null, null, null, null);
			base.OnHide();
		}

		public override void OnUnload()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("OnUnload", null, null, null, null, null);
			this.doc = null;
			base.OnUnload();
		}

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

		private void _OnItemClick(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)iSp.ID, null);
		}

		private bool _OnLearnSkillClick(IXUIButton btn)
		{
			this.ReqRecentMount(btn.ID, this.doc.CurSelectedPet.UID);
			return true;
		}

		private bool OnGoClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)btn.ID, 0UL);
			return true;
		}

		public void ReqRecentMount(ulong itemuid, ulong petuid)
		{
			RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
			rpcC2G_UseItem.oArg.uid = itemuid;
			rpcC2G_UseItem.oArg.petid = petuid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
		}

		private XPetDocument doc;

		private IXUIButton m_Close;

		private IXUIButton m_Help;

		private IXUIButton m_BtnGetSkillBook;

		private IXUIScrollView m_PetListScrollView;

		private IXUIWrapContent m_WrapContent;
	}
}
