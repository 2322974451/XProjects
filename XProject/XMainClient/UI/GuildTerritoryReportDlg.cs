using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200177A RID: 6010
	internal class GuildTerritoryReportDlg : DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>
	{
		// Token: 0x17003825 RID: 14373
		// (get) Token: 0x0600F809 RID: 63497 RVA: 0x00389A9C File Offset: 0x00387C9C
		public override string fileName
		{
			get
			{
				return "Battle/GuildTerritoryBattleInfo";
			}
		}

		// Token: 0x17003826 RID: 14374
		// (get) Token: 0x0600F80A RID: 63498 RVA: 0x00389AB4 File Offset: 0x00387CB4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003827 RID: 14375
		// (get) Token: 0x0600F80B RID: 63499 RVA: 0x00389AC8 File Offset: 0x00387CC8
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F80C RID: 63500 RVA: 0x00389ADC File Offset: 0x00387CDC
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateItem));
			GuildTransfer.RowData[] table = XGuildTerritoryDocument.mGuildTransfer.Table;
			this.dic.Clear();
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = !this.dic.ContainsKey(table[i].sceneid);
				if (flag)
				{
					this.dic.Add(table[i].sceneid, table[i]);
				}
			}
			this.timeConnter = new XLeftTimeCounter(base.uiBehaviour.m_lblTime, false);
		}

		// Token: 0x0600F80D RID: 63501 RVA: 0x00389B8C File Offset: 0x00387D8C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._close_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x0600F80E RID: 63502 RVA: 0x00389BB3 File Offset: 0x00387DB3
		protected override void OnShow()
		{
			this._doc.SendGCFCommonReq(GCFReqType.GCF_FIGHT_REPORT);
		}

		// Token: 0x0600F80F RID: 63503 RVA: 0x00389BC3 File Offset: 0x00387DC3
		public void RefreshAll()
		{
			this.MergeInfo();
			this.RefreshTitleInfo();
			this.RefreshList();
		}

		// Token: 0x0600F810 RID: 63504 RVA: 0x00389BDC File Offset: 0x00387DDC
		public override void OnUpdate()
		{
			bool flag = this.timeConnter != null;
			if (flag)
			{
				this.timeConnter.Update();
			}
		}

		// Token: 0x0600F811 RID: 63505 RVA: 0x00389C08 File Offset: 0x00387E08
		private void MergeInfo()
		{
			this.reportList.Clear();
			List<GCFBattleField> fields = this._doc.fields;
			for (int i = 0; i < fields.Count; i++)
			{
				ReportNode reportNode = new ReportNode();
				reportNode.row = this.dic[fields[i].mapid];
				for (int j = 0; j < fields[i].jvdians.Count; j++)
				{
					bool flag = fields[i].jvdians[j].type == GCFJvDianType.GCF_JUDIAN_UP;
					if (flag)
					{
						reportNode.up = fields[i].jvdians[j].guildname;
					}
					else
					{
						bool flag2 = fields[i].jvdians[j].type == GCFJvDianType.GCF_JUDIAN_MID;
						if (flag2)
						{
							reportNode.mid = fields[i].jvdians[j].guildname;
						}
						else
						{
							bool flag3 = fields[i].jvdians[j].type == GCFJvDianType.GCF_JUDIAN_DOWN;
							if (flag3)
							{
								reportNode.btm = fields[i].jvdians[j].guildname;
							}
						}
					}
				}
				reportNode.info = fields[i].zhanchinfo;
				this.reportList.Add(reportNode);
			}
		}

		// Token: 0x0600F812 RID: 63506 RVA: 0x00389D80 File Offset: 0x00387F80
		private void RefreshTitleInfo()
		{
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			}
			GCFGuildBrief winguild = this._doc.winguild;
			base.uiBehaviour.m_lblGuildName.SetText(winguild.guildname);
			this.timeConnter.SetLeftTime(this._doc.fight_lefttime, -1);
			TerritoryBattle.RowData byID = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(this._doc.territoryid);
			base.uiBehaviour.m_sprIcon.SetSprite(byID.territoryIcon);
		}

		// Token: 0x0600F813 RID: 63507 RVA: 0x00389E15 File Offset: 0x00388015
		private void RefreshList()
		{
			base.uiBehaviour.m_scroll.ResetPosition();
			base.uiBehaviour.m_wrap.SetContentCount(6, false);
		}

		// Token: 0x0600F814 RID: 63508 RVA: 0x00389E3C File Offset: 0x0038803C
		private void UpdateItem(Transform t, int index)
		{
			bool flag = this.reportList.Count > index;
			if (flag)
			{
				IXUISprite ixuisprite = t.Find("Gate").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Top/GuildName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Middle/GuildName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Bottom/GuildName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.Find("Triple/T").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject = t.Find("Triple").gameObject;
				IXUILabel ixuilabel6 = t.Find("PlayerNum").GetComponent("XUILabel") as IXUILabel;
				ixuilabel4.SetText(this.reportList[index].row.name);
				ixuilabel.SetText(string.IsNullOrEmpty(this.reportList[index].up) ? "-" : this.reportList[index].up);
				ixuilabel2.SetText(string.IsNullOrEmpty(this.reportList[index].mid) ? "-" : this.reportList[index].mid);
				ixuilabel3.SetText(string.IsNullOrEmpty(this.reportList[index].btm) ? "-" : this.reportList[index].btm);
				ixuisprite.SetSprite(this.reportList[index].row.icon);
				GCFZhanChBriefInfo info = this.reportList[index].info;
				bool flag2 = info != null;
				if (flag2)
				{
					gameObject.SetActive(info.multipoint >= 2U);
					ixuilabel5.SetText(XStringDefineProxy.GetString("Territtory_Score" + info.multipoint));
					ixuilabel6.SetText(info.curusercount + "/" + info.maxusercount);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddLog("info is nil " + ixuilabel4.GetText(), null, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
		}

		// Token: 0x0600F815 RID: 63509 RVA: 0x0038A0C0 File Offset: 0x003882C0
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x04006C37 RID: 27703
		private XGuildTerritoryDocument _doc = null;

		// Token: 0x04006C38 RID: 27704
		private Dictionary<uint, GuildTransfer.RowData> dic = new Dictionary<uint, GuildTransfer.RowData>();

		// Token: 0x04006C39 RID: 27705
		private List<ReportNode> reportList = new List<ReportNode>();

		// Token: 0x04006C3A RID: 27706
		public XLeftTimeCounter timeConnter;
	}
}
