using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BattleShowInfoHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_pauseGroup = (base.transform.FindChild("Bg").GetComponent("PositionGroup") as IXPositionGroup);
			Transform transform = base.transform.FindChild("Bg/InfoTpl");
			this.m_InfoPool.SetupPool(null, transform.gameObject, BattleShowInfoHandler.GAME_INFO_MAX, false);
		}

		protected override string FileName
		{
			get
			{
				return "Battle/BattleShowGameInfo";
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowInfoTimerID);
			this.RefreshInfo();
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_SURVIVE;
			if (flag)
			{
				this.m_pauseGroup.SetGroup(1);
			}
			else
			{
				this.m_pauseGroup.SetGroup(0);
			}
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowInfoTimerID);
			this.m_ShowInfoTimerID = 0U;
			base.OnHide();
		}

		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowInfoTimerID);
			this.m_ShowInfoTimerID = 0U;
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = Time.time > this.lastShowInfoTime + BattleShowInfoHandler.CLEAR_GAME_INFO_TIME;
			if (flag)
			{
				while (this.qInfo.Count != 0)
				{
					this.qInfo.Clear();
					this.isChange = true;
				}
			}
			bool flag2 = this.isChange;
			if (flag2)
			{
				this.RefreshInfo();
				this.isChange = false;
			}
		}

		public void AddInfo(string newInfo)
		{
			this.lastShowInfoTime = Time.time;
			this.qInfo.Enqueue(newInfo);
			bool flag = (long)this.qInfo.Count > (long)((ulong)BattleShowInfoHandler.GAME_INFO_MAX);
			if (flag)
			{
				this.qInfo.Dequeue();
			}
			this.RefreshInfo();
		}

		private void RefreshInfo()
		{
			this.m_InfoPool.FakeReturnAll();
			int num = 0;
			while ((long)num < (long)((ulong)BattleShowInfoHandler.GAME_INFO_MAX))
			{
				GameObject gameObject = this.m_InfoPool.FetchGameObject(false);
				bool flag = this.qInfo.Count <= num;
				if (flag)
				{
					gameObject.transform.localPosition = XGameUI.Far_Far_Away;
				}
				else
				{
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_InfoPool.TplHeight * num), 0f);
					int num2 = 0;
					foreach (string text in this.qInfo)
					{
						bool flag2 = num2 == num;
						if (flag2)
						{
							IXUILabel ixuilabel = gameObject.transform.FindChild("info").GetComponent("XUILabel") as IXUILabel;
							ixuilabel.SetText(text);
							break;
						}
						num2++;
					}
				}
				num++;
			}
			this.m_InfoPool.ActualReturnAll(false);
		}

		public static readonly uint GAME_INFO_MAX = 3U;

		public static readonly uint CLEAR_GAME_INFO_TIME = 10U;

		private uint m_ShowInfoTimerID = 0U;

		private Queue<string> qInfo = new Queue<string>();

		private float lastShowInfoTime;

		private bool isChange = false;

		public static readonly string red = "[ef2717]";

		public static readonly string blue = "[21b2ff]";

		public IXPositionGroup m_pauseGroup;

		public XUIPool m_InfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
