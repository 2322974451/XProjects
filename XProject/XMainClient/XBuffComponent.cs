using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC2 RID: 4034
	internal class XBuffComponent : XComponent
	{
		// Token: 0x170036AD RID: 13997
		// (get) Token: 0x0600D18F RID: 53647 RVA: 0x0030ABAC File Offset: 0x00308DAC
		public override uint ID
		{
			get
			{
				return XBuffComponent.uuID;
			}
		}

		// Token: 0x170036AE RID: 13998
		// (get) Token: 0x0600D190 RID: 53648 RVA: 0x0030ABC4 File Offset: 0x00308DC4
		public List<XBuff> BuffList
		{
			get
			{
				return this._BuffList;
			}
		}

		// Token: 0x170036AF RID: 13999
		// (get) Token: 0x0600D191 RID: 53649 RVA: 0x0030ABDC File Offset: 0x00308DDC
		public List<ServerBuffInfo> ServerBuffList
		{
			get
			{
				return this._ServerBuffList;
			}
		}

		// Token: 0x170036B0 RID: 14000
		// (get) Token: 0x0600D192 RID: 53650 RVA: 0x0030ABF4 File Offset: 0x00308DF4
		public bool bDemo
		{
			get
			{
				return this._entity.IsDummy;
			}
		}

		// Token: 0x170036B1 RID: 14001
		// (get) Token: 0x0600D193 RID: 53651 RVA: 0x0030AC14 File Offset: 0x00308E14
		public bool bLeavingScene
		{
			get
			{
				return this.m_bLeavingScene;
			}
		}

		// Token: 0x170036B2 RID: 14002
		// (get) Token: 0x0600D194 RID: 53652 RVA: 0x0030AC2C File Offset: 0x00308E2C
		public bool bDestroying
		{
			get
			{
				return this.m_bDestroying;
			}
		}

		// Token: 0x0600D195 RID: 53653 RVA: 0x0030AC44 File Offset: 0x00308E44
		public static void InitConfigs()
		{
			XBuffComponent._ParseBounds(ref XBuffComponent.CAST_DAMAGE_CHANGE_LOWERBOUND, ref XBuffComponent.CAST_DAMAGE_CHANGE_UPPERBOUND, "BuffChangeCastDamageLimit");
			XBuffComponent._ParseBounds(ref XBuffComponent.RECEIVED_DAMAGE_CHANGE_LOWERBOUND, ref XBuffComponent.RECEIVED_DAMAGE_CHANGE_UPPERBOUND, "BuffChangeReceivedDamageLimit");
			XBuffComponent._ParseBounds(ref XBuffComponent.MP_COST_CHANGE_LOWERBOUND, ref XBuffComponent.MP_COST_CHANGE_UPPERBOUND, "MpCostChangeLimit");
			XBuffComponent.TransformBuffsChangeOutlook.Clear();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("TransformBuffsChangeOutlook").Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				XBuffComponent.TransformBuffsChangeOutlook.Add(int.Parse(array[i]));
			}
		}

		// Token: 0x0600D196 RID: 53654 RVA: 0x0030ACE0 File Offset: 0x00308EE0
		private static void _ParseBounds(ref double lowerBound, ref double upperBound, string key)
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue(key).Split(XGlobalConfig.SequenceSeparator);
			bool flag = array.Length != 2;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(key, " format error: ", XSingleton<XGlobalConfig>.singleton.GetValue("key"), null, null, null);
			}
			else
			{
				lowerBound = double.Parse(array[0]) - 1.0;
				upperBound = double.Parse(array[1]) - 1.0;
			}
		}

		// Token: 0x0600D197 RID: 53655 RVA: 0x0030AD60 File Offset: 0x00308F60
		public override void Attached()
		{
			bool flag = !XSingleton<XGame>.singleton.SyncMode && this._entity.Attributes != null;
			if (flag)
			{
				int i = 0;
				int count = this._entity.Attributes.InBornBuff.Count;
				while (i < count)
				{
					int buffID = this._entity.Attributes.InBornBuff[i, 0];
					int buffLevel = this._entity.Attributes.InBornBuff[i, 1];
					XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
					@event.Firer = this._entity;
					@event.xBuffDesc.BuffID = buffID;
					@event.xBuffDesc.BuffLevel = buffLevel;
					@event.xBuffDesc.CasterID = this._entity.ID;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					i++;
				}
				this._entity.Attributes.SkillLevelInfo.CaskAuraSkills(this._entity);
			}
			this.m_bLeavingScene = false;
			this.m_bDestroying = false;
		}

		// Token: 0x0600D198 RID: 53656 RVA: 0x0030AE80 File Offset: 0x00309080
		public bool IsBuffStateOn(XBuffType type)
		{
			bool flag = this._entity.Attributes == null;
			return !flag && this._entity.Attributes.BuffState.IsBuffStateOn(type);
		}

		// Token: 0x0600D199 RID: 53657 RVA: 0x0030AEC0 File Offset: 0x003090C0
		public short GetBuffStateCounter(XBuffType type)
		{
			bool flag = this._entity.Attributes == null;
			short result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = this._entity.Attributes.BuffState.GetBuffStateCounter(type);
			}
			return result;
		}

		// Token: 0x0600D19A RID: 53658 RVA: 0x0030AF00 File Offset: 0x00309100
		public void IncBuffState(XBuffType type, int param)
		{
			bool flag = this._entity.Attributes == null;
			if (!flag)
			{
				this._entity.Attributes.BuffState.IncBuffState(type, param);
			}
		}

		// Token: 0x0600D19B RID: 53659 RVA: 0x0030AF3C File Offset: 0x0030913C
		public void DecBuffState(XBuffType type, int param)
		{
			bool flag = this._entity.Attributes == null;
			if (!flag)
			{
				this._entity.Attributes.BuffState.DecBuffState(type, param);
			}
		}

		// Token: 0x0600D19C RID: 53660 RVA: 0x0030AF78 File Offset: 0x00309178
		public int GetStateParam(XBuffType type)
		{
			bool flag = this._entity.Attributes == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = this._entity.Attributes.BuffState.GetStateParam(type);
			}
			return result;
		}

		// Token: 0x0600D19D RID: 53661 RVA: 0x0030AFB8 File Offset: 0x003091B8
		public void ClearBuff()
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool valid = xbuff.Valid;
				if (valid)
				{
					this._RemoveBuff(xbuff, false);
				}
			}
			bool flag = this.m_bLeavingScene || this.m_bDestroying;
			if (flag)
			{
				for (int j = this._ServerBuffList.Count - 1; j >= 0; j--)
				{
					ServerBuffInfo buff = this._ServerBuffList[j];
					this._ServerBuffList.RemoveAt(j);
					this._RemoveBuff(buff, null);
				}
			}
			this._BuffList.Clear();
			this._AddBuffQueue.Clear();
			this._AddBuffQueue2.Clear();
			this._ServerBuffList.Clear();
			this._RefreshQueueImm();
			bool flag2 = this._entity.Attributes != null;
			if (flag2)
			{
				bool flag3 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag3)
				{
					this._entity.Attributes.BuffState.CheckBuffState();
				}
				this._entity.Attributes.BuffState.Reset();
			}
		}

		// Token: 0x0600D19E RID: 53662 RVA: 0x0030B0F8 File Offset: 0x003092F8
		public void OnHurt(HurtInfo rawInput, ProjectDamageResult result)
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool flag = !xbuff.Valid;
				if (!flag)
				{
					xbuff.OnBuffEffect(rawInput, result, new XBuff.BuffEffectDelegate(XBuff.OnHurt));
				}
			}
		}

		// Token: 0x0600D19F RID: 53663 RVA: 0x0030B154 File Offset: 0x00309354
		public void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool flag = !xbuff.Valid;
				if (!flag)
				{
					xbuff.OnBuffEffect(rawInput, result, new XBuff.BuffEffectDelegate(XBuff.OnCastDamage));
				}
			}
		}

		// Token: 0x0600D1A0 RID: 53664 RVA: 0x0030B1B0 File Offset: 0x003093B0
		public void OnCastSkill(HurtInfo rawInput)
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool flag = !xbuff.Valid;
				if (!flag)
				{
					xbuff.OnCastSkill(rawInput);
				}
			}
		}

		// Token: 0x0600D1A1 RID: 53665 RVA: 0x0030B200 File Offset: 0x00309400
		public void MakeSingleEffect(XBuff buff)
		{
			bool flag = buff == null;
			if (!flag)
			{
				for (int i = 0; i < this._BuffList.Count; i++)
				{
					XBuff xbuff = this._BuffList[i];
					bool flag2 = !xbuff.Valid || xbuff == buff;
					if (!flag2)
					{
						bool flag3 = xbuff.ExclusiveData.IsSingleEffectConflict(buff.ExclusiveData);
						if (flag3)
						{
							this._RemoveBuff(xbuff, false);
						}
					}
				}
			}
		}

		// Token: 0x0600D1A2 RID: 53666 RVA: 0x0030B27C File Offset: 0x0030947C
		protected void _CheckRelatedBuffs(BuffTable.RowData rowData, out bool bCanAdd, List<XBuff> buffsShouldRemove)
		{
			bCanAdd = true;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool flag = !xbuff.Valid;
				if (!flag)
				{
					bool flag2 = !xbuff.ExclusiveData.CanAdd(rowData.BuffClearType);
					if (flag2)
					{
						bCanAdd = false;
						break;
					}
				}
			}
		}

		// Token: 0x0600D1A3 RID: 53667 RVA: 0x0030B2EC File Offset: 0x003094EC
		private bool _PreAddBuff(BuffTable.RowData rowData)
		{
			List<XBuff> list = ListPool<XBuff>.Get();
			bool flag;
			this._CheckRelatedBuffs(rowData, out flag, list);
			bool flag2 = !flag;
			bool result;
			if (flag2)
			{
				ListPool<XBuff>.Release(list);
				result = false;
			}
			else
			{
				bool flag3 = list.Count != 0;
				if (flag3)
				{
					for (int i = 0; i < list.Count; i++)
					{
						this._RemoveBuff(list[i], false);
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600D1A4 RID: 53668 RVA: 0x0030B364 File Offset: 0x00309564
		private void _PostAddBuff(XBuff newBuff)
		{
			bool flag = newBuff == null;
			if (!flag)
			{
				for (int i = 0; i < this._BuffList.Count; i++)
				{
					XBuff xbuff = this._BuffList[i];
					bool flag2 = !xbuff.Valid || xbuff == newBuff;
					if (!flag2)
					{
						bool flag3 = !newBuff.ExclusiveData.ShouldClear(xbuff.ClearType);
						if (flag3)
						{
							this._RemoveBuff(xbuff, false);
						}
					}
				}
			}
		}

		// Token: 0x0600D1A5 RID: 53669 RVA: 0x0030B3E8 File Offset: 0x003095E8
		private void _AddBuff(BuffDesc buffDesc)
		{
			BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(buffDesc.BuffID, buffDesc.BuffLevel);
			bool flag = buffData == null;
			if (!flag)
			{
				bool flag2 = !this._PreAddBuff(buffData);
				if (!flag2)
				{
					bool flag3 = buffDesc.CasterID == 0UL;
					if (flag3)
					{
						buffDesc.CasterID = this._entity.ID;
					}
					CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
					data.Set(buffData, buffDesc.CasterID, this._entity);
					XBuff xbuff = XSingleton<XBuffTemplateManager>.singleton.CreateBuff(buffDesc, data);
					bool flag4 = xbuff == null;
					if (flag4)
					{
						data.Recycle();
					}
					else
					{
						xbuff.CasterID = buffDesc.CasterID;
						xbuff.OnAdd(this, data);
						this._PostAddBuff(xbuff);
						this._BuffList.Add(xbuff);
						this._SendAIEvent(xbuff);
						this._AddBuffNotifyDoc(xbuff.UIBuff);
						this._PlayBuffFx(xbuff.ID, xbuff.Level, xbuff.Duration);
						data.Recycle();
					}
				}
			}
		}

		// Token: 0x0600D1A6 RID: 53670 RVA: 0x0030B4EC File Offset: 0x003096EC
		private void _AppendBuff(XBuff oldBuff)
		{
			CombatEffectHelper data = XDataPool<CombatEffectHelper>.GetData();
			data.Set(oldBuff.BuffInfo, oldBuff.CasterID, this._entity);
			oldBuff.Append(this, data);
			this._UpdateBuffNotifyDoc(oldBuff.UIBuff);
			data.Recycle();
			oldBuff.OnAppend(this);
		}

		// Token: 0x0600D1A7 RID: 53671 RVA: 0x0030B540 File Offset: 0x00309740
		private void _RemoveBuff(XBuff buff, bool bIsReplaced)
		{
			UIBuffInfo uibuff = buff.UIBuff;
			this._StopBuffFx(buff.ID);
			buff.OnRemove(this, bIsReplaced);
			this._removeFlag = true;
			this._RemoveBuffNotifyDoc(uibuff);
		}

		// Token: 0x0600D1A8 RID: 53672 RVA: 0x0030B57C File Offset: 0x0030977C
		private void _SendAIEvent(XBuff buff)
		{
			bool flag = buff.BuffInfo.AIEvent[0].Length != 0 && buff.BuffInfo.AIEvent[1].Length != 0;
			if (flag)
			{
				XAIEventArgs @event = XEventPool<XAIEventArgs>.GetEvent();
				@event.EventArg = buff.BuffInfo.AIEvent[1];
				@event.TypeId = buff.ID;
				@event.Pos = this._entity.MoveObj.Position;
				@event.Firer = ((buff.BuffInfo.AIEvent[0] == "0") ? XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host : this._entity);
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600D1A9 RID: 53673 RVA: 0x0030B650 File Offset: 0x00309850
		private void PlayFxAtSlot(int slot, int buffID, string fxPath, Dictionary<int, ClientBuffInfo> container, bool scale, XEntity entity)
		{
			bool flag = container.ContainsKey(slot);
			ClientBuffInfo clientBuffInfo;
			if (flag)
			{
				clientBuffInfo = container[slot];
			}
			else
			{
				clientBuffInfo = new ClientBuffInfo();
				container.Add(slot, clientBuffInfo);
			}
			bool flag2 = clientBuffInfo.oFx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(clientBuffInfo.oFx, true);
				clientBuffInfo.oFx = null;
			}
			clientBuffInfo.BuffID = buffID;
			bool flag3 = XSingleton<XScene>.singleton.IsMustTransform && entity.IsRole && !entity.IsTransform;
			if (!flag3)
			{
				float num = scale ? entity.Height : 1f;
				bool flag4 = fxPath != "nullfx";
				if (flag4)
				{
					clientBuffInfo.oFx = XSingleton<XFxMgr>.singleton.CreateFx(fxPath, null, true);
					bool sticky = fxPath.Contains("_TIEDI");
					clientBuffInfo.oFx.Play(entity.EngineObject, Vector3.zero, num / entity.Scale * Vector3.one, 1f, true, sticky, "", 0f);
				}
			}
		}

		// Token: 0x0600D1AA RID: 53674 RVA: 0x0030B76C File Offset: 0x0030996C
		private void _PlayBuffFx(int BuffID, int BuffLevel, float duration)
		{
			bool flag = !this._entity.IsVisible;
			if (!flag)
			{
				bool flag2 = duration > 0f && duration < 3f && XEntity.FilterFx(this._entity, XFxMgr.FilterFxDis2);
				if (!flag2)
				{
					BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(BuffID, BuffLevel);
					bool flag3 = buffData == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Play buff fx: Buff data not found: [{0} {1}]", BuffID, BuffLevel), null, null, null, null, null);
					}
					else
					{
						bool flag4 = !string.IsNullOrEmpty(buffData.BuffEffectFx);
						if (flag4)
						{
							int slot = 0;
							string[] array = buffData.BuffEffectFx.Split(XGlobalConfig.ListSeparator);
							for (int i = 0; i < array.Length; i++)
							{
								string[] array2 = array[i].Split(XGlobalConfig.SequenceSeparator);
								bool flag5 = array2.Length == 2;
								if (flag5)
								{
									int.TryParse(array2[1], out slot);
								}
								this.PlayFxAtSlot(slot, BuffID, array2[0], this._NoScaleFx, true, this._entity);
							}
						}
						bool flag6 = !string.IsNullOrEmpty(buffData.BuffFx);
						if (flag6)
						{
							int slot2 = 0;
							string[] array3 = buffData.BuffFx.Split(XGlobalConfig.ListSeparator);
							for (int j = 0; j < array3.Length; j++)
							{
								string[] array4 = array3[j].Split(XGlobalConfig.SequenceSeparator);
								bool flag7 = array4.Length == 2;
								if (flag7)
								{
									int.TryParse(array4[1], out slot2);
								}
								this.PlayFxAtSlot(slot2, BuffID, array4[0], this._ScaleFx, false, this._entity);
							}
						}
						bool flag8 = !string.IsNullOrEmpty(buffData.BuffSpriteFx) && !XQualitySetting.GetQuality(EFun.ELowEffect);
						if (flag8)
						{
							int slot3 = 10;
							XAffiliate xaffiliate = null;
							bool flag9 = !this._entity.IsTransform && this._entity.Equipment != null;
							if (flag9)
							{
								xaffiliate = this._entity.Equipment.Sprite;
							}
							bool flag10 = xaffiliate != null;
							if (flag10)
							{
								string[] array5 = buffData.BuffSpriteFx.Split(XGlobalConfig.ListSeparator);
								for (int k = 0; k < array5.Length; k++)
								{
									string[] array6 = array5[k].Split(XGlobalConfig.SequenceSeparator);
									bool flag11 = array6.Length == 2;
									if (flag11)
									{
										int.TryParse(array6[1], out slot3);
									}
									this.PlayFxAtSlot(slot3, BuffID, array6[0], this._NoScaleFx, false, xaffiliate);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600D1AB RID: 53675 RVA: 0x0030B9F8 File Offset: 0x00309BF8
		private void _StopBuffFx(int BuffID)
		{
			foreach (KeyValuePair<int, ClientBuffInfo> keyValuePair in this._NoScaleFx)
			{
				bool flag = keyValuePair.Value.BuffID == BuffID;
				if (flag)
				{
					bool flag2 = keyValuePair.Value.oFx != null;
					if (flag2)
					{
						XSingleton<XFxMgr>.singleton.DestroyFx(keyValuePair.Value.oFx, true);
						keyValuePair.Value.oFx = null;
						keyValuePair.Value.BuffID = 0;
					}
				}
			}
			foreach (KeyValuePair<int, ClientBuffInfo> keyValuePair2 in this._ScaleFx)
			{
				bool flag3 = keyValuePair2.Value.BuffID == BuffID;
				if (flag3)
				{
					bool flag4 = keyValuePair2.Value.oFx != null;
					if (flag4)
					{
						XSingleton<XFxMgr>.singleton.DestroyFx(keyValuePair2.Value.oFx, true);
						keyValuePair2.Value.oFx = null;
						keyValuePair2.Value.BuffID = 0;
					}
					break;
				}
			}
		}

		// Token: 0x0600D1AC RID: 53676 RVA: 0x0030BB48 File Offset: 0x00309D48
		public XBuff GetBuffByID(int buffID)
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool flag = !xbuff.Valid;
				if (!flag)
				{
					bool flag2 = xbuff.ID == buffID;
					if (flag2)
					{
						return xbuff;
					}
				}
			}
			return null;
		}

		// Token: 0x0600D1AD RID: 53677 RVA: 0x0030BBAC File Offset: 0x00309DAC
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_BuffAdd, new XComponent.XEventHandler(this.OnAddBuffEvent));
			base.RegisterEvent(XEventDefine.XEvent_BuffRemove, new XComponent.XEventHandler(this.OnRemoveBuffEvent));
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnRealDead));
			base.RegisterEvent(XEventDefine.XEvent_LeaveScene, new XComponent.XEventHandler(this.OnLeaveScene));
			bool flag = !this.bDemo;
			if (flag)
			{
				base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
			}
			else
			{
				base.RegisterEvent(XEventDefine.XEvent_AttackShowEnd, new XComponent.XEventHandler(this.SkillPlayFinished));
			}
			bool flag2 = !XSingleton<XGame>.singleton.SyncMode;
			if (flag2)
			{
				base.RegisterEvent(XEventDefine.XEvent_ComboChange, new XComponent.XEventHandler(this.OnComboChange));
			}
			base.RegisterEvent(XEventDefine.XEvent_BattleEnd, new XComponent.XEventHandler(this.OnBattleEndEvent));
		}

		// Token: 0x0600D1AE RID: 53678 RVA: 0x0030BC8C File Offset: 0x00309E8C
		private bool SkillPlayFinished(XEventArgs args)
		{
			this.ClearBuff();
			this.ClearBuffFx();
			return true;
		}

		// Token: 0x0600D1AF RID: 53679 RVA: 0x0030BCB0 File Offset: 0x00309EB0
		private bool OnLeaveScene(XEventArgs e)
		{
			this.m_bLeavingScene = true;
			this.ClearBuff();
			this.ClearTriggerStates();
			return true;
		}

		// Token: 0x0600D1B0 RID: 53680 RVA: 0x0030BCD8 File Offset: 0x00309ED8
		private bool OnRealDead(XEventArgs e)
		{
			XRealDeadEventArgs e2 = e as XRealDeadEventArgs;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool valid = xbuff.Valid;
				if (valid)
				{
					xbuff.OnRealDead(e2);
				}
			}
			this.ClearBuff();
			this.ClearBuffFx();
			return true;
		}

		// Token: 0x0600D1B1 RID: 53681 RVA: 0x0030BD44 File Offset: 0x00309F44
		public void ClearBuffFx()
		{
			foreach (KeyValuePair<int, ClientBuffInfo> keyValuePair in this._NoScaleFx)
			{
				bool flag = keyValuePair.Value.oFx != null;
				if (flag)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(keyValuePair.Value.oFx, true);
					keyValuePair.Value.oFx = null;
				}
			}
			foreach (KeyValuePair<int, ClientBuffInfo> keyValuePair2 in this._ScaleFx)
			{
				bool flag2 = keyValuePair2.Value.oFx != null;
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(keyValuePair2.Value.oFx, true);
					keyValuePair2.Value.oFx = null;
				}
			}
			this._NoScaleFx.Clear();
			this._ScaleFx.Clear();
		}

		// Token: 0x0600D1B2 RID: 53682 RVA: 0x0030BE64 File Offset: 0x0030A064
		private void _MergeBuff(BuffDesc buffDesc, XBuff existBuff)
		{
			BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(buffDesc.BuffID, buffDesc.BuffLevel);
			bool flag = buffData == null;
			if (!flag)
			{
				bool flag2 = existBuff.Level > (int)buffData.BuffLevel;
				if (!flag2)
				{
					bool flag3 = existBuff.Level < (int)buffData.BuffLevel;
					if (flag3)
					{
						this._RemoveBuff(existBuff, true);
						this._AddBuff(buffDesc);
					}
					else
					{
						switch (existBuff.MergeType)
						{
						case XBuffMergeType.XBuffMergeType_Replace:
							this._RemoveBuff(existBuff, true);
							this._AddBuff(buffDesc);
							break;
						case XBuffMergeType.XBuffMergeType_ExtendTime:
							XSingleton<XDebug>.singleton.AddGreenLog("extend buff ", buffData.BuffID.ToString(), " to ", this._entity.ID.ToString(), " at time ", (Environment.TickCount % 1000000).ToString());
							existBuff.AddBuffTime(existBuff.OriginalDuration, this);
							this._UpdateBuffNotifyDoc(existBuff.UIBuff);
							break;
						case XBuffMergeType.XBuffMergeType_Stacking:
							this._AppendBuff(existBuff);
							break;
						case XBuffMergeType.XBuffMergeType_Reset:
							existBuff.ResetTime(this);
							this._UpdateBuffNotifyDoc(existBuff.UIBuff);
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600D1B3 RID: 53683 RVA: 0x0030BFA4 File Offset: 0x0030A1A4
		private bool OnAddBuffEvent(XEventArgs e)
		{
			XBuffAddEventArgs xbuffAddEventArgs = e as XBuffAddEventArgs;
			BuffDesc xBuffDesc = xbuffAddEventArgs.xBuffDesc;
			this._AddBuffQueue.Add(xBuffDesc);
			bool xEffectImm = xbuffAddEventArgs.xEffectImm;
			if (xEffectImm)
			{
				this._RefreshQueueImm();
			}
			return true;
		}

		// Token: 0x0600D1B4 RID: 53684 RVA: 0x0030BFE4 File Offset: 0x0030A1E4
		private bool OnRemoveBuffEvent(XEventArgs e)
		{
			XBuffRemoveEventArgs xbuffRemoveEventArgs = e as XBuffRemoveEventArgs;
			for (int i = this._AddBuffQueue.Count - 1; i >= 0; i--)
			{
				bool flag = this._AddBuffQueue[i].BuffID == xbuffRemoveEventArgs.xBuffID;
				if (flag)
				{
					this._AddBuffQueue.RemoveAt(i);
				}
			}
			XBuff buffByID = this.GetBuffByID(xbuffRemoveEventArgs.xBuffID);
			bool flag2 = buffByID == null;
			bool result;
			if (flag2)
			{
				result = true;
			}
			else
			{
				this._RemoveBuff(buffByID, false);
				result = true;
			}
			return result;
		}

		// Token: 0x0600D1B5 RID: 53685 RVA: 0x0030C074 File Offset: 0x0030A274
		private bool OnBattleEndEvent(XEventArgs e)
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				bool valid = this._BuffList[i].Valid;
				if (valid)
				{
					this._BuffList[i].OnBattleEnd(this);
				}
			}
			return true;
		}

		// Token: 0x0600D1B6 RID: 53686 RVA: 0x0030C0CC File Offset: 0x0030A2CC
		public override void Update(float fDeltaT)
		{
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				bool valid = this._BuffList[i].Valid;
				if (valid)
				{
					this._BuffList[i].Update();
				}
			}
		}

		// Token: 0x0600D1B7 RID: 53687 RVA: 0x0030C120 File Offset: 0x0030A320
		public override void PostUpdate(float fDeltaT)
		{
			bool bPostUpdating = this._bPostUpdating;
			if (!bPostUpdating)
			{
				this._bPostUpdating = true;
				bool removeFlag = this._removeFlag;
				if (removeFlag)
				{
					this._removeFlag = false;
					for (int i = this._BuffList.Count - 1; i >= 0; i--)
					{
						XBuff xbuff = this._BuffList[i];
						bool flag = !xbuff.Valid;
						if (flag)
						{
							this._BuffList.RemoveAt(i);
						}
					}
				}
				while (this._AddBuffQueue.Count > 0)
				{
					List<BuffDesc> addBuffQueue = this._AddBuffQueue;
					this._AddBuffQueue = this._AddBuffQueue2;
					this._AddBuffQueue2 = addBuffQueue;
					for (int j = 0; j < addBuffQueue.Count; j++)
					{
						XBuff buffByID = this.GetBuffByID(addBuffQueue[j].BuffID);
						bool flag2 = buffByID != null;
						if (flag2)
						{
							this._MergeBuff(addBuffQueue[j], buffByID);
						}
						else
						{
							this._AddBuff(addBuffQueue[j]);
						}
					}
					addBuffQueue.Clear();
				}
				this._bPostUpdating = false;
			}
		}

		// Token: 0x0600D1B8 RID: 53688 RVA: 0x0030C258 File Offset: 0x0030A458
		protected bool OnAttributeChange(XEventArgs e)
		{
			XAttrChangeEventArgs e2 = e as XAttrChangeEventArgs;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool valid = xbuff.Valid;
				if (valid)
				{
					xbuff.OnAttributeChanged(this, e2);
				}
			}
			return true;
		}

		// Token: 0x0600D1B9 RID: 53689 RVA: 0x0030C2B4 File Offset: 0x0030A4B4
		protected bool OnQTEChange(XEventArgs e)
		{
			XSkillQTEEventArgs e2 = e as XSkillQTEEventArgs;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool valid = xbuff.Valid;
				if (valid)
				{
					xbuff.OnQTEStateChanged(this, e2);
				}
			}
			return true;
		}

		// Token: 0x0600D1BA RID: 53690 RVA: 0x0030C310 File Offset: 0x0030A510
		protected bool OnComboChange(XEventArgs e)
		{
			XOnComboChangeEventArgs xonComboChangeEventArgs = e as XOnComboChangeEventArgs;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				XBuff xbuff = this._BuffList[i];
				bool valid = xbuff.Valid;
				if (valid)
				{
					xbuff.OnComboChange(xonComboChangeEventArgs.ComboCount);
				}
			}
			return true;
		}

		// Token: 0x0600D1BB RID: 53691 RVA: 0x0030C370 File Offset: 0x0030A570
		public double ModifySkillDamage()
		{
			double num = 0.0;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				num += this._BuffList[i].ModifySkillDamage();
			}
			return XSingleton<XCommon>.singleton.Clamp(num, XBuffComponent.CAST_DAMAGE_CHANGE_LOWERBOUND, XBuffComponent.CAST_DAMAGE_CHANGE_UPPERBOUND);
		}

		// Token: 0x0600D1BC RID: 53692 RVA: 0x0030C3D4 File Offset: 0x0030A5D4
		public double IncReceivedDamage()
		{
			double num = 0.0;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				num += this._BuffList[i].IncReceivedDamage();
			}
			bool flag = num > XBuffComponent.RECEIVED_DAMAGE_CHANGE_UPPERBOUND;
			double result;
			if (flag)
			{
				result = XBuffComponent.RECEIVED_DAMAGE_CHANGE_UPPERBOUND;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x0600D1BD RID: 53693 RVA: 0x0030C438 File Offset: 0x0030A638
		public double DecReceivedDamage()
		{
			double num = 0.0;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				num += this._BuffList[i].DecReceivedDamage();
			}
			bool flag = num < XBuffComponent.RECEIVED_DAMAGE_CHANGE_LOWERBOUND;
			double result;
			if (flag)
			{
				result = XBuffComponent.RECEIVED_DAMAGE_CHANGE_LOWERBOUND;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x0600D1BE RID: 53694 RVA: 0x0030C49C File Offset: 0x0030A69C
		public double ChangeSkillDamage(uint skillID)
		{
			double num = 0.0;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				num += this._BuffList[i].ChangeSkillDamage(skillID);
			}
			return num;
		}

		// Token: 0x0600D1BF RID: 53695 RVA: 0x0030C4EC File Offset: 0x0030A6EC
		public double ModifySkillCost()
		{
			double num = 0.0;
			for (int i = 0; i < this._BuffList.Count; i++)
			{
				num += this._BuffList[i].ModifySkillCost();
			}
			return XSingleton<XCommon>.singleton.Clamp(num, XBuffComponent.MP_COST_CHANGE_LOWERBOUND, XBuffComponent.MP_COST_CHANGE_UPPERBOUND);
		}

		// Token: 0x0600D1C0 RID: 53696 RVA: 0x0030C550 File Offset: 0x0030A750
		public List<uint> GetBuffList()
		{
			this.m_TempBuffList.Clear();
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			List<uint> tempBuffList;
			if (syncMode)
			{
				for (int i = 0; i < this._ServerBuffList.Count; i++)
				{
					this.m_TempBuffList.Add(this._ServerBuffList[i].buffID);
				}
				tempBuffList = this.m_TempBuffList;
			}
			else
			{
				for (int j = 0; j < this._BuffList.Count; j++)
				{
					bool valid = this._BuffList[j].Valid;
					if (valid)
					{
						this.m_TempBuffList.Add((uint)this._BuffList[j].ID);
					}
				}
				tempBuffList = this.m_TempBuffList;
			}
			return tempBuffList;
		}

		// Token: 0x0600D1C1 RID: 53697 RVA: 0x0030C620 File Offset: 0x0030A820
		public List<UIBuffInfo> GetUIBuffList()
		{
			this.m_UIBuffList.Clear();
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			List<UIBuffInfo> uibuffList;
			if (syncMode)
			{
				for (int i = 0; i < this._ServerBuffList.Count; i++)
				{
					this.m_UIBuffList.Add(this._ServerBuffList[i].UIBuff);
				}
				uibuffList = this.m_UIBuffList;
			}
			else
			{
				for (int j = 0; j < this._BuffList.Count; j++)
				{
					bool valid = this._BuffList[j].Valid;
					if (valid)
					{
						this.m_UIBuffList.Add(this._BuffList[j].UIBuff);
					}
				}
				uibuffList = this.m_UIBuffList;
			}
			return uibuffList;
		}

		// Token: 0x0600D1C2 RID: 53698 RVA: 0x0030C6F0 File Offset: 0x0030A8F0
		public void AddBuffByServer(BuffInfo data)
		{
			ServerBuffInfo serverBuffInfo = new ServerBuffInfo();
			bool flag = !serverBuffInfo.Set(data);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("cant find add buff in client, while id = ", data.BuffID.ToString(), " and level = ", data.BuffLevel.ToString(), null, null);
			}
			else
			{
				this._ServerBuffList.Add(serverBuffInfo);
				this._AddBuffNotifyDoc(serverBuffInfo.UIBuff);
				bool flag2 = serverBuffInfo.UIBuff.buffInfo != null;
				if (flag2)
				{
					this._PlayBuffFx((int)serverBuffInfo.buffID, (int)serverBuffInfo.buffLevel, serverBuffInfo.UIBuff.buffInfo.BuffDuration);
				}
				this._OnAddServerBuff(serverBuffInfo);
			}
		}

		// Token: 0x0600D1C3 RID: 53699 RVA: 0x0030C7A4 File Offset: 0x0030A9A4
		private void _OnAddServerBuff(ServerBuffInfo info)
		{
			XBuffSpecialState.TryTransform(this._entity, (int)info.buffID, info.transformID, true);
			XBuffSpecialState.TryScale(this._entity, info.UIBuff, true);
			XBuffSpecialState.TryToggleTrapUI(this._entity, info.UIBuff, true);
			XBuffSpecialState.TryStealth(this._entity, info.UIBuff, true);
			XBuffSkillsReplace.TrySkillsReplace(this._entity, info.UIBuff, true);
		}

		// Token: 0x0600D1C4 RID: 53700 RVA: 0x0030C818 File Offset: 0x0030AA18
		public void RemoveBuffByServer(BuffInfo data)
		{
			ServerBuffInfo serverBuffInfo = null;
			for (int i = 0; i < this._ServerBuffList.Count; i++)
			{
				bool flag = this._ServerBuffList[i].buffID == data.BuffID && this._ServerBuffList[i].buffLevel == data.BuffLevel;
				if (flag)
				{
					serverBuffInfo = this._ServerBuffList[i];
					this._ServerBuffList.RemoveAt(i);
					break;
				}
			}
			bool flag2 = serverBuffInfo == null;
			if (!flag2)
			{
				this._RemoveBuff(serverBuffInfo, data);
			}
		}

		// Token: 0x0600D1C5 RID: 53701 RVA: 0x0030C8B0 File Offset: 0x0030AAB0
		private void _RemoveBuff(ServerBuffInfo buff, BuffInfo data)
		{
			bool flag = buff == null;
			if (!flag)
			{
				UIBuffInfo uibuff = buff.UIBuff;
				bool flag2 = data != null;
				if (flag2)
				{
					buff.UpdateFromRemoveBuff(data);
				}
				this._OnRemoveServerBuff(buff);
				this._RemoveBuffNotifyDoc(uibuff);
				this._StopBuffFx((int)buff.buffID);
			}
		}

		// Token: 0x0600D1C6 RID: 53702 RVA: 0x0030C8FC File Offset: 0x0030AAFC
		private void _OnRemoveServerBuff(ServerBuffInfo info)
		{
			bool flag = !this.m_bDestroying && !this.m_bLeavingScene;
			if (flag)
			{
				XBuffSpecialState.TryTransform(this._entity, (int)info.buffID, info.transformID, false);
			}
			bool flag2 = !this.m_bLeavingScene;
			if (flag2)
			{
				XBuffSpecialState.TryScale(this._entity, info.UIBuff, false);
				XBuffSpecialState.TryToggleTrapUI(this._entity, info.UIBuff, false);
				XBuffSpecialState.TryStealth(this._entity, info.UIBuff, false);
				XBuffSkillsReplace.TrySkillsReplace(this._entity, info.UIBuff, false);
			}
		}

		// Token: 0x0600D1C7 RID: 53703 RVA: 0x0030C998 File Offset: 0x0030AB98
		public void UpdateBuffByServer(BuffInfo data)
		{
			UIBuffInfo uibuffInfo = null;
			ServerBuffInfo serverBuffInfo = null;
			for (int i = 0; i < this._ServerBuffList.Count; i++)
			{
				bool flag = this._ServerBuffList[i].buffID == data.BuffID && this._ServerBuffList[i].buffLevel == data.BuffLevel;
				if (flag)
				{
					serverBuffInfo = this._ServerBuffList[i];
					serverBuffInfo.Set(data);
					uibuffInfo = serverBuffInfo.UIBuff;
					break;
				}
			}
			bool flag2 = uibuffInfo == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("cant find update buff in client, while id = ", data.BuffID.ToString(), " and level = ", data.BuffLevel.ToString(), null, null);
			}
			else
			{
				this._UpdateBuffNotifyDoc(uibuffInfo);
				this._OnUpdateServerBuff(serverBuffInfo);
			}
		}

		// Token: 0x0600D1C8 RID: 53704 RVA: 0x0030CA72 File Offset: 0x0030AC72
		private void _OnUpdateServerBuff(ServerBuffInfo info)
		{
			XBuffSpecialState.TryTransform(this._entity, (int)info.buffID, info.transformID, true);
		}

		// Token: 0x0600D1C9 RID: 53705 RVA: 0x0030CA90 File Offset: 0x0030AC90
		public void SetServerAllBuffsInfo(AllBuffsInfo data)
		{
			bool flag = data == null;
			if (!flag)
			{
				this.SetServerBuffState(data.BuffState);
				this.SetServerBuffValues(data.StateParamIndex, data.StateParamValues);
			}
		}

		// Token: 0x0600D1CA RID: 53706 RVA: 0x0030CAC8 File Offset: 0x0030ACC8
		public void SetServerBuffState(uint state)
		{
			for (int i = 0; i < XFastEnumIntEqualityComparer<XBuffType>.ToInt(XBuffType.XBuffType_Max); i++)
			{
				this._entity.Attributes.BuffState.SetBuffState((XBuffType)i, (short)(state >> i & 1U));
			}
		}

		// Token: 0x0600D1CB RID: 53707 RVA: 0x0030CB10 File Offset: 0x0030AD10
		public void SetServerBuffValues(List<int> index, List<int> values)
		{
			for (int i = 0; i < XFastEnumIntEqualityComparer<XBuffType>.ToInt(XBuffType.XBuffType_Max); i++)
			{
				this._entity.Attributes.BuffState.SetStateParam((XBuffType)i, 0);
			}
			bool flag = index.Count != values.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Format("data.StateParamValues.Count ({0}) != data.StateParamIndex.Count ({1})", values.Count, index.Count), null, null, null, null, null);
			}
			for (int j = 0; j < index.Count; j++)
			{
				this._entity.Attributes.BuffState.SetStateParam((XBuffType)index[j], values[j]);
			}
		}

		// Token: 0x0600D1CC RID: 53708 RVA: 0x0030CBD2 File Offset: 0x0030ADD2
		public override void OnDetachFromHost()
		{
			this.m_bDestroying = true;
			this.ClearBuff();
			this.ClearBuffFx();
			base.OnDetachFromHost();
		}

		// Token: 0x0600D1CD RID: 53709 RVA: 0x0030CBF1 File Offset: 0x0030ADF1
		public void InitFromServer(List<BuffInfo> buffs, AllBuffsInfo states)
		{
			this.ClearBuff();
			this.ClearBuffFx();
			this.SetServerAllBuffsInfo(states);
			this.AddBuffByServer(buffs);
		}

		// Token: 0x0600D1CE RID: 53710 RVA: 0x0030CC14 File Offset: 0x0030AE14
		public void AddBuffByServer(List<BuffInfo> buffs)
		{
			bool flag = buffs == null;
			if (!flag)
			{
				for (int i = 0; i < buffs.Count; i++)
				{
					this.AddBuffByServer(buffs[i]);
				}
			}
		}

		// Token: 0x0600D1CF RID: 53711 RVA: 0x0030CC54 File Offset: 0x0030AE54
		private void _AddBuffNotifyDoc(UIBuffInfo buffInfo)
		{
			bool flag = buffInfo == null;
			if (!flag)
			{
				XBuffChangeEventArgs @event = XEventPool<XBuffChangeEventArgs>.GetEvent();
				@event.addBuff = buffInfo;
				@event.entity = base.Entity;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XBuffChangeEventArgs event2 = XEventPool<XBuffChangeEventArgs>.GetEvent();
				event2.addBuff = buffInfo;
				event2.entity = base.Entity;
				event2.Firer = this._entity;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		// Token: 0x0600D1D0 RID: 53712 RVA: 0x0030CCD4 File Offset: 0x0030AED4
		private void _RemoveBuffNotifyDoc(UIBuffInfo buffInfo)
		{
			bool flag = buffInfo == null;
			if (!flag)
			{
				XBuffChangeEventArgs @event = XEventPool<XBuffChangeEventArgs>.GetEvent();
				@event.removeBuff = buffInfo;
				@event.entity = base.Entity;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XBuffChangeEventArgs event2 = XEventPool<XBuffChangeEventArgs>.GetEvent();
				event2.removeBuff = buffInfo;
				event2.entity = base.Entity;
				event2.Firer = this._entity;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		// Token: 0x0600D1D1 RID: 53713 RVA: 0x0030CD54 File Offset: 0x0030AF54
		private void _UpdateBuffNotifyDoc(UIBuffInfo buffInfo)
		{
			bool flag = buffInfo == null;
			if (!flag)
			{
				XBuffChangeEventArgs @event = XEventPool<XBuffChangeEventArgs>.GetEvent();
				@event.updateBuff = buffInfo;
				@event.entity = base.Entity;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XBuffChangeEventArgs event2 = XEventPool<XBuffChangeEventArgs>.GetEvent();
				event2.updateBuff = buffInfo;
				event2.entity = base.Entity;
				event2.Firer = this._entity;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
		}

		// Token: 0x0600D1D2 RID: 53714 RVA: 0x0030CDD4 File Offset: 0x0030AFD4
		private void _RefreshQueueImm()
		{
			this.PostUpdate(0f);
		}

		// Token: 0x0600D1D3 RID: 53715 RVA: 0x0030CDE4 File Offset: 0x0030AFE4
		public XTriggerCondition GetTriggerState(BuffTable.RowData info)
		{
			XTriggerCondition xtriggerCondition;
			bool flag = !this.m_GlobalTriggerState.TryGetValue(info.BuffID, out xtriggerCondition);
			if (flag)
			{
				xtriggerCondition = new XTriggerCondition(info);
				this.m_GlobalTriggerState[info.BuffID] = xtriggerCondition;
			}
			return xtriggerCondition;
		}

		// Token: 0x0600D1D4 RID: 53716 RVA: 0x0030CE2D File Offset: 0x0030B02D
		public void ClearTriggerStates()
		{
			this.m_GlobalTriggerState.Clear();
		}

		// Token: 0x04005F1E RID: 24350
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Character_Buff");

		// Token: 0x04005F1F RID: 24351
		private bool _removeFlag = false;

		// Token: 0x04005F20 RID: 24352
		private List<XBuff> _BuffList = new List<XBuff>();

		// Token: 0x04005F21 RID: 24353
		private List<BuffDesc> _AddBuffQueue = new List<BuffDesc>();

		// Token: 0x04005F22 RID: 24354
		private List<BuffDesc> _AddBuffQueue2 = new List<BuffDesc>();

		// Token: 0x04005F23 RID: 24355
		private List<ServerBuffInfo> _ServerBuffList = new List<ServerBuffInfo>();

		// Token: 0x04005F24 RID: 24356
		private Dictionary<int, ClientBuffInfo> _ScaleFx = new Dictionary<int, ClientBuffInfo>();

		// Token: 0x04005F25 RID: 24357
		private Dictionary<int, ClientBuffInfo> _NoScaleFx = new Dictionary<int, ClientBuffInfo>();

		// Token: 0x04005F26 RID: 24358
		public Dictionary<int, XTriggerCondition> m_GlobalTriggerState = new Dictionary<int, XTriggerCondition>();

		// Token: 0x04005F27 RID: 24359
		private bool m_bLeavingScene;

		// Token: 0x04005F28 RID: 24360
		private bool m_bDestroying;

		// Token: 0x04005F29 RID: 24361
		private static double CAST_DAMAGE_CHANGE_UPPERBOUND;

		// Token: 0x04005F2A RID: 24362
		private static double CAST_DAMAGE_CHANGE_LOWERBOUND;

		// Token: 0x04005F2B RID: 24363
		private static double RECEIVED_DAMAGE_CHANGE_UPPERBOUND;

		// Token: 0x04005F2C RID: 24364
		private static double RECEIVED_DAMAGE_CHANGE_LOWERBOUND;

		// Token: 0x04005F2D RID: 24365
		private static double MP_COST_CHANGE_UPPERBOUND;

		// Token: 0x04005F2E RID: 24366
		private static double MP_COST_CHANGE_LOWERBOUND;

		// Token: 0x04005F2F RID: 24367
		public static HashSet<int> TransformBuffsChangeOutlook = new HashSet<int>();

		// Token: 0x04005F30 RID: 24368
		private bool _bPostUpdating = false;

		// Token: 0x04005F31 RID: 24369
		private List<uint> m_TempBuffList = new List<uint>();

		// Token: 0x04005F32 RID: 24370
		private List<UIBuffInfo> m_UIBuffList = new List<UIBuffInfo>();
	}
}
