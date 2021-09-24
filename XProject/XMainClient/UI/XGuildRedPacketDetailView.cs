using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildRedPacketDetailView : DlgBase<XGuildRedPacketDetailView, GuildRedPackageDetailBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRedPackageDetailPanel";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			DlgHandlerBase.EnsureCreate<XGuildRedPakageLogView>(ref this.m_LogView, base.uiBehaviour.m_LogPanel, null, true);
			this.m_LogView.LogSource = this._Doc;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_bgSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_Reply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnReplyBtnClick));
		}

		public void ShowEffect(bool state, uint id = 0U)
		{
			this.m_ShowEffect = state;
			this.m_selectID = id;
			this.SetVisibleWithAnimation(true, null);
		}

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

		public void Refresh()
		{
			XGuildRedPacketDetail packetDetail = this._Doc.PacketDetail;
			this.m_LogView.Refresh();
			this._RefreshContent(packetDetail);
			this._RefreshReason(packetDetail);
			this._RefreshReply(packetDetail);
		}

		public void _RefreshReply(XGuildRedPacketDetail detailData)
		{
			bool flag = detailData.canThank && Time.time < detailData.brif.endTime && detailData.brif.fetchState != FetchState.FS_CANNOT_FETCH;
			base.uiBehaviour.m_ReplyLabel.SetText(flag ? XStringDefineProxy.GetString("QUICK_REPLY_1") : XStringDefineProxy.GetString("GUILD_REDPACKET_DETAIL_EXIT"));
		}

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

		private void CloseRedPackageDetail(bool statu)
		{
			if (statu)
			{
				XQuickReplyDocument specificDocument = XDocuments.GetSpecificDocument<XQuickReplyDocument>(XQuickReplyDocument.uuID);
				specificDocument.GetThanksForBonus(this._Doc.PacketDetail.brif.uid);
				this._OnCloseBtnClick(null);
			}
		}

		private void _OnCloseBtnClick(IXUISprite go)
		{
			this.SetVisibleWithAnimation(false, null);
		}

		private XGuildRedPacketDocument _Doc;

		private XGuildDocument _GuildDoc;

		private XGuildRedPakageLogView m_LogView;

		private uint m_selectID = 0U;

		private bool m_ShowEffect = false;

		private XFx m_maskXfx = null;
	}
}
