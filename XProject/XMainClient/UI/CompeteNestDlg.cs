using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D5 RID: 5845
	internal class CompeteNestDlg : DlgBase<CompeteNestDlg, CompeteNestBehaviour>
	{
		// Token: 0x17003740 RID: 14144
		// (get) Token: 0x0600F10E RID: 61710 RVA: 0x00352890 File Offset: 0x00350A90
		public override string fileName
		{
			get
			{
				return "OperatingActivity/CompeteNest";
			}
		}

		// Token: 0x17003741 RID: 14145
		// (get) Token: 0x0600F10F RID: 61711 RVA: 0x003528A8 File Offset: 0x00350AA8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003742 RID: 14146
		// (get) Token: 0x0600F110 RID: 61712 RVA: 0x003528BC File Offset: 0x00350ABC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003743 RID: 14147
		// (get) Token: 0x0600F111 RID: 61713 RVA: 0x003528D0 File Offset: 0x00350AD0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003744 RID: 14148
		// (get) Token: 0x0600F112 RID: 61714 RVA: 0x003528E4 File Offset: 0x00350AE4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003745 RID: 14149
		// (get) Token: 0x0600F113 RID: 61715 RVA: 0x003528F8 File Offset: 0x00350AF8
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F114 RID: 61716 RVA: 0x0035290B File Offset: 0x00350B0B
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XCompeteDocument>(XCompeteDocument.uuID);
			this.m_doc.View = this;
		}

		// Token: 0x0600F115 RID: 61717 RVA: 0x00352934 File Offset: 0x00350B34
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_goBattleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoBattleClicked));
			base.uiBehaviour.m_rankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankBtnClicked));
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosed));
			base.uiBehaviour.m_claimBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClaim));
		}

		// Token: 0x0600F116 RID: 61718 RVA: 0x003529C0 File Offset: 0x00350BC0
		protected override void OnShow()
		{
			this.m_doc.HadRedDot = false;
			base.uiBehaviour.m_tipsLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeekDragonTips")));
			this.m_doc.ReqCompeteDragonInfo();
		}

		// Token: 0x0600F117 RID: 61719 RVA: 0x00352A11 File Offset: 0x00350C11
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F118 RID: 61720 RVA: 0x00352A1B File Offset: 0x00350C1B
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600F119 RID: 61721 RVA: 0x00352A25 File Offset: 0x00350C25
		protected override void OnUnload()
		{
			base.uiBehaviour.m_bgTexture.SetTexturePath("");
			DlgHandlerBase.EnsureUnload<CompeteNestRankHandler>(ref this.m_rankHandler);
			base.OnUnload();
		}

		// Token: 0x0600F11A RID: 61722 RVA: 0x00352A51 File Offset: 0x00350C51
		public void Resfresh()
		{
			this.FillContent();
		}

		// Token: 0x0600F11B RID: 61723 RVA: 0x00352A5C File Offset: 0x00350C5C
		private void FillContent()
		{
			XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
			ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(this.m_doc.CurDNid);
			int leftRewardCount = this.m_doc.LeftRewardCount;
			int getRewardMax = this.m_doc.GetRewardMax;
			base.uiBehaviour.m_timesLab.SetText(string.Format("{0}/{1}", leftRewardCount, getRewardMax));
			base.uiBehaviour.m_claimBtn.SetEnable(this.m_doc.CanGetCount != 0, false);
			base.uiBehaviour.m_claimredpoint.gameObject.SetActive(this.m_doc.CanGetCount > 0);
			this.FillBgTexture();
			bool flag = expeditionDataByID != null;
			if (flag)
			{
				base.uiBehaviour.m_tittleLab.SetText(expeditionDataByID.DNExpeditionName);
				this.FillItem(expeditionDataByID);
			}
		}

		// Token: 0x0600F11C RID: 61724 RVA: 0x00352B4C File Offset: 0x00350D4C
		private void FillItem(ExpeditionTable.RowData rowData)
		{
			base.uiBehaviour.m_ItemPool.ReturnAll(false);
			bool flag = rowData.ViewableDropList == null || rowData.ViewableDropList.Length == 0;
			if (!flag)
			{
				for (int i = 0; i < rowData.ViewableDropList.Length; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_ItemPool.FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_itemsGo.transform;
					gameObject.name = i.ToString();
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.m_ItemPool.TplWidth * i), 0f, 0f);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)rowData.ViewableDropList[i];
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rowData.ViewableDropList[i], 0, false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
		}

		// Token: 0x0600F11D RID: 61725 RVA: 0x00352C88 File Offset: 0x00350E88
		private void FillBgTexture()
		{
			string picNameByDNid = this.m_doc.GetPicNameByDNid((uint)this.m_doc.CurDNid);
			bool flag = picNameByDNid == "" || picNameByDNid == null;
			if (flag)
			{
				base.uiBehaviour.m_bgTexture.SetTexturePath("atlas/UI/common/Pic/Loading_23_h2Split");
			}
			else
			{
				base.uiBehaviour.m_bgTexture.SetTexturePath("atlas/UI/common/Pic/" + this.m_doc.GetPicNameByDNid((uint)this.m_doc.CurDNid));
			}
		}

		// Token: 0x0600F11E RID: 61726 RVA: 0x00352D10 File Offset: 0x00350F10
		private bool OnGoBattleClicked(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				specificDocument.SetAndMatch(this.m_doc.CurDNid);
				result = true;
			}
			return result;
		}

		// Token: 0x0600F11F RID: 61727 RVA: 0x00352D54 File Offset: 0x00350F54
		private bool OnRankBtnClicked(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgHandlerBase.EnsureCreate<CompeteNestRankHandler>(ref this.m_rankHandler, base.uiBehaviour.m_rankTra, true, this);
				result = true;
			}
			return result;
		}

		// Token: 0x0600F120 RID: 61728 RVA: 0x00352D94 File Offset: 0x00350F94
		private bool OnClickClosed(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.SetVisible(false, true);
				result = true;
			}
			return result;
		}

		// Token: 0x0600F121 RID: 61729 RVA: 0x00352DC4 File Offset: 0x00350FC4
		private bool OnClickClaim(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_doc.ReqFetchReward();
				result = true;
			}
			return result;
		}

		// Token: 0x0600F122 RID: 61730 RVA: 0x00352DF8 File Offset: 0x00350FF8
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x040066F6 RID: 26358
		private XCompeteDocument m_doc;

		// Token: 0x040066F7 RID: 26359
		public CompeteNestRankHandler m_rankHandler;

		// Token: 0x040066F8 RID: 26360
		private float m_fCoolTime = 0.5f;

		// Token: 0x040066F9 RID: 26361
		private float m_fLastClickBtnTime = 0f;
	}
}
