using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001756 RID: 5974
	internal class BattleContiDlg : DlgBase<BattleContiDlg, BattleContiBehaviour>
	{
		// Token: 0x170037F7 RID: 14327
		// (get) Token: 0x0600F6B4 RID: 63156 RVA: 0x0037FED4 File Offset: 0x0037E0D4
		public ulong CurEnemy
		{
			get
			{
				return this._curEnemy;
			}
		}

		// Token: 0x170037F8 RID: 14328
		// (get) Token: 0x0600F6B5 RID: 63157 RVA: 0x0037FEEC File Offset: 0x0037E0EC
		public override string fileName
		{
			get
			{
				return "Battle/BattleKillInfo";
			}
		}

		// Token: 0x170037F9 RID: 14329
		// (get) Token: 0x0600F6B6 RID: 63158 RVA: 0x0037FF04 File Offset: 0x0037E104
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037FA RID: 14330
		// (get) Token: 0x0600F6B7 RID: 63159 RVA: 0x0037FF18 File Offset: 0x0037E118
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F6B8 RID: 63160 RVA: 0x0037FF2C File Offset: 0x0037E12C
		protected override void Init()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			if (flag)
			{
				this.InitMultiMode();
			}
			else
			{
				this._mode = KillInfoMode.Single;
			}
			bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
			if (flag2)
			{
				base.uiBehaviour.m_KillInfoGroup.SetGroup(1);
			}
			else
			{
				bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BIGMELEE_FIGHT;
				if (flag3)
				{
					base.uiBehaviour.m_KillInfoGroup.SetGroup(2);
					this._isRevengePlay = true;
				}
				else
				{
					base.uiBehaviour.m_KillInfoGroup.SetGroup(0);
				}
			}
			this.HideKillInfo();
			this._killOrAssitQueue.Clear();
			this.HideAll();
		}

		// Token: 0x0600F6B9 RID: 63161 RVA: 0x0037FFE0 File Offset: 0x0037E1E0
		private void InitMultiMode()
		{
			this._mode = KillInfoMode.Multiple;
			this._killInfoPool.SetupPool(base.uiBehaviour.m_InfoTpl.parent.gameObject, base.uiBehaviour.m_InfoTpl.gameObject, BattleContiDlg.MULTIPLESHOWMAX, true);
			Vector3 tplPos = this._killInfoPool.TplPos;
			this._killLabelList.Clear();
			this._showqueue.Clear();
			this._waitQueue.Clear();
			int num = 0;
			while ((long)num < (long)((ulong)BattleContiDlg.MULTIPLESHOWMAX))
			{
				GameObject gameObject = this._killInfoPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(num * this._killInfoPool.TplHeight));
				Transform transform = gameObject.transform.FindChild("Bg");
				transform.localPosition = XGameUI.Far_Far_Away;
				IXUILabel item = transform.FindChild("killer").GetComponent("XUILabel") as IXUILabel;
				IXUILabel item2 = transform.FindChild("dead").GetComponent("XUILabel") as IXUILabel;
				this._killLabelList.Add(item);
				this._killLabelList.Add(item2);
				num++;
			}
		}

		// Token: 0x0600F6BA RID: 63162 RVA: 0x00380128 File Offset: 0x0037E328
		public void AddBattleSkill(GVGBattleSkill battleSkill)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.m_battleSkillTemp = battleSkill;
				this.SetVisibleWithAnimation(true, null);
			}
			else
			{
				this.m_battleSkillTemp = null;
				this.SetBattleSkill(battleSkill);
			}
		}

		// Token: 0x0600F6BB RID: 63163 RVA: 0x00380168 File Offset: 0x0037E368
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.m_battleSkillTemp != null;
			if (flag)
			{
				this.SetBattleSkill(this.m_battleSkillTemp);
			}
		}

		// Token: 0x0600F6BC RID: 63164 RVA: 0x0038019C File Offset: 0x0037E39C
		private void SetBattleSkill(GVGBattleSkill battleSkill)
		{
			bool flag = battleSkill.contiKillCount >= 0;
			if (flag)
			{
				this._waitQueue.Enqueue(battleSkill);
			}
			bool flag2 = battleSkill.killerID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID || battleSkill.contiKillCount < 0;
			if (flag2)
			{
				bool flag3 = battleSkill.contiKillCount != 0;
				if (flag3)
				{
					bool flag4 = this._currShow == 0;
					if (flag4)
					{
						this._currShow = -1;
					}
					bool flag5 = battleSkill.contiKillCount > 0;
					if (flag5)
					{
						this._killOrAssitQueue.Clear();
						this.m_conKillerTime.LeftTime = 0f;
						this.myInfoTemp.SetInfo(battleSkill.contiKillCount, this._isRevengePlay && this.IsRevenge(battleSkill.deadID));
						this._killOrAssitQueue.Enqueue(this.myInfoTemp);
					}
					else
					{
						this.myInfoTemp.SetInfo(battleSkill.contiKillCount, false);
						this._killOrAssitQueue.Enqueue(this.myInfoTemp);
					}
				}
			}
			else
			{
				bool flag6 = battleSkill.deadID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag6)
				{
					bool isRevengePlay = this._isRevengePlay;
					if (isRevengePlay)
					{
						this.ChangeEnemy(battleSkill.killerID);
					}
					bool flag7 = this._currShow > 0;
					if (flag7)
					{
						this.HideConKill();
						this.m_conKillerTime.LeftTime = 0f;
					}
				}
			}
		}

		// Token: 0x0600F6BD RID: 63165 RVA: 0x00380310 File Offset: 0x0037E510
		private void UpdateBattleSkill()
		{
			bool flag = this.m_battleKiller == null;
			if (!flag)
			{
				this.m_battleKiller.Update();
				bool flag2 = this.m_battleKiller.LeftTime > 0f;
				if (!flag2)
				{
					bool flag3 = this._mode == KillInfoMode.Single;
					if (flag3)
					{
						bool flag4 = this._waitQueue.Count > 0;
						if (flag4)
						{
							GVGBattleSkill battle = this._waitQueue.Dequeue();
							this.Set(battle, base.uiBehaviour.m_killer, base.uiBehaviour.m_deader);
							this.m_battleKiller.LeftTime = ((this._waitQueue.Count > 0) ? 1f : 5f);
						}
						else
						{
							this.HideKillInfo();
						}
					}
					else
					{
						bool flag5 = this._showqueue.Count <= 0 && this._waitQueue.Count <= 0;
						if (!flag5)
						{
							for (;;)
							{
								bool flag6 = this._showqueue.Count == 0;
								if (flag6)
								{
									break;
								}
								GVGBattleSkill gvgbattleSkill = this._showqueue.Peek();
								bool flag7 = gvgbattleSkill.validTime < Time.time;
								if (!flag7)
								{
									break;
								}
								this._showqueue.Dequeue();
							}
							while ((long)this._showqueue.Count < (long)((ulong)BattleContiDlg.MULTIPLESHOWMAX) && this._waitQueue.Count > 0)
							{
								GVGBattleSkill gvgbattleSkill2 = this._waitQueue.Dequeue();
								gvgbattleSkill2.validTime = Time.time + BattleContiDlg.EACHSHOWTIME;
								this._showqueue.Enqueue(gvgbattleSkill2);
							}
							int i = 0;
							foreach (GVGBattleSkill battle2 in this._showqueue)
							{
								this.Set(battle2, this._killLabelList[i], this._killLabelList[i + 1]);
								i += 2;
							}
							while (i < this._killLabelList.Count)
							{
								this._killLabelList[i].gameObject.transform.parent.localPosition = XGameUI.Far_Far_Away;
								i += 2;
							}
							this.m_battleKiller.LeftTime = 0.5f;
						}
					}
				}
			}
		}

		// Token: 0x0600F6BE RID: 63166 RVA: 0x00380580 File Offset: 0x0037E780
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateBattleSkill();
			this.UpdateConKiller();
		}

		// Token: 0x0600F6BF RID: 63167 RVA: 0x00380598 File Offset: 0x0037E798
		private void UpdateConKiller()
		{
			this.m_conKillerTime.Update();
			bool flag = this.m_conKillerTime.LeftTime > 0f;
			if (!flag)
			{
				bool flag2 = this._currShow == 0;
				if (!flag2)
				{
					bool flag3 = this._killOrAssitQueue.Count != 0;
					if (flag3)
					{
						MyBattleKillInfo myBattleKillInfo = this._killOrAssitQueue.Dequeue();
						this.ShowConKill(myBattleKillInfo.contiKillCount, myBattleKillInfo.isRevenge);
					}
					else
					{
						this.HideAll();
						this._currShow = 0;
					}
				}
			}
		}

		// Token: 0x0600F6C0 RID: 63168 RVA: 0x00380620 File Offset: 0x0037E820
		public void Set(GVGBattleSkill battle, IXUILabel l1, IXUILabel l2)
		{
			bool flag = battle == null;
			if (!flag)
			{
				l1.gameObject.transform.parent.localPosition = Vector3.zero;
				bool killerPosition = battle.killerPosition;
				if (killerPosition)
				{
					l1.SetText(XStringDefineProxy.GetString("GUILD_ARENA_BLUE", new object[]
					{
						battle.killerName
					}));
					l2.SetText(XStringDefineProxy.GetString("GUILD_ARENA_RED", new object[]
					{
						battle.deadName
					}));
				}
				else
				{
					l1.SetText(XStringDefineProxy.GetString("GUILD_ARENA_RED", new object[]
					{
						battle.killerName
					}));
					l2.SetText(XStringDefineProxy.GetString("GUILD_ARENA_BLUE", new object[]
					{
						battle.deadName
					}));
				}
			}
		}

		// Token: 0x0600F6C1 RID: 63169 RVA: 0x003806E6 File Offset: 0x0037E8E6
		public void HideKillInfo()
		{
			base.uiBehaviour.m_killer.gameObject.transform.parent.localPosition = XGameUI.Far_Far_Away;
		}

		// Token: 0x0600F6C2 RID: 63170 RVA: 0x0038070E File Offset: 0x0037E90E
		public void HideAll()
		{
			this.HideConKill();
			this.HideAssit();
		}

		// Token: 0x0600F6C3 RID: 63171 RVA: 0x00380720 File Offset: 0x0037E920
		public void HideConKill()
		{
			base.uiBehaviour.m_KillText.SetAlpha(0f);
			int num = 1;
			while ((long)num <= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL))
			{
				base.uiBehaviour.m_Killicon[num].gameObject.transform.localPosition = XGameUI.Far_Far_Away;
				num++;
			}
		}

		// Token: 0x0600F6C4 RID: 63172 RVA: 0x0038077F File Offset: 0x0037E97F
		public void HideAssit()
		{
			base.uiBehaviour.m_AssitIcon.gameObject.transform.localPosition = XGameUI.Far_Far_Away;
		}

		// Token: 0x0600F6C5 RID: 63173 RVA: 0x003807A4 File Offset: 0x0037E9A4
		public void ShowConKill(int count, bool isRevenge)
		{
			this._currShow = count;
			bool flag = count >= 0;
			if (flag)
			{
				this.HideAssit();
				this.m_conKillerTime.LeftTime = 3f;
				if (isRevenge)
				{
					base.uiBehaviour.m_KillText.SetAlpha(1f);
					base.uiBehaviour.m_KillText.SetSprite("revenge");
					base.uiBehaviour.m_KillText.MakePixelPerfect();
				}
				else
				{
					bool flag2 = count <= 1;
					if (flag2)
					{
						base.uiBehaviour.m_KillText.SetAlpha(0f);
					}
					else
					{
						base.uiBehaviour.m_KillText.SetAlpha(1f);
						string arg = (count >= 9) ? "9" : count.ToString();
						base.uiBehaviour.m_KillText.SetSprite(string.Format("{0}{1}", "kill", arg));
						base.uiBehaviour.m_KillText.MakePixelPerfect();
					}
				}
				bool flag3 = count > 0;
				if (flag3)
				{
					int num = (count >= 5) ? 5 : count;
					XSingleton<XAudioMgr>.singleton.PlayUISound(string.Format("Audio/VO/System/system{0}", num), true, AudioChannel.Action);
				}
				bool flag4 = (long)count >= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL);
				if (flag4)
				{
					count = (int)XBattleCaptainPVPDocument.CONTINUOUS_KILL;
				}
				int num2 = 1;
				while ((long)num2 <= (long)((ulong)XBattleCaptainPVPDocument.CONTINUOUS_KILL))
				{
					bool flag5 = num2 <= count;
					if (flag5)
					{
						base.uiBehaviour.m_Killicon[num2].gameObject.transform.localPosition = new Vector3((float)(((double)((float)(num2 - 1) + 0.5f) - (double)count / 2.0) * (double)XBattleCaptainPVPDocument.ConKillIconDis), 0f, 0f);
						base.uiBehaviour.m_Killicon[num2].PlayTween(true, -1f);
					}
					else
					{
						base.uiBehaviour.m_Killicon[num2].gameObject.transform.localPosition = XGameUI.Far_Far_Away;
					}
					num2++;
				}
			}
			else
			{
				this.m_conKillerTime.LeftTime = 2f;
				this.HideConKill();
				base.uiBehaviour.m_AssitIcon.gameObject.transform.localPosition = Vector3.zero;
				base.uiBehaviour.m_AssitIcon.PlayTween(true, -1f);
			}
		}

		// Token: 0x0600F6C6 RID: 63174 RVA: 0x00380A18 File Offset: 0x0037EC18
		private bool IsRevenge(ulong deadID)
		{
			bool flag = this._curEnemy == deadID;
			bool flag2 = flag;
			if (flag2)
			{
				XBigMeleeEnemyChange @event = XEventPool<XBigMeleeEnemyChange>.GetEvent();
				XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(this._curEnemy);
				@event.isEnemy = false;
				@event.Firer = entityConsiderDeath;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.ClearRevenge();
			}
			return flag;
		}

		// Token: 0x0600F6C7 RID: 63175 RVA: 0x00380A78 File Offset: 0x0037EC78
		private void ChangeEnemy(ulong KillID)
		{
			XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(KillID);
			bool isRole = entityConsiderDeath.IsRole;
			if (isRole)
			{
				XBigMeleeEnemyChange @event = XEventPool<XBigMeleeEnemyChange>.GetEvent();
				XEntity entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(this._curEnemy);
				@event.isEnemy = false;
				@event.Firer = entityConsiderDeath2;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				entityConsiderDeath2 = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(KillID);
				@event.isEnemy = true;
				@event.Firer = entityConsiderDeath2;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this._curEnemy = KillID;
			}
		}

		// Token: 0x0600F6C8 RID: 63176 RVA: 0x00380AFE File Offset: 0x0037ECFE
		public void ClearRevenge()
		{
			this._curEnemy = 0UL;
		}

		// Token: 0x04006B34 RID: 27444
		private XElapseTimer m_conKillerTime = new XElapseTimer();

		// Token: 0x04006B35 RID: 27445
		private XElapseTimer m_battleKiller = new XElapseTimer();

		// Token: 0x04006B36 RID: 27446
		private Queue<GVGBattleSkill> _waitQueue = new Queue<GVGBattleSkill>();

		// Token: 0x04006B37 RID: 27447
		private GVGBattleSkill m_battleSkillTemp;

		// Token: 0x04006B38 RID: 27448
		private KillInfoMode _mode;

		// Token: 0x04006B39 RID: 27449
		public Queue<GVGBattleSkill> _showqueue = new Queue<GVGBattleSkill>();

		// Token: 0x04006B3A RID: 27450
		private static readonly uint MULTIPLESHOWMAX = 5U;

		// Token: 0x04006B3B RID: 27451
		private static readonly float EACHSHOWTIME = 5f;

		// Token: 0x04006B3C RID: 27452
		private List<IXUILabel> _killLabelList = new List<IXUILabel>();

		// Token: 0x04006B3D RID: 27453
		private XUIPool _killInfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006B3E RID: 27454
		private MyBattleKillInfo myInfoTemp = new MyBattleKillInfo();

		// Token: 0x04006B3F RID: 27455
		private Queue<MyBattleKillInfo> _killOrAssitQueue = new Queue<MyBattleKillInfo>();

		// Token: 0x04006B40 RID: 27456
		private int _currShow;

		// Token: 0x04006B41 RID: 27457
		private bool _isRevengePlay = false;

		// Token: 0x04006B42 RID: 27458
		private ulong _curEnemy = 0UL;
	}
}
