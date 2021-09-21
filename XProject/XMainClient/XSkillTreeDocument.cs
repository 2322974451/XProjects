using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009DB RID: 2523
	internal class XSkillTreeDocument : XDocComponent
	{
		// Token: 0x17002DE0 RID: 11744
		// (get) Token: 0x06009998 RID: 39320 RVA: 0x00180920 File Offset: 0x0017EB20
		public override uint ID
		{
			get
			{
				return XSkillTreeDocument.uuID;
			}
		}

		// Token: 0x17002DE1 RID: 11745
		// (get) Token: 0x06009999 RID: 39321 RVA: 0x00180937 File Offset: 0x0017EB37
		// (set) Token: 0x0600999A RID: 39322 RVA: 0x0018093F File Offset: 0x0017EB3F
		public XDummy Dummy { get; set; }

		// Token: 0x17002DE2 RID: 11746
		// (get) Token: 0x0600999B RID: 39323 RVA: 0x00180948 File Offset: 0x0017EB48
		public static int SkillSlotCount
		{
			get
			{
				return 11;
			}
		}

		// Token: 0x17002DE3 RID: 11747
		// (get) Token: 0x0600999C RID: 39324 RVA: 0x0018095C File Offset: 0x0017EB5C
		// (set) Token: 0x0600999D RID: 39325 RVA: 0x00180964 File Offset: 0x0017EB64
		public XPlayer Player { get; set; }

		// Token: 0x17002DE4 RID: 11748
		// (get) Token: 0x0600999E RID: 39326 RVA: 0x0018096D File Offset: 0x0017EB6D
		// (set) Token: 0x0600999F RID: 39327 RVA: 0x00180975 File Offset: 0x0017EB75
		public uint CurrentSkillID { get; set; }

		// Token: 0x17002DE5 RID: 11749
		// (get) Token: 0x060099A0 RID: 39328 RVA: 0x0018097E File Offset: 0x0017EB7E
		// (set) Token: 0x060099A1 RID: 39329 RVA: 0x00180986 File Offset: 0x0017EB86
		public int TotalSkillPoint { get; set; }

		// Token: 0x17002DE6 RID: 11750
		// (get) Token: 0x060099A2 RID: 39330 RVA: 0x0018098F File Offset: 0x0017EB8F
		// (set) Token: 0x060099A3 RID: 39331 RVA: 0x00180997 File Offset: 0x0017EB97
		public int TotalAwakeSkillPoint { get; set; }

		// Token: 0x17002DE7 RID: 11751
		// (get) Token: 0x060099A4 RID: 39332 RVA: 0x001809A0 File Offset: 0x0017EBA0
		// (set) Token: 0x060099A5 RID: 39333 RVA: 0x001809A8 File Offset: 0x0017EBA8
		public bool RedPoint { get; set; }

		// Token: 0x17002DE8 RID: 11752
		// (get) Token: 0x060099A6 RID: 39334 RVA: 0x001809B4 File Offset: 0x0017EBB4
		public bool IsAwakeSkillSlotOpen
		{
			get
			{
				return 1 == XSingleton<XGlobalConfig>.singleton.GetInt("AwakeSkillSlotOpen");
			}
		}

		// Token: 0x17002DE9 RID: 11753
		// (get) Token: 0x060099A7 RID: 39335 RVA: 0x001809D8 File Offset: 0x0017EBD8
		public bool IsSelfAwaked
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID / 1000U > 0U;
			}
		}

		// Token: 0x17002DEA RID: 11754
		// (get) Token: 0x060099A8 RID: 39336 RVA: 0x00180A04 File Offset: 0x0017EC04
		public static int AwakeSkillSlot
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSkillSlot>.ToInt(XSkillSlot.Awake_Attack);
			}
		}

		// Token: 0x060099A9 RID: 39337 RVA: 0x00180A1D File Offset: 0x0017EC1D
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.NewSkillDic.Clear();
			this.GetSlotUnLockLevel();
			this.GetSkillInfo();
		}

		// Token: 0x060099AA RID: 39338 RVA: 0x00180A42 File Offset: 0x0017EC42
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSkillTreeDocument.AsyncLoader.AddTask("Table/SkillTreeConfig", XSkillTreeDocument._skillTreeConfig, false);
			XSkillTreeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060099AB RID: 39339 RVA: 0x00180A68 File Offset: 0x0017EC68
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.SkillPlayFinished));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.SkillPointChanged));
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.IsTurnProTaskFinish));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x060099AC RID: 39340 RVA: 0x00180AD8 File Offset: 0x0017ECD8
		public override void OnEnterSceneFinally()
		{
			base.OnEnterScene();
			this.Player = XSingleton<XEntityMgr>.singleton.Player;
			uint sceneID = XSingleton<XScene>.singleton.SceneID;
			this.Dummy = null;
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.CalSkillPointTotalCount();
				this.RefreshRedPoint();
			}
		}

		// Token: 0x060099AD RID: 39341 RVA: 0x00180B38 File Offset: 0x0017ED38
		private void GetSlotUnLockLevel()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SkillSlotUnlockLevel").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				this._slot_unlock_level.Add(uint.Parse(array[i]));
			}
		}

		// Token: 0x060099AE RID: 39342 RVA: 0x00180B88 File Offset: 0x0017ED88
		private void GetSkillInfo()
		{
			this.TransferLimit.Add(0U);
			for (int i = 1; i < this.TRANSFERNUM; i++)
			{
				this.TransferLimit.Add((uint)XSingleton<XGlobalConfig>.singleton.GetInt(string.Format("Promote{0}", i)));
			}
			this.TurnProTaskIDList = XSingleton<XGlobalConfig>.singleton.GetIntList("ChangeProTaskIds");
			this.NpcID = XSingleton<XGlobalConfig>.singleton.GetIntList("ChangeProNpc");
			this.SkillPageOpenLevel = XSingleton<XGlobalConfig>.singleton.GetInt("SkillPageNewOpen");
		}

		// Token: 0x060099AF RID: 39343 RVA: 0x00180C20 File Offset: 0x0017EE20
		public uint GetSkillSlotUnLockLevel(int slotid)
		{
			bool flag = slotid >= this._slot_unlock_level.Count;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = this._slot_unlock_level[slotid];
			}
			return result;
		}

		// Token: 0x060099B0 RID: 39344 RVA: 0x00180C58 File Offset: 0x0017EE58
		public SkillTypeEnum GetSkillSlotType(int slotid)
		{
			bool flag = (2 <= slotid && 6 >= slotid) || 10 == slotid;
			SkillTypeEnum result;
			if (flag)
			{
				result = SkillTypeEnum.Skill_Normal;
			}
			else
			{
				bool flag2 = 9 == slotid;
				if (flag2)
				{
					result = SkillTypeEnum.Skill_Big;
				}
				else
				{
					bool flag3 = 7 <= slotid && 8 >= slotid;
					if (flag3)
					{
						result = SkillTypeEnum.Skill_Buff;
					}
					else
					{
						result = SkillTypeEnum.Skill_None;
					}
				}
			}
			return result;
		}

		// Token: 0x060099B1 RID: 39345 RVA: 0x00180CB0 File Offset: 0x0017EEB0
		public void SetNewSkillDic()
		{
			int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			int num2 = num % 10;
			int num3 = (num > 10) ? (num % 100) : 0;
			int num4 = (num > 100) ? (num % 1000) : 0;
			bool flag = num2 > 0;
			if (flag)
			{
				List<uint> profSkillID = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num2);
				for (int i = 0; i < profSkillID.Count; i++)
				{
					uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID[i]);
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID[i], skillOriginalLevel);
					bool flag2 = this.CheckRedPoint(profSkillID[i]);
					if (flag2)
					{
						bool flag3 = !this.NewSkillDic.ContainsKey(profSkillID[i]);
						if (flag3)
						{
							this.NewSkillDic.Add(profSkillID[i], false);
						}
					}
					bool flag4 = this.CheckNew(profSkillID[i]);
					if (flag4)
					{
						bool flag5 = !this.NewSkillDic.ContainsKey(profSkillID[i]);
						if (flag5)
						{
							this.NewSkillDic.Add(profSkillID[i], false);
						}
					}
				}
			}
			bool flag6 = num3 > 0;
			if (flag6)
			{
				List<uint> profSkillID2 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num3);
				for (int j = 0; j < profSkillID2.Count; j++)
				{
					uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID2[j]);
					SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID2[j], skillOriginalLevel2);
					bool flag7 = this.CheckRedPoint(profSkillID2[j]);
					if (flag7)
					{
						bool flag8 = !this.NewSkillDic.ContainsKey(profSkillID2[j]);
						if (flag8)
						{
							this.NewSkillDic.Add(profSkillID2[j], false);
						}
					}
					bool flag9 = this.CheckNew(profSkillID2[j]);
					if (flag9)
					{
						bool flag10 = !this.NewSkillDic.ContainsKey(profSkillID2[j]);
						if (flag10)
						{
							this.NewSkillDic.Add(profSkillID2[j], false);
						}
					}
				}
			}
			bool flag11 = num4 > 0;
			if (flag11)
			{
				List<uint> profSkillID3 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num4);
				for (int k = 0; k < profSkillID3.Count; k++)
				{
					uint skillOriginalLevel3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID3[k]);
					SkillList.RowData skillConfig3 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID3[k], skillOriginalLevel3);
					bool flag12 = this.CheckRedPoint(profSkillID3[k]);
					if (flag12)
					{
						bool flag13 = !this.NewSkillDic.ContainsKey(profSkillID3[k]);
						if (flag13)
						{
							this.NewSkillDic.Add(profSkillID3[k], false);
						}
					}
					bool flag14 = this.CheckNew(profSkillID3[k]);
					if (flag14)
					{
						bool flag15 = !this.NewSkillDic.ContainsKey(profSkillID3[k]);
						if (flag15)
						{
							this.NewSkillDic.Add(profSkillID3[k], false);
						}
					}
				}
			}
		}

		// Token: 0x060099B2 RID: 39346 RVA: 0x00181020 File Offset: 0x0017F220
		public bool CanSkillLevelUp(uint skillID, uint skillLevel, int addLevel = 0)
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, 0U);
			bool flag = skillLevel != 0U && XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(skillID, 0U) > 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				SkillLevelupRequest levelupRequest = XSingleton<XSkillEffectMgr>.singleton.GetLevelupRequest(skillID, skillLevel + (uint)addLevel);
				bool flag2 = (ulong)skillLevel >= (ulong)((long)XSingleton<XSkillEffectMgr>.singleton.GetSkillMaxLevel(skillID, 0U));
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)levelupRequest.Level);
					result = !flag3;
				}
			}
			return result;
		}

		// Token: 0x060099B3 RID: 39347 RVA: 0x001810B0 File Offset: 0x0017F2B0
		public bool SkillIsEquip(uint skillID)
		{
			uint num = skillID;
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, 0U);
			bool flag = skillConfig.ExSkillScript != "" && XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID) > 0U;
			if (flag)
			{
				num = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.ExSkillScript, 0U);
			}
			for (int i = 0; i < XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot.Length; i++)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[i] == skillID || XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[i] == num;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060099B4 RID: 39348 RVA: 0x00181174 File Offset: 0x0017F374
		public void SendResetSkill()
		{
			RpcC2G_ResetSkill rpcC2G_ResetSkill = new RpcC2G_ResetSkill();
			rpcC2G_ResetSkill.oArg.resetType = ResetType.RESET_SKILL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ResetSkill);
		}

		// Token: 0x060099B5 RID: 39349 RVA: 0x001811A4 File Offset: 0x0017F3A4
		public void SendSkillLevelup()
		{
			RpcC2G_SkillLevelup rpcC2G_SkillLevelup = new RpcC2G_SkillLevelup();
			rpcC2G_SkillLevelup.oArg.skillHash = this.CurrentSkillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SkillLevelup);
		}

		// Token: 0x060099B6 RID: 39350 RVA: 0x001811D8 File Offset: 0x0017F3D8
		public void SendResetProf()
		{
			RpcC2G_ResetSkill rpcC2G_ResetSkill = new RpcC2G_ResetSkill();
			rpcC2G_ResetSkill.oArg.resetType = ResetType.RESET_PROFESSION;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ResetSkill);
		}

		// Token: 0x060099B7 RID: 39351 RVA: 0x00181208 File Offset: 0x0017F408
		public void SendBindSkill(uint skillID, uint slot)
		{
			RpcC2G_BindSkill rpcC2G_BindSkill = new RpcC2G_BindSkill();
			rpcC2G_BindSkill.oArg.skillhash = skillID;
			rpcC2G_BindSkill.oArg.slot = (int)slot;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BindSkill);
		}

		// Token: 0x060099B8 RID: 39352 RVA: 0x00181244 File Offset: 0x0017F444
		public void QuerySwitchSkillPage()
		{
			RpcC2G_ChangeSkillSet rpcC2G_ChangeSkillSet = new RpcC2G_ChangeSkillSet();
			rpcC2G_ChangeSkillSet.oArg.index = 1U - XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeSkillSet);
		}

		// Token: 0x060099B9 RID: 39353 RVA: 0x00181284 File Offset: 0x0017F484
		public void OnSwitchSkillPageSuccess(uint index, SkillRecord data)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SwitchSkillPageSuccess"), "fece00");
			XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex = index;
			XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot = ((index == 0U) ? data.SkillSlot.ToArray() : data.SkillSlotTwo.ToArray());
			XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.Init((index == 0U) ? data.Skills : data.SkillsTwo);
			this.CalSkillPointTotalCount();
			this.SkillRefresh(false, true);
		}

		// Token: 0x060099BA RID: 39354 RVA: 0x00181320 File Offset: 0x0017F520
		public bool SkillPlayFinished(XEventArgs args)
		{
			bool flag = !DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.uiBehaviour.m_SkillPlayBtn.SetVisible(true);
				bool flag2 = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton._skillDlgPromoteHandler.IsVisible();
				if (flag2)
				{
					DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton._skillDlgPromoteHandler.m_PlayBtn.SetVisible(true);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060099BB RID: 39355 RVA: 0x00181388 File Offset: 0x0017F588
		public bool SkillPointChanged(XEventArgs args)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
				ItemEnum itemID = (ItemEnum)xvirtualItemChangedEventArgs.itemID;
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex == 0U;
				if (flag2)
				{
					bool flag3 = itemID != ItemEnum.SKILL_POINT && itemID != ItemEnum.AWAKE_SKILL_POINT;
					if (flag3)
					{
						return true;
					}
				}
				else
				{
					bool flag4 = itemID != ItemEnum.SKILL_POINT_TWO && itemID != ItemEnum.AWAKE_SKILL_POINT_TWO;
					if (flag4)
					{
						return true;
					}
				}
				this.RefreshRedPoint();
				this.CalSkillPointTotalCount();
				bool flag5 = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
				if (flag5)
				{
					DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.CalAllTabRedPoint();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060099BC RID: 39356 RVA: 0x0018143C File Offset: 0x0017F63C
		public bool IsTurnProTaskFinish(XEventArgs args)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XTaskStatusChangeArgs xtaskStatusChangeArgs = args as XTaskStatusChangeArgs;
				bool flag2 = xtaskStatusChangeArgs.status != TaskStatus.TaskStatus_Over;
				if (flag2)
				{
					result = false;
				}
				else
				{
					for (int i = 0; i < this.TurnProTaskIDList.Count; i++)
					{
						bool flag3 = xtaskStatusChangeArgs.id == (uint)this.TurnProTaskIDList[i];
						if (flag3)
						{
							uint num = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
							for (int j = 0; j < 5; j++)
							{
								num /= 10U;
								bool flag4 = num == 0U;
								if (flag4)
								{
									DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.LastSelectPromote = j + 1;
									bool flag5 = j + 1 == XSkillTreeView.AwakeIndex;
									if (flag5)
									{
										this.AwakeTaskFinish();
									}
									else
									{
										DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									}
									return true;
								}
							}
						}
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060099BD RID: 39357 RVA: 0x0018154C File Offset: 0x0017F74C
		private void AwakeTaskFinish()
		{
			XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/Roles/Lzg_Ty/Ty_juexing", XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, 3f, true);
			uint num = 1U;
			for (int i = 0; i < XSkillTreeView.AwakeIndex; i++)
			{
				num *= 10U;
			}
			uint key = num + XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
			ProfessionTable.RowData byProfID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(key);
			bool flag = byProfID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("ProfessionTable config not found: profID = ", key.ToString(), null, null, null, null);
			}
			else
			{
				uint awakeHair = byProfID.AwakeHair;
				XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				bool flag2 = XFashionDocument.IsTargetPart((int)awakeHair, FashionPosition.Hair);
				if (flag2)
				{
					specificDocument.CheckMutuexHair((int)awakeHair);
					RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
					rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionDisplayWear);
					rpcC2G_UseItem.oArg.itemID = awakeHair;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
				}
			}
		}

		// Token: 0x060099BE RID: 39358 RVA: 0x0018165C File Offset: 0x0017F85C
		public static bool IsAvengerTaskDone(int prof)
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			uint avengerTaskID = XSkillTreeDocument.GetAvengerTaskID(prof);
			return specificDocument.TaskRecord.IsTaskFinished(avengerTaskID);
		}

		// Token: 0x060099BF RID: 39359 RVA: 0x0018168C File Offset: 0x0017F88C
		private static uint GetAvengerTaskID(int prof)
		{
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("AvengerProTaskIds");
			bool flag = intList != null && intList.Count > 0;
			uint result;
			if (flag)
			{
				int num = 0;
				bool flag2 = prof / 100 > 0;
				if (flag2)
				{
					num = 1;
				}
				bool flag3 = prof / 1000 > 0;
				if (flag3)
				{
					num = 2;
				}
				uint num2 = (uint)((num < intList.Count) ? intList[num] : 0);
				result = num2;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x060099C0 RID: 39360 RVA: 0x00181704 File Offset: 0x0017F904
		private bool OnPlayerLevelChange(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

		// Token: 0x060099C1 RID: 39361 RVA: 0x00181720 File Offset: 0x0017F920
		public void SkillRefresh(bool resetTabs = false, bool resetPosition = true)
		{
			this.RefreshRedPoint();
			bool flag = !DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool isPromoteHandlerShow = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsPromoteHandlerShow;
				if (isPromoteHandlerShow)
				{
					DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton._skillDlgPromoteHandler.SetVisible(false);
					DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsPromoteHandlerShow = false;
				}
				if (resetTabs)
				{
					DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetupTabs();
				}
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.Refresh(DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.LastSelectPromote, resetTabs, resetPosition);
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.CalAllTabRedPoint();
			}
		}

		// Token: 0x060099C2 RID: 39362 RVA: 0x001817A8 File Offset: 0x0017F9A8
		public void OnSkillLevelUp(uint skillID)
		{
			bool flag = !DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, 0U);
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.OnSkillLevelUp((int)skillConfig.XPostion, (int)skillConfig.YPostion);
				bool flag2 = skillOriginalLevel == 1U && skillConfig.SkillType == 2;
				if (flag2)
				{
					int num = XFastEnumIntEqualityComparer<XSkillSlot>.ToInt(XSkillSlot.Ultra_Attack);
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[num] == 0U;
					if (flag3)
					{
						this.SendBindSkill(this.CurrentSkillID, (uint)num);
					}
				}
			}
		}

		// Token: 0x060099C3 RID: 39363 RVA: 0x00181854 File Offset: 0x0017FA54
		public int CheckPreSkillLevel(uint skillID)
		{
			uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillOriginalLevel);
			uint skillID2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.PreSkill, 0U);
			uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID2);
			bool flag = skillID2 == 0U;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				result = (int)skillOriginalLevel2;
			}
			return result;
		}

		// Token: 0x060099C4 RID: 39364 RVA: 0x001818C4 File Offset: 0x0017FAC4
		public bool CheckFx(uint skillID)
		{
			uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillOriginalLevel);
			uint skillID2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.PreSkill, 0U);
			uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID2);
			bool flag = skillOriginalLevel >= (uint)skillConfig.SkillLevel;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !this.CanSkillLevelUp(skillID, skillOriginalLevel, 0);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool isAwake = skillConfig.IsAwake;
					int num = (int)skillConfig.LevelupCost[(int)Math.Min((long)((ulong)skillOriginalLevel), (long)(skillConfig.LevelupCost.Length - 1))];
					bool flag3 = num > (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = skillID2 != 0U && skillOriginalLevel2 == 0U;
						if (flag4)
						{
							result = false;
						}
						else
						{
							int num2 = (isAwake ? this.TotalAwakeSkillPoint : this.TotalSkillPoint) - (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
							bool flag5 = num2 < (int)skillConfig.PreSkillPoint;
							result = !flag5;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060099C5 RID: 39365 RVA: 0x001819FC File Offset: 0x0017FBFC
		public bool CheckNew(uint skillID)
		{
			uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillOriginalLevel);
			uint skillID2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.PreSkill, 0U);
			uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID2);
			bool flag = skillOriginalLevel > 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.NewSkillDic.ContainsKey(skillID);
				if (flag2)
				{
					result = this.NewSkillDic[skillID];
				}
				else
				{
					bool flag3 = !this.CanSkillLevelUp(skillID, skillOriginalLevel, 0);
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = skillID2 != 0U && skillOriginalLevel2 == 0U;
						if (flag4)
						{
							result = false;
						}
						else
						{
							bool isAwake = skillConfig.IsAwake;
							int num = (isAwake ? this.TotalAwakeSkillPoint : this.TotalSkillPoint) - (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
							bool flag5 = num < (int)skillConfig.PreSkillPoint;
							result = !flag5;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060099C6 RID: 39366 RVA: 0x00181B0C File Offset: 0x0017FD0C
		public bool CheckLevelUpButton()
		{
			return this.CheckLevelUpButton(this.CurrentSkillID);
		}

		// Token: 0x060099C7 RID: 39367 RVA: 0x00181B2C File Offset: 0x0017FD2C
		public bool CheckLevelUpButton(uint skillID)
		{
			uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillOriginalLevel);
			uint skillID2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.PreSkill, 0U);
			uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID2);
			bool flag = !this.CanSkillLevelUp(skillID, skillOriginalLevel, 0);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool isAwake = skillConfig.IsAwake;
				int num = (int)skillConfig.LevelupCost[(int)Math.Min((long)((ulong)skillOriginalLevel), (long)(skillConfig.LevelupCost.Length - 1))];
				bool flag2 = num > (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = skillID2 != 0U && skillOriginalLevel2 == 0U;
					if (flag3)
					{
						result = false;
					}
					else
					{
						int num2 = (isAwake ? this.TotalAwakeSkillPoint : this.TotalSkillPoint) - (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
						bool flag4 = num2 < (int)skillConfig.PreSkillPoint;
						result = !flag4;
					}
				}
			}
			return result;
		}

		// Token: 0x060099C8 RID: 39368 RVA: 0x00181C4C File Offset: 0x0017FE4C
		public bool CheckRedPoint(uint skillID)
		{
			SkillTreeConfigTable.RowData byLevel = XSkillTreeDocument._skillTreeConfig.GetByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			bool flag = byLevel == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Can't find skill tree show redpoint num level config from SkillTreeConfigTable, level = ", XSingleton<XAttributeMgr>.singleton.XPlayerData.Level.ToString(), null, null, null, null);
				result = false;
			}
			else
			{
				uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID);
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, skillOriginalLevel);
				bool isAwake = skillConfig.IsAwake;
				bool flag2 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake) < (ulong)byLevel.RedPointShowNum;
				if (flag2)
				{
					result = false;
				}
				else
				{
					uint skillID2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillConfig.PreSkill, 0U);
					uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillID2);
					bool flag3 = skillOriginalLevel >= (uint)skillConfig.SkillLevel;
					if (flag3)
					{
						result = false;
					}
					else
					{
						SkillTypeEnum skillType = (SkillTypeEnum)skillConfig.SkillType;
						bool flag4 = !this.IsExSkill(skillConfig);
						if (flag4)
						{
							bool flag5 = skillOriginalLevel != 0U && (skillType == SkillTypeEnum.Skill_Normal || skillType == SkillTypeEnum.Skill_Big || skillType == SkillTypeEnum.Skill_Buff) && !this.SkillIsEquip(skillID);
							if (flag5)
							{
								return false;
							}
						}
						bool flag6 = !this.CanSkillLevelUp(skillID, skillOriginalLevel, 0);
						if (flag6)
						{
							result = false;
						}
						else
						{
							int num = (int)skillConfig.LevelupCost[(int)Math.Min((long)((ulong)skillOriginalLevel), (long)(skillConfig.LevelupCost.Length - 1))];
							bool flag7 = num > (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
							if (flag7)
							{
								result = false;
							}
							else
							{
								bool flag8 = skillID2 != 0U && skillOriginalLevel2 == 0U;
								if (flag8)
								{
									result = false;
								}
								else
								{
									int num2 = (isAwake ? this.TotalAwakeSkillPoint : this.TotalSkillPoint) - (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(isAwake);
									bool flag9 = num2 < (int)skillConfig.PreSkillPoint;
									result = !flag9;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060099C9 RID: 39369 RVA: 0x00181E54 File Offset: 0x00180054
		public void RefreshRedPoint()
		{
			int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			int num2 = num % 10;
			int num3 = (num > 10) ? (num % 100) : 0;
			int num4 = (num > 100) ? (num % 1000) : 0;
			int num5 = (num > 1000) ? (num % 10000) : 0;
			this.RedPoint = false;
			bool flag = num2 > 0;
			if (flag)
			{
				List<uint> profSkillID = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num2);
				for (int i = 0; i < profSkillID.Count; i++)
				{
					uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID[i]);
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID[i], skillOriginalLevel);
					bool flag2 = this.CheckRedPoint(profSkillID[i]);
					if (flag2)
					{
						this.RedPoint = true;
						break;
					}
				}
			}
			bool flag3 = num3 > 0 && !this.RedPoint;
			if (flag3)
			{
				List<uint> profSkillID2 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num3);
				for (int j = 0; j < profSkillID2.Count; j++)
				{
					uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID2[j]);
					SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID2[j], skillOriginalLevel2);
					bool flag4 = this.CheckRedPoint(profSkillID2[j]);
					if (flag4)
					{
						this.RedPoint = true;
						break;
					}
				}
			}
			bool flag5 = num4 > 0 && !this.RedPoint;
			if (flag5)
			{
				List<uint> profSkillID3 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num4);
				for (int k = 0; k < profSkillID3.Count; k++)
				{
					uint skillOriginalLevel3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID3[k]);
					SkillList.RowData skillConfig3 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID3[k], skillOriginalLevel3);
					bool flag6 = this.CheckRedPoint(profSkillID3[k]);
					if (flag6)
					{
						this.RedPoint = true;
						break;
					}
				}
			}
			bool flag7 = num5 > 0 && !this.RedPoint;
			if (flag7)
			{
				List<uint> profSkillID4 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num5);
				for (int l = 0; l < profSkillID4.Count; l++)
				{
					uint skillOriginalLevel4 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID4[l]);
					SkillList.RowData skillConfig4 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID4[l], skillOriginalLevel4);
					bool flag8 = this.CheckRedPoint(profSkillID4[l]);
					if (flag8)
					{
						this.RedPoint = true;
						break;
					}
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Skill, true);
		}

		// Token: 0x060099CA RID: 39370 RVA: 0x0018212C File Offset: 0x0018032C
		public void CalSkillPointTotalCount()
		{
			int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession);
			int num2 = num % 10;
			int num3 = (num > 10) ? (num % 100) : 0;
			int num4 = (num > 100) ? (num % 1000) : 0;
			int num5 = (num > 1000) ? (num % 10000) : 0;
			this.TotalSkillPoint = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(false);
			this.TotalAwakeSkillPoint = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount(true);
			bool flag = num2 > 0;
			if (flag)
			{
				List<uint> profSkillID = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num2);
				for (int i = 0; i < profSkillID.Count; i++)
				{
					uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID[i]);
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID[i], skillOriginalLevel);
					int num6 = 0;
					while ((long)num6 < (long)((ulong)skillOriginalLevel))
					{
						this.TotalSkillPoint += (int)skillConfig.LevelupCost[Math.Min(num6, skillConfig.LevelupCost.Length - 1)];
						num6++;
					}
				}
			}
			bool flag2 = num3 > 0;
			if (flag2)
			{
				List<uint> profSkillID2 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num3);
				for (int j = 0; j < profSkillID2.Count; j++)
				{
					uint skillOriginalLevel2 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID2[j]);
					SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID2[j], skillOriginalLevel2);
					int num7 = 0;
					while ((long)num7 < (long)((ulong)skillOriginalLevel2))
					{
						this.TotalSkillPoint += (int)skillConfig2.LevelupCost[Math.Min(num7, skillConfig2.LevelupCost.Length - 1)];
						num7++;
					}
				}
			}
			bool flag3 = num4 > 0;
			if (flag3)
			{
				List<uint> profSkillID3 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num4);
				for (int k = 0; k < profSkillID3.Count; k++)
				{
					uint skillOriginalLevel3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID3[k]);
					SkillList.RowData skillConfig3 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID3[k], skillOriginalLevel3);
					int num8 = 0;
					while ((long)num8 < (long)((ulong)skillOriginalLevel3))
					{
						this.TotalSkillPoint += (int)skillConfig3.LevelupCost[Math.Min(num8, skillConfig3.LevelupCost.Length - 1)];
						num8++;
					}
				}
			}
			bool flag4 = num5 > 0;
			if (flag4)
			{
				List<uint> profSkillID4 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num5);
				for (int l = 0; l < profSkillID4.Count; l++)
				{
					uint skillOriginalLevel4 = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(profSkillID4[l]);
					SkillList.RowData skillConfig4 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID4[l], skillOriginalLevel4);
					int num9 = 0;
					while ((long)num9 < (long)((ulong)skillOriginalLevel4))
					{
						bool isAwake = skillConfig4.IsAwake;
						if (isAwake)
						{
							this.TotalAwakeSkillPoint += (int)skillConfig4.LevelupCost[Math.Min(num9, skillConfig4.LevelupCost.Length - 1)];
						}
						else
						{
							this.TotalSkillPoint += (int)skillConfig4.LevelupCost[Math.Min(num9, skillConfig4.LevelupCost.Length - 1)];
						}
						num9++;
					}
				}
			}
		}

		// Token: 0x060099CB RID: 39371 RVA: 0x001824DC File Offset: 0x001806DC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.SkillRefresh(false, true);
		}

		// Token: 0x060099CC RID: 39372 RVA: 0x001824E8 File Offset: 0x001806E8
		public void CreateSkillBlackHouse()
		{
			bool flag = this.BlackHouse == null;
			if (flag)
			{
				XSingleton<XSkillPreViewMgr>.singleton.GetSkillBlackHouse(ref this.BlackHouse, ref this.BlackHouseCamera);
				this.BlackHouseCamera.enabled = false;
			}
			bool flag2 = this.Dummy == null || this.Dummy.Deprecated;
			if (flag2)
			{
				this.CreateDummy();
			}
		}

		// Token: 0x060099CD RID: 39373 RVA: 0x00182550 File Offset: 0x00180750
		private void CreateDummy()
		{
			XOutlookData outlook = XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook;
			this.Dummy = XSingleton<XEntityMgr>.singleton.CreateDummy(XSingleton<XAttributeMgr>.singleton.XPlayerData.PresentID, XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID, outlook, true, true, true);
			bool flag = this.Dummy == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Dummy Creat Fail.", null, null, null, null, null);
			}
			else
			{
				this.Dummy.OverrideAnimClip("Idle", XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle, true, false);
				XSingleton<XSkillPreViewMgr>.singleton.ResetDummyPos(this.Dummy);
			}
		}

		// Token: 0x060099CE RID: 39374 RVA: 0x00182604 File Offset: 0x00180804
		public void DelDummy()
		{
			bool flag = this.Dummy != null;
			if (flag)
			{
				XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this.Dummy);
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this.Dummy);
			}
		}

		// Token: 0x060099CF RID: 39375 RVA: 0x00182644 File Offset: 0x00180844
		public void SetSkillPreviewTexture(RenderTexture rt)
		{
			this.skillPreView = rt;
			bool flag = this.BlackHouseCamera != null;
			if (flag)
			{
				this.BlackHouseCamera.targetTexture = rt;
			}
		}

		// Token: 0x060099D0 RID: 39376 RVA: 0x00182678 File Offset: 0x00180878
		public void CreateAndPlayFxFxFirework()
		{
			bool flag = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.CreateAndPlayFxFxFirework();
			}
		}

		// Token: 0x060099D1 RID: 39377 RVA: 0x001826A0 File Offset: 0x001808A0
		public bool IsExSkill(SkillList.RowData data)
		{
			return XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(XSingleton<XCommon>.singleton.XHash(data.SkillScript), 0U) > 0U;
		}

		// Token: 0x060099D2 RID: 39378 RVA: 0x001826D0 File Offset: 0x001808D0
		public bool isTutorialNeed(int promote, int index)
		{
			int[] array = new int[]
			{
				1,
				10,
				100,
				1000
			};
			int profID = (int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % (uint)array[promote + 1]);
			List<uint> profSkillID = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(profID);
			List<SkillTreeSortItem> list = new List<SkillTreeSortItem>();
			for (int i = 0; i < profSkillID.Count; i++)
			{
				SkillTreeSortItem skillTreeSortItem = new SkillTreeSortItem();
				skillTreeSortItem.skillID = profSkillID[i];
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID[i], 0U);
				skillTreeSortItem.x = (int)skillConfig.XPostion;
				skillTreeSortItem.y = (int)skillConfig.YPostion;
				list.Add(skillTreeSortItem);
			}
			list.Sort(new Comparison<SkillTreeSortItem>(this.Compare));
			return XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(list[index - 1].skillID) == 0U;
		}

		// Token: 0x060099D3 RID: 39379 RVA: 0x001827C4 File Offset: 0x001809C4
		private int Compare(SkillTreeSortItem x, SkillTreeSortItem y)
		{
			bool flag = x.skillID == y.skillID;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = x.y != y.y;
				if (flag2)
				{
					result = y.y - x.y;
				}
				else
				{
					result = x.x - y.x;
				}
			}
			return result;
		}

		// Token: 0x060099D4 RID: 39380 RVA: 0x00182820 File Offset: 0x00180A20
		public static string GetSkillAttrStr(int element)
		{
			string @string;
			switch (element)
			{
			case 0:
				@string = XStringDefineProxy.GetString("Void");
				break;
			case 1:
				@string = XStringDefineProxy.GetString("Fire");
				break;
			case 2:
				@string = XStringDefineProxy.GetString("Water");
				break;
			case 3:
				@string = XStringDefineProxy.GetString("Light");
				break;
			case 4:
				@string = XStringDefineProxy.GetString("Dark");
				break;
			default:
				@string = XStringDefineProxy.GetString("Void");
				break;
			}
			return @string;
		}

		// Token: 0x060099D5 RID: 39381 RVA: 0x0018289C File Offset: 0x00180A9C
		public bool IsEquipThisSkill(List<string> skillNames)
		{
			for (int i = 0; i < skillNames.Count; i++)
			{
				bool flag = skillNames[i] == string.Empty;
				if (!flag)
				{
					uint skillID = XSingleton<XSkillEffectMgr>.singleton.GetSkillID(skillNames[i], 0U);
					bool flag2 = skillID > 0U;
					if (flag2)
					{
						bool flag3 = this.IsEquipThisSkill(skillID);
						if (flag3)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x060099D6 RID: 39382 RVA: 0x00182910 File Offset: 0x00180B10
		public void ShowEmblemTips(List<int> hashList)
		{
			bool flag = hashList.Count == 0;
			if (!flag)
			{
				List<SkillEmblem.RowData> skillRow = new List<SkillEmblem.RowData>();
				XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
				for (int i = 0; i < hashList.Count; i++)
				{
					uint num = XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[hashList[i]];
					bool flag2 = num > 0U;
					if (flag2)
					{
						bool flag3 = specificDocument.IsEquipThisSkillEmblem(num, ref skillRow);
						bool flag4 = flag3;
						if (flag4)
						{
							this.ShowTips(skillRow, false);
						}
					}
				}
			}
		}

		// Token: 0x060099D7 RID: 39383 RVA: 0x001829A0 File Offset: 0x00180BA0
		public void ShowEmblemTips(ulong skillHash, int slot)
		{
			bool flag = skillHash == 0UL;
			if (!flag)
			{
				uint num = XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[slot];
				bool flag2 = (ulong)num == skillHash;
				if (!flag2)
				{
					List<SkillEmblem.RowData> skillRow = new List<SkillEmblem.RowData>();
					XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
					bool flag3 = this.IsEquipThisSkill((uint)skillHash);
					bool flag4 = num == 0U && skillHash > 0UL;
					if (flag4)
					{
						bool flag5 = !flag3;
						if (flag5)
						{
							bool flag6 = specificDocument.IsEquipThisSkillEmblem((uint)skillHash, ref skillRow);
							bool flag7 = flag6;
							if (flag7)
							{
								this.ShowTips(skillRow, true);
							}
						}
					}
					else
					{
						bool flag8 = !flag3;
						if (flag8)
						{
							bool flag6 = specificDocument.IsEquipThisSkillEmblem((uint)skillHash, ref skillRow);
							bool flag9 = flag6;
							if (flag9)
							{
								this.ShowTips(skillRow, true);
							}
							flag6 = specificDocument.IsEquipThisSkillEmblem(num, ref skillRow);
							bool flag10 = flag6;
							if (flag10)
							{
								this.ShowTips(skillRow, false);
							}
						}
					}
				}
			}
		}

		// Token: 0x060099D8 RID: 39384 RVA: 0x00182A80 File Offset: 0x00180C80
		public void ShowTips(List<SkillEmblem.RowData> skillRow, bool isUp)
		{
			bool flag = skillRow.Count == 0;
			if (!flag)
			{
				for (int i = 0; i < skillRow.Count; i++)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)skillRow[i].EmblemID);
					bool flag2 = itemConf == null;
					if (flag2)
					{
						break;
					}
					if (isUp)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("Active_Emblem"), itemConf.ItemName[0], skillRow[i].SkillPPT), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("Deactive_Emblem"), itemConf.ItemName[0], skillRow[i].SkillPPT), "fece00");
					}
				}
			}
		}

		// Token: 0x060099D9 RID: 39385 RVA: 0x00182B58 File Offset: 0x00180D58
		private bool IsEquipThisSkill(uint skillHash)
		{
			bool flag = this.IsPassiveSkill(skillHash);
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				for (int i = 0; i < XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot.Length; i++)
				{
					uint num = XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot[i];
					bool flag3 = num > 0U && skillHash == num;
					if (flag3)
					{
						return true;
					}
				}
				result = false;
			}
			else
			{
				uint skillOriginalLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.GetSkillOriginalLevel(skillHash);
				bool flag4 = skillOriginalLevel > 0U;
				result = flag4;
			}
			return result;
		}

		// Token: 0x060099DA RID: 39386 RVA: 0x00182BFC File Offset: 0x00180DFC
		public bool IsPassiveSkill(uint skillHash)
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillHash, 0U);
			return skillConfig != null && skillConfig.SkillType == 5;
		}

		// Token: 0x040034C4 RID: 13508
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SkillTreeDocument");

		// Token: 0x040034C5 RID: 13509
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040034C6 RID: 13510
		private static SkillTreeConfigTable _skillTreeConfig = new SkillTreeConfigTable();

		// Token: 0x040034C8 RID: 13512
		public Camera BlackHouseCamera;

		// Token: 0x040034C9 RID: 13513
		public GameObject BlackHouse;

		// Token: 0x040034CC RID: 13516
		public readonly uint UNSELECT = 0U;

		// Token: 0x040034D0 RID: 13520
		public Dictionary<uint, bool> NewSkillDic = new Dictionary<uint, bool>();

		// Token: 0x040034D1 RID: 13521
		private List<uint> _slot_unlock_level = new List<uint>();

		// Token: 0x040034D2 RID: 13522
		public List<uint> TransferLimit = new List<uint>();

		// Token: 0x040034D3 RID: 13523
		public readonly int TRANSFERNUM = 4;

		// Token: 0x040034D4 RID: 13524
		private RenderTexture skillPreView;

		// Token: 0x040034D5 RID: 13525
		public List<int> TurnProTaskIDList = new List<int>();

		// Token: 0x040034D6 RID: 13526
		public List<int> NpcID = new List<int>();

		// Token: 0x040034D7 RID: 13527
		public int SkillPageOpenLevel;
	}
}
