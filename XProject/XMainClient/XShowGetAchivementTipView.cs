using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E58 RID: 3672
	internal class XShowGetAchivementTipView : DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>
	{
		// Token: 0x17003475 RID: 13429
		// (get) Token: 0x0600C4C6 RID: 50374 RVA: 0x002B19DC File Offset: 0x002AFBDC
		// (set) Token: 0x0600C4C7 RID: 50375 RVA: 0x002B19F4 File Offset: 0x002AFBF4
		public XShowGetAchivementTipView.State state
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
				this.m_uiBehaviour.m_Bg.SetActive(value == XShowGetAchivementTipView.State.Silver);
				this.m_uiBehaviour.m_Bg2.SetActive(value == XShowGetAchivementTipView.State.Gold);
			}
		}

		// Token: 0x17003476 RID: 13430
		// (get) Token: 0x0600C4C8 RID: 50376 RVA: 0x002B1A28 File Offset: 0x002AFC28
		public override string fileName
		{
			get
			{
				return "GameSystem/ShowAchivementTipDlg";
			}
		}

		// Token: 0x17003477 RID: 13431
		// (get) Token: 0x0600C4C9 RID: 50377 RVA: 0x002B1A40 File Offset: 0x002AFC40
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003478 RID: 13432
		// (get) Token: 0x0600C4CA RID: 50378 RVA: 0x002B1A54 File Offset: 0x002AFC54
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C4CB RID: 50379 RVA: 0x002B1A67 File Offset: 0x002AFC67
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XShowGetAchivementTipDocument>(XShowGetAchivementTipDocument.uuID);
		}

		// Token: 0x0600C4CC RID: 50380 RVA: 0x002B1A81 File Offset: 0x002AFC81
		protected override void OnShow()
		{
			base.uiBehaviour.m_Bg.SetActive(false);
		}

		// Token: 0x0600C4CD RID: 50381 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnUnload()
		{
		}

		// Token: 0x0600C4CE RID: 50382 RVA: 0x002B1A98 File Offset: 0x002AFC98
		public void ShowUI()
		{
			bool flag = this.queue.Count <= 0;
			if (!flag)
			{
				this.SetVisible(true, true);
				TipNode tipNode = this.queue.Peek();
				bool flag2 = tipNode.type == 0;
				if (flag2)
				{
					AchievementV2Table.RowData rowData = tipNode.data as AchievementV2Table.RowData;
					bool flag3 = rowData.GainShowIcon != 0;
					if (flag3)
					{
						this.state = XShowGetAchivementTipView.State.Silver;
						base.uiBehaviour.m_AchivementName.SetText(rowData.Achievement);
						base.uiBehaviour.m_AchivementText.SetText(rowData.Explanation);
					}
					else
					{
						this.state = XShowGetAchivementTipView.State.Gold;
						base.uiBehaviour.m_AchivementName2.SetText(rowData.Achievement);
						base.uiBehaviour.m_AchivementText2.SetText(rowData.Explanation);
					}
				}
				else
				{
					bool flag4 = tipNode.type == 1;
					if (flag4)
					{
						DesignationTable.RowData rowData2 = tipNode.data as DesignationTable.RowData;
						bool flag5 = rowData2.GainShowIcon != 0;
						if (flag5)
						{
							this.state = XShowGetAchivementTipView.State.Silver;
							base.uiBehaviour.m_AchivementName.SetText(rowData2.Designation);
							base.uiBehaviour.m_AchivementText.SetText(rowData2.Explanation);
						}
						else
						{
							this.state = XShowGetAchivementTipView.State.Gold;
							base.uiBehaviour.m_AchivementName2.SetText(rowData2.Designation);
							base.uiBehaviour.m_AchivementText2.SetText(rowData2.Explanation);
						}
					}
				}
				bool flag6 = this.state == XShowGetAchivementTipView.State.Silver;
				if (flag6)
				{
					IXUITweenTool ixuitweenTool = base.uiBehaviour.m_Bg.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool.SetTargetGameObject(base.uiBehaviour.m_Bg);
					ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
					ixuitweenTool.PlayTween(true, -1f);
				}
				else
				{
					IXUITweenTool ixuitweenTool2 = base.uiBehaviour.m_Bg2.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
					ixuitweenTool2.SetTargetGameObject(base.uiBehaviour.m_Bg2);
					ixuitweenTool2.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
					ixuitweenTool2.PlayTween(true, -1f);
				}
			}
		}

		// Token: 0x0600C4CF RID: 50383 RVA: 0x002B1CE4 File Offset: 0x002AFEE4
		public void Show(AchievementV2Table.RowData data)
		{
			bool flag = this.queue.Count > 0;
			if (flag)
			{
				TipNode tipNode = new TipNode();
				tipNode.data = data;
				tipNode.type = 0;
				this.queue.Enqueue(tipNode);
			}
			else
			{
				TipNode tipNode2 = new TipNode();
				tipNode2.data = data;
				tipNode2.type = 0;
				this.queue.Enqueue(tipNode2);
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag2)
				{
					this.ShowUI();
				}
			}
		}

		// Token: 0x0600C4D0 RID: 50384 RVA: 0x002B1D6C File Offset: 0x002AFF6C
		public void ShowDesignation(DesignationTable.RowData data)
		{
			bool flag = this.queue.Count > 0;
			if (flag)
			{
				TipNode tipNode = new TipNode();
				tipNode.data = data;
				tipNode.type = 1;
				this.queue.Enqueue(tipNode);
			}
			else
			{
				TipNode tipNode2 = new TipNode();
				tipNode2.data = data;
				tipNode2.type = 1;
				this.queue.Enqueue(tipNode2);
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag2)
				{
					this.ShowUI();
				}
			}
		}

		// Token: 0x0600C4D1 RID: 50385 RVA: 0x002B1DF4 File Offset: 0x002AFFF4
		public void ShowTip(AchivementTable.RowData date)
		{
			this.state = XShowGetAchivementTipView.State.Silver;
			bool flag = date.AchievementIcon != null;
			if (flag)
			{
				base.uiBehaviour.m_AchivementName.SetText(date.AchievementName);
			}
			base.uiBehaviour.m_AchivementName.SetText(date.AchievementName);
			base.uiBehaviour.m_AchivementText.SetText(date.AchievementDescription);
			IXUITweenTool ixuitweenTool = base.uiBehaviour.m_Bg.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.SetTargetGameObject(base.uiBehaviour.m_Bg);
			ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			ixuitweenTool.PlayTween(true, -1f);
		}

		// Token: 0x0600C4D2 RID: 50386 RVA: 0x002B1EB0 File Offset: 0x002B00B0
		public void OnPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			this.queue.Dequeue();
			bool flag = this.queue.Count > 0;
			if (flag)
			{
				this.ShowUI();
			}
			else
			{
				base.uiBehaviour.m_Bg.SetActive(false);
				this.SetVisible(false, true);
			}
		}

		// Token: 0x0600C4D3 RID: 50387 RVA: 0x002B1F02 File Offset: 0x002B0102
		protected override void OnHide()
		{
			this.queue.Clear();
		}

		// Token: 0x040055D5 RID: 21973
		public Queue<TipNode> queue = new Queue<TipNode>();

		// Token: 0x040055D6 RID: 21974
		private XShowGetAchivementTipView.State _state = XShowGetAchivementTipView.State.Silver;

		// Token: 0x040055D7 RID: 21975
		private XShowGetAchivementTipDocument _doc = null;

		// Token: 0x020019CE RID: 6606
		public enum State
		{
			// Token: 0x04007FF5 RID: 32757
			Silver,
			// Token: 0x04007FF6 RID: 32758
			Gold
		}
	}
}
