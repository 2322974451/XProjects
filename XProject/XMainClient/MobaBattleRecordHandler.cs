using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C4E RID: 3150
	internal class MobaBattleRecordHandler : DlgHandlerBase
	{
		// Token: 0x0600B2BC RID: 45756 RVA: 0x00229844 File Offset: 0x00227A44
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

		// Token: 0x1700318F RID: 12687
		// (get) Token: 0x0600B2BD RID: 45757 RVA: 0x00229A34 File Offset: 0x00227C34
		protected override string FileName
		{
			get
			{
				return "GameSystem/MobaRecords";
			}
		}

		// Token: 0x0600B2BE RID: 45758 RVA: 0x00229A4B File Offset: 0x00227C4B
		public override void RegisterEvent()
		{
			this.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B2BF RID: 45759 RVA: 0x00229A66 File Offset: 0x00227C66
		protected override void OnShow()
		{
			base.OnShow();
			this.SelectID = 0U;
			this.doc.ReqMobaRecordTotal();
			this.InitShow();
		}

		// Token: 0x0600B2C0 RID: 45760 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B2C1 RID: 45761 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B2C2 RID: 45762 RVA: 0x00229A8C File Offset: 0x00227C8C
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

		// Token: 0x0600B2C3 RID: 45763 RVA: 0x00229B04 File Offset: 0x00227D04
		public void InitDetail()
		{
			this.m_Date.SetText("00-00");
			this.m_Time.SetText(string.Format("0{0}", XSingleton<XStringTable>.singleton.GetString("MINUTE_DUARATION")));
			this.m_Kill1.SetText("[0096ff]0[-]");
			this.m_Kill2.SetText("[fd4343]0[-]");
			this.m_DetailPool.ReturnAll(false);
		}

		// Token: 0x0600B2C4 RID: 45764 RVA: 0x00229B78 File Offset: 0x00227D78
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

		// Token: 0x0600B2C5 RID: 45765 RVA: 0x00229C74 File Offset: 0x00227E74
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

		// Token: 0x0600B2C6 RID: 45766 RVA: 0x00229FA4 File Offset: 0x002281A4
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

		// Token: 0x0600B2C7 RID: 45767 RVA: 0x0022A5C0 File Offset: 0x002287C0
		private void SetupMiniIconList(Transform ts, XMobaEntranceDocument.XMobaRecordDetailOne curOne, XMobaEntranceDocument.XMobaRecordRound data)
		{
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			List<string> mobaIconList = specificDocument.GetMobaIconList(curOne.data, data.damagemaxid, data.behitdamagemaxid, this.KillMax, this.AssistsMax);
			for (int i = 0; i < mobaIconList.Count; i++)
			{
				this.AddMiniIcon(ts, mobaIconList[i], i);
			}
		}

		// Token: 0x0600B2C8 RID: 45768 RVA: 0x0022A628 File Offset: 0x00228828
		private void AddMiniIcon(Transform ts, string iconName, int index)
		{
			GameObject gameObject = this.m_MiniIconPool.FetchGameObject(false);
			gameObject.transform.parent = ts;
			gameObject.transform.localPosition = new Vector3((float)(index * this.m_MiniIconPool.TplWidth), 0f) + this.m_MiniIconPool.TplPos;
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = iconName;
		}

		// Token: 0x0600B2C9 RID: 45769 RVA: 0x0022A6A0 File Offset: 0x002288A0
		private void OnRoundClick(IXUISprite btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(btn.ID.ToString(), null, null, null, null, null);
			this.SelectID = (uint)btn.ID;
			this.RefreshTotal();
			this.doc.ReqMobaRecordRound(this.SelectID);
		}

		// Token: 0x0600B2CA RID: 45770 RVA: 0x0022A6F4 File Offset: 0x002288F4
		private bool OnCloseClicked(IXUIButton button)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x040044F8 RID: 17656
		private XMobaEntranceDocument doc = null;

		// Token: 0x040044F9 RID: 17657
		private uint SelectID;

		// Token: 0x040044FA RID: 17658
		private int KillMax;

		// Token: 0x040044FB RID: 17659
		private int AssistsMax;

		// Token: 0x040044FC RID: 17660
		private IXUIButton m_Close;

		// Token: 0x040044FD RID: 17661
		private IXUILabel m_BattleTotal;

		// Token: 0x040044FE RID: 17662
		private IXUILabel m_BattleRate;

		// Token: 0x040044FF RID: 17663
		private IXUILabel m_BattleWin;

		// Token: 0x04004500 RID: 17664
		private IXUILabel m_BattleLose;

		// Token: 0x04004501 RID: 17665
		private IXUILabel m_Date;

		// Token: 0x04004502 RID: 17666
		private IXUILabel m_Time;

		// Token: 0x04004503 RID: 17667
		private IXUILabel m_Kill1;

		// Token: 0x04004504 RID: 17668
		private IXUILabel m_Kill2;

		// Token: 0x04004505 RID: 17669
		private Transform m_Empty;

		// Token: 0x04004506 RID: 17670
		private XUIPool m_RoundPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004507 RID: 17671
		private XUIPool m_DetailPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004508 RID: 17672
		private XUIPool m_MiniIconPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
