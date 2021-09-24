using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XShowGetAchivementTipView : DlgBase<XShowGetAchivementTipView, XShowGetAchivementTipBehaviour>
	{

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

		public override string fileName
		{
			get
			{
				return "GameSystem/ShowAchivementTipDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XShowGetAchivementTipDocument>(XShowGetAchivementTipDocument.uuID);
		}

		protected override void OnShow()
		{
			base.uiBehaviour.m_Bg.SetActive(false);
		}

		protected override void OnUnload()
		{
		}

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

		protected override void OnHide()
		{
			this.queue.Clear();
		}

		public Queue<TipNode> queue = new Queue<TipNode>();

		private XShowGetAchivementTipView.State _state = XShowGetAchivementTipView.State.Silver;

		private XShowGetAchivementTipDocument _doc = null;

		public enum State
		{

			Silver,

			Gold
		}
	}
}
