using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001893 RID: 6291
	internal class XSceneDamageRankHandler : DlgHandlerBase, IRankView
	{
		// Token: 0x0601060F RID: 67087 RVA: 0x003FD430 File Offset: 0x003FB630
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XSceneDamageRankDocument>(XSceneDamageRankDocument.uuID);
			this.doc.RankHandler = this;
			Transform transform = base.PanelObject.transform.FindChild("RankTpl");
			this.m_RankPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
		}

		// Token: 0x06010610 RID: 67088 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06010611 RID: 67089 RVA: 0x003FD496 File Offset: 0x003FB696
		public override void OnUnload()
		{
			this.doc.RankHandler = null;
			this._ClearAutoClose();
			base.OnUnload();
		}

		// Token: 0x06010612 RID: 67090 RVA: 0x003FD4B4 File Offset: 0x003FB6B4
		protected override void OnShow()
		{
			base.OnShow();
			this.m_bShow = true;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			SceneType type = (SceneType)sceneData.type;
			if (type <= SceneType.SCENE_HEROBATTLE)
			{
				if (type == SceneType.SCENE_PVP)
				{
					XBattleCaptainPVPDocument specificDocument = XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID);
					this.doc.OnGetRank(specificDocument.RankList);
					return;
				}
				if (type == SceneType.SCENE_HEROBATTLE)
				{
					XHeroBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					this.doc.OnGetRank(specificDocument2.RankList);
					return;
				}
			}
			else if (type - SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT <= 4 || type == SceneType.SCENE_WEEKEND4V4_DUCK)
			{
				this.RefreshWeekendPartRank();
				return;
			}
			this._AutoReqData(null);
		}

		// Token: 0x06010613 RID: 67091 RVA: 0x003FD560 File Offset: 0x003FB760
		protected override void OnHide()
		{
			this.m_bShow = false;
			this._ClearAutoClose();
			this._ClearAutoReqData();
			base.OnHide();
		}

		// Token: 0x06010614 RID: 67092 RVA: 0x003FD580 File Offset: 0x003FB780
		public void RefreshPage()
		{
			List<XBaseRankInfo> rankList = this.doc.RankList;
			bool flag = rankList.Count > this.m_RankList.Count;
			if (flag)
			{
				for (int i = this.m_RankList.Count; i < rankList.Count; i++)
				{
					GameObject gameObject = this.m_RankPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(this.m_RankPool.TplPos.x, this.m_RankPool.TplPos.y - (float)(this.m_RankPool.TplHeight * i), this.m_RankPool.TplPos.z);
					this.m_RankList.Add(gameObject);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(string.Format("{0}.", i + 1));
					bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
					if (bSpectator)
					{
						IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
						ixuicheckBox.ID = (ulong)((long)i);
						ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSpectateChangeClick));
					}
				}
			}
			else
			{
				bool flag2 = rankList.Count < this.m_RankList.Count;
				if (flag2)
				{
					for (int j = this.m_RankList.Count - 1; j >= rankList.Count; j--)
					{
						this.m_RankPool.ReturnInstance(this.m_RankList[j], false);
					}
					this.m_RankList.RemoveRange(rankList.Count, this.m_RankList.Count - rankList.Count);
				}
			}
			for (int k = 0; k < rankList.Count; k++)
			{
				GameObject gameObject2 = this.m_RankList[k];
				bool bSpectator2 = XSingleton<XScene>.singleton.bSpectator;
				if (bSpectator2)
				{
					IXUICheckBox ixuicheckBox2 = gameObject2.GetComponent("XUICheckBox") as IXUICheckBox;
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo != null && rankList[k].id == XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID;
					if (flag3)
					{
						ixuicheckBox2.ForceSetFlag(true);
					}
					else
					{
						ixuicheckBox2.ForceSetFlag(false);
					}
				}
				IXUILabel ixuilabel2 = gameObject2.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject2.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(rankList[k].name);
				XCaptainPVPRankInfo xcaptainPVPRankInfo = rankList[k] as XCaptainPVPRankInfo;
				bool flag4 = xcaptainPVPRankInfo != null;
				if (flag4)
				{
					ixuilabel3.SetText(rankList[k].GetValue());
				}
				else
				{
					ixuilabel3.SetText(XSingleton<UiUtility>.singleton.NumberFormat(rankList[k].value));
				}
			}
			this.HideVoice();
		}

		// Token: 0x06010615 RID: 67093 RVA: 0x003FD8BC File Offset: 0x003FBABC
		private void _AutoReqData(object o)
		{
			this.doc.ReqRank();
			bool bShow = this.m_bShow;
			if (bShow)
			{
				this.m_AutoReqDataTimerToken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this._AutoReqData), null);
			}
		}

		// Token: 0x06010616 RID: 67094 RVA: 0x003FD902 File Offset: 0x003FBB02
		private void _ClearAutoClose()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_AutoCloseTimerToken);
		}

		// Token: 0x06010617 RID: 67095 RVA: 0x003FD916 File Offset: 0x003FBB16
		private void _ClearAutoReqData()
		{
			this.m_AutoReqDataTimerToken = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_AutoReqDataTimerToken);
		}

		// Token: 0x06010618 RID: 67096 RVA: 0x003FD934 File Offset: 0x003FBB34
		private bool OnSpectateChangeClick(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				ulong id = this.doc.RankList[(int)checkBox.ID].id;
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo != null && id == XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID;
				if (flag2)
				{
					result = true;
				}
				else
				{
					XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(id);
					bool flag3 = entityConsiderDeath != null && entityConsiderDeath.IsRole;
					if (flag3)
					{
						XSingleton<XEntityMgr>.singleton.Player.WatchIt(entityConsiderDeath as XRole);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06010619 RID: 67097 RVA: 0x003FD9F0 File Offset: 0x003FBBF0
		public void RefreshVoice(ulong[] roleids, int[] states)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				this.cacheRoleids = roleids;
				this.cacheStates = states;
				bool flag2 = roleids == null || states == null;
				if (!flag2)
				{
					for (int i = 0; i < roleids.Length; i++)
					{
						this.PlayRole(roleids[i], states[i]);
					}
				}
			}
		}

		// Token: 0x0601061A RID: 67098 RVA: 0x003FDA50 File Offset: 0x003FBC50
		public void PlayRole(ulong roleid, int state)
		{
			for (int i = 0; i < this.doc.RankList.Count; i++)
			{
				bool flag = this.doc.RankList[i].id == roleid && this.m_RankList.Count > i;
				if (flag)
				{
					Transform transform = this.m_RankList[i].transform.Find("voice");
					bool flag2 = transform != null;
					if (flag2)
					{
						transform.gameObject.SetActive(state == 1);
					}
					Transform transform2 = this.m_RankList[i].transform.Find("speak");
					bool flag3 = transform2 != null;
					if (flag3)
					{
						transform2.gameObject.SetActive(state == 2);
					}
				}
			}
		}

		// Token: 0x0601061B RID: 67099 RVA: 0x003FDB2C File Offset: 0x003FBD2C
		public void HideVoice()
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				for (int i = 0; i < this.m_RankList.Count; i++)
				{
					Transform transform = this.m_RankList[i].transform.Find("voice");
					Transform transform2 = this.m_RankList[i].transform.Find("speak");
					bool flag2 = transform.gameObject.activeSelf && transform2.gameObject.activeSelf;
					if (flag2)
					{
						transform.gameObject.SetActive(false);
						transform2.gameObject.SetActive(false);
					}
				}
				this.RefreshVoice(this.cacheRoleids, this.cacheStates);
			}
		}

		// Token: 0x0601061C RID: 67100 RVA: 0x003FDBF8 File Offset: 0x003FBDF8
		public void RefreshWeekendPartRank()
		{
			XWeekendPartyDocument specificDocument = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
			List<WeekendPartyBattleRoleInfo> selfWeekendPartyBattleList = specificDocument.SelfWeekendPartyBattleList;
			bool flag = selfWeekendPartyBattleList.Count > this.m_RankList.Count;
			if (flag)
			{
				for (int i = this.m_RankList.Count; i < selfWeekendPartyBattleList.Count; i++)
				{
					GameObject gameObject = this.m_RankPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(this.m_RankPool.TplPos.x, this.m_RankPool.TplPos.y - (float)(this.m_RankPool.TplHeight * i), this.m_RankPool.TplPos.z);
					this.m_RankList.Add(gameObject);
				}
			}
			else
			{
				bool flag2 = selfWeekendPartyBattleList.Count < this.m_RankList.Count;
				if (flag2)
				{
					for (int j = this.m_RankList.Count - 1; j >= selfWeekendPartyBattleList.Count; j--)
					{
						this.m_RankPool.ReturnInstance(this.m_RankList[j], false);
					}
					this.m_RankList.RemoveRange(selfWeekendPartyBattleList.Count, this.m_RankList.Count - selfWeekendPartyBattleList.Count);
				}
			}
			for (int k = 0; k < selfWeekendPartyBattleList.Count; k++)
			{
				GameObject gameObject2 = this.m_RankList[k];
				IXUILabel ixuilabel = gameObject2.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject2.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject2.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Format("{0}.", selfWeekendPartyBattleList[k].Rank));
				ixuilabel2.SetText((selfWeekendPartyBattleList[k].roleName != null) ? selfWeekendPartyBattleList[k].roleName : "");
				string arg = (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE) ? XStringDefineProxy.GetString("WeekendPartyBattleRankTypeDeath") : XStringDefineProxy.GetString("WeekendPartyBattleRankTypeScore");
				uint num = (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE) ? selfWeekendPartyBattleList[k].beKilled : selfWeekendPartyBattleList[k].score;
				ixuilabel3.SetText(string.Format("{0}{1}", arg, num));
			}
			this.HideVoice();
		}

		// Token: 0x04007629 RID: 30249
		private XSceneDamageRankDocument doc;

		// Token: 0x0400762A RID: 30250
		private XUIPool m_RankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400762B RID: 30251
		private List<GameObject> m_RankList = new List<GameObject>();

		// Token: 0x0400762C RID: 30252
		private bool m_bShow = false;

		// Token: 0x0400762D RID: 30253
		private uint m_AutoCloseTimerToken = 0U;

		// Token: 0x0400762E RID: 30254
		private uint m_AutoReqDataTimerToken = 0U;

		// Token: 0x0400762F RID: 30255
		private ulong[] cacheRoleids;

		// Token: 0x04007630 RID: 30256
		private int[] cacheStates;
	}
}
