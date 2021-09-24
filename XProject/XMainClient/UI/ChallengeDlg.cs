using System;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ChallengeDlg : DlgBase<ChallengeDlg, ChallengeDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/ChallengeDlg";
			}
		}

		public override int layer
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

		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Accept.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnAcceptClick));
			base.uiBehaviour.m_HintBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHintClick));
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._UpdateState();
		}

		public void ShowRandomTask(int rtask)
		{
			this.SetVisible(true, true);
			base.uiBehaviour.m_Tween.SetTweenGroup(1);
			base.uiBehaviour.m_Tween.RegisterOnFinishEventHandler(null);
			base.uiBehaviour.m_Tween.PlayTween(true, -1f);
			RandomTaskTable.RowData randomTaskData = this._doc.GetRandomTaskData(rtask);
			this._CurrentTaskData = randomTaskData;
			string text = string.Format(randomTaskData.TaskDescription, randomTaskData.TaskParam);
			base.uiBehaviour.m_MainDesc.SetText(text);
			base.uiBehaviour.m_HintDesc.SetText(text);
			bool flag = randomTaskData.TaskReward.Count == 1;
			if (flag)
			{
				base.uiBehaviour.m_RewardValue[0].gameObject.SetActive(false);
				base.uiBehaviour.m_RewardValue[1].gameObject.SetActive(false);
				base.uiBehaviour.m_RewardValue[2].gameObject.SetActive(true);
				this.SetReward(2, randomTaskData.TaskReward[0, 0], randomTaskData.TaskReward[0, 1]);
			}
			else
			{
				bool flag2 = randomTaskData.TaskReward.Count == 2;
				if (flag2)
				{
					base.uiBehaviour.m_RewardValue[0].gameObject.SetActive(true);
					base.uiBehaviour.m_RewardValue[1].gameObject.SetActive(true);
					base.uiBehaviour.m_RewardValue[2].gameObject.SetActive(false);
					this.SetReward(0, randomTaskData.TaskReward[0, 0], randomTaskData.TaskReward[0, 1]);
					this.SetReward(1, randomTaskData.TaskReward[1, 0], randomTaskData.TaskReward[1, 1]);
				}
			}
			base.uiBehaviour.m_HintBg.gameObject.SetActive(false);
			this._UpdateState();
		}

		protected void OnTweenOver(IXUITweenTool tween)
		{
			base.uiBehaviour.m_Tween.gameObject.SetActive(false);
		}

		protected void SetReward(int slot, int itemid, int value)
		{
			base.uiBehaviour.m_RewardValue[slot].SetText(value.ToString());
			base.uiBehaviour.m_RewardIcon[slot].SetSprite(XBagDocument.GetItemSmallIcon(itemid, 0U));
		}

		protected void OnAcceptClick(IXUILabel lb)
		{
			base.uiBehaviour.m_Tween.SetTweenGroup(2);
			base.uiBehaviour.m_Tween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnTweenOver));
			base.uiBehaviour.m_Tween.PlayTween(true, -1f);
			base.uiBehaviour.m_HintBg.gameObject.SetActive(true);
		}

		protected void OnHintClick(IXUISprite sp)
		{
			base.uiBehaviour.m_Tween.SetTweenGroup(1);
			base.uiBehaviour.m_Tween.RegisterOnFinishEventHandler(null);
			base.uiBehaviour.m_Tween.PlayTween(true, -1f);
		}

		private void _UpdateState()
		{
			bool flag = this._CurrentTaskData == null;
			if (!flag)
			{
				string text = null;
				ChallegeType taskCondition = (ChallegeType)this._CurrentTaskData.TaskCondition;
				if (taskCondition != ChallegeType.CT_COMBO)
				{
					if (taskCondition != ChallegeType.CT_PASSTIME)
					{
						if (taskCondition == ChallegeType.CT_OPENCHEST)
						{
							bool flag2 = XSingleton<XLevelStatistics>.singleton.ls._box_enemy_kill >= this._CurrentTaskData.TaskParam;
							if (flag2)
							{
								text = XStringDefineProxy.GetString("LEVEL_CHALLENGE_FINISH");
							}
							else
							{
								text = string.Format("{0}/{1}", XSingleton<XLevelStatistics>.singleton.ls._box_enemy_kill, this._CurrentTaskData.TaskParam);
							}
						}
					}
					else
					{
						bool flag3 = XSingleton<XLevelStatistics>.singleton.ls._end_time > 0f && (float)this._CurrentTaskData.TaskParam - (XSingleton<XLevelStatistics>.singleton.ls._end_time - XSingleton<XLevelStatistics>.singleton.ls._start_time) >= 0f;
						if (flag3)
						{
							text = XStringDefineProxy.GetString("LEVEL_CHALLENGE_FINISH");
						}
						else
						{
							int num = (int)((float)this._CurrentTaskData.TaskParam - (Time.time - XSingleton<XLevelStatistics>.singleton.ls._start_time));
							bool flag4 = num < 0;
							if (flag4)
							{
								num = 0;
							}
							text = XSingleton<UiUtility>.singleton.TimeFormatString(num, 2, 2, 4, false, true);
						}
					}
				}
				else
				{
					bool flag5 = (ulong)XSingleton<XLevelStatistics>.singleton.ls._max_combo >= (ulong)((long)this._CurrentTaskData.TaskParam);
					if (flag5)
					{
						text = XStringDefineProxy.GetString("LEVEL_CHALLENGE_FINISH");
					}
					else
					{
						text = string.Format("{0}/{1}", XSingleton<XLevelStatistics>.singleton.ls._max_combo, this._CurrentTaskData.TaskParam);
					}
				}
				bool flag6 = text != null;
				if (flag6)
				{
					this._SB.Remove(0, this._SB.Length);
					this._SB.Append('(').Append(text).Append(')');
					base.uiBehaviour.m_HintState.SetText(this._SB.ToString());
				}
				else
				{
					base.uiBehaviour.m_HintState.SetText("");
				}
			}
		}

		private XLevelDocument _doc;

		private RandomTaskTable.RowData _CurrentTaskData;

		private StringBuilder _SB = new StringBuilder();
	}
}
