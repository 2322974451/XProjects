using System;
using System.Collections.Generic;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009BF RID: 2495
	internal class XShowGetAchivementTipDocument : XDocComponent
	{
		// Token: 0x17002D8E RID: 11662
		// (get) Token: 0x0600973C RID: 38716 RVA: 0x0016F2AC File Offset: 0x0016D4AC
		public override uint ID
		{
			get
			{
				return XShowGetAchivementTipDocument.uuID;
			}
		}

		// Token: 0x0600973D RID: 38717 RVA: 0x0016F2C3 File Offset: 0x0016D4C3
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.AchivementQueue.Clear();
		}

		// Token: 0x0600973E RID: 38718 RVA: 0x0016F2DA File Offset: 0x0016D4DA
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			this.CheckScene();
		}

		// Token: 0x0600973F RID: 38719 RVA: 0x0016F2EC File Offset: 0x0016D4EC
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.queue.Count > 0;
			if (flag)
			{
				DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.ShowUI();
			}
		}

		// Token: 0x06009740 RID: 38720 RVA: 0x0016F33C File Offset: 0x0016D53C
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			bool flag = DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.SetVisible(false, true);
			}
		}

		// Token: 0x06009741 RID: 38721 RVA: 0x0016F370 File Offset: 0x0016D570
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

		// Token: 0x06009742 RID: 38722 RVA: 0x0016F3CC File Offset: 0x0016D5CC
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

		// Token: 0x06009743 RID: 38723 RVA: 0x0016F444 File Offset: 0x0016D644
		private void CheckScene()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && !DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ShowAchivementTip(null);
			}
		}

		// Token: 0x06009744 RID: 38724 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040033A2 RID: 13218
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ShowGetAchivementTipDocument");

		// Token: 0x040033A3 RID: 13219
		private Queue<AchivementTable.RowData> AchivementQueue = new Queue<AchivementTable.RowData>();
	}
}
