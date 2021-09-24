using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSkillTreeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSkillTreeDocument.uuID;
			}
		}

		public XDummy Dummy { get; set; }

		public static int SkillSlotCount
		{
			get
			{
				return 11;
			}
		}

		public XPlayer Player { get; set; }

		public uint CurrentSkillID { get; set; }

		public int TotalSkillPoint { get; set; }

		public int TotalAwakeSkillPoint { get; set; }

		public bool RedPoint { get; set; }

		public bool IsAwakeSkillSlotOpen
		{
			get
			{
				return 1 == XSingleton<XGlobalConfig>.singleton.GetInt("AwakeSkillSlotOpen");
			}
		}

		public bool IsSelfAwaked
		{
			get
			{
				return XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID / 1000U > 0U;
			}
		}

		public static int AwakeSkillSlot
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSkillSlot>.ToInt(XSkillSlot.Awake_Attack);
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.NewSkillDic.Clear();
			this.GetSlotUnLockLevel();
			this.GetSkillInfo();
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSkillTreeDocument.AsyncLoader.AddTask("Table/SkillTreeConfig", XSkillTreeDocument._skillTreeConfig, false);
			XSkillTreeDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.SkillPlayFinished));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.SkillPointChanged));
			base.RegisterEvent(XEventDefine.XEvent_TaskStateChange, new XComponent.XEventHandler(this.IsTurnProTaskFinish));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

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

		private void GetSlotUnLockLevel()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SkillSlotUnlockLevel").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				this._slot_unlock_level.Add(uint.Parse(array[i]));
			}
		}

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

		public void SendResetSkill()
		{
			RpcC2G_ResetSkill rpcC2G_ResetSkill = new RpcC2G_ResetSkill();
			rpcC2G_ResetSkill.oArg.resetType = ResetType.RESET_SKILL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ResetSkill);
		}

		public void SendSkillLevelup()
		{
			RpcC2G_SkillLevelup rpcC2G_SkillLevelup = new RpcC2G_SkillLevelup();
			rpcC2G_SkillLevelup.oArg.skillHash = this.CurrentSkillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SkillLevelup);
		}

		public void SendResetProf()
		{
			RpcC2G_ResetSkill rpcC2G_ResetSkill = new RpcC2G_ResetSkill();
			rpcC2G_ResetSkill.oArg.resetType = ResetType.RESET_PROFESSION;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ResetSkill);
		}

		public void SendBindSkill(uint skillID, uint slot)
		{
			RpcC2G_BindSkill rpcC2G_BindSkill = new RpcC2G_BindSkill();
			rpcC2G_BindSkill.oArg.skillhash = skillID;
			rpcC2G_BindSkill.oArg.slot = (int)slot;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_BindSkill);
		}

		public void QuerySwitchSkillPage()
		{
			RpcC2G_ChangeSkillSet rpcC2G_ChangeSkillSet = new RpcC2G_ChangeSkillSet();
			rpcC2G_ChangeSkillSet.oArg.index = 1U - XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeSkillSet);
		}

		public void OnSwitchSkillPageSuccess(uint index, SkillRecord data)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SwitchSkillPageSuccess"), "fece00");
			XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillPageIndex = index;
			XSingleton<XAttributeMgr>.singleton.XPlayerData.skillSlot = ((index == 0U) ? data.SkillSlot.ToArray() : data.SkillSlotTwo.ToArray());
			XSingleton<XAttributeMgr>.singleton.XPlayerData.SkillLevelInfo.Init((index == 0U) ? data.Skills : data.SkillsTwo);
			this.CalSkillPointTotalCount();
			this.SkillRefresh(false, true);
		}

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

		public static bool IsAvengerTaskDone(int prof)
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			uint avengerTaskID = XSkillTreeDocument.GetAvengerTaskID(prof);
			return specificDocument.TaskRecord.IsTaskFinished(avengerTaskID);
		}

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

		private bool OnPlayerLevelChange(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

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

		public bool CheckLevelUpButton()
		{
			return this.CheckLevelUpButton(this.CurrentSkillID);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.SkillRefresh(false, true);
		}

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

		public void DelDummy()
		{
			bool flag = this.Dummy != null;
			if (flag)
			{
				XSingleton<XSkillPreViewMgr>.singleton.SkillShowEnd(this.Dummy);
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this.Dummy);
			}
		}

		public void SetSkillPreviewTexture(RenderTexture rt)
		{
			this.skillPreView = rt;
			bool flag = this.BlackHouseCamera != null;
			if (flag)
			{
				this.BlackHouseCamera.targetTexture = rt;
			}
		}

		public void CreateAndPlayFxFxFirework()
		{
			bool flag = DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.CreateAndPlayFxFxFirework();
			}
		}

		public bool IsExSkill(SkillList.RowData data)
		{
			return XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(XSingleton<XCommon>.singleton.XHash(data.SkillScript), 0U) > 0U;
		}

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

		public bool IsPassiveSkill(uint skillHash)
		{
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillHash, 0U);
			return skillConfig != null && skillConfig.SkillType == 5;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SkillTreeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static SkillTreeConfigTable _skillTreeConfig = new SkillTreeConfigTable();

		public Camera BlackHouseCamera;

		public GameObject BlackHouse;

		public readonly uint UNSELECT = 0U;

		public Dictionary<uint, bool> NewSkillDic = new Dictionary<uint, bool>();

		private List<uint> _slot_unlock_level = new List<uint>();

		public List<uint> TransferLimit = new List<uint>();

		public readonly int TRANSFERNUM = 4;

		private RenderTexture skillPreView;

		public List<int> TurnProTaskIDList = new List<int>();

		public List<int> NpcID = new List<int>();

		public int SkillPageOpenLevel;
	}
}
