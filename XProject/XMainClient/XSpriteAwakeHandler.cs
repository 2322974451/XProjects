using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D0B RID: 3339
	internal class XSpriteAwakeHandler : DlgHandlerBase
	{
		// Token: 0x170032DA RID: 13018
		// (get) Token: 0x0600BA86 RID: 47750 RVA: 0x00261A8C File Offset: 0x0025FC8C
		protected override string FileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteAwakeWindow";
			}
		}

		// Token: 0x0600BA87 RID: 47751 RVA: 0x00261AA4 File Offset: 0x0025FCA4
		protected override void Init()
		{
			Transform parent = base.PanelObject.transform.Find("Bg/AvatarRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this._AvatarHandler, parent, true, this);
			Transform parent2 = base.PanelObject.transform.Find("Bg/CurrFrameRoot/AptitudeRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler1, parent2, true, this);
			Transform parent3 = base.PanelObject.transform.Find("Bg/AfterFrameRoot/AptitudeRoot");
			DlgHandlerBase.EnsureCreate<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler2, parent3, true, this);
			this.m_CurrPower = (base.PanelObject.transform.Find("Bg/CurrPower").GetComponent("XUILabel") as IXUILabel);
			this.m_AfterPower = (base.PanelObject.transform.Find("Bg/AfterPower").GetComponent("XUILabel") as IXUILabel);
			this.m_ArrowUp = base.PanelObject.transform.Find("Bg/ArrowUp");
			this.m_ArrowDown = base.PanelObject.transform.Find("Bg/ArrowDown");
			this.m_btnKeepOrigHighlight = base.PanelObject.transform.Find("Bg/KeepOrig/Recommend").gameObject;
			this.m_btnEnsureAwakeHighlight = base.PanelObject.transform.Find("Bg/EnsureAwake/Recommend").gameObject;
			this.m_Tip = (base.PanelObject.transform.FindChild("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600BA88 RID: 47752 RVA: 0x00261C15 File Offset: 0x0025FE15
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this._AvatarHandler);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler1);
			DlgHandlerBase.EnsureUnload<XSpriteAttributeAHandler>(ref this.m_AptitudeHandler2);
			base.OnUnload();
		}

		// Token: 0x0600BA89 RID: 47753 RVA: 0x00261C44 File Offset: 0x0025FE44
		public override void RegisterEvent()
		{
			IXUIButton ixuibutton = base.PanelObject.transform.Find("Bg/KeepOrig").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnKeepOrgClicked));
			IXUIButton ixuibutton2 = base.PanelObject.transform.Find("Bg/EnsureAwake").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnsureAwakeClicked));
		}

		// Token: 0x0600BA8A RID: 47754 RVA: 0x00261CC4 File Offset: 0x0025FEC4
		private bool OnKeepOrgClicked(IXUIButton btn)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._AwakeWindow.SetVisible(false);
			return true;
		}

		// Token: 0x0600BA8B RID: 47755 RVA: 0x00261CE8 File Offset: 0x0025FEE8
		protected override void OnShow()
		{
			base.OnShow();
			this._AvatarHandler.SetVisible(true);
			this.m_Tip.SetText(XSingleton<XStringTable>.singleton.GetString("SpriteAwake_Tip2"));
		}

		// Token: 0x0600BA8C RID: 47756 RVA: 0x00261D1A File Offset: 0x0025FF1A
		protected override void OnHide()
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.SetAvatar();
			this._AvatarHandler.SetVisible(false);
			base.OnHide();
		}

		// Token: 0x0600BA8D RID: 47757 RVA: 0x00261D44 File Offset: 0x0025FF44
		private bool OnEnsureAwakeClicked(IXUIButton btn)
		{
			DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteMainFrame.OnAwakeBtnClick(null);
			return true;
		}

		// Token: 0x0600BA8E RID: 47758 RVA: 0x00261D68 File Offset: 0x0025FF68
		private bool OnKeepNew(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			specificDocument.ReqSpriteOperation(SpriteType.Sprite_Awake_Replace);
			return true;
		}

		// Token: 0x0600BA8F RID: 47759 RVA: 0x00261D9C File Offset: 0x0025FF9C
		public void SetSpritesInfo(SpriteInfo currSprite, SpriteInfo newSprite)
		{
			this.m_OrgInfo = currSprite;
			this.m_NewInfo = newSprite;
			this._AvatarHandler.SetSpriteInfo(currSprite, XSingleton<XAttributeMgr>.singleton.XPlayerData, 6, false, true);
			this.m_CurrPower.SetText(currSprite.PowerPoint.ToString());
			this.m_AptitudeHandler1.SetSpriteAttributeInfo(currSprite, XSingleton<XAttributeMgr>.singleton.XPlayerData, null);
			this.m_AptitudeHandler2.SetSpriteAttributeInfo(newSprite, XSingleton<XAttributeMgr>.singleton.XPlayerData, currSprite);
			this.m_ArrowUp.gameObject.SetActive(newSprite.PowerPoint > currSprite.PowerPoint);
			this.m_ArrowDown.gameObject.SetActive(newSprite.PowerPoint < currSprite.PowerPoint);
			bool flag = newSprite.PowerPoint > currSprite.PowerPoint;
			if (flag)
			{
				this.m_AfterPower.SetText(XStringDefineProxy.GetString("SpriteAttributeUpColor", new object[]
				{
					newSprite.PowerPoint
				}));
			}
			else
			{
				bool flag2 = newSprite.PowerPoint < currSprite.PowerPoint;
				if (flag2)
				{
					this.m_AfterPower.SetText(XStringDefineProxy.GetString("SpriteAttributeDownColor", new object[]
					{
						newSprite.PowerPoint
					}));
				}
				else
				{
					this.m_AfterPower.SetText(newSprite.PowerPoint.ToString());
				}
			}
		}

		// Token: 0x04004AEA RID: 19178
		private XSpriteAvatarHandler _AvatarHandler;

		// Token: 0x04004AEB RID: 19179
		private XSpriteAttributeAHandler m_AptitudeHandler1;

		// Token: 0x04004AEC RID: 19180
		private XSpriteAttributeAHandler m_AptitudeHandler2;

		// Token: 0x04004AED RID: 19181
		private IXUILabel m_CurrPower;

		// Token: 0x04004AEE RID: 19182
		private IXUILabel m_AfterPower;

		// Token: 0x04004AEF RID: 19183
		private Transform m_ArrowUp;

		// Token: 0x04004AF0 RID: 19184
		private Transform m_ArrowDown;

		// Token: 0x04004AF1 RID: 19185
		private GameObject m_btnKeepOrigHighlight;

		// Token: 0x04004AF2 RID: 19186
		private GameObject m_btnEnsureAwakeHighlight;

		// Token: 0x04004AF3 RID: 19187
		private SpriteInfo m_OrgInfo;

		// Token: 0x04004AF4 RID: 19188
		private SpriteInfo m_NewInfo;

		// Token: 0x04004AF5 RID: 19189
		private IXUILabel m_Tip;
	}
}
