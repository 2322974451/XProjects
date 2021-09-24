using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DragonCrusadeGateDlg : DlgBase<DragonCrusadeGateDlg, DragonCrusadeGateBehavior>
	{

		public override string fileName
		{
			get
			{
				return "DragonCrusade/DragonCrusadeGate";
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return 50;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClosedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.mRwdBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChallenge));
		}

		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		protected override void OnShow()
		{
			base.Alloc3DAvatarPool("DragonCrusadeGateDlg");
			base.OnShow();
		}

		protected override void OnUnload()
		{
			base.Return3DAvatarPool();
			base.OnUnload();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("DragonCrusadeGateDlg");
		}

		private bool OnClose(IXUIButton btn)
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			this.SetVisible(false, true);
			return true;
		}

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

		private XDummy m_Dummy;

		private DragonCrusageGateData mDragonCrusageGateData = null;
	}
}
