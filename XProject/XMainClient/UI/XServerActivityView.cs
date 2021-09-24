using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XServerActivityView : DlgHandlerBase
	{

		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XAchievementDocument.uuID) as XAchievementDocument);
			this._doc.ServerActivityView = this;
			this.m_RemainTime = (base.PanelObject.transform.FindChild("RemainTime/Label").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.FindChild("Panel");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform2 = base.PanelObject.transform.FindChild("Panel/RecordTpl/ItemReward/ItemTpl");
			this.m_RewardItemPool.SetupPool(transform.gameObject, transform2.gameObject, 30U, false);
			transform2 = base.PanelObject.transform.FindChild("Panel/RecordTpl");
			this.m_RewardPool.SetupPool(transform2.parent.gameObject, transform2.gameObject, 10U, false);
		}

		public void UpdateRedPoint()
		{
			this._doc.HasCompleteAchivement(XSysDefine.XSys_ServerActivity);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._remainTime = 0U;
			RpcC2G_QueryOpenGameActivityTime rpc = new RpcC2G_QueryOpenGameActivityTime();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
			this.RefreshList();
		}

		public override void OnUnload()
		{
			this._remainTime = 0U;
			bool flag = this._timer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
			}
			base.OnUnload();
			this._doc.ServerActivityView = null;
		}

		protected string GetActivityString(string format, int catergory, int param, AchivementState state)
		{
			string result;
			if (catergory - 502 > 1)
			{
				bool flag = state == AchivementState.Not_Achive || state == AchivementState.Exceed;
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
				bool flag2 = state == AchivementState.Not_Achive || state == AchivementState.Exceed;
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

		protected bool OnFetchClicked(IXUIButton button)
		{
			this._doc.FetchAchivement((uint)button.ID);
			return true;
		}

		protected bool OnLinkToClick(IXUIButton button)
		{
			return true;
		}

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

		public void RefreshList()
		{
			this.UpdateRedPoint();
			this.m_RewardPool.ReturnAll(false);
			this.m_RewardItemPool.ReturnAll(false);
			this.m_ScrollView.SetPosition(0f);
			List<int> catergoryActivity = this._doc.GetCatergoryActivity(501);
			bool flag = catergoryActivity == null || catergoryActivity.Count <= 0;
			if (!flag)
			{
				catergoryActivity.Sort(new Comparison<int>(this.ActivityCompare));
				for (int i = 0; i < catergoryActivity.Count; i++)
				{
					GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
					gameObject.name = "record" + catergoryActivity[i];
					gameObject.transform.localPosition = this.m_RewardPool.TplPos - new Vector3(0f, (float)(this.m_RewardPool.TplHeight * i));
					AchivementTable.RowData achivementData = this._doc.GetAchivementData((uint)catergoryActivity[i]);
					bool flag2 = achivementData != null;
					if (flag2)
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
						bool flag3 = achivementData.AchievementCategory == 504;
						if (flag3)
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
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						}
					}
				}
			}
		}

		public void SetRemainTime(uint second)
		{
			this._remainTime = second;
			this._RemainTime();
		}

		public void UpateRemainTime(object param)
		{
			bool flag = this._remainTime > 0U;
			if (flag)
			{
				this._remainTime -= 1U;
				this._RemainTime();
			}
		}

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

		public IXUIScrollView m_ScrollView;

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_RewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_RemainTime;

		protected XAchievementDocument _doc;

		protected uint _remainTime;

		protected uint _timer;
	}
}
