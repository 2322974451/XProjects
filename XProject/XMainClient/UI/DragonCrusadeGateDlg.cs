using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001739 RID: 5945
	internal class DragonCrusadeGateDlg : DlgBase<DragonCrusadeGateDlg, DragonCrusadeGateBehavior>
	{
		// Token: 0x170037C9 RID: 14281
		// (get) Token: 0x0600F585 RID: 62853 RVA: 0x00376FF8 File Offset: 0x003751F8
		public override string fileName
		{
			get
			{
				return "DragonCrusade/DragonCrusadeGate";
			}
		}

		// Token: 0x170037CA RID: 14282
		// (get) Token: 0x0600F586 RID: 62854 RVA: 0x00377010 File Offset: 0x00375210
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037CB RID: 14283
		// (get) Token: 0x0600F587 RID: 62855 RVA: 0x00377024 File Offset: 0x00375224
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037CC RID: 14284
		// (get) Token: 0x0600F588 RID: 62856 RVA: 0x00377038 File Offset: 0x00375238
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037CD RID: 14285
		// (get) Token: 0x0600F589 RID: 62857 RVA: 0x0037704C File Offset: 0x0037524C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037CE RID: 14286
		// (get) Token: 0x0600F58A RID: 62858 RVA: 0x00377060 File Offset: 0x00375260
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170037CF RID: 14287
		// (get) Token: 0x0600F58B RID: 62859 RVA: 0x00377074 File Offset: 0x00375274
		public override int sysid
		{
			get
			{
				return 50;
			}
		}

		// Token: 0x0600F58C RID: 62860 RVA: 0x00377088 File Offset: 0x00375288
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClosedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.mRwdBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChallenge));
		}

		// Token: 0x0600F58D RID: 62861 RVA: 0x003770D7 File Offset: 0x003752D7
		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		// Token: 0x0600F58E RID: 62862 RVA: 0x003770E3 File Offset: 0x003752E3
		protected override void OnShow()
		{
			base.Alloc3DAvatarPool("DragonCrusadeGateDlg");
			base.OnShow();
		}

		// Token: 0x0600F58F RID: 62863 RVA: 0x003770F9 File Offset: 0x003752F9
		protected override void OnUnload()
		{
			base.Return3DAvatarPool();
			base.OnUnload();
		}

		// Token: 0x0600F590 RID: 62864 RVA: 0x0037710A File Offset: 0x0037530A
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("DragonCrusadeGateDlg");
		}

		// Token: 0x0600F591 RID: 62865 RVA: 0x00377120 File Offset: 0x00375320
		private bool OnClose(IXUIButton btn)
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F592 RID: 62866 RVA: 0x0037714C File Offset: 0x0037534C
		private bool OnChallenge(IXUIButton btn)
		{
			bool flag = this.mDragonCrusageGateData.leftcount <= 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DragonCrusadeEnoughCount"), "fece00");
				result = true;
			}
			else
			{
				bool flag2 = this.mDragonCrusageGateData.deProgress.state == DEProgressState.DEPS_NOTOPEN;
				if (flag2)
				{
					string text = string.Format(XSingleton<XStringTable>.singleton.GetString("DragonCrusadeLast"), this.GetAheadGate().sceneData.Comment);
					XSingleton<UiUtility>.singleton.ShowSystemTip(text, "fece00");
					result = true;
				}
				else
				{
					bool flag3 = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnChallenge), btn);
					if (flag3)
					{
						result = true;
					}
					else
					{
						PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
						ptcC2G_EnterSceneReq.Data.sceneID = this.mDragonCrusageGateData.SceneID;
						XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
						XDragonCrusadeDocument.QuitFromCrusade = true;
						XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_DragonCrusade, EXStage.Hall);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600F593 RID: 62867 RVA: 0x00377248 File Offset: 0x00375448
		private DragonCrusageGateData GetAheadGate()
		{
			for (int i = 0; i < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; i++)
			{
				DragonCrusageGateData dragonCrusageGateData = XDragonCrusadeDocument._DragonCrusageGateDataInfo[i];
				bool flag = dragonCrusageGateData.deProgress.state == DEProgressState.DEPS_FIGHT;
				if (flag)
				{
					return dragonCrusageGateData;
				}
			}
			return null;
		}

		// Token: 0x0600F594 RID: 62868 RVA: 0x0037729C File Offset: 0x0037549C
		public void FreshInfo(DragonCrusageGateData data)
		{
			this.mDragonCrusageGateData = data;
			XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(data.expData.BossID);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
			GameObject gameObject = base.SetXUILable("Bg/ContentFrame/BossStatus/TitleLabel", data.sceneData.Comment);
			IUIDummy snapShot = gameObject.transform.Find("SnapShot").GetComponent("UIDummy") as IUIDummy;
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, byID.PresentID, snapShot, this.m_Dummy, 25f);
			this.m_Dummy.Scale = byPresentID.UIAvatarScale;
			XSingleton<X3DAvatarMgr>.singleton.EnableCommonDummy(this.m_Dummy, snapShot, true);
			GameObject gameObject2 = base.SetXUILable("Bg/ContentFrame/BossStatus/HP/Percent", data.deProgress.bossavghppercent.ToString() + "%");
			IXUIProgress ixuiprogress = gameObject2.transform.Find("HP").GetComponent("XUIProgress") as IXUIProgress;
			ixuiprogress.value = (float)data.deProgress.bossavghppercent / 100f;
			base.SetXUILable("Bg/ContentFrame/content/contentLabel", data.expData.Description);
			int num = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
			string content = string.Format(XSingleton<XStringTable>.singleton.GetString("DragonCrusadeCurrent"), num);
			IXUILabel ixuilabel = base.SetXUILable("Bg/ContentFrame/FightValue/Current", content).GetComponent("XUILabel") as IXUILabel;
			string content2 = string.Format(XSingleton<XStringTable>.singleton.GetString("DragonCrusadeBossFight"), data.sceneData.RecommendPower);
			IXUILabel ixuilabel2 = base.SetXUILable("Bg/ContentFrame/FightValue/Original", content2).GetComponent("XUILabel") as IXUILabel;
			bool flag = data.sceneData.RecommendPower >= num;
			if (flag)
			{
				ixuilabel.SetColor(Color.red);
			}
			else
			{
				ixuilabel.SetColor(Color.green);
			}
			GameObject gameObject3 = base.uiBehaviour.transform.Find("Bg/ContentFrame/FightValue/Buff").gameObject;
			bool flag2 = data.SealLevel < data.expData.SealLevel;
			if (flag2)
			{
				gameObject3.SetActive(true);
				IXUISprite ixuisprite = gameObject3.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(data.expData.BuffIcon);
				base.SetXUILable("Bg/ContentFrame/FightValue/Buff/Label", data.expData.BuffDes);
			}
			else
			{
				gameObject3.SetActive(false);
			}
			base.SetXUILable("Bg/ContentFrame/FightValue/Buff/Label", data.expData.BuffDes);
			base.SetXUILable("ChallengeCount/Value", string.Format("{0}/{1}", data.leftcount, data.allcount));
			base.uiBehaviour.mBuff.SetSprite(data.expData.BuffIcon);
			bool flag3 = (uint)data.sceneData.RequiredLevel > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			if (flag3)
			{
				string content3 = string.Format(XSingleton<XStringTable>.singleton.GetString("DragonCrusadeNeedLevel"), data.sceneData.RequiredLevel);
				base.SetXUILable("Bg/ContentFrame/NeedLevel", content3);
			}
			else
			{
				base.SetXUILable("Bg/ContentFrame/NeedLevel", "");
			}
			for (int i = 0; i < 4; i++)
			{
				GameObject gameObject4 = base.uiBehaviour.transform.Find("Bg/ContentFrame/items/Item" + i.ToString().ToString()).gameObject;
				bool flag4 = i < data.expData.WinReward.Count;
				if (flag4)
				{
					gameObject4.SetActive(true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject4, (int)data.expData.WinReward[i, 0], (int)data.expData.WinReward[i, 1], false);
					IXUISprite ixuisprite2 = gameObject4.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)data.expData.WinReward[i, 0];
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				else
				{
					gameObject4.SetActive(false);
				}
			}
			GameObject gameObject5 = base.SetXUILable("Bg/ContentFrame/ResultLabel", XSingleton<XStringTable>.singleton.GetString("DragonCrusadeDone"));
			GameObject gameObject6 = base.uiBehaviour.transform.Find("Bg/ContentFrame/btm").gameObject;
			bool flag5 = this.mDragonCrusageGateData.deProgress.state == DEProgressState.DEPS_FINISH;
			if (flag5)
			{
				gameObject5.SetActive(true);
				gameObject6.SetActive(false);
			}
			else
			{
				gameObject6.SetActive(true);
				gameObject5.SetActive(false);
			}
		}

		// Token: 0x04006A63 RID: 27235
		private XDummy m_Dummy;

		// Token: 0x04006A64 RID: 27236
		private DragonCrusageGateData mDragonCrusageGateData = null;
	}
}
