using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200189C RID: 6300
	internal class XGuildRedPacketDetailView : DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>
	{
		// Token: 0x170039F2 RID: 14834
		// (get) Token: 0x0601066C RID: 67180 RVA: 0x003FFFF4 File Offset: 0x003FE1F4
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRedPackageDetailPanel";
			}
		}

		// Token: 0x170039F3 RID: 14835
		// (get) Token: 0x0601066D RID: 67181 RVA: 0x0040000C File Offset: 0x003FE20C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039F4 RID: 14836
		// (get) Token: 0x0601066E RID: 67182 RVA: 0x00400020 File Offset: 0x003FE220
		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170039F5 RID: 14837
		// (get) Token: 0x0601066F RID: 67183 RVA: 0x00400034 File Offset: 0x003FE234
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010670 RID: 67184 RVA: 0x00400048 File Offset: 0x003FE248
		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			DlgHandlerBase.EnsureCreate<XGuildRedPakageLogView>(ref this.m_LogView, base.uiBehaviour.m_LogPanel, null, true);
			this.m_LogView.LogSource = this._Doc;
		}

		// Token: 0x06010671 RID: 67185 RVA: 0x004000A4 File Offset: 0x003FE2A4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_bgSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_Reply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnReplyBtnClick));
		}

		// Token: 0x06010672 RID: 67186 RVA: 0x004000F3 File Offset: 0x003FE2F3
		public void ShowEffect(bool state, uint id = 0U)
		{
			this.m_ShowEffect = state;
			this.m_selectID = id;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x06010673 RID: 67187 RVA: 0x00400110 File Offset: 0x003FE310
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.ReqDetail(this.m_selectID);
			bool showEffect = this.m_ShowEffect;
			if (showEffect)
			{
				this.m_maskXfx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_ghhb_cd_01", base.uiBehaviour.m_bgSprite.gameObject.transform, false);
				XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_ghhb_cd", base.uiBehaviour.m_root, Vector3.zero, Vector3.one, 1f, true, 3f, true);
				this.m_ShowEffect = false;
			}
			base.uiBehaviour.m_playTween.PlayTween(true, -1f);
		}

		// Token: 0x06010674 RID: 67188 RVA: 0x004001C0 File Offset: 0x003FE3C0
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = base.uiBehaviour.m_playTween != null;
			if (flag)
			{
				base.uiBehaviour.m_playTween.ResetTween(true);
			}
			bool flag2 = this.m_maskXfx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_maskXfx, true);
				this.m_maskXfx = null;
			}
			base.uiBehaviour.m_sendHeadTexture.SetTexturePath("");
		}

		// Token: 0x06010675 RID: 67189 RVA: 0x0040023C File Offset: 0x003FE43C
		protected override void OnUnload()
		{
			bool flag = this.m_maskXfx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_maskXfx, true);
				this.m_maskXfx = null;
			}
			DlgHandlerBase.EnsureUnload<XGuildRedPakageLogView>(ref this.m_LogView);
			base.OnUnload();
		}

		// Token: 0x06010676 RID: 67190 RVA: 0x00400288 File Offset: 0x003FE488
		public void Refresh()
		{
			XGuildRedPacketDetail packetDetail = this._Doc.PacketDetail;
			this.m_LogView.Refresh();
			this._RefreshContent(packetDetail);
			this._RefreshReason(packetDetail);
			this._RefreshReply(packetDetail);
		}

		// Token: 0x06010677 RID: 67191 RVA: 0x004002C8 File Offset: 0x003FE4C8
		public void _RefreshReply(XGuildRedPacketDetail detailData)
		{
			bool flag = detailData.canThank && Time.time < detailData.brif.endTime && detailData.brif.fetchState != FetchState.FS_CANNOT_FETCH;
			base.uiBehaviour.m_ReplyLabel.SetText(flag ? XStringDefineProxy.GetString("QUICK_REPLY_1") : XStringDefineProxy.GetString("GUILD_REDPACKET_DETAIL_EXIT"));
		}

		// Token: 0x06010678 RID: 67192 RVA: 0x00400330 File Offset: 0x003FE530
		public void _RefreshReason(XGuildRedPacketDetail data)
		{
			GuildBonusTable.RowData redPacketConfig = XGuildRedPacketDocument.GetRedPacketConfig(data.brif.typeid);
			bool flag = redPacketConfig == null;
			if (flag)
			{
				base.uiBehaviour.m_Reason.InputText = "";
			}
			else
			{
				string guildBonusDesc = redPacketConfig.GuildBonusDesc;
				bool flag2 = guildBonusDesc.Contains("{0}");
				if (flag2)
				{
					base.uiBehaviour.m_Reason.InputText = string.Format(guildBonusDesc, data.brif.senderName);
				}
				else
				{
					base.uiBehaviour.m_Reason.InputText = guildBonusDesc;
				}
			}
		}

		// Token: 0x06010679 RID: 67193 RVA: 0x004003BC File Offset: 0x003FE5BC
		private void _RefreshContent(XGuildRedPacketDetail data)
		{
			base.uiBehaviour.m_Count.SetText(string.Format("{0}/{1}", data.getCount, data.brif.maxCount));
			base.uiBehaviour.m_Money.InputText = string.Format("{0}/{1}", data.getTotalCount, XLabelSymbolHelper.FormatCostWithIconLast(data.itemTotalCount, (ItemEnum)data.brif.itemid));
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = data.brif.sourceID > 0UL;
			if (flag)
			{
				base.uiBehaviour.m_sendHeadSprite.SetVisible(false);
				base.uiBehaviour.m_sendHeadTexture.SetVisible(true);
				XSingleton<XUICacheImage>.singleton.Load(string.IsNullOrEmpty(data.brif.iconUrl) ? string.Empty : data.brif.iconUrl, base.uiBehaviour.m_sendHeadTexture, base.uiBehaviour);
				base.uiBehaviour.m_SendName.InputText = XStringDefineProxy.GetString("GUILD_BONUE_PACKAGE_NAME", new object[]
				{
					data.brif.sourceName
				});
			}
			else
			{
				base.uiBehaviour.m_SendName.InputText = XStringDefineProxy.GetString("GUILD_BONUE_PACKAGE_NAME", new object[]
				{
					specificDocument.BasicData.guildName
				});
				base.uiBehaviour.m_sendHeadSprite.SetVisible(true);
				base.uiBehaviour.m_sendHeadTexture.SetTexturePath("");
				base.uiBehaviour.m_sendHeadTexture.SetVisible(false);
			}
			bool flag2 = data.brif.fetchState == FetchState.FS_CAN_FETCH;
			if (flag2)
			{
				float time = Time.time;
				bool flag3 = time < data.brif.endTime;
				if (flag3)
				{
					base.uiBehaviour.m_Note.InputText = XStringDefineProxy.GetString("GUILD_REDPACKET_FETCH");
				}
				else
				{
					base.uiBehaviour.m_Note.InputText = XStringDefineProxy.GetString("GUILD_REDPACKET_TIMEOVER");
				}
			}
			else
			{
				bool flag4 = data.brif.fetchState == FetchState.FS_CANNOT_FETCH;
				if (flag4)
				{
					base.uiBehaviour.m_Note.InputText = string.Empty;
				}
				else
				{
					ulong roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					int i;
					for (i = 0; i < data.logList.Count; i++)
					{
						XGuildRedPacketLog xguildRedPacketLog = data.logList[i] as XGuildRedPacketLog;
						bool flag5 = xguildRedPacketLog.uid == roleID;
						if (flag5)
						{
							base.uiBehaviour.m_Note.InputText = XLabelSymbolHelper.FormatCostWithIconLast(xguildRedPacketLog.itemcount, (ItemEnum)xguildRedPacketLog.itemid);
							break;
						}
					}
					bool flag6 = i == data.logList.Count;
					if (flag6)
					{
						base.uiBehaviour.m_Note.InputText = XStringDefineProxy.GetString("GUILD_REDPACKET_ALLFETCHED");
					}
				}
			}
		}

		// Token: 0x0601067A RID: 67194 RVA: 0x004006B0 File Offset: 0x003FE8B0
		private bool _OnReplyBtnClick(IXUIButton go)
		{
			XGuildRedPacketDetail packetDetail = this._Doc.PacketDetail;
			bool flag = packetDetail != null && packetDetail.canThank && Time.time < packetDetail.brif.endTime && packetDetail.brif.fetchState != FetchState.FS_CANNOT_FETCH;
			if (flag)
			{
				DlgBase<QuickReplyDlg, XQuickReplyBehavior>.singleton.ShowView(1, new Action<bool>(this.CloseRedPackageDetail));
			}
			else
			{
				this._OnCloseBtnClick(null);
			}
			return true;
		}

		// Token: 0x0601067B RID: 67195 RVA: 0x0040072C File Offset: 0x003FE92C
		private void CloseRedPackageDetail(bool statu)
		{
			if (statu)
			{
				XQuickReplyDocument specificDocument = XDocuments.GetSpecificDocument<XQuickReplyDocument>(XQuickReplyDocument.uuID);
				specificDocument.GetThanksForBonus(this._Doc.PacketDetail.brif.uid);
				this._OnCloseBtnClick(null);
			}
		}

		// Token: 0x0601067C RID: 67196 RVA: 0x00400770 File Offset: 0x003FE970
		private void _OnCloseBtnClick(IXUISprite go)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x04007662 RID: 30306
		private XGuildRedPacketDocument _Doc;

		// Token: 0x04007663 RID: 30307
		private XGuildDocument _GuildDoc;

		// Token: 0x04007664 RID: 30308
		private XGuildRedPakageLogView m_LogView;

		// Token: 0x04007665 RID: 30309
		private uint m_selectID = 0U;

		// Token: 0x04007666 RID: 30310
		private bool m_ShowEffect = false;

		// Token: 0x04007667 RID: 30311
		private XFx m_maskXfx = null;
	}
}
