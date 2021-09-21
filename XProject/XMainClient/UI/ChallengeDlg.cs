using System;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200188B RID: 6283
	internal class ChallengeDlg : DlgBase<ChallengeDlg, ChallengeDlgBehaviour>
	{
		// Token: 0x170039D2 RID: 14802
		// (get) Token: 0x060105AE RID: 66990 RVA: 0x003FAC50 File Offset: 0x003F8E50
		public override string fileName
		{
			get
			{
				return "Battle/ChallengeDlg";
			}
		}

		// Token: 0x170039D3 RID: 14803
		// (get) Token: 0x060105AF RID: 66991 RVA: 0x003FAC68 File Offset: 0x003F8E68
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039D4 RID: 14804
		// (get) Token: 0x060105B0 RID: 66992 RVA: 0x003FAC7C File Offset: 0x003F8E7C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060105B1 RID: 66993 RVA: 0x003FAC8F File Offset: 0x003F8E8F
		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XLevelDocument.uuID) as XLevelDocument);
		}

		// Token: 0x060105B2 RID: 66994 RVA: 0x003FACB1 File Offset: 0x003F8EB1
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Accept.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnAcceptClick));
			base.uiBehaviour.m_HintBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHintClick));
		}

		// Token: 0x060105B3 RID: 66995 RVA: 0x003FACEE File Offset: 0x003F8EEE
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._UpdateState();
		}

		// Token: 0x060105B4 RID: 66996 RVA: 0x003FAD00 File Offset: 0x003F8F00
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

		// Token: 0x060105B5 RID: 66997 RVA: 0x003FAEEB File Offset: 0x003F90EB
		protected void OnTweenOver(IXUITweenTool tween)
		{
			base.uiBehaviour.m_Tween.gameObject.SetActive(false);
		}

		// Token: 0x060105B6 RID: 66998 RVA: 0x003FAF05 File Offset: 0x003F9105
		protected void SetReward(int slot, int itemid, int value)
		{
			base.uiBehaviour.m_RewardValue[slot].SetText(value.ToString());
			base.uiBehaviour.m_RewardIcon[slot].SetSprite(XBagDocument.GetItemSmallIcon(itemid, 0U));
		}

		// Token: 0x060105B7 RID: 66999 RVA: 0x003FAF3C File Offset: 0x003F913C
		protected void OnAcceptClick(IXUILabel lb)
		{
			base.uiBehaviour.m_Tween.SetTweenGroup(2);
			base.uiBehaviour.m_Tween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnTweenOver));
			base.uiBehaviour.m_Tween.PlayTween(true, -1f);
			base.uiBehaviour.m_HintBg.gameObject.SetActive(true);
		}

		// Token: 0x060105B8 RID: 67000 RVA: 0x003FAFA7 File Offset: 0x003F91A7
		protected void OnHintClick(IXUISprite sp)
		{
			base.uiBehaviour.m_Tween.SetTweenGroup(1);
			base.uiBehaviour.m_Tween.RegisterOnFinishEventHandler(null);
			base.uiBehaviour.m_Tween.PlayTween(true, -1f);
		}

		// Token: 0x060105B9 RID: 67001 RVA: 0x003FAFE8 File Offset: 0x003F91E8
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

		// Token: 0x040075E8 RID: 30184
		private XLevelDocument _doc;

		// Token: 0x040075E9 RID: 30185
		private RandomTaskTable.RowData _CurrentTaskData;

		// Token: 0x040075EA RID: 30186
		private StringBuilder _SB = new StringBuilder();
	}
}
