using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class MobaBattleRecordHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
			this.m_Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("BattleInfo");
			this.m_BattleTotal = (transform.Find("Total").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleRate = (transform.Find("Rate").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleWin = (transform.Find("Win").GetComponent("XUILabel") as IXUILabel);
			this.m_BattleLose = (transform.Find("Lose").GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.Find("Detail/LogMenu");
			this.m_Date = (transform.Find("Date").GetComponent("XUILabel") as IXUILabel);
			this.m_Time = (transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Kill1 = (transform.Find("KillCount/Kill1").GetComponent("XUILabel") as IXUILabel);
			this.m_Kill2 = (transform.Find("KillCount/Kill2").GetComponent("XUILabel") as IXUILabel);
			this.m_Empty = base.transform.Find("Detail/Empty");
			Transform transform2 = base.transform.FindChild("Round/RoundTpl");
			this.m_RoundPool.SetupPool(null, transform2.gameObject, 8U, false);
			Transform transform3 = base.transform.FindChild("Detail/Panel/DetailTpl");
			this.m_DetailPool.SetupPool(null, transform3.gameObject, 8U, false);
			Transform transform4 = base.transform.Find("Detail/Panel/MiniIconTpl");
			this.m_MiniIconPool.SetupPool(null, transform4.gameObject, 15U, false);
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/MobaRecords";
			}
		}

		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.SelectID = 0U;
			this.doc.ReqMobaRecordTotal();
			this.InitShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void InitShow()
		{
			this.m_BattleTotal.SetText("0");
			this.m_BattleRate.SetText("0%");
			this.m_BattleWin.SetText("0");
			this.m_BattleLose.SetText("0");
			this.m_Empty.gameObject.SetActive(true);
			this.m_RoundPool.ReturnAll(false);
			this.InitDetail();
		}

		public void InitDetail()
		{
			this.m_Date.SetText("00-00");
			this.m_Time.SetText(string.Format("0{0}", XSingleton<XStringTable>.singleton.GetString("MINUTE_DUARATION")));
			this.m_Kill1.SetText("[0096ff]0[-]");
			this.m_Kill2.SetText("[fd4343]0[-]");
			this.m_DetailPool.ReturnAll(false);
		}

		public void Refresh()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_BattleTotal.SetText(this.doc.MatchTotalCount.ToString());
				this.m_BattleRate.SetText(string.Format("{0}%", this.doc.MatchTotalPercent));
				this.m_BattleWin.SetText(this.doc.WinCount.ToString());
				this.m_BattleLose.SetText(this.doc.LoseCount.ToString());
				bool flag2 = this.doc.RecordTotalList.Count > 0;
				if (flag2)
				{
					this.SelectID = this.doc.RecordTotalList[this.doc.RecordTotalList.Count - 1].roundID;
					this.doc.ReqMobaRecordRound(this.SelectID);
				}
				this.RefreshTotal();
			}
		}

		public void RefreshTotal()
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			List<XMobaEntranceDocument.XMobaRecordTotal> recordTotalList = this.doc.RecordTotalList;
			int num = 0;
			this.m_RoundPool.FakeReturnAll();
			for (int i = recordTotalList.Count - 1; i >= 0; i--)
			{
				OverWatchTable.RowData dataByHeroID = XHeroBattleDocument.GetDataByHeroID(recordTotalList[i].heroID);
				GameObject gameObject = this.m_RoundPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num * this.m_RoundPool.TplHeight), 0f) + this.m_RoundPool.TplPos;
				num++;
				IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
				bool flag = dataByHeroID != null;
				if (flag)
				{
					ixuilabel.SetText(dataByHeroID.Name);
				}
				else
				{
					ixuilabel.SetText("");
				}
				IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				Transform transform = gameObject.transform.Find("NoIcon");
				bool flag2 = dataByHeroID != null;
				if (flag2)
				{
					ixuisprite.SetSprite(dataByHeroID.Icon, dataByHeroID.IconAtlas, false);
				}
				else
				{
					ixuisprite.SetSprite("");
				}
				transform.gameObject.SetActive(dataByHeroID == null);
				ixuisprite.ID = (ulong)recordTotalList[i].roundID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRoundClick));
				IXUILabel ixuilabel2 = gameObject.transform.Find("Date").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)recordTotalList[i].date, XStringDefineProxy.GetString("MOBA_RECORD_DATE"), true));
				Transform transform2 = gameObject.transform.Find("Select");
				transform2.gameObject.SetActive(recordTotalList[i].roundID == this.SelectID);
				Transform transform3 = gameObject.transform.Find("Win");
				Transform transform4 = gameObject.transform.Find("Lose");
				Transform transform5 = gameObject.transform.Find("Escape");
				Transform transform6 = gameObject.transform.Find("MvpWin");
				Transform transform7 = gameObject.transform.Find("MvpLose");
				transform3.gameObject.SetActive(!recordTotalList[i].isEscape && recordTotalList[i].isWin);
				transform4.gameObject.SetActive(!recordTotalList[i].isEscape && !recordTotalList[i].isWin);
				transform5.gameObject.SetActive(recordTotalList[i].isEscape);
				transform6.gameObject.SetActive(recordTotalList[i].isMVP);
				transform7.gameObject.SetActive(recordTotalList[i].isLoseMVP);
			}
			this.m_RoundPool.ActualReturnAll(false);
		}

		public void RefreshDetail(XMobaEntranceDocument.XMobaRecordRound data)
		{
			bool flag = data.roundID != this.SelectID;
			if (flag)
			{
				this.InitDetail();
			}
			else
			{
				this.m_Empty.gameObject.SetActive(false);
				this.KillMax = 0;
				this.AssistsMax = 0;
				for (int i = 0; i < data.team1.Count; i++)
				{
					this.KillMax = Math.Max(this.KillMax, data.team1[i].data.KillCount);
					this.AssistsMax = Math.Max(this.AssistsMax, (int)data.team1[i].data.AssitCount);
				}
				for (int j = 0; j < data.team2.Count; j++)
				{
					this.KillMax = Math.Max(this.KillMax, data.team2[j].data.KillCount);
					this.AssistsMax = Math.Max(this.AssistsMax, (int)data.team2[j].data.AssitCount);
				}
				uint num = 0U;
				uint num2 = 0U;
				this.m_DetailPool.FakeReturnAll();
				this.m_MiniIconPool.FakeReturnAll();
				for (int k = 0; k < data.team1.Count + data.team2.Count; k++)
				{
					bool flag2 = k < data.team1.Count;
					bool flag3 = flag2;
					XMobaEntranceDocument.XMobaRecordDetailOne xmobaRecordDetailOne;
					if (flag3)
					{
						xmobaRecordDetailOne = data.team1[k];
						num += (uint)xmobaRecordDetailOne.data.KillCount;
					}
					else
					{
						xmobaRecordDetailOne = data.team2[k - data.team1.Count];
						num2 += (uint)xmobaRecordDetailOne.data.KillCount;
					}
					OverWatchTable.RowData dataByHeroID = XHeroBattleDocument.GetDataByHeroID(xmobaRecordDetailOne.heroID);
					GameObject gameObject = this.m_DetailPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)k * this.m_DetailPool.TplHeight), 0f) + this.m_DetailPool.TplPos;
					IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(xmobaRecordDetailOne.data.Name);
					IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					Transform transform = gameObject.transform.Find("NoIcon");
					bool flag4 = dataByHeroID != null;
					if (flag4)
					{
						ixuisprite.SetSprite(dataByHeroID.Icon, dataByHeroID.IconAtlas, false);
					}
					else
					{
						ixuisprite.SetSprite("");
					}
					transform.gameObject.SetActive(dataByHeroID == null);
					Transform transform2 = gameObject.transform.Find("Icon/Blue");
					Transform transform3 = gameObject.transform.Find("Icon/Red");
					string arg = "[8c896c]";
					bool flag5 = data.isteam1win ^ flag2;
					if (flag5)
					{
						transform2.gameObject.SetActive(false);
						transform3.gameObject.SetActive(true);
						Transform transform4 = gameObject.transform.Find("Icon/Red/MVP");
						transform4.gameObject.SetActive(xmobaRecordDetailOne.data.uID == data.losemvpid);
						Transform transform5 = gameObject.transform.Find("Icon/Red/My");
						transform5.gameObject.SetActive(xmobaRecordDetailOne.data.uID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
					}
					else
					{
						transform2.gameObject.SetActive(true);
						transform3.gameObject.SetActive(false);
						Transform transform6 = gameObject.transform.Find("Icon/Blue/MVP");
						transform6.gameObject.SetActive(xmobaRecordDetailOne.data.uID == data.mvpid);
						bool flag6 = xmobaRecordDetailOne.data.uID == data.mvpid;
						if (flag6)
						{
							arg = "[ffdc00]";
						}
						Transform transform7 = gameObject.transform.Find("Icon/Blue/My");
						transform7.gameObject.SetActive(xmobaRecordDetailOne.data.uID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
					}
					IXUILabel ixuilabel2 = gameObject.transform.Find("Point").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(string.Format("{0}{1}[-]", arg, xmobaRecordDetailOne.data.Kda.ToString("f1")));
					IXUILabel ixuilabel3 = gameObject.transform.Find("Kill").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(string.Format("{0}/{1}/{2}", xmobaRecordDetailOne.data.KillCount, xmobaRecordDetailOne.data.DeathCount, xmobaRecordDetailOne.data.AssitCount));
					this.SetupMiniIconList(gameObject.transform.Find("MiniIconFrame"), xmobaRecordDetailOne, data);
				}
				this.m_MiniIconPool.ActualReturnAll(false);
				this.m_DetailPool.ActualReturnAll(false);
				this.m_Date.SetText(XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)data.date, XStringDefineProxy.GetString("MOBA_RECORD_DATE"), true));
				this.m_Time.SetText(string.Format("{0}{1}", data.time / 60U, XSingleton<XStringTable>.singleton.GetString("MINUTE_DUARATION")));
				string arg2 = data.isteam1win ? "[0096ff]" : "[fd4343]";
				string arg3 = data.isteam1win ? "[fd4343]" : "[0096ff]";
				this.m_Kill1.SetText(string.Format("{0}{1}[-]", arg2, num));
				this.m_Kill2.SetText(string.Format("{0}{1}[-]", arg3, num2));
			}
		}

		private void SetupMiniIconList(Transform ts, XMobaEntranceDocument.XMobaRecordDetailOne curOne, XMobaEntranceDocument.XMobaRecordRound data)
		{
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			List<string> mobaIconList = specificDocument.GetMobaIconList(curOne.data, data.damagemaxid, data.behitdamagemaxid, this.KillMax, this.AssistsMax);
			for (int i = 0; i < mobaIconList.Count; i++)
			{
				this.AddMiniIcon(ts, mobaIconList[i], i);
			}
		}

		private void AddMiniIcon(Transform ts, string iconName, int index)
		{
			GameObject gameObject = this.m_MiniIconPool.FetchGameObject(false);
			gameObject.transform.parent = ts;
			gameObject.transform.localPosition = new Vector3((float)(index * this.m_MiniIconPool.TplWidth), 0f) + this.m_MiniIconPool.TplPos;
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = iconName;
		}

		private void OnRoundClick(IXUISprite btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(btn.ID.ToString(), null, null, null, null, null);
			this.SelectID = (uint)btn.ID;
			this.RefreshTotal();
			this.doc.ReqMobaRecordRound(this.SelectID);
		}

		private bool OnCloseClicked(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		private XMobaEntranceDocument doc = null;

		private uint SelectID;

		private int KillMax;

		private int AssistsMax;

		private IXUIButton m_Close;

		private IXUILabel m_BattleTotal;

		private IXUILabel m_BattleRate;

		private IXUILabel m_BattleWin;

		private IXUILabel m_BattleLose;

		private IXUILabel m_Date;

		private IXUILabel m_Time;

		private IXUILabel m_Kill1;

		private IXUILabel m_Kill2;

		private Transform m_Empty;

		private XUIPool m_RoundPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_DetailPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_MiniIconPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
