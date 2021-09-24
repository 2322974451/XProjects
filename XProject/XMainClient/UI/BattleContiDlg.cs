using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class BattleContiDlg : DlgBase<BattleContiDlg, BattleContiBehaviour>
	{

		public ulong CurEnemy
		{
			get
			{
				return this._curEnemy;
			}
		}

		public override string fileName
		{
			get
			{
				return "Battle/BattleKillInfo";
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

		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this.m_battleSkillTemp != null;
			if (flag)
			{
				this.SetBattleSkill(this.m_battleSkillTemp);
			}
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.UpdateBattleSkill();
			this.UpdateConKiller();
		}

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

		public void HideKillInfo()
		{
			base.uiBehaviour.m_killer.gameObject.transform.parent.localPosition = XGameUI.Far_Far_Away;
		}

		public void HideAll()
		{
			this.HideConKill();
			this.HideAssit();
		}

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

		public void HideAssit()
		{
			base.uiBehaviour.m_AssitIcon.gameObject.transform.localPosition = XGameUI.Far_Far_Away;
		}

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

		public void ClearRevenge()
		{
			this._curEnemy = 0UL;
		}

		private XElapseTimer m_conKillerTime = new XElapseTimer();

		private XElapseTimer m_battleKiller = new XElapseTimer();

		private Queue<GVGBattleSkill> _waitQueue = new Queue<GVGBattleSkill>();

		private GVGBattleSkill m_battleSkillTemp;

		private KillInfoMode _mode;

		public Queue<GVGBattleSkill> _showqueue = new Queue<GVGBattleSkill>();

		private static readonly uint MULTIPLESHOWMAX = 5U;

		private static readonly float EACHSHOWTIME = 5f;

		private List<IXUILabel> _killLabelList = new List<IXUILabel>();

		private XUIPool _killInfoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private MyBattleKillInfo myInfoTemp = new MyBattleKillInfo();

		private Queue<MyBattleKillInfo> _killOrAssitQueue = new Queue<MyBattleKillInfo>();

		private int _currShow;

		private bool _isRevengePlay = false;

		private ulong _curEnemy = 0UL;
	}
}
