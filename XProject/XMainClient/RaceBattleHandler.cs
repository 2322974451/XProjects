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

	internal class RaceBattleHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "Battle/RaceBattleDlg";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowRankTimerID);
			this.RefreshInfo();
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowRankTimerID);
			this.m_ShowRankTimerID = 0U;
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.doc.RaceHandler = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowRankTimerID);
			this.m_ShowRankTimerID = 0U;
			base.OnUnload();
		}

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

		public void RefreshRank(uint rank)
		{
			this.m_Rank.SetText(rank.ToString());
		}

		public void RefreshLap(uint lap)
		{
			this.m_NowLap.SetText(lap.ToString());
		}

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

		private void UpdateWifi()
		{
			XSingleton<UiUtility>.singleton.UpdateWifi(null, this.m_sprwifi);
		}

		private void RefreshPing()
		{
			XSingleton<UiUtility>.singleton.RefreshPing(this.m_lblTime, this.m_sliderBattery, null);
		}

		public void RaceStart()
		{
			this.RefreshTime(0.01f);
			this.isRaceLeftTime = true;
		}

		public void RaceEnd()
		{
			this.isRaceEnd = true;
		}

		public void HideInfo()
		{
			this.CloseEndLeftTime();
			this.CloseRank(null);
		}

		public void ShowRank(uint rank)
		{
			this.m_EndRank.gameObject.SetActive(true);
			this.m_EndRank.SetText(rank.ToString());
			this.m_ShowRankTimerID = XSingleton<XTimerMgr>.singleton.SetTimer((float)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HorseShowRankTime")), new XTimerMgr.ElapsedEventHandler(this.CloseRank), null);
		}

		private void CloseRank(object param)
		{
			this.m_EndRank.gameObject.SetActive(false);
		}

		public void ShowEndLeftTime(float time)
		{
			this.m_End.gameObject.SetActive(true);
			this.isEndLeftTime = true;
			this._EndCounter.SetLeftTime(time, -1);
		}

		private void CloseEndLeftTime()
		{
			this.m_End.gameObject.SetActive(false);
			this.isEndLeftTime = false;
		}

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

		public void UseDoodad(uint index)
		{
			this.ItemDoodad[(int)index].gameObject.SetActive(false);
		}

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

		private XRaceDocument doc = null;

		private XLeftTimeCounter _RaceCounter;

		private XLeftTimeCounter _EndCounter;

		private uint m_ShowRankTimerID = 0U;

		private bool isRaceLeftTime = false;

		private bool isEndLeftTime = false;

		private bool isRaceEnd = false;

		public static readonly uint ITEM_DOODAD_COUNT_MAX = 2U;

		private IXUILabel m_lblTime;

		private IXUISlider m_sliderBattery;

		private IXUISprite m_sprwifi;

		private IXUILabel m_lblFree;

		private IXUILabel m_Rank;

		private IXUILabel m_NowLap;

		private IXUILabel m_MAXLap;

		private IXUILabel m_RaceTime;

		private Transform m_End;

		private IXUILabel m_EndTime;

		private IXUILabel m_EndRank;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform[] ItemDoodad = new Transform[2];

		private IXUISprite[] DoodadIcon = new IXUISprite[2];

		private IXUILabel[] DoodadName = new IXUILabel[2];

		private float lastPingTime = -60f;
	}
}
