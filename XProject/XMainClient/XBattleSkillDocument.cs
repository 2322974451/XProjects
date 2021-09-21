using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000995 RID: 2453
	internal class XBattleSkillDocument : XDocComponent
	{
		// Token: 0x17002CCF RID: 11471
		// (get) Token: 0x060093C0 RID: 37824 RVA: 0x0015A5A8 File Offset: 0x001587A8
		public override uint ID
		{
			get
			{
				return XBattleSkillDocument.uuID;
			}
		}

		// Token: 0x17002CD0 RID: 11472
		// (get) Token: 0x060093C1 RID: 37825 RVA: 0x0015A5C0 File Offset: 0x001587C0
		// (set) Token: 0x060093C2 RID: 37826 RVA: 0x0015A5D8 File Offset: 0x001587D8
		public BattleSkillHandler BattleView
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		// Token: 0x060093C3 RID: 37827 RVA: 0x0015A5E2 File Offset: 0x001587E2
		public void Init()
		{
			this._player = XSingleton<XEntityMgr>.singleton.Player;
			this._locate = this._player.TargetLocated;
		}

		// Token: 0x060093C4 RID: 37828 RVA: 0x0015A606 File Offset: 0x00158806
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._canSkillLevelTransScene = XSingleton<XGlobalConfig>.singleton.GetSequenceList("CanLevelTransSkill", false);
		}

		// Token: 0x060093C5 RID: 37829 RVA: 0x0015A628 File Offset: 0x00158828
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnDeath));
			base.RegisterEvent(XEventDefine.XEvent_CoolDownAllSkills, new XComponent.XEventHandler(this.OnCoolDown));
			base.RegisterEvent(XEventDefine.XEvent_InitCoolDownAllSkills, new XComponent.XEventHandler(this.OnInitCoolDown));
			base.RegisterEvent(XEventDefine.XEvent_BuffChange, new XComponent.XEventHandler(this.OnBuffChange));
		}

		// Token: 0x060093C6 RID: 37830 RVA: 0x0015A694 File Offset: 0x00158894
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ARENA;
			if (flag)
			{
				this._view.SetVisible(false);
			}
			for (int i = 0; i < XBattleSkillDocument._slot_total_clicked.Length; i++)
			{
				XBattleSkillDocument._slot_total_clicked[i] = 0U;
			}
		}

		// Token: 0x060093C7 RID: 37831 RVA: 0x0015A6E0 File Offset: 0x001588E0
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			XBattleSkillDocument.m_canlevelrans = false;
			for (int i = 0; i < (int)this._canSkillLevelTransScene.Count; i++)
			{
				bool flag = this._canSkillLevelTransScene[i, 0] == 1;
				if (flag)
				{
					bool flag2 = XSingleton<XScene>.singleton.SceneType == (SceneType)this._canSkillLevelTransScene[i, 1];
					if (flag2)
					{
						XBattleSkillDocument.m_canlevelrans = true;
						break;
					}
				}
				else
				{
					bool flag3 = (ulong)XSingleton<XScene>.singleton.SceneID == (ulong)((long)this._canSkillLevelTransScene[i, 1]);
					if (flag3)
					{
						XBattleSkillDocument.m_canlevelrans = true;
						break;
					}
				}
			}
			XBattleSkillDocument.SkillLevelDict.Clear();
			for (int j = 0; j < XBattleSkillDocument.SkillLevel.Length; j++)
			{
				XBattleSkillDocument.SkillLevel[j] = 0;
			}
			bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB;
			if (flag4)
			{
				XBattleSkillDocument.SkillLevel[0] = 1;
			}
		}

		// Token: 0x060093C8 RID: 37832 RVA: 0x0015A7D0 File Offset: 0x001589D0
		public override void OnLeaveScene()
		{
			base.OnLeaveScene();
			XBattleSkillDocument.SkillLevelDict.Clear();
		}

		// Token: 0x060093C9 RID: 37833 RVA: 0x0015A7E8 File Offset: 0x001589E8
		public bool IsInQTEChain(uint skill)
		{
			return this._player.QTE.QTEList.Contains(skill);
		}

		// Token: 0x060093CA RID: 37834 RVA: 0x0015A810 File Offset: 0x00158A10
		public bool CanCast(uint skill, int slot)
		{
			bool flag = this._player == null || this._player.Deprecated || this._player.SkillMgr == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA && slot >= 2 && slot <= 5;
				if (flag2)
				{
					bool flag3 = XBattleSkillDocument.SkillLevel[slot] == 0;
					if (flag3)
					{
						return false;
					}
				}
				bool flag4 = this._player.SkillMgr.GetPhysicalIdentity() != skill && this._player.Buffs.IsBuffStateOn(XBuffType.XBuffType_Silencing);
				if (flag4)
				{
					result = false;
				}
				else
				{
					bool flag5 = this.IsInQTEChain(skill);
					if (flag5)
					{
						result = true;
					}
					else
					{
						bool flag6 = this._player.QTE.IsInReservedState();
						if (flag6)
						{
							result = false;
						}
						else
						{
							XSkillCore skill2 = this._player.SkillMgr.GetSkill(skill);
							bool flag7 = skill2 == null || !skill2.ExternalCanCast();
							if (flag7)
							{
								result = false;
							}
							else
							{
								bool flag8 = skill2.Soul.OnceOnly && skill2.EverFired;
								if (flag8)
								{
									result = false;
								}
								else
								{
									bool flag9 = skill2.Soul.Chain != null && skill2.Soul.Chain.TemplateID > 0;
									if (flag9)
									{
										bool flag10 = this._player.Skill.SkillMobs == null;
										if (flag10)
										{
											result = false;
										}
										else
										{
											for (int i = 0; i < this._player.Skill.SkillMobs.Count; i++)
											{
												bool flag11 = (ulong)this._player.Skill.SkillMobs[i].TypeID == (ulong)((long)skill2.Soul.Chain.TemplateID) && XEntity.ValideEntity(this._player.Skill.SkillMobs[i]);
												if (flag11)
												{
													return !this._player.Skill.IsCasting() || this._player.Skill.CurrentSkill.MainCore.CanReplacedBy(skill2);
												}
											}
											result = false;
										}
									}
									else
									{
										bool flag12 = this._player.Skill.IsCasting();
										result = (!flag12 || this._player.Skill.CurrentSkill.MainCore.CanReplacedBy(skill2));
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060093CB RID: 37835 RVA: 0x0015AA90 File Offset: 0x00158C90
		public bool CanFind(uint skill)
		{
			return false;
		}

		// Token: 0x060093CC RID: 37836 RVA: 0x0015AAA4 File Offset: 0x00158CA4
		public XSkillCore HasReplaced(uint id)
		{
			return this._player.Skill.TryGetSkillReplace(id, this._player.SkillMgr.GetSkill(id));
		}

		// Token: 0x060093CD RID: 37837 RVA: 0x0015AAD8 File Offset: 0x00158CD8
		public void ResetAll(bool fx = false, bool rebind = false)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.ResetSkill(fx, rebind);
			}
		}

		// Token: 0x060093CE RID: 37838 RVA: 0x0015AB04 File Offset: 0x00158D04
		public void Reset(int slot)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.ResetSkill(slot, false);
			}
		}

		// Token: 0x060093CF RID: 37839 RVA: 0x0015AB30 File Offset: 0x00158D30
		public void UpdateQTE(int key, uint skill)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.UpdateQTESkill(key, skill);
			}
		}

		// Token: 0x060093D0 RID: 37840 RVA: 0x0015AB5C File Offset: 0x00158D5C
		public void CastSkill(BattleSkillHandler.XSkillButton button)
		{
			bool flag = !XEntity.ValideEntity(this._player);
			if (!flag)
			{
				int num = (int)this._player.PlayerAttributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
				XSkillCore xskillCore = this.HasReplaced(button.m_skillId);
				bool flag2 = xskillCore != null && xskillCore.CooledDown;
				if (flag2)
				{
					bool flag3 = (float)num >= button.m_skillCost;
					if (flag3)
					{
						this.FireSkillEvent(button);
					}
					else
					{
						bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XStringDefineProxy.GetString("COMMON_NO_MP"));
						}
					}
				}
			}
		}

		// Token: 0x060093D1 RID: 37841 RVA: 0x0015ABF8 File Offset: 0x00158DF8
		public void FireSkillEvent(int idx)
		{
			bool freezed = XSingleton<XInput>.singleton.Freezed;
			if (!freezed)
			{
				XSingleton<XEntityMgr>.singleton.Player.Net.ReportSkillAction((this._locate == null) ? null : this._locate.Target, idx);
			}
		}

		// Token: 0x060093D2 RID: 37842 RVA: 0x0015AC44 File Offset: 0x00158E44
		public void FireSkillEvent(BattleSkillHandler.XSkillButton button)
		{
			bool freezed = XSingleton<XInput>.singleton.Freezed;
			if (!freezed)
			{
				this._player.Net.ReportSkillAction((this._locate == null) ? null : this._locate.Target, button.m_skillId, (int)button.m_skill.ID);
			}
		}

		// Token: 0x060093D3 RID: 37843 RVA: 0x0015AC9C File Offset: 0x00158E9C
		public void OnSkillCasted(uint id, int slot, bool succeed)
		{
			bool flag = slot < 0;
			if (!flag)
			{
				if (succeed)
				{
					uint num = this.NextJASkill(id);
					bool flag2 = num > 0U;
					if (flag2)
					{
						bool flag3 = this._view != null;
						if (flag3)
						{
							this._view.BindSkill(slot, num, false);
						}
						return;
					}
				}
				bool flag4 = this._view != null;
				if (flag4)
				{
					this._view.ResetSkill(slot, false);
				}
			}
		}

		// Token: 0x060093D4 RID: 37844 RVA: 0x0015AD10 File Offset: 0x00158F10
		public void OnSlotClicked(int slot)
		{
			bool flag = slot >= 0 && (long)slot < (long)((ulong)XBattleSkillDocument.Total_skill_slot);
			if (flag)
			{
				XBattleSkillDocument._slot_total_clicked[slot] += 1U;
			}
		}

		// Token: 0x060093D5 RID: 37845 RVA: 0x0015AD44 File Offset: 0x00158F44
		public uint GetSlotClicked(int slot)
		{
			bool flag = slot >= 0 && (long)slot < (long)((ulong)XBattleSkillDocument.Total_skill_slot);
			uint result;
			if (flag)
			{
				result = XBattleSkillDocument._slot_total_clicked[slot];
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x060093D6 RID: 37846 RVA: 0x0015AD78 File Offset: 0x00158F78
		public uint NextJASkillBaseOnCurrent()
		{
			bool flag = this._player.Skill.IsCasting();
			uint result;
			if (flag)
			{
				result = this.NextJASkill(this._player.Skill.CurrentSkill.MainCore.ID);
			}
			else
			{
				result = (XSingleton<XGame>.singleton.SyncMode ? this._player.Net.LastReqSkill : 0U);
			}
			return result;
		}

		// Token: 0x060093D7 RID: 37847 RVA: 0x0015ADE4 File Offset: 0x00158FE4
		private uint NextJASkill(uint skill)
		{
			XSkillCore skill2 = this._player.SkillMgr.GetSkill(skill);
			uint num = (skill2 == null) ? 0U : ((skill2.Soul.Ja == null || skill2.Soul.Ja.Count == 0) ? 0U : XSingleton<XCommon>.singleton.XHash(skill2.Soul.Ja[0].Name));
			return (this._player.SkillMgr.GetSkill(num) == null) ? 0U : num;
		}

		// Token: 0x060093D8 RID: 37848 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060093D9 RID: 37849 RVA: 0x0015AE68 File Offset: 0x00159068
		private bool OnDeath(object o)
		{
			XRealDeadEventArgs xrealDeadEventArgs = o as XRealDeadEventArgs;
			bool isPlayer = xrealDeadEventArgs.TheDead.IsPlayer;
			if (isPlayer)
			{
				this.ResetAll(false, false);
				bool flag = this._view != null;
				if (flag)
				{
					this._view.OnDeath();
				}
			}
			return true;
		}

		// Token: 0x060093DA RID: 37850 RVA: 0x0015AEB8 File Offset: 0x001590B8
		public override void OnSceneStarted()
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.MakeCoolDownAtLaunch();
			}
		}

		// Token: 0x060093DB RID: 37851 RVA: 0x0015AEE0 File Offset: 0x001590E0
		public bool OnCoolDown(object o)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.CoolDownSkillAll();
			}
			return true;
		}

		// Token: 0x060093DC RID: 37852 RVA: 0x0015AF0C File Offset: 0x0015910C
		public bool OnInitCoolDown(object o)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.MakeCoolDownAtLaunch();
			}
			return true;
		}

		// Token: 0x060093DD RID: 37853 RVA: 0x0015AF38 File Offset: 0x00159138
		public void SetSkillLevel(uint skillHash, uint level)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				XBattleSkillDocument.SkillLevelDict[skillHash] = level;
				for (int i = 0; i < XSingleton<XEntityMgr>.singleton.Player.SkillSlot.Length; i++)
				{
					bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA && (i < 2 || i > 5);
					if (!flag2)
					{
						bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB && i != 0;
						if (!flag3)
						{
							bool flag4 = XSingleton<XEntityMgr>.singleton.Player.SkillSlot[i] == skillHash;
							if (flag4)
							{
								bool isLevelUp = XBattleSkillDocument.SkillLevel[i] != (int)level && XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
								XBattleSkillDocument.SkillLevel[i] = (int)level;
								bool flag5 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
								if (flag5)
								{
									DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetMobaSkillLevel(i, isLevelUp);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060093DE RID: 37854 RVA: 0x0015B03C File Offset: 0x0015923C
		private bool OnBuffChange(XEventArgs args)
		{
			XBuffChangeEventArgs xbuffChangeEventArgs = args as XBuffChangeEventArgs;
			bool flag = xbuffChangeEventArgs.addBuff != null;
			if (flag)
			{
				bool bReduceCD = xbuffChangeEventArgs.addBuff.bReduceCD;
				if (bReduceCD)
				{
					XBuffReduceSkillCD.DoReduce((int)xbuffChangeEventArgs.addBuff.buffID, (int)xbuffChangeEventArgs.addBuff.buffLevel, xbuffChangeEventArgs.entity);
				}
			}
			bool flag2 = xbuffChangeEventArgs.removeBuff != null;
			if (flag2)
			{
				bool bReduceCD2 = xbuffChangeEventArgs.removeBuff.bReduceCD;
				if (bReduceCD2)
				{
					XBuffReduceSkillCD.UnDo((int)xbuffChangeEventArgs.removeBuff.buffID, (int)xbuffChangeEventArgs.removeBuff.buffLevel, xbuffChangeEventArgs.entity);
				}
			}
			return true;
		}

		// Token: 0x040031AB RID: 12715
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("BattleSkillDocument");

		// Token: 0x040031AC RID: 12716
		public static uint Total_skill_slot = (uint)(XFastEnumIntEqualityComparer<XSkillSlot>.ToInt(XSkillSlot.Attack_Max) - 1);

		// Token: 0x040031AD RID: 12717
		private static uint[] _slot_total_clicked = new uint[XBattleSkillDocument.Total_skill_slot];

		// Token: 0x040031AE RID: 12718
		public static int[] SkillLevel = new int[6];

		// Token: 0x040031AF RID: 12719
		public static bool m_canlevelrans = false;

		// Token: 0x040031B0 RID: 12720
		private SeqList<int> _canSkillLevelTransScene;

		// Token: 0x040031B1 RID: 12721
		public static Dictionary<uint, uint> SkillLevelDict = new Dictionary<uint, uint>();

		// Token: 0x040031B2 RID: 12722
		private BattleSkillHandler _view = null;

		// Token: 0x040031B3 RID: 12723
		private XLocateTargetComponent _locate = null;

		// Token: 0x040031B4 RID: 12724
		private XPlayer _player = null;
	}
}
