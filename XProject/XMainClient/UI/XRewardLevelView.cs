using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001716 RID: 5910
	internal class XRewardLevelView : DlgHandlerBase
	{
		// Token: 0x0600F411 RID: 62481 RVA: 0x0036A33C File Offset: 0x0036853C
		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XAchievementDocument.uuID) as XAchievementDocument);
			this._doc.RewardLevelView = this;
			this.m_RemainTime = (base.PanelObject.transform.FindChild("RemainTime/Label").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform2 = base.PanelObject.transform.FindChild("Panel/RecordTpl/ItemReward/ItemTpl");
			this.m_RewardItemPool.SetupPool(transform.gameObject, transform2.gameObject, 30U, false);
			transform2 = base.PanelObject.transform.FindChild("Panel/RecordTpl");
			this.m_RewardPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 10U, false);
		}

		// Token: 0x0600F412 RID: 62482 RVA: 0x0036A433 File Offset: 0x00368633
		public void UpdateRedPoint()
		{
			this._doc.HasCompleteAchivement(XSysDefine.XSys_ServerActivity);
		}

		// Token: 0x0600F413 RID: 62483 RVA: 0x0036A444 File Offset: 0x00368644
		protected override void OnShow()
		{
			base.OnShow();
			this._remainTime = 0U;
			RpcC2G_QueryOpenGameActivityTime rpc = new RpcC2G_QueryOpenGameActivityTime();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			this.RefreshList();
		}

		// Token: 0x0600F414 RID: 62484 RVA: 0x0036A47C File Offset: 0x0036867C
		public override void OnUnload()
		{
			this._remainTime = 0U;
			bool flag = this._timer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
			}
			this._doc.RewardLevelView = null;
			base.OnUnload();
		}

		// Token: 0x0600F415 RID: 62485 RVA: 0x0036A4C4 File Offset: 0x003686C4
		protected string GetActivityString(string format, int catergory, int param, AchivementState state)
		{
			string result;
			if (catergory - 502 > 1)
			{
				bool flag = state == AchivementState.Exceed || state == AchivementState.Not_Achive;
				if (flag)
				{
					result = string.Format(format, "[ff0000]" + param + "[-]");
				}
				else
				{
					result = string.Format(format, "[00ff00]" + param + "[-]");
				}
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)param);
				bool flag2 = state == AchivementState.Exceed || state == AchivementState.Not_Achive;
				if (flag2)
				{
					result = string.Format(format, "[ff0000]" + sceneData.Comment + "[-]");
				}
				else
				{
					result = string.Format(format, "[00ff00]" + sceneData.Comment + "[-]");
				}
			}
			return result;
		}

		// Token: 0x0600F416 RID: 62486 RVA: 0x0036A594 File Offset: 0x00368794
		protected bool OnFetchClicked(IXUIButton button)
		{
			this._curID = (uint)button.ID;
			int achivementFatigue = this._doc.GetAchivementFatigue(this._curID);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("MaxFatigue");
			int num = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
			bool flag = achivementFatigue > 0 && num + achivementFatigue > @int;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowFatigueSureDlg(new ButtonClickEventHandler(this.SureToFetch));
			}
			else
			{
				this._doc.FetchAchivement(this._curID);
			}
			return true;
		}

		// Token: 0x0600F417 RID: 62487 RVA: 0x0036A628 File Offset: 0x00368828
		protected bool SureToFetch(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._doc.FetchAchivement(this._curID);
			return true;
		}

		// Token: 0x0600F418 RID: 62488 RVA: 0x0036A658 File Offset: 0x00368858
		protected bool OnLinkToClick(IXUIButton button)
		{
			return true;
		}

		// Token: 0x0600F419 RID: 62489 RVA: 0x0036A66C File Offset: 0x0036886C
		private int ActivityCompare(int act1, int act2)
		{
			AchivementState achivementState = this._doc.GetAchivementState((uint)act1);
			AchivementState achivementState2 = this._doc.GetAchivementState((uint)act2);
			bool flag = achivementState > achivementState2;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = achivementState < achivementState2;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = act1.CompareTo(act2);
				}
			}
			return result;
		}

		// Token: 0x0600F41A RID: 62490 RVA: 0x0036A6BC File Offset: 0x003688BC
		public void RefreshList()
		{
			this.UpdateRedPoint();
			this.m_RewardPool.ReturnAll(false);
			this.m_RewardItemPool.ReturnAll(false);
			this.m_ScrollView.SetPosition(0f);
			List<int> catergoryActivity = this._doc.GetCatergoryActivity(500);
			catergoryActivity.Sort(new Comparison<int>(this.ActivityCompare));
			for (int i = 0; i < catergoryActivity.Count; i++)
			{
				GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
				gameObject.name = "record" + catergoryActivity[i];
				gameObject.transform.localPosition = this.m_RewardPool.TplPos - new Vector3(0f, (float)(this.m_RewardPool.TplHeight * i));
				AchivementTable.RowData achivementData = this._doc.GetAchivementData((uint)catergoryActivity[i]);
				bool flag = achivementData != null;
				if (flag)
				{
					AchivementState achivementState = this._doc.GetAchivementState((uint)achivementData.AchievementID);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
					string activityString = this.GetActivityString(achivementData.AchievementDescription, achivementData.AchievementCategory, achivementData.AchievementParam, achivementState);
					ixuilabel.SetText(activityString);
					IXUIButton ixuibutton = gameObject.transform.FindChild("Fetch").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)((long)catergoryActivity[i]);
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetchClicked));
					GameObject gameObject2 = gameObject.transform.FindChild("Fetched").gameObject;
					GameObject gameObject3 = gameObject.transform.FindChild("LinkTo").gameObject;
					IXUIProgress ixuiprogress = gameObject.transform.FindChild("Progress").GetComponent("XUIProgress") as IXUIProgress;
					ixuiprogress.gameObject.SetActive(false);
					ixuibutton.gameObject.SetActive(false);
					gameObject2.SetActive(false);
					gameObject3.SetActive(false);
					bool flag2 = achivementData.AchievementCategory == 504;
					if (flag2)
					{
						ixuiprogress.gameObject.SetActive(true);
						XFashionDocument specificDocument = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
						int count = specificDocument.FashionBag.Count;
						ixuiprogress.value = (float)count / (float)achivementData.AchievementParam;
						IXUILabel ixuilabel2 = gameObject.transform.FindChild("Progress/T").GetComponent("XUILabel") as IXUILabel;
						ixuilabel2.SetText(string.Format("{0}/{1}", count, achivementData.AchievementParam));
					}
					switch (achivementState)
					{
					case AchivementState.Exceed:
						ixuibutton.gameObject.SetActive(true);
						ixuibutton.SetEnable(false, false);
						break;
					case AchivementState.Fetched:
						gameObject2.SetActive(true);
						break;
					case AchivementState.Not_Achive:
						gameObject3.SetActive(true);
						break;
					case AchivementState.Achive_NoFetch:
						ixuibutton.gameObject.SetActive(true);
						ixuibutton.SetEnable(true, false);
						break;
					}
					Transform parent = gameObject.transform.FindChild("ItemReward");
					for (int j = 0; j < achivementData.AchievementItem.Count; j++)
					{
						int num = achivementData.AchievementItem[j, 0];
						GameObject gameObject4 = this.m_RewardItemPool.FetchGameObject(false);
						gameObject4.name = "reward item " + num;
						gameObject4.transform.parent = parent;
						gameObject4.transform.localPosition = this.m_RewardItemPool.TplPos + new Vector3((float)(this.m_RewardItemPool.TplWidth * j), 0f);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject4, num, achivementData.AchievementItem[j, 1], false);
						IXUISprite ixuisprite = gameObject4.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)((long)num);
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowItemDialog));
					}
				}
			}
		}

		// Token: 0x0600F41B RID: 62491 RVA: 0x0036AAF4 File Offset: 0x00368CF4
		private void ShowItemDialog(IXUISprite spr)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)spr.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
		}

		// Token: 0x0600F41C RID: 62492 RVA: 0x0036AB1F File Offset: 0x00368D1F
		public void SetRemainTime(uint second)
		{
			this._remainTime = second;
			this._RemainTime();
		}

		// Token: 0x0600F41D RID: 62493 RVA: 0x0036AB30 File Offset: 0x00368D30
		public void UpateRemainTime(object param)
		{
			bool flag = this._remainTime > 0U;
			if (flag)
			{
				this._remainTime -= 1U;
				this._RemainTime();
			}
		}

		// Token: 0x0600F41E RID: 62494 RVA: 0x0036AB64 File Offset: 0x00368D64
		protected void _RemainTime()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._remainTime > 0U;
				if (flag2)
				{
					string @string = XStringDefineProxy.GetString("REMAIN_TIME");
					string text = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)this._remainTime, @string, false);
					this.m_RemainTime.SetText(text);
					this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.UpateRemainTime), null);
				}
				else
				{
					string string2 = XStringDefineProxy.GetString("GUILD_REDPACKET_TIMEOVER");
					this.m_RemainTime.SetText(string2);
				}
			}
		}

		// Token: 0x040068F4 RID: 26868
		public IXUIScrollView m_ScrollView;

		// Token: 0x040068F5 RID: 26869
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040068F6 RID: 26870
		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040068F7 RID: 26871
		public IXUILabel m_RemainTime;

		// Token: 0x040068F8 RID: 26872
		protected XAchievementDocument _doc;

		// Token: 0x040068F9 RID: 26873
		protected uint _remainTime;

		// Token: 0x040068FA RID: 26874
		protected uint _timer;

		// Token: 0x040068FB RID: 26875
		private uint _curID;
	}
}
