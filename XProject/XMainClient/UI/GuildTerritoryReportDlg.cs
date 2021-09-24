using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryReportDlg : DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/GuildTerritoryBattleInfo";
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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._close_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		protected override void OnShow()
		{
			this._doc.SendGCFCommonReq(GCFReqType.GCF_FIGHT_REPORT);
		}

		public void RefreshAll()
		{
			this.MergeInfo();
			this.RefreshTitleInfo();
			this.RefreshList();
		}

		public override void OnUpdate()
		{
			bool flag = this.timeConnter != null;
			if (flag)
			{
				this.timeConnter.Update();
			}
		}

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

		private void RefreshList()
		{
			base.uiBehaviour.m_scroll.ResetPosition();
			base.uiBehaviour.m_wrap.SetContentCount(6, false);
		}

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

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		private XGuildTerritoryDocument _doc = null;

		private Dictionary<uint, GuildTransfer.RowData> dic = new Dictionary<uint, GuildTransfer.RowData>();

		private List<ReportNode> reportList = new List<ReportNode>();

		public XLeftTimeCounter timeConnter;
	}
}
