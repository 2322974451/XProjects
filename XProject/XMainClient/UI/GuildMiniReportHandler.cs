using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildMiniReportHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/BattleMiniReportDlg";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnReport.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReportClick));
			this.m_btnHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.qInfo.Clear();
			this.ShowList();
			this.ShowBuffs();
		}

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

		public void Push(string content)
		{
			ReportMsg reportMsg = new ReportMsg();
			reportMsg.LoopID = XSingleton<XCommon>.singleton.XHash(content + DateTime.Now.ToString());
			reportMsg.content = content;
			GuildMiniReportHandler.msgs.Add(reportMsg);
			this.ShowList();
		}

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

		private bool OnReportClick(IXUIButton btn)
		{
			DlgBase<GuildTerritoryReportDlg, GuildTerritoryBahaviour>.singleton.SetVisible(true, true);
			return true;
		}

		private bool OnHelpClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildTerritory);
			return true;
		}

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

		public readonly int max_count = 40;

		public static List<ReportMsg> msgs = new List<ReportMsg>();

		public string lastCahceMsg = string.Empty;

		public ILoopScrollView loopScrool;

		public IXUIButton m_btnReport;

		public IXUIButton m_btnHelp;

		public GameObject m_objpreparing;

		public IXUITweenTool m_tween;

		private Vector3 infoDis;

		public XUIPool m_ShowIntoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel[] m_Killer = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		public IXUILabel[] m_Dead = new IXUILabel[XBattleCaptainPVPDocument.GAME_INFO];

		public IXUISprite[] m_InfoIcon = new IXUISprite[XBattleCaptainPVPDocument.GAME_INFO];

		public Transform m_objMyinfo;

		public IXUILabel m_lblRank;

		public IXUILabel m_lblAttack;

		public IXUILabel m_lblAccupy;

		private XGuildTerritoryDocument _doc;

		private bool isopen = true;

		private Vector3 NoVisible = new Vector3(2000f, 0f, 0f);
	}
}
