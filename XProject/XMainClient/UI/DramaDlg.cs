using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class DramaDlg : DlgBase<DramaDlg, DramaDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Hall/DramaDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool exclusive
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._TogglePage(DramaPage.DP_MAX);
			this.taskDoc = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			this.doc = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
			DlgHandlerBase.EnsureCreate<XNPCFavorDramaSend>(ref this.sendHandler, base.uiBehaviour.m_FavorFrame, false, this);
			DlgHandlerBase.EnsureCreate<XNPCFavorDramaExchange>(ref this.exchangeHandler, base.uiBehaviour.m_FavorFrame, false, this);
		}

		public override void RegisterEvent()
		{
			IXUISprite ixuisprite = base.uiBehaviour.m_TaskArea.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.GotoNextTalk));
			ixuisprite = (base.uiBehaviour.m_OperateArea.GetComponent("XUISprite") as IXUISprite);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			ixuisprite = (base.uiBehaviour.m_FavorGB.GetComponent("XUISprite") as IXUISprite);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			base.uiBehaviour.m_RewardBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRewardClick));
			base.uiBehaviour.m_FuncArea.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNormalFuncClick));
			base.uiBehaviour.m_BtnAccept.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnBtnAcceptTaskClicked));
			base.uiBehaviour.m_BtnReject.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnBtnRejectTaskClicked));
		}

		protected void OnNormalFuncClick(IXUISprite sp)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				bool flag2 = this.m_npc != null && !this.m_npc.Deprecated;
				if (flag2)
				{
					XNpcInfo.RowData byNPCID = XSingleton<XEntityMgr>.singleton.NpcInfo.GetByNPCID(this.m_npc.TypeID);
					bool flag3 = byNPCID != null && byNPCID.NPCType == 3U;
					if (flag3)
					{
						HomePlantDocument.Doc.HomeSprite.SetNextStepOperation();
					}
					bool flag4 = byNPCID != null && byNPCID.NPCType == 4U;
					if (flag4)
					{
						XGuildCollectDocument specificDocument = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
						specificDocument.OnMeetNpc(this.m_npc.TypeID);
					}
				}
				this.SetVisible(false, true);
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("DramaDlg");
			this.m_npc = null;
			this.m_npcAttr = null;
			this._TogglePage(DramaPage.DP_MAX);
			XSingleton<XGameUI>.singleton.HpbarRoot.gameObject.SetActive(false);
			XSingleton<XGameUI>.singleton.NpcHpbarRoot.gameObject.SetActive(false);
			XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, false);
			XSingleton<XAudioMgr>.singleton.StopUISound();
		}

		protected override void OnHide()
		{
			this.doc.OnUIClose();
			this.m_RelativeTask = null;
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			bool flag = base.uiBehaviour.m_leftSnapshot != null;
			if (flag)
			{
				base.uiBehaviour.m_rightSnapshot.RefreshRenderQueue = null;
			}
			bool flag2 = base.uiBehaviour.m_leftSnapshot != null;
			if (flag2)
			{
				base.uiBehaviour.m_leftSnapshot.RefreshRenderQueue = null;
			}
			base.Return3DAvatarPool();
			this.m_npcDummy = null;
			XCameraCloseUpEndEventArgs @event = XEventPool<XCameraCloseUpEndEventArgs>.GetEvent();
			@event.Firer = XSingleton<XScene>.singleton.GameCamera;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.DramaDlgCloseTime = Time.time;
			XSingleton<XGameUI>.singleton.HpbarRoot.gameObject.SetActive(true);
			XSingleton<XGameUI>.singleton.NpcHpbarRoot.gameObject.SetActive(true);
			bool flag3 = this.sendHandler != null;
			if (flag3)
			{
				this.sendHandler.SetVisible(false);
			}
			bool flag4 = this.exchangeHandler != null;
			if (flag4)
			{
				this.exchangeHandler.SetVisible(false);
			}
			XNPCFavorDocument specificDocument = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(XSysDefine.XSys_NPCFavor, specificDocument.IsNeedShowRedpoint);
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XNPCFavorDramaSend>(ref this.sendHandler);
			DlgHandlerBase.EnsureUnload<XNPCFavorDramaExchange>(ref this.exchangeHandler);
			base.Return3DAvatarPool();
			this.doc.OnUIClose();
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			for (int i = 0; i < base.uiBehaviour.MAX_OPERATE_BTN_COUNT; i++)
			{
				base.uiBehaviour.m_OperateBtns[i].Update();
			}
			for (int j = 0; j < base.uiBehaviour.MAX_OPERATE_LIST_COUNT; j++)
			{
				base.uiBehaviour.m_OperateLists[j].Update();
			}
		}

		private void _TogglePage(DramaPage page)
		{
			base.uiBehaviour.m_TaskArea.gameObject.SetActive(page == DramaPage.DP_DIALOG || page == DramaPage.DP_ACCEPT);
			base.uiBehaviour.m_RewardArea.gameObject.SetActive(page == DramaPage.DP_REWARD);
			base.uiBehaviour.m_FuncArea.gameObject.SetActive(page == DramaPage.DP_FUNC);
			base.uiBehaviour.m_TaskAcceptArea.SetActive(page == DramaPage.DP_ACCEPT);
			base.uiBehaviour.m_OperateArea.SetActive(page == DramaPage.DP_OPERATE);
			base.uiBehaviour.m_FavorGB.SetActive(page == DramaPage.DP_FAVOR);
		}

		public void ShowNpcDialog(XNpc npc)
		{
			bool flag = !XEntity.ValideEntity(npc);
			if (!flag)
			{
				XSingleton<XGameUI>.singleton.OnGenericClick();
				bool flag2 = XSingleton<XChatIFlyMgr>.singleton.IsRecording();
				if (flag2)
				{
					XCameraCloseUpEndEventArgs @event = XEventPool<XCameraCloseUpEndEventArgs>.GetEvent();
					@event.Firer = XSingleton<XScene>.singleton.GameCamera;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				else
				{
					this.SetVisible(true, true);
					this.m_npc = npc;
					this.m_npcAttr = (npc.Attributes as XNpcAttributes);
					bool flag3 = this.m_npcAttr == null;
					if (flag3)
					{
						this.SetVisible(false, true);
					}
					else
					{
						this.SetupTalkerName(this.m_npcAttr.Name);
						npc.ShowUp(null);
						NpcTaskState npcTaskState = this.taskDoc.GetNpcTaskState(npc.TypeID, ref this.m_RelativeTask);
						bool flag4 = this.m_RelativeTask != null;
						if (flag4)
						{
							this.m_RelativeTaskID = this.m_RelativeTask.ID;
						}
						else
						{
							this.m_RelativeTaskID = 0U;
						}
						bool flag5 = npcTaskState == NpcTaskState.Normal || npc.NPCType == 3U;
						if (flag5)
						{
							int index = this.PlayNpcVoice();
							this.SetupNpcNormalDialog(index, npc.NPCType);
						}
						else
						{
							this.m_DialogQueue.Clear();
							XTaskDialog curDialog = this.m_RelativeTask.CurDialog;
							for (int i = 0; i < curDialog.Dialog.Count; i++)
							{
								this.m_DialogQueue.Enqueue(curDialog.Dialog[i]);
							}
							this.SetupNpcTaskDialog();
						}
					}
				}
			}
		}

		protected void OnRewardClick(IXUISprite sp)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				XTaskInfo xtaskInfo = null;
				NpcTaskState npcTaskState = this.taskDoc.GetNpcTaskState(this.m_npc.TypeID, ref xtaskInfo);
				bool flag2 = npcTaskState == NpcTaskState.TaskEnd;
				if (flag2)
				{
					RpcC2G_TaskOperate rpcC2G_TaskOperate = new RpcC2G_TaskOperate();
					rpcC2G_TaskOperate.oArg.taskID = (int)xtaskInfo.ID;
					rpcC2G_TaskOperate.oArg.taskOP = 2;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TaskOperate);
					XSingleton<XOperationRecord>.singleton.DoScriptRecord("finishtask+" + xtaskInfo.ID);
					DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
				}
			}
		}

		protected void _PlayVoice(string voice, bool isNPC)
		{
			if (isNPC)
			{
				bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XAudioMgr>.singleton.IsPlayingSound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Motion);
				if (flag)
				{
					XSingleton<XAudioMgr>.singleton.StopSound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Motion);
				}
				bool flag2 = this.m_npc != null && !string.IsNullOrEmpty(voice);
				if (flag2)
				{
					XSingleton<XAudioMgr>.singleton.PlaySound(this.m_npc, AudioChannel.Motion, voice);
				}
			}
			else
			{
				bool flag3 = this.m_npc != null && XSingleton<XAudioMgr>.singleton.IsPlayingSound(this.m_npc, AudioChannel.Motion);
				if (flag3)
				{
					XSingleton<XAudioMgr>.singleton.StopSound(this.m_npc, AudioChannel.Motion);
				}
				bool flag4 = XSingleton<XEntityMgr>.singleton.Player != null && !string.IsNullOrEmpty(voice);
				if (flag4)
				{
					XSingleton<XAudioMgr>.singleton.PlaySound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Motion, voice);
				}
			}
		}

		public void StopVoice()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XAudioMgr>.singleton.IsPlayingSound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Motion);
			if (flag)
			{
				XSingleton<XAudioMgr>.singleton.StopSound(XSingleton<XEntityMgr>.singleton.Player, AudioChannel.Motion);
			}
			bool flag2 = this.m_npc != null && XSingleton<XAudioMgr>.singleton.IsPlayingSound(this.m_npc, AudioChannel.Motion);
			if (flag2)
			{
				XSingleton<XAudioMgr>.singleton.StopSound(this.m_npc, AudioChannel.Motion);
			}
		}

		protected void GotoNextTalk(IXUISprite sp)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				bool activeSelf = base.uiBehaviour.m_TaskAcceptArea.activeSelf;
				if (!activeSelf)
				{
					bool flag2 = this.m_DialogQueue.Count > 0;
					if (flag2)
					{
						XDialogSentence xdialogSentence = this.m_DialogQueue.Dequeue();
						bool flag3 = xdialogSentence.bCanReject && this.m_RelativeTask.Status == TaskStatus.TaskStatus_CanTake;
						if (flag3)
						{
							this._TogglePage(DramaPage.DP_ACCEPT);
							this.ShowTaskAccept(ref xdialogSentence);
						}
						else
						{
							this._TogglePage(DramaPage.DP_DIALOG);
						}
						bool flag4 = xdialogSentence.Talker == 1;
						if (flag4)
						{
							this.SetupNpcText(this.m_npc, XSingleton<UiUtility>.singleton.ReplaceReturn(xdialogSentence.Content));
							this._PlayVoice(xdialogSentence.Voice, true);
						}
						else
						{
							this.SetupPlayerText(XSingleton<UiUtility>.singleton.ReplaceReturn(xdialogSentence.Content));
							this._PlayVoice(xdialogSentence.Voice, false);
						}
					}
					else
					{
						this.SetupNpcText(this.m_npc, "");
						NpcTaskState npcTaskState = NpcTaskState.Normal;
						this.m_RelativeTask = this.taskDoc.GetTaskInfo(this.m_RelativeTaskID);
						bool flag5 = this.m_RelativeTask != null;
						if (flag5)
						{
							npcTaskState = this.m_RelativeTask.NpcState;
						}
						bool flag6 = npcTaskState == NpcTaskState.TaskBegin;
						if (flag6)
						{
							RpcC2G_TaskOperate rpcC2G_TaskOperate = new RpcC2G_TaskOperate();
							rpcC2G_TaskOperate.oArg.taskID = (int)this.m_RelativeTask.ID;
							rpcC2G_TaskOperate.oArg.taskOP = 1;
							XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TaskOperate);
							XSingleton<XOperationRecord>.singleton.DoScriptRecord("accepttask+" + this.m_RelativeTask.ID);
							bool flag7 = !this.CanAutoContinue(this.m_RelativeTask);
							if (flag7)
							{
								this.SetVisible(false, true);
							}
						}
						else
						{
							bool flag8 = npcTaskState == NpcTaskState.TaskEnd;
							if (flag8)
							{
								this.ShowTaskReward(this.m_RelativeTask.ID);
							}
							else
							{
								this.SetVisible(false, true);
							}
						}
					}
				}
			}
		}

		public bool CanAutoContinue(XTaskInfo taskInfo)
		{
			return (taskInfo != null & taskInfo.Conds.Count == 0) && XSingleton<UiUtility>.singleton.ChooseProfData<uint>(taskInfo.TableData.BeginTaskNPCID, 0U) == XSingleton<UiUtility>.singleton.ChooseProfData<uint>(taskInfo.TableData.EndTaskNPCID, 0U);
		}

		protected void ShowTaskAccept(ref XDialogSentence dialog)
		{
			bool flag = this.m_RelativeTask == null || this.m_RelativeTask.TableData == null;
			if (!flag)
			{
				this._TogglePage(DramaPage.DP_ACCEPT);
				TaskTableNew.RowData tableData = this.m_RelativeTask.TableData;
				bool flag2 = tableData.RewardItem.Count > 0;
				if (flag2)
				{
					base.uiBehaviour.m_AcceptItemBg.SetActive(true);
					base.uiBehaviour.m_AcceptItemPool.FakeReturnAll();
					for (int i = 0; i < tableData.RewardItem.Count; i++)
					{
						GameObject gameObject = base.uiBehaviour.m_AcceptItemPool.FetchGameObject(false);
						gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_AcceptItemPool.TplPos.x + (float)(i * base.uiBehaviour.m_AcceptItemPool.TplWidth), base.uiBehaviour.m_AcceptItemPool.TplPos.y, base.uiBehaviour.m_AcceptItemPool.TplPos.z);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)tableData.RewardItem[i, 0], (int)tableData.RewardItem[i, 1], false);
					}
					base.uiBehaviour.m_AcceptItemPool.ActualReturnAll(false);
				}
				else
				{
					base.uiBehaviour.m_AcceptItemBg.SetActive(false);
				}
			}
		}

		protected void ShowTaskReward(uint taskID)
		{
			TaskTableNew.RowData taskData = XTaskDocument.GetTaskData(taskID);
			base.uiBehaviour.m_RewardGold.SetText("0");
			base.uiBehaviour.m_RewardExp.SetText("0");
			bool flag = taskData != null;
			if (flag)
			{
				this._TogglePage(DramaPage.DP_REWARD);
				bool flag2 = taskData.RewardItem.Count > 0;
				if (flag2)
				{
					base.uiBehaviour.m_RewardItemBg.gameObject.SetActive(true);
					Vector3 localPosition = base.uiBehaviour.m_RewardItemPool._tpl.transform.localPosition;
					float num = (float)(base.uiBehaviour.m_RewardItemPool.TplWidth + 5);
					base.uiBehaviour.m_RewardItemPool.ReturnAll(false);
					int i = 0;
					int num2 = 0;
					while (i < taskData.RewardItem.Count)
					{
						int num3 = (int)taskData.RewardItem[i, 0];
						int itemCount = (int)taskData.RewardItem[i, 1];
						bool flag3 = num3 == 1;
						if (flag3)
						{
							base.uiBehaviour.m_RewardGold.SetText(itemCount.ToString());
						}
						else
						{
							bool flag4 = num3 == 4;
							if (flag4)
							{
								base.uiBehaviour.m_RewardExp.SetText(itemCount.ToString());
							}
							else
							{
								GameObject gameObject = base.uiBehaviour.m_RewardItemPool.FetchGameObject(false);
								gameObject.transform.localPosition = localPosition + new Vector3((float)num2 * num, 0f, 0f);
								num2++;
								XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, num3, itemCount, false);
								XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject, num3);
							}
						}
						i++;
					}
				}
				else
				{
					base.uiBehaviour.m_RewardItemBg.gameObject.SetActive(false);
				}
			}
		}

		protected void SetupNpcTaskDialog()
		{
			bool flag = this.m_DialogQueue.Count > 0;
			if (flag)
			{
				this.GotoNextTalk(null);
			}
		}

		protected void SetupNPCAvatar(uint presentID, bool playtween)
		{
			base.uiBehaviour.m_rightSnapshot.transform.localPosition = base.uiBehaviour.m_rightDummyPos;
			base.uiBehaviour.m_leftSnapshot.transform.localPosition = XGameUI.Far_Far_Away;
			this.m_npcDummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, presentID, base.uiBehaviour.m_rightSnapshot, this.m_npcDummy, 1f);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID);
			bool flag = byPresentID != null && byPresentID.AvatarPos != null;
			if (flag)
			{
				int num = XSingleton<XCommon>.singleton.RandomInt(0, byPresentID.AvatarPos.Length);
				this.m_npcDummy.SetAnimation(byPresentID.AvatarPos[num]);
			}
		}

		protected void SetupTalkerName(string name)
		{
			base.uiBehaviour.m_name.SetText(name);
		}

		protected void SetupNpcNormalDialog(int index, uint npcType)
		{
			this._TogglePage(DramaPage.DP_FUNC);
			bool flag = npcType == 3U;
			if (flag)
			{
				HomePlantDocument homePlantDocument = HomePlantDocument.Doc;
				base.uiBehaviour.m_FuncText.SetText(homePlantDocument.HomeSprite.GetDialogue());
				this.SetupNPCAvatar(this.m_npcAttr.PresentID, true);
			}
			else
			{
				index = ((this.m_npcAttr.Content != null && index >= this.m_npcAttr.Content.Length) ? 0 : index);
				base.uiBehaviour.m_FuncText.SetText(this.m_npcAttr.Content[index]);
				this.SetupNPCAvatar(this.m_npcAttr.PresentID, true);
				Vector3 localPosition = base.uiBehaviour.m_FuncPool._tpl.transform.localPosition;
				float num = (float)(base.uiBehaviour.m_FuncPool.TplHeight + 2);
				base.uiBehaviour.m_FuncPool.ReturnAll(false);
				bool flag2 = this.m_npcAttr.Content != null && this.m_npcAttr.FunctionList != null;
				if (flag2)
				{
					for (int i = 0; i < this.m_npcAttr.FunctionList.Length; i++)
					{
						GameObject gameObject = base.uiBehaviour.m_FuncPool.FetchGameObject(false);
						gameObject.transform.localPosition = localPosition + new Vector3(0f, (float)(-(float)i) * num);
						IXUILabel ixuilabel = gameObject.GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(XSingleton<XGameSysMgr>.singleton.GetSysName(this.m_npcAttr.FunctionList[i]));
						ixuilabel.ID = (ulong)((long)this.m_npcAttr.FunctionList[i]);
					}
				}
				bool flag3 = this.m_npcAttr.FunctionList == null || this.m_npcAttr.FunctionList.Length == 0;
				if (flag3)
				{
					base.uiBehaviour.m_FuncTplBg.gameObject.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_FuncTplBg.gameObject.SetActive(true);
				}
			}
		}

		protected int PlayNpcVoice()
		{
			bool flag = this.m_npcAttr.Voice == null || this.m_npcAttr.Voice.Length == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = !XSingleton<XAudioMgr>.singleton.IsPlayingSound(this.m_npc, AudioChannel.Motion);
				if (flag2)
				{
					int num = XSingleton<XCommon>.singleton.RandomInt(0, this.m_npcAttr.Voice.Length);
					XSingleton<XAudioMgr>.singleton.PlaySound(this.m_npc, AudioChannel.Motion, this.m_npcAttr.Voice[num]);
					result = num;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		protected void SetupNpcText(XNpc npc, string text)
		{
			base.uiBehaviour.m_NpcText.gameObject.SetActive(true);
			base.uiBehaviour.m_PlayerText.gameObject.SetActive(false);
			base.uiBehaviour.m_name.gameObject.transform.parent.gameObject.SetActive(true);
			this.SetupNPCAvatar(this.m_npcAttr.PresentID, false);
			base.uiBehaviour.m_NpcText.SetText(text);
		}

		protected void SetupPlayerText(string text)
		{
			base.uiBehaviour.m_NpcText.gameObject.SetActive(false);
			base.uiBehaviour.m_PlayerText.gameObject.SetActive(true);
			base.uiBehaviour.m_name.gameObject.transform.parent.gameObject.SetActive(false);
			base.uiBehaviour.m_PlayerText.SetText(text);
			base.uiBehaviour.m_rightSnapshot.transform.localPosition = XGameUI.Far_Far_Away;
			base.uiBehaviour.m_leftSnapshot.transform.localPosition = base.uiBehaviour.m_leftDummyPos;
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.m_leftSnapshot);
			XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(XSingleton<XAttributeMgr>.singleton.XPlayerData.PresentID);
			bool flag = byPresentID != null && byPresentID.AvatarPos != null;
			if (flag)
			{
				int num = XSingleton<XCommon>.singleton.RandomInt(0, byPresentID.AvatarPos.Length);
				XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(byPresentID.AvatarPos[num]);
			}
		}

		private bool _OnBtnAcceptTaskClicked(IXUIButton btn)
		{
			bool flag = !base.IsLoaded();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_RelativeTask == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					RpcC2G_TaskOperate rpcC2G_TaskOperate = new RpcC2G_TaskOperate();
					rpcC2G_TaskOperate.oArg.taskID = (int)this.m_RelativeTask.ID;
					rpcC2G_TaskOperate.oArg.taskOP = 1;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TaskOperate);
					XSingleton<XOperationRecord>.singleton.DoScriptRecord("accepttask+" + this.m_RelativeTask.ID);
					this.SetVisible(false, true);
					result = true;
				}
			}
			return result;
		}

		private bool _OnBtnRejectTaskClicked(IXUIButton btn)
		{
			bool flag = !base.IsLoaded();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.SetVisible(false, true);
				result = true;
			}
			return result;
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				bool bBlockClose = this.doc.bBlockClose;
				if (!bBlockClose)
				{
					this.SetVisible(false, true);
				}
			}
		}

		public void SetupOperate(XDramaOperateParam param)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				this._TogglePage(DramaPage.DP_OPERATE);
				bool flag2 = param.Npc != null;
				if (flag2)
				{
					this.m_npc = param.Npc;
					this.m_npcAttr = (this.m_npc.Attributes as XNpcAttributes);
					this.SetupTalkerName(this.m_npcAttr.Name);
					this.m_npc.ShowUp(null);
					this.SetupNPCAvatar(this.m_npcAttr.PresentID, true);
				}
				bool flag3 = param.Text != null;
				if (flag3)
				{
					base.uiBehaviour.m_OperateText.SetText(param.Text);
				}
				bool flag4 = param.ButtonCount > 0;
				if (flag4)
				{
					base.uiBehaviour.m_OperateBtnPanel.SetActive(true);
					int i = 0;
					while (i < param.ButtonCount && i < base.uiBehaviour.MAX_OPERATE_BTN_COUNT)
					{
						XDramaOperateButton xdramaOperateButton = param.Buttons[i];
						DramaDlgBehaviour.OperateButton operateButton = base.uiBehaviour.m_OperateBtns[i];
						operateButton.SetActive(true);
						operateButton.SetButton(xdramaOperateButton.Name, xdramaOperateButton.RID, xdramaOperateButton.ClickEvent, xdramaOperateButton.StateEnable);
						operateButton.SetLeftTime(xdramaOperateButton.TargetTime - Time.realtimeSinceStartup, xdramaOperateButton.TimeNote);
						i++;
					}
					while (i < base.uiBehaviour.MAX_OPERATE_BTN_COUNT)
					{
						base.uiBehaviour.m_OperateBtns[i].SetActive(false);
						i++;
					}
				}
				else
				{
					base.uiBehaviour.m_OperateBtnPanel.SetActive(false);
				}
				bool flag5 = param.ListCount > 0;
				if (flag5)
				{
					base.uiBehaviour.m_OperateListPanel.SetActive(true);
					int j = 0;
					while (j < param.ListCount && j < base.uiBehaviour.MAX_OPERATE_LIST_COUNT)
					{
						XDramaOperateList xdramaOperateList = param.Lists[j];
						DramaDlgBehaviour.OperateList operateList = base.uiBehaviour.m_OperateLists[j];
						operateList.SetActive(true);
						SpriteClickEventHandler spriteClickEventHandler = new SpriteClickEventHandler(xdramaOperateList.ClickEvent.Invoke);
						spriteClickEventHandler = (SpriteClickEventHandler)Delegate.Combine(spriteClickEventHandler, new SpriteClickEventHandler(this._OnOperateListClicked));
						operateList.SetList(xdramaOperateList.Name, xdramaOperateList.RID, spriteClickEventHandler);
						operateList.SetLeftTime(xdramaOperateList.TargetTime - Time.realtimeSinceStartup, xdramaOperateList.TimeNote);
						this._ToggleOperateListSelection(j, false);
						j++;
					}
					while (j < base.uiBehaviour.MAX_OPERATE_LIST_COUNT)
					{
						base.uiBehaviour.m_OperateLists[j].SetActive(false);
						j++;
					}
				}
				else
				{
					base.uiBehaviour.m_OperateListPanel.SetActive(false);
				}
			}
		}

		private void _OnOperateListClicked(IXUISprite iSp)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				this._SelectOperateList((int)iSp.ID);
			}
		}

		private void _ToggleOperateListSelection(int index, bool bSelect)
		{
			base.uiBehaviour.m_OperateLists[index].SetSelect(bSelect);
		}

		private void _SelectOperateList(int index)
		{
			for (int i = 0; i < base.uiBehaviour.MAX_OPERATE_LIST_COUNT; i++)
			{
				this._ToggleOperateListSelection(i, index == i);
			}
		}

		public void SetUpFavorParam(XFavorParam param)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				this._TogglePage(DramaPage.DP_FAVOR);
				bool flag2 = param.Npc != null;
				if (flag2)
				{
					this.m_npc = param.Npc;
					this.m_npcAttr = (this.m_npc.Attributes as XNpcAttributes);
					this.SetupTalkerName(this.m_npcAttr.Name);
					this.m_npc.ShowUp(null);
					this.SetupNPCAvatar(this.m_npcAttr.PresentID, true);
				}
				bool flag3 = param.Text != null;
				if (flag3)
				{
					base.uiBehaviour.m_FavorText.SetText(param.Text);
				}
				base.uiBehaviour.m_SendBtn.gameObject.SetActive(param.isShowSend);
				base.uiBehaviour.m_SendBtn.RegisterClickEventHandler(param.sendCallback);
				base.uiBehaviour.m_ExchangeBtn.gameObject.SetActive(param.isShowExchange);
				base.uiBehaviour.m_ExchangeBtn.RegisterClickEventHandler(param.exchangeCallback);
				base.uiBehaviour.m_ExchangeRedPoint.SetActive(param.isShowExchangeRedpoint);
				base.uiBehaviour.m_FavorBtnList.Refresh();
			}
		}

		public void NtfSendDramaRefresh()
		{
			bool flag = this.sendHandler.IsVisible();
			if (flag)
			{
				this.sendHandler.RefreshData();
			}
		}

		public void NtfExchangeDramaRefresh()
		{
			bool flag = this.exchangeHandler.IsVisible();
			if (flag)
			{
				this.exchangeHandler.RefreshData();
			}
		}

		public void NtfExchangeDlgClose()
		{
			bool flag = this.exchangeHandler.IsVisible();
			if (flag)
			{
				this.exchangeHandler.SetVisible(false);
			}
		}

		public void ShowNPCFavorSend()
		{
			bool flag = this.exchangeHandler.IsVisible();
			if (flag)
			{
				this.exchangeHandler.SetVisible(false);
			}
			this.sendHandler.SetVisible(true);
		}

		public void ShowNPCFavorExchnage()
		{
			bool flag = this.sendHandler.IsVisible();
			if (flag)
			{
				this.sendHandler.SetVisible(false);
			}
			this.exchangeHandler.SetVisible(true);
		}

		public bool IsSendDilogVisible()
		{
			return this.sendHandler != null && this.sendHandler.IsVisible();
		}

		public bool IsChangeDialogVisible()
		{
			return this.exchangeHandler != null && this.exchangeHandler.IsVisible();
		}

		public XNpc m_npc;

		protected XNpcAttributes m_npcAttr;

		public Queue<XDialogSentence> m_DialogQueue = new Queue<XDialogSentence>();

		private XDummy m_npcDummy;

		private XTaskDocument taskDoc;

		private XTaskInfo m_RelativeTask;

		private uint m_RelativeTaskID;

		private XDramaDocument doc;

		private XNPCFavorDramaSend sendHandler = null;

		private XNPCFavorDramaExchange exchangeHandler = null;
	}
}
