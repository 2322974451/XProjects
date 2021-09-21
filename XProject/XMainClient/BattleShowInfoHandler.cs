using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B93 RID: 2963
	internal class BattleShowInfoHandler : DlgHandlerBase
	{
		// Token: 0x0600A9CA RID: 43466 RVA: 0x001E4638 File Offset: 0x001E2838
		protected override void Init()
		{
			base.Init();
			this.m_pauseGroup = (base.transform.FindChild("Bg").GetComponent("PositionGroup") as IXPositionGroup);
			Transform transform = base.transform.FindChild("Bg/InfoTpl");
			this.m_InfoPool.SetupPool(null, transform.gameObject, BattleShowInfoHandler.GAME_INFO_MAX, false);
		}

		// Token: 0x17003034 RID: 12340
		// (get) Token: 0x0600A9CB RID: 43467 RVA: 0x001E469C File Offset: 0x001E289C
		protected override string FileName
		{
			get
			{
				return "Battle/BattleShowGameInfo";
			}
		}

		// Token: 0x0600A9CC RID: 43468 RVA: 0x001E46B4 File Offset: 0x001E28B4
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

		// Token: 0x0600A9CD RID: 43469 RVA: 0x001E4713 File Offset: 0x001E2913
		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowInfoTimerID);
			this.m_ShowInfoTimerID = 0U;
			base.OnHide();
		}

		// Token: 0x0600A9CE RID: 43470 RVA: 0x001E4735 File Offset: 0x001E2935
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_ShowInfoTimerID);
			this.m_ShowInfoTimerID = 0U;
			base.OnUnload();
		}

		// Token: 0x0600A9CF RID: 43471 RVA: 0x001E4758 File Offset: 0x001E2958
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

		// Token: 0x0600A9D0 RID: 43472 RVA: 0x001E47CC File Offset: 0x001E29CC
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

		// Token: 0x0600A9D1 RID: 43473 RVA: 0x001E4820 File Offset: 0x001E2A20
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

		// Token: 0x04003ED8 RID: 16088
		public static readonly uint GAME_INFO_MAX = 3U;

		// Token: 0x04003ED9 RID: 16089
		public static readonly uint CLEAR_GAME_INFO_TIME = 10U;

		// Token: 0x04003EDA RID: 16090
		private uint m_ShowInfoTimerID = 0U;

		// Token: 0x04003EDB RID: 16091
		private Queue<string> qInfo = new Queue<string>();

		// Token: 0x04003EDC RID: 16092
		private float lastShowInfoTime;

		// Token: 0x04003EDD RID: 16093
		private bool isChange = false;

		// Token: 0x04003EDE RID: 16094
		public static readonly string red = "[ef2717]";

		// Token: 0x04003EDF RID: 16095
		public static readonly string blue = "[21b2ff]";

		// Token: 0x04003EE0 RID: 16096
		public IXPositionGroup m_pauseGroup;

		// Token: 0x04003EE1 RID: 16097
		public XUIPool m_InfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
