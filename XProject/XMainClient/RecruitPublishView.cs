using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A38 RID: 2616
	internal class RecruitPublishView<T, V> : DlgBase<T, V> where T : IXUIDlg, new() where V : RecruitPublishBehaviour
	{
		// Token: 0x06009F3D RID: 40765 RVA: 0x001A5D44 File Offset: 0x001A3F44
		protected override void OnUnload()
		{
			bool flag = this.m_typeVector != null;
			if (flag)
			{
				this.m_typeVector.Release();
				this.m_typeVector = null;
			}
			DlgHandlerBase.EnsureUnload<RecruitStepCounter>(ref this._timeFrame);
			base.OnUnload();
		}

		// Token: 0x06009F3E RID: 40766 RVA: 0x001A5D88 File Offset: 0x001A3F88
		public void OpenView(uint stageID = 1100U)
		{
			this._setupStageID = stageID;
			bool flag = base.IsVisible();
			if (flag)
			{
				this.Refresh();
			}
			else
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		// Token: 0x06009F3F RID: 40767 RVA: 0x001A5DBC File Offset: 0x001A3FBC
		protected virtual uint GetNormalSelect()
		{
			return this._setupStageID;
		}

		// Token: 0x06009F40 RID: 40768 RVA: 0x001A5DD4 File Offset: 0x001A3FD4
		protected uint GetSelectStageID()
		{
			GroupStageType.RowData groupStage = GroupChatDocument.GetGroupStage(this._curStageID);
			return (uint)((groupStage != null) ? groupStage.Stage2Expedition : 0);
		}

		// Token: 0x06009F41 RID: 40769 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Refresh()
		{
		}

		// Token: 0x06009F42 RID: 40770 RVA: 0x001A5DFE File Offset: 0x001A3FFE
		protected override void OnShow()
		{
			base.OnShow();
			this.SetupTypeList();
			this.SetupNormalSeclect();
			this.Refresh();
		}

		// Token: 0x06009F43 RID: 40771 RVA: 0x001A5E20 File Offset: 0x001A4020
		protected uint GetMemberType()
		{
			uint result = 0U;
			int i = 0;
			int num = base.uiBehaviour._memberTypes.Length;
			while (i < num)
			{
				bool bChecked = base.uiBehaviour._memberTypes[i].bChecked;
				if (bChecked)
				{
					result = (uint)base.uiBehaviour._memberTypes[i].ID;
					break;
				}
				i++;
			}
			return result;
		}

		// Token: 0x06009F44 RID: 40772 RVA: 0x001A5E98 File Offset: 0x001A4098
		protected int GetTime()
		{
			return this._timeFrame.Cur;
		}

		// Token: 0x06009F45 RID: 40773 RVA: 0x001A5EB5 File Offset: 0x001A40B5
		protected override void Init()
		{
			base.Init();
			this.SetupView();
		}

		// Token: 0x06009F46 RID: 40774 RVA: 0x001A5EC8 File Offset: 0x001A40C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour._Submit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSubmitClick));
		}

		// Token: 0x06009F47 RID: 40775 RVA: 0x001A5F24 File Offset: 0x001A4124
		protected virtual bool OnSubmitClick(IXUIButton btn)
		{
			this.OnCloseClick(null);
			return true;
		}

		// Token: 0x06009F48 RID: 40776 RVA: 0x001A5F40 File Offset: 0x001A4140
		private bool OnCloseClick(IXUIButton btn = null)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06009F49 RID: 40777 RVA: 0x001A5F5C File Offset: 0x001A415C
		private void SetupView()
		{
			this.m_typeVector = new XBetterDictionary<uint, Transform>(0);
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			this._timeFrame = DlgHandlerBase.EnsureCreate<RecruitStepCounter>(ref this._timeFrame, base.uiBehaviour._StartTime.gameObject, null, true);
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("RecruitPublishTimeLimit");
			int num = 86400 / @int;
			int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("RecruitPublishTimeNormal");
			this._timeFrame.Setup(0, 86400, int2 * num, num, new RecruitStepCounterUpdate(this.OnStepCounterUpdate));
		}

		// Token: 0x06009F4A RID: 40778 RVA: 0x001A5FF8 File Offset: 0x001A41F8
		private void OnStepCounterUpdate(IXUILabel label)
		{
			int cur = this._timeFrame.Cur;
			string format = "{0} - {1}";
			bool flag = cur == 0;
			string text;
			if (flag)
			{
				text = string.Format(format, "0:00", XSingleton<UiUtility>.singleton.TimeFormatString(cur + this._timeFrame.Step, 0, 3, 3, false, true));
			}
			else
			{
				text = string.Format(format, XSingleton<UiUtility>.singleton.TimeFormatString(cur, 0, 3, 3, false, true), XSingleton<UiUtility>.singleton.TimeFormatString(cur + this._timeFrame.Step, 0, 3, 3, false, true));
			}
			label.SetText(text);
		}

		// Token: 0x06009F4B RID: 40779 RVA: 0x001A608C File Offset: 0x001A428C
		private void SetupTypeList()
		{
			base.uiBehaviour._levelOnePool.ReturnAll(true);
			base.uiBehaviour._levelTwoPool.ReturnAll(true);
			this.m_typeVector.Clear();
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			GroupStageType.RowData[] stageTable = GroupChatDocument.GetStageTable();
			int i = 0;
			int num = stageTable.Length;
			while (i < num)
			{
				bool flag = stageTable[i].StagePerent == 0U;
				if (flag)
				{
					GameObject gameObject = base.uiBehaviour._levelOnePool.FetchGameObject(false);
					this.SetSelectorInfo(gameObject.transform, stageTable[i]);
					IXUISprite ixuisprite = gameObject.transform.Find("Selected/Switch").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetAlpha(0f);
					ixuisprite2.ID = (ulong)stageTable[i].StageID;
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClick));
					IXUIPlayTweenGroup ixuiplayTweenGroup = gameObject.transform.GetComponent("XUIPlayTweenGroup") as IXUIPlayTweenGroup;
					bool flag2 = ixuiplayTweenGroup != null;
					if (flag2)
					{
						ixuiplayTweenGroup.ResetTween(true);
					}
				}
				i++;
			}
			i = 0;
			num = stageTable.Length;
			while (i < num)
			{
				bool flag3 = stageTable[i].StagePerent == 0U;
				if (!flag3)
				{
					bool flag4 = !this.m_typeVector.ContainsKey(stageTable[i].StagePerent);
					if (!flag4)
					{
						GameObject gameObject = base.uiBehaviour._levelTwoPool.FetchGameObject(false);
						this.SetSelectorInfo(gameObject.transform, stageTable[i]);
						Transform transform = this.m_typeVector[stageTable[i].StagePerent].Find("ChildList");
						IXUISprite ixuisprite3 = gameObject.transform.Find("Switch").GetComponent("XUISprite") as IXUISprite;
						IXUISprite ixuisprite4 = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
						ixuisprite4.ID = (ulong)stageTable[i].StageID;
						ixuisprite3.SetAlpha(0f);
						gameObject.transform.parent = transform;
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = new Vector3(0f, -((float)transform.childCount - 0.5f) * (float)ixuisprite4.spriteHeight, 0f);
						ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTypeCheckBoxClick));
					}
				}
				i++;
			}
		}

		// Token: 0x06009F4C RID: 40780 RVA: 0x001A633C File Offset: 0x001A453C
		private void SetupNormalSeclect()
		{
			uint key = 0U;
			uint normalSelect = this.GetNormalSelect();
			Transform transform;
			bool flag = this.m_typeVector.TryGetValue(normalSelect, out transform);
			if (flag)
			{
				this._curStageID = normalSelect;
				IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.bChecked = true;
				bool flag2 = GroupChatDocument.TryGetParentStage(this._curStageID, out key) && this.m_typeVector.TryGetValue(key, out transform);
				if (flag2)
				{
					IXUIPlayTweenGroup ixuiplayTweenGroup = transform.GetComponent("XUIPlayTweenGroup") as IXUIPlayTweenGroup;
					bool flag3 = ixuiplayTweenGroup == null;
					if (!flag3)
					{
						ixuiplayTweenGroup.ResetTween(true);
						ixuiplayTweenGroup.PlayTween(true);
					}
				}
			}
		}

		// Token: 0x06009F4D RID: 40781 RVA: 0x001A63E4 File Offset: 0x001A45E4
		private void SetSelectorInfo(Transform t, GroupStageType.RowData rowData)
		{
			IXUILabel ixuilabel = t.Find("Label").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(rowData.StageName);
			t.name = rowData.StageID.ToString();
			ixuilabel2.SetText(rowData.StageName);
			bool flag = !this.m_typeVector.ContainsKey(rowData.StageID);
			if (flag)
			{
				this.m_typeVector.Add(rowData.StageID, t);
			}
		}

		// Token: 0x06009F4E RID: 40782 RVA: 0x001A6480 File Offset: 0x001A4680
		private void OnTypeCheckBoxClick(IXUISprite sprite)
		{
			this._curStageID = (uint)sprite.ID;
			this.OnStageSelect();
			XSingleton<XDebug>.singleton.AddGreenLog("OnTypeCheckBoxClick", sprite.ID.ToString(), null, null, null, null);
		}

		// Token: 0x06009F4F RID: 40783 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnStageSelect()
		{
		}

		// Token: 0x040038D0 RID: 14544
		protected GroupChatDocument _doc;

		// Token: 0x040038D1 RID: 14545
		private XBetterDictionary<uint, Transform> m_typeVector;

		// Token: 0x040038D2 RID: 14546
		private RecruitStepCounter _timeFrame;

		// Token: 0x040038D3 RID: 14547
		private uint _setupStageID = 1100U;

		// Token: 0x040038D4 RID: 14548
		private uint _curStageID = 1100U;
	}
}
