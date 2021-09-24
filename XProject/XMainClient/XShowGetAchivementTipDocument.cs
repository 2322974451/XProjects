using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShowGetAchivementTipDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XShowGetAchivementTipDocument.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.AchivementQueue.Clear();
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.CheckScene();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.queue.Count > 0;
			if (flag)
			{
				DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.ShowUI();
			}
		}

		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool flag = DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.SetVisible(false, true);
			}
		}

		public void AddAchivement(uint AchivementID, uint state)
		{
			bool flag = state != 1U;
			if (!flag)
			{
				AchivementTable.RowData achivementData = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID).GetAchivementData(AchivementID);
				bool flag2 = achivementData == null;
				if (!flag2)
				{
					bool flag3 = achivementData.ShowAchivementTip == 0;
					if (!flag3)
					{
						this.AchivementQueue.Enqueue(achivementData);
						this.CheckScene();
					}
				}
			}
		}

		public void ShowAchivementTip(object o = null)
		{
			bool flag = this.AchivementQueue.Count > 0 && !DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.SetAlpha(1f);
				}
				DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.SetVisible(true, true);
				DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.ShowTip(this.AchivementQueue.Dequeue());
			}
		}

		private void CheckScene()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && !DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ShowAchivementTip(null);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ShowGetAchivementTipDocument");

		private Queue<AchivementTable.RowData> AchivementQueue = new Queue<AchivementTable.RowData>();
	}
}
