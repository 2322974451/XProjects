using System;
using System.Text;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C89 RID: 3209
	internal class RaceBattleHandler : DlgHandlerBase
	{
		// Token: 0x0600B53B RID: 46395 RVA: 0x0023B728 File Offset: 0x00239928
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XRaceDocument>(XRaceDocument.uuID);
			this.doc.RaceHandler = this;
			this.m_lblTime = (base.transform.FindChild("Bg/PING/TIME").GetComponent("XUILabel") as IXUILabel);
			this.m_sliderBattery = (base.transform.FindChild("Bg/PING/Battery").GetComponent("XUISlider") as IXUISlider);
			this.m_sprwifi = (base.transform.FindChild("Bg/PING/SysWifi").GetComponent("XUISprite") as IXUISprite);
			this.m_lblFree = (base.transform.FindChild("Bg/PING/T2").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.FindChild("Bg/RaceInfo");
			this.m_Rank = (transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel);
			this.m_NowLap = (transform.FindChild("NowLap").GetComponent("XUILabel") as IXUILabel);
			this.m_MAXLap = (transform.FindChild("MAXLap").GetComponent("XUILabel") as IXUILabel);
			this.m_RaceTime = (transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_End = base.transform.FindChild("Bg/End");
			this.m_EndTime = (this.m_End.FindChild("Time/LeftTime").GetComponent("XUILabel") as IXUILabel);
			this.m_EndRank = (base.transform.FindChild("Bg/EndRank").GetComponent("XUILabel") as IXUILabel);
			this._RaceCounter = new XLeftTimeCounter(this.m_RaceTime, false);
			this._RaceCounter.SetForward(1);
			this._RaceCounter.SetTimeFormat(2, 3, 4, true);
			this._EndCounter = new XLeftTimeCounter(this.m_EndTime, false);
			this._EndCounter.SetFormat(false);
			Transform transform2 = base.transform.FindChild("Bg/Item/ItemTpl");
			this.m_ItemPool.SetupPool(null, transform2.gameObject, RaceBattleHandler.ITEM_DOODAD_COUNT_MAX, false);
			this.m_ItemPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)RaceBattleHandler.ITEM_DOODAD_COUNT_MAX))
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3((float)(num * this.m_ItemPool.TplWidth), 0f, 0f);
				this.ItemDoodad[num] = gameObject.transform.Find("Item");
				this.ItemDoodad[num].gameObject.SetActive(false);
				this.DoodadIcon[num] = (this.ItemDoodad[num].Find("uiIcon").GetComponent("XUISprite") as IXUISprite);
				this.DoodadName[num] = (this.ItemDoodad[num].Find("Name").GetComponent("XUILabel") as IXUILabel);
				num++;
			}
			this.m_ItemPool.ActualReturnAll(false);
		}

		// Token: 0x17003211 RID: 12817
		// (get) Token: 0x0600B53C RID: 46396 RVA: 0x0023BA44 File Offset: 0x00239C44
		protected override string FileName
		{
			get
			{
				return "Battle/RaceBattleDlg";
			}
		}

		// Token: 0x0600B53D RID: 46397 RVA: 0x0023BA5C File Offset: 0x00239C5C
		public override void RegisterEvent()
		{
			int num = 0;
			while ((long)num < (long)((ulong)RaceBattleHandler.ITEM_DOODAD_COUNT_MAX))
			{
				this.DoodadIcon[num].ID = (ulong)((long)num);
				this.DoodadIcon[num].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnItemClick));
				num++;
			}
		}

		// Token: 0x0600B53E RID: 46398 RVA: 0x0023BAAC File Offset: 0x00239CAC
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowRankTimerID);
			this.RefreshInfo();
		}

		// Token: 0x0600B53F RID: 46399 RVA: 0x0023BACE File Offset: 0x00239CCE
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowRankTimerID);
			this.m_ShowRankTimerID = 0U;
			base.OnHide();
		}

		// Token: 0x0600B540 RID: 46400 RVA: 0x0023BAF0 File Offset: 0x00239CF0
		public override void OnUnload()
		{
			this.doc.RaceHandler = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowRankTimerID);
			this.m_ShowRankTimerID = 0U;
			base.OnUnload();
		}

		// Token: 0x0600B541 RID: 46401 RVA: 0x0023BB20 File Offset: 0x00239D20
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateWifi();
			bool flag = Time.unscaledTime - this.lastPingTime > 60f || this.lastPingTime < 0f;
			if (flag)
			{
				this.RefreshPing();
				this.lastPingTime = Time.unscaledTime;
			}
			bool flag2 = this.isRaceLeftTime && !this.isRaceEnd;
			if (flag2)
			{
				this._RaceCounter.Update();
			}
			bool flag3 = this.isEndLeftTime;
			if (flag3)
			{
				this._EndCounter.Update();
			}
		}

		// Token: 0x0600B542 RID: 46402 RVA: 0x0023BBB4 File Offset: 0x00239DB4
		private void RefreshInfo()
		{
			this.m_Rank.SetText("0");
			this.m_NowLap.SetText("0");
			Horse.RowData horseRace = XRaceDocument.GetHorseRace(XSingleton<XScene>.singleton.SceneID);
			this.m_MAXLap.SetText(string.Format("/{0}", horseRace.Laps));
			this.m_RaceTime.SetText("00:00.00");
			DlgBase<BattleMain, BattleMainBehaviour>.singleton.HideLeftTime();
			this.m_End.gameObject.SetActive(false);
			this.m_EndRank.gameObject.SetActive(false);
		}

		// Token: 0x0600B543 RID: 46403 RVA: 0x0023BC55 File Offset: 0x00239E55
		public void RefreshRank(uint rank)
		{
			this.m_Rank.SetText(rank.ToString());
		}

		// Token: 0x0600B544 RID: 46404 RVA: 0x0023BC6B File Offset: 0x00239E6B
		public void RefreshLap(uint lap)
		{
			this.m_NowLap.SetText(lap.ToString());
		}

		// Token: 0x0600B545 RID: 46405 RVA: 0x0023BC84 File Offset: 0x00239E84
		public void RefreshTime(float time)
		{
			bool flag = time == 0f;
			if (flag)
			{
				time = 0.01f;
			}
			this._RaceCounter.SetLeftTime(time, -1);
			this.isRaceLeftTime = true;
		}

		// Token: 0x0600B546 RID: 46406 RVA: 0x0023BCBA File Offset: 0x00239EBA
		private void UpdateWifi()
		{
			XSingleton<UiUtility>.singleton.UpdateWifi(null, this.m_sprwifi);
		}

		// Token: 0x0600B547 RID: 46407 RVA: 0x0023BCCF File Offset: 0x00239ECF
		private void RefreshPing()
		{
			XSingleton<UiUtility>.singleton.RefreshPing(this.m_lblTime, this.m_sliderBattery, null);
		}

		// Token: 0x0600B548 RID: 46408 RVA: 0x0023BCEA File Offset: 0x00239EEA
		public void RaceStart()
		{
			this.RefreshTime(0.01f);
			this.isRaceLeftTime = true;
		}

		// Token: 0x0600B549 RID: 46409 RVA: 0x0023BD00 File Offset: 0x00239F00
		public void RaceEnd()
		{
			this.isRaceEnd = true;
		}

		// Token: 0x0600B54A RID: 46410 RVA: 0x0023BD0A File Offset: 0x00239F0A
		public void HideInfo()
		{
			this.CloseEndLeftTime();
			this.CloseRank(null);
		}

		// Token: 0x0600B54B RID: 46411 RVA: 0x0023BD1C File Offset: 0x00239F1C
		public void ShowRank(uint rank)
		{
			this.m_EndRank.gameObject.SetActive(true);
			this.m_EndRank.SetText(rank.ToString());
			this.m_ShowRankTimerID = XSingleton<XTimerMgr>.singleton.SetTimer((float)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HorseShowRankTime")), new XTimerMgr.ElapsedEventHandler(this.CloseRank), null);
		}

		// Token: 0x0600B54C RID: 46412 RVA: 0x0023BD81 File Offset: 0x00239F81
		private void CloseRank(object param)
		{
			this.m_EndRank.gameObject.SetActive(false);
		}

		// Token: 0x0600B54D RID: 46413 RVA: 0x0023BD96 File Offset: 0x00239F96
		public void ShowEndLeftTime(float time)
		{
			this.m_End.gameObject.SetActive(true);
			this.isEndLeftTime = true;
			this._EndCounter.SetLeftTime(time, -1);
		}

		// Token: 0x0600B54E RID: 46414 RVA: 0x0023BDC0 File Offset: 0x00239FC0
		private void CloseEndLeftTime()
		{
			this.m_End.gameObject.SetActive(false);
			this.isEndLeftTime = false;
		}

		// Token: 0x0600B54F RID: 46415 RVA: 0x0023BDDC File Offset: 0x00239FDC
		public void RefreshDoodad(DoodadItemAllSkill data)
		{
			bool flag = data == null;
			if (!flag)
			{
				int num = 0;
				while ((long)num < (long)((ulong)RaceBattleHandler.ITEM_DOODAD_COUNT_MAX))
				{
					int num2 = -1;
					for (int i = 0; i < data.skills.Count; i++)
					{
						bool flag2 = (ulong)data.skills[i].index == (ulong)((long)num);
						if (flag2)
						{
							num2 = i;
						}
					}
					bool flag3 = num2 == -1;
					if (flag3)
					{
						this.ItemDoodad[num].gameObject.SetActive(false);
					}
					else
					{
						uint itemid = data.skills[num2].itemid;
						BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData((int)itemid, 1);
						bool flag4 = buffData == null;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ChickenDinner GetDoodad: Buff data not found: [{0} {1}]", itemid, 1), null, null, null, null, null);
							break;
						}
						this.ItemDoodad[num].gameObject.SetActive(true);
						this.DoodadIcon[num].SetSprite(buffData.BuffIcon);
						StringBuilder stringBuilder = new StringBuilder();
						bool flag5 = false;
						for (int j = 0; j < buffData.BuffName.Length; j++)
						{
							bool flag6 = buffData.BuffName[j] == ')';
							if (flag6)
							{
								flag5 = false;
							}
							bool flag7 = flag5;
							if (flag7)
							{
								stringBuilder.Append(buffData.BuffName[j]);
							}
							bool flag8 = buffData.BuffName[j] == '(';
							if (flag8)
							{
								flag5 = true;
							}
						}
						this.DoodadName[num].SetText(stringBuilder.ToString());
					}
					num++;
				}
			}
		}

		// Token: 0x0600B550 RID: 46416 RVA: 0x0023BF95 File Offset: 0x0023A195
		public void UseDoodad(uint index)
		{
			this.ItemDoodad[(int)index].gameObject.SetActive(false);
		}

		// Token: 0x0600B551 RID: 46417 RVA: 0x0023BFAC File Offset: 0x0023A1AC
		private void _OnItemClick(IXUISprite iSp)
		{
			bool activeSelf = this.ItemDoodad[(int)(checked((IntPtr)iSp.ID))].gameObject.activeSelf;
			if (activeSelf)
			{
				RpcC2G_ItemBuffOp rpcC2G_ItemBuffOp = new RpcC2G_ItemBuffOp();
				rpcC2G_ItemBuffOp.oArg.index = (uint)iSp.ID;
				rpcC2G_ItemBuffOp.oArg.op = 3U;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ItemBuffOp);
			}
		}

		// Token: 0x040046CA RID: 18122
		private XRaceDocument doc = null;

		// Token: 0x040046CB RID: 18123
		private XLeftTimeCounter _RaceCounter;

		// Token: 0x040046CC RID: 18124
		private XLeftTimeCounter _EndCounter;

		// Token: 0x040046CD RID: 18125
		private uint m_ShowRankTimerID = 0U;

		// Token: 0x040046CE RID: 18126
		private bool isRaceLeftTime = false;

		// Token: 0x040046CF RID: 18127
		private bool isEndLeftTime = false;

		// Token: 0x040046D0 RID: 18128
		private bool isRaceEnd = false;

		// Token: 0x040046D1 RID: 18129
		public static readonly uint ITEM_DOODAD_COUNT_MAX = 2U;

		// Token: 0x040046D2 RID: 18130
		private IXUILabel m_lblTime;

		// Token: 0x040046D3 RID: 18131
		private IXUISlider m_sliderBattery;

		// Token: 0x040046D4 RID: 18132
		private IXUISprite m_sprwifi;

		// Token: 0x040046D5 RID: 18133
		private IXUILabel m_lblFree;

		// Token: 0x040046D6 RID: 18134
		private IXUILabel m_Rank;

		// Token: 0x040046D7 RID: 18135
		private IXUILabel m_NowLap;

		// Token: 0x040046D8 RID: 18136
		private IXUILabel m_MAXLap;

		// Token: 0x040046D9 RID: 18137
		private IXUILabel m_RaceTime;

		// Token: 0x040046DA RID: 18138
		private Transform m_End;

		// Token: 0x040046DB RID: 18139
		private IXUILabel m_EndTime;

		// Token: 0x040046DC RID: 18140
		private IXUILabel m_EndRank;

		// Token: 0x040046DD RID: 18141
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040046DE RID: 18142
		private Transform[] ItemDoodad = new Transform[2];

		// Token: 0x040046DF RID: 18143
		private IXUISprite[] DoodadIcon = new IXUISprite[2];

		// Token: 0x040046E0 RID: 18144
		private IXUILabel[] DoodadName = new IXUILabel[2];

		// Token: 0x040046E1 RID: 18145
		private float lastPingTime = -60f;
	}
}
