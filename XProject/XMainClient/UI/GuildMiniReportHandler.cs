using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001766 RID: 5990
	internal class GuildMiniReportHandler : DlgHandlerBase
	{
		// Token: 0x1700380E RID: 14350
		// (get) Token: 0x0600F73F RID: 63295 RVA: 0x00383804 File Offset: 0x00381A04
		protected override string FileName
		{
			get
			{
				return "Battle/BattleMiniReportDlg";
			}
		}

		// Token: 0x0600F740 RID: 63296 RVA: 0x0038381C File Offset: 0x00381A1C
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			this.m_btnReport = (base.transform.Find("Bg/Report").GetComponent("XUIButton") as IXUIButton);
			this.m_btnHelp = (base.transform.Find("Bg/help").GetComponent("XUIButton") as IXUIButton);
			this.loopScrool = (base.transform.FindChild("Bg/items").GetComponent("LoopScrollView") as ILoopScrollView);
			this.m_objpreparing = base.transform.Find("Bg/Preparing").gameObject;
			this.m_tween = (base.transform.Find("Bg/BeginFrame").GetComponent("XUIPlayTween") as IXUITweenTool);
			Transform transform = base.transform.FindChild("Bg/buffs/InfoTpl");
			this.m_ShowIntoPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_ShowIntoPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)XGuildTerritoryDocument.GAME_INFO))
			{
				GameObject gameObject = this.m_ShowIntoPool.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				this.infoDis = new Vector3(0f, (float)(-(float)ixuisprite.spriteHeight), 0f);
				gameObject.transform.localPosition = this.infoDis * (float)num;
				this.m_Killer[num] = (gameObject.transform.Find("killer").GetComponent("XUILabel") as IXUILabel);
				this.m_Dead[num] = (gameObject.transform.Find("dead").GetComponent("XUILabel") as IXUILabel);
				this.m_InfoIcon[num] = (gameObject.transform.Find("icon").GetComponent("XUISprite") as IXUISprite);
				num++;
			}
			this.m_ShowIntoPool.ActualReturnAll(false);
			this.m_objMyinfo = base.transform.Find("Bg/MyInfo");
			this.m_lblRank = (this.m_objMyinfo.Find("Label_rank").GetComponent("XUILabel") as IXUILabel);
			this.m_lblAttack = (this.m_objMyinfo.Find("Label_attack").GetComponent("XUILabel") as IXUILabel);
			this.m_lblAccupy = (this.m_objMyinfo.Find("Label_accupy").GetComponent("XUILabel") as IXUILabel);
			this.m_objpreparing.SetActive(false);
			this.m_tween.gameObject.SetActive(false);
			this.m_objMyinfo.gameObject.SetActive(XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT);
			GameObject tpl = this.loopScrool.GetTpl();
			bool flag = tpl != null && tpl.GetComponent<GuildMiniReportItem>() == null;
			if (flag)
			{
				tpl.AddComponent<GuildMiniReportItem>();
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_WAIT && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_CASTLE_FIGHT;
			if (flag2)
			{
				GuildMiniReportHandler.msgs.Clear();
			}
		}

		// Token: 0x0600F741 RID: 63297 RVA: 0x00383B4F File Offset: 0x00381D4F
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnReport.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReportClick));
			this.m_btnHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClick));
		}

		// Token: 0x0600F742 RID: 63298 RVA: 0x00383B89 File Offset: 0x00381D89
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.qInfo.Clear();
			this.ShowList();
			this.ShowBuffs();
		}

		// Token: 0x0600F743 RID: 63299 RVA: 0x00383BB4 File Offset: 0x00381DB4
		public void Push(GCFG2CSynType type, GCFG2CSynPara para)
		{
			string text = string.Empty;
			switch (type)
			{
			case GCFG2CSynType.GCF_G2C_SYN_MUL_POINT:
			{
				TerritoryBattle.RowData byID = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(para.territoryid);
				GuildTransfer.RowData bySceneID = this.GetBySceneID(para.mapid);
				bool flag = byID == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("territory id: " + para.territoryid, null, null, null, null, null);
				}
				else
				{
					bool flag2 = byID.territorylevel == 1U;
					if (flag2)
					{
						text = XStringDefineProxy.GetString("TERRITORY_TYPE3", new object[]
						{
							bySceneID.name,
							byID.territoryname,
							para.mulpoint
						});
					}
					else
					{
						bool flag3 = byID.territorylevel == 2U;
						if (flag3)
						{
							text = XStringDefineProxy.GetString("TERRITORY_TYPE4", new object[]
							{
								bySceneID.name,
								byID.territoryname,
								para.mulpoint
							});
						}
						else
						{
							bool flag4 = byID.territorylevel == 3U;
							if (flag4)
							{
								text = XStringDefineProxy.GetString("TERRITORY_TYPE5", new object[]
								{
									bySceneID.name,
									byID.territoryname,
									para.mulpoint
								});
							}
						}
					}
				}
				break;
			}
			case GCFG2CSynType.GCF_G2C_SYN_OCCUPY:
			{
				int num = XFastEnumIntEqualityComparer<GCFJvDianType>.ToInt(para.jvdian.type);
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(para.roleid);
				bool flag5 = entity != null;
				if (flag5)
				{
					string @string = XStringDefineProxy.GetString("Territory_judian" + num);
					text = XStringDefineProxy.GetString("TERRITORY_TYPE2", new object[]
					{
						entity.Name,
						para.jvdian.guildname,
						@string
					});
				}
				else
				{
					XSingleton<XDebug>.singleton.AddWarningLog("entity is null, roleid: ", para.roleid.ToString(), null, null, null, null);
				}
				break;
			}
			}
			bool flag6 = !string.IsNullOrEmpty(text);
			if (flag6)
			{
				this.Push(text);
			}
		}

		// Token: 0x0600F744 RID: 63300 RVA: 0x00383DC8 File Offset: 0x00381FC8
		public GuildTransfer.RowData GetBySceneID(uint sceneid)
		{
			for (int i = 0; i < XGuildTerritoryDocument.mGuildTransfer.Table.Length; i++)
			{
				bool flag = XGuildTerritoryDocument.mGuildTransfer.Table[i].sceneid == sceneid;
				if (flag)
				{
					return XGuildTerritoryDocument.mGuildTransfer.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600F745 RID: 63301 RVA: 0x00383E20 File Offset: 0x00382020
		public void Push(string content)
		{
			ReportMsg reportMsg = new ReportMsg();
			reportMsg.LoopID = XSingleton<XCommon>.singleton.XHash(content + DateTime.Now.ToString());
			reportMsg.content = content;
			GuildMiniReportHandler.msgs.Add(reportMsg);
			this.ShowList();
		}

		// Token: 0x0600F746 RID: 63302 RVA: 0x00383E74 File Offset: 0x00382074
		public void ShowPrepare(bool show)
		{
			bool flag = this.m_objpreparing != null;
			if (flag)
			{
				this.m_objpreparing.SetActive(show);
			}
			bool flag2 = this.m_objMyinfo != null;
			if (flag2)
			{
				this.m_objMyinfo.gameObject.SetActive(!show);
			}
		}

		// Token: 0x0600F747 RID: 63303 RVA: 0x00383EC4 File Offset: 0x003820C4
		public void ShowBegin(bool open)
		{
			bool flag = this.m_tween != null;
			if (flag)
			{
				bool flag2 = open && open != this.isopen;
				if (flag2)
				{
					this.m_tween.gameObject.SetActive(true);
					this.m_tween.ResetTween(true);
					this.m_tween.PlayTween(true, -1f);
				}
				this.isopen = open;
			}
		}

		// Token: 0x0600F748 RID: 63304 RVA: 0x00383F34 File Offset: 0x00382134
		public void ShowList()
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				List<LoopItemData> list = new List<LoopItemData>();
				string b = string.Empty;
				for (int i = 0; i < GuildMiniReportHandler.msgs.Count; i++)
				{
					ReportMsg reportMsg = new ReportMsg();
					reportMsg.LoopID = XSingleton<XCommon>.singleton.XHash(GuildMiniReportHandler.msgs[i].content + i);
					reportMsg.content = GuildMiniReportHandler.msgs[i].content;
					list.Add(reportMsg);
					b = reportMsg.content;
				}
				bool flag2 = string.IsNullOrEmpty(this.lastCahceMsg) || this.lastCahceMsg != b;
				if (flag2)
				{
					this.loopScrool.Init(list, new DelegateHandler(this.RefreshItem), null, (GuildMiniReportHandler.msgs.Count < 4) ? 0 : 1, false);
				}
				bool flag3 = GuildMiniReportHandler.msgs != null && GuildMiniReportHandler.msgs.Count > 0;
				if (flag3)
				{
					int index = GuildMiniReportHandler.msgs.Count - 1;
					this.lastCahceMsg = GuildMiniReportHandler.msgs[index].content;
				}
			}
		}

		// Token: 0x0600F749 RID: 63305 RVA: 0x0038406C File Offset: 0x0038226C
		public void ShowBuffs()
		{
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			}
			this.m_ShowIntoPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)XGuildTerritoryDocument.GAME_INFO))
			{
				GameObject gameObject = this.m_ShowIntoPool.FetchGameObject(false);
				bool flag2 = this._doc.qInfo.Count <= num;
				if (flag2)
				{
					gameObject.transform.localPosition = this.NoVisible;
				}
				else
				{
					gameObject.transform.localPosition = this.infoDis * (float)num;
					int num2 = 0;
					foreach (XBattleCaptainPVPDocument.KillInfo killInfo in this._doc.qInfo)
					{
						bool flag3 = num2 == num;
						if (flag3)
						{
							this.m_Killer[num].SetText(killInfo.KillName);
							this.m_Dead[num].SetText(killInfo.DeadName);
							this.m_InfoIcon[num].SetSprite("hall_zljt_0");
							break;
						}
						num2++;
					}
				}
				num++;
			}
			this.m_ShowIntoPool.ActualReturnAll(false);
		}

		// Token: 0x0600F74A RID: 63306 RVA: 0x003841CC File Offset: 0x003823CC
		private void RefreshItem(ILoopItemObject item, LoopItemData data)
		{
			ReportMsg reportMsg = data as ReportMsg;
			bool flag = reportMsg != null;
			if (flag)
			{
				GameObject obj = item.GetObj();
				bool flag2 = obj != null;
				if (flag2)
				{
					GuildMiniReportItem component = obj.GetComponent<GuildMiniReportItem>();
					bool flag3 = component != null;
					if (flag3)
					{
						component.Refresh(reportMsg.content);
					}
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GuildMiniReportItem info is null", null, null, null, null, null);
			}
		}

		// Token: 0x0600F74B RID: 63307 RVA: 0x0038423C File Offset: 0x0038243C
		private bool OnReportClick(IXUIButton btn)
		{
			DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600F74C RID: 63308 RVA: 0x0038425C File Offset: 0x0038245C
		private bool OnHelpClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildTerritory);
			return true;
		}

		// Token: 0x0600F74D RID: 63309 RVA: 0x00384280 File Offset: 0x00382480
		public void RefreshMyInfo(GCFRoleBrief info)
		{
			bool flag = info != null;
			if (flag)
			{
				uint rank = info.rank;
				this.m_lblRank.SetText((rank == 0U) ? "-" : rank.ToString());
				this.m_lblAttack.SetText(info.killcount.ToString());
				this.m_lblAccupy.SetText(info.occupycount.ToString());
			}
		}

		// Token: 0x04006B90 RID: 27536
		public readonly int max_count = 40;

		// Token: 0x04006B91 RID: 27537
		public static List<ReportMsg> msgs = new List<ReportMsg>();

		// Token: 0x04006B92 RID: 27538
		public string lastCahceMsg = string.Empty;

		// Token: 0x04006B93 RID: 27539
		public ILoopScrollView loopScrool;

		// Token: 0x04006B94 RID: 27540
		public IXUIButton m_btnReport;

		// Token: 0x04006B95 RID: 27541
		public IXUIButton m_btnHelp;

		// Token: 0x04006B96 RID: 27542
		public GameObject m_objpreparing;

		// Token: 0x04006B97 RID: 27543
		public IXUITweenTool m_tween;

		// Token: 0x04006B98 RID: 27544
		private Vector3 infoDis;

		// Token: 0x04006B99 RID: 27545
		public XUIPool m_ShowIntoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006B9A RID: 27546
		public IXUILabel[] m_Killer = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		// Token: 0x04006B9B RID: 27547
		public IXUILabel[] m_Dead = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		// Token: 0x04006B9C RID: 27548
		public IXUISprite[] m_InfoIcon = new IXUISprite[XBattleCaptainPVPDocument.GAME_INFO];

		// Token: 0x04006B9D RID: 27549
		public Transform m_objMyinfo;

		// Token: 0x04006B9E RID: 27550
		public IXUILabel m_lblRank;

		// Token: 0x04006B9F RID: 27551
		public IXUILabel m_lblAttack;

		// Token: 0x04006BA0 RID: 27552
		public IXUILabel m_lblAccupy;

		// Token: 0x04006BA1 RID: 27553
		private XGuildTerritoryDocument _doc;

		// Token: 0x04006BA2 RID: 27554
		private bool isopen = true;

		// Token: 0x04006BA3 RID: 27555
		private Vector3 NoVisible = new Vector3(2000f, 0f, 0f);
	}
}
