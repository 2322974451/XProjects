using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001729 RID: 5929
	internal class XBattleEnemyInfoHandler : DlgHandlerBase
	{
		// Token: 0x170037B4 RID: 14260
		// (get) Token: 0x0600F4D2 RID: 62674 RVA: 0x003710DC File Offset: 0x0036F2DC
		public List<XBattleEnemyInfo> EnemyList
		{
			get
			{
				return this.m_EnemyList;
			}
		}

		// Token: 0x0600F4D3 RID: 62675 RVA: 0x003710F4 File Offset: 0x0036F2F4
		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.FindChild("BossInfo");
			this.m_BossPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			transform = base.PanelObject.transform.FindChild("RoleInfo");
			this.m_RolePool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			XBattleEnemyInfo.fNotBeHitTime = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("BossNotBeHitTime"));
		}

		// Token: 0x0600F4D4 RID: 62676 RVA: 0x0037118C File Offset: 0x0036F38C
		public override void OnUnload()
		{
			for (int i = 0; i < this.m_EnemyList.Count; i++)
			{
				this.m_EnemyList[i].Unload();
			}
			base.OnUnload();
		}

		// Token: 0x0600F4D5 RID: 62677 RVA: 0x003711CF File Offset: 0x0036F3CF
		public void InitBoss()
		{
			this.m_Type = BattleEnemyType.BET_BOSS;
			this._Init();
		}

		// Token: 0x0600F4D6 RID: 62678 RVA: 0x003711E0 File Offset: 0x0036F3E0
		public void InitRole()
		{
			this.m_Type = BattleEnemyType.BET_ROLE;
			this._Init();
		}

		// Token: 0x0600F4D7 RID: 62679 RVA: 0x003711F4 File Offset: 0x0036F3F4
		private void _Init()
		{
			for (int i = 0; i < this.m_EnemyList.Count; i++)
			{
				this.m_EnemyList[i].Unload();
			}
			this.m_EnemyList.Clear();
			this.m_BossPool.ReturnAll(false);
			this.m_RolePool.ReturnAll(false);
			XBattleEnemyInfo.bShow = false;
			this.m_MainTargetIndex = -1;
		}

		// Token: 0x0600F4D8 RID: 62680 RVA: 0x00371264 File Offset: 0x0036F464
		private XBattleEnemyInfo _CreateEnemy()
		{
			GameObject go = null;
			bool flag = this.m_CurUICount < this.m_MaxUICount;
			if (flag)
			{
				bool flag2 = this.m_Type == BattleEnemyType.BET_BOSS;
				if (flag2)
				{
					go = this.m_BossPool.FetchGameObject(false);
				}
				else
				{
					go = this.m_RolePool.FetchGameObject(false);
				}
				this.m_CurUICount++;
			}
			XBattleEnemyInfo xbattleEnemyInfo = new XBattleEnemyInfo(this.m_EnemyList.Count, go, this.m_Type);
			this.m_EnemyList.Add(xbattleEnemyInfo);
			return xbattleEnemyInfo;
		}

		// Token: 0x0600F4D9 RID: 62681 RVA: 0x003712EC File Offset: 0x0036F4EC
		private void _TryGetEnemy()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (!flag)
			{
				bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
				List<XEntity> opponent;
				if (bSpectator)
				{
					bool isPVPScene = XSingleton<XScene>.singleton.IsPVPScene;
					if (isPVPScene)
					{
						return;
					}
					opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player.WatchTo);
				}
				else
				{
					opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
				}
				for (int i = 0; i < opponent.Count; i++)
				{
					bool flag2 = this.m_Type == BattleEnemyType.BET_BOSS && !opponent[i].IsBoss;
					if (!flag2)
					{
						bool flag3 = this.m_Type == BattleEnemyType.BET_ROLE && !opponent[i].IsBoss && !opponent[i].IsRole;
						if (!flag3)
						{
							bool flag4 = opponent[i].IsDead || opponent[i].Deprecated;
							if (!flag4)
							{
								ulong id = opponent[i].ID;
								int j;
								for (j = 0; j < this.m_EnemyList.Count; j++)
								{
									bool flag5 = this.m_EnemyList[j].Entity == opponent[i];
									if (flag5)
									{
										break;
									}
								}
								bool flag6 = j == this.m_EnemyList.Count;
								if (flag6)
								{
									XBattleEnemyInfo xbattleEnemyInfo = this._CreateEnemy();
									xbattleEnemyInfo.Entity = opponent[i];
									xbattleEnemyInfo.SetPosition(false);
									xbattleEnemyInfo.RefreshBuff();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F4DA RID: 62682 RVA: 0x003714A8 File Offset: 0x0036F6A8
		public override void OnUpdate()
		{
			bool flag = !this.active;
			if (!flag)
			{
				base.OnUpdate();
				this._RemoveDisappearEnemies();
				this._TryGetEnemy();
				for (int i = 0; i < this.m_EnemyList.Count; i++)
				{
					this.m_EnemyList[i].SetVisible(XBattleEnemyInfo.bShow);
				}
				bool flag2 = this.m_MainTargetIndex < 0 && XBattleEnemyInfo.bShow;
				if (flag2)
				{
					this._UpdateMainTarget(true);
				}
				for (int j = 0; j < this.m_EnemyList.Count; j++)
				{
					this.m_EnemyList[j].Update();
				}
				this._UpdateMainTarget(false);
			}
		}

		// Token: 0x0600F4DB RID: 62683 RVA: 0x0037156C File Offset: 0x0036F76C
		private void _DestroyEnemy(int index)
		{
			XBattleEnemyInfo xbattleEnemyInfo = this.m_EnemyList[index];
			bool flag = xbattleEnemyInfo.m_Go != null;
			if (flag)
			{
				bool flag2 = this.m_Type == BattleEnemyType.BET_BOSS;
				if (flag2)
				{
					this.m_BossPool.ReturnInstance(xbattleEnemyInfo.m_Go, false);
				}
				else
				{
					this.m_RolePool.ReturnInstance(xbattleEnemyInfo.m_Go, false);
				}
				this.m_CurUICount--;
			}
			int sequenceNum = xbattleEnemyInfo.SequenceNum;
			xbattleEnemyInfo.Unload();
			this.m_EnemyList.RemoveAt(index);
			for (int i = 0; i < this.m_EnemyList.Count; i++)
			{
				bool flag3 = this.m_EnemyList[i].SequenceNum > sequenceNum;
				if (flag3)
				{
					XBattleEnemyInfo xbattleEnemyInfo2 = this.m_EnemyList[i];
					int sequenceNum2 = xbattleEnemyInfo2.SequenceNum - 1;
					xbattleEnemyInfo2.SequenceNum = sequenceNum2;
				}
			}
			bool flag4 = this.m_MainTargetIndex == index;
			if (flag4)
			{
				this.m_MainTargetIndex = -1;
			}
			else
			{
				bool flag5 = this.m_MainTargetIndex > index;
				if (flag5)
				{
					this.m_MainTargetIndex--;
				}
			}
		}

		// Token: 0x0600F4DC RID: 62684 RVA: 0x00371688 File Offset: 0x0036F888
		private void _RemoveDisappearEnemies()
		{
			bool flag = false;
			for (int i = this.m_EnemyList.Count - 1; i >= 0; i--)
			{
				bool deprecated = this.m_EnemyList[i].Entity.Deprecated;
				if (deprecated)
				{
					this._DestroyEnemy(i);
					flag = true;
				}
			}
			bool flag2 = flag;
			if (flag2)
			{
				for (int j = 0; j < this.m_EnemyList.Count; j++)
				{
					bool flag3 = this.m_EnemyList[j].m_Go == null && this.m_CurUICount < this.m_MaxUICount;
					if (flag3)
					{
						bool flag4 = this.m_Type == BattleEnemyType.BET_BOSS;
						GameObject go;
						if (flag4)
						{
							go = this.m_BossPool.FetchGameObject(false);
						}
						else
						{
							go = this.m_RolePool.FetchGameObject(false);
						}
						this.m_CurUICount++;
						this.m_EnemyList[j].AttachUI(go);
					}
					this.m_EnemyList[j].SetPosition(false);
				}
			}
			bool flag5 = this.m_EnemyList.Count == 0;
			if (flag5)
			{
				XBattleEnemyInfo.bShow = false;
			}
		}

		// Token: 0x0600F4DD RID: 62685 RVA: 0x003717C8 File Offset: 0x0036F9C8
		private void _UpdateMainTarget(bool bInit)
		{
			bool flag = !bInit && this.m_MainTargetIndex < 0;
			if (!flag)
			{
				if (bInit)
				{
					this.m_MainTargetIndex = 0;
					this._FindMainTarget(true);
				}
				else
				{
					this._FindMainTarget(this.m_EnemyList[this.m_MainTargetIndex].bNotBeHitRecently);
				}
				bool flag2 = this.m_NextMainTargetIndex == -1;
				if (!flag2)
				{
					XBattleEnemyInfoHandler.SwapRes swapRes = this._SwapSequence(this.m_MainTargetIndex, this.m_NextMainTargetIndex);
					bool flag3 = swapRes == XBattleEnemyInfoHandler.SwapRes.Success;
					if (flag3)
					{
						this.m_EnemyList[this.m_MainTargetIndex].SetPosition(true);
						this.m_EnemyList[this.m_NextMainTargetIndex].SetPosition(true);
						this.m_MainTargetIndex = this.m_NextMainTargetIndex;
					}
					else
					{
						bool flag4 = swapRes == XBattleEnemyInfoHandler.SwapRes.NoUI;
						if (flag4)
						{
						}
					}
				}
			}
		}

		// Token: 0x0600F4DE RID: 62686 RVA: 0x003718A0 File Offset: 0x0036FAA0
		private void _FindMainTarget(bool bForceFind = false)
		{
			this.m_NextMainTargetIndex = -1;
			bool flag = bForceFind || this.m_MainTargetIndex < 0;
			float fMainTargetHitTime = 0f;
			bool flag2 = this.m_MainTargetIndex >= 0;
			if (flag2)
			{
				XEntity entity = this.m_EnemyList[this.m_MainTargetIndex].Entity;
				bool flag3 = entity != null && entity.IsDead;
				if (flag3)
				{
					flag = true;
					fMainTargetHitTime = this.m_EnemyList[this.m_MainTargetIndex].HitTime - XBattleEnemyInfo.fNotBeHitTime + 1.5f;
				}
				else
				{
					fMainTargetHitTime = this.m_EnemyList[this.m_MainTargetIndex].HitTime;
				}
			}
			bool flag4 = flag;
			if (flag4)
			{
				for (int i = 0; i < this.m_EnemyList.Count; i++)
				{
					bool flag5 = this.m_EnemyList[i].IsRecentlyHit(fMainTargetHitTime) && this.m_EnemyList[i].Entity != null && !this.m_EnemyList[i].Entity.IsDead;
					if (flag5)
					{
						this.m_NextMainTargetIndex = i;
						break;
					}
				}
			}
		}

		// Token: 0x0600F4DF RID: 62687 RVA: 0x003719CC File Offset: 0x0036FBCC
		private XBattleEnemyInfoHandler.SwapRes _SwapSequence(int oneIndex, int otherIndex)
		{
			bool flag = oneIndex == otherIndex || oneIndex < 0 || otherIndex < 0 || oneIndex >= this.m_EnemyList.Count || otherIndex >= this.m_EnemyList.Count;
			XBattleEnemyInfoHandler.SwapRes result;
			if (flag)
			{
				result = XBattleEnemyInfoHandler.SwapRes.Fail;
			}
			else
			{
				bool flag2 = this.m_EnemyList[oneIndex].m_Go == null || this.m_EnemyList[otherIndex].m_Go == null;
				if (flag2)
				{
					this.m_EnemyList[oneIndex].SwapData(this.m_EnemyList[otherIndex]);
					result = XBattleEnemyInfoHandler.SwapRes.NoUI;
				}
				else
				{
					int sequenceNum = this.m_EnemyList[oneIndex].SequenceNum;
					this.m_EnemyList[oneIndex].SequenceNum = this.m_EnemyList[otherIndex].SequenceNum;
					this.m_EnemyList[otherIndex].SequenceNum = sequenceNum;
					result = XBattleEnemyInfoHandler.SwapRes.Success;
				}
			}
			return result;
		}

		// Token: 0x0600F4E0 RID: 62688 RVA: 0x00371ABC File Offset: 0x0036FCBC
		public void OnBuffChange(ulong uid)
		{
			for (int i = 0; i < this.m_EnemyList.Count; i++)
			{
				bool flag = this.m_EnemyList[i].Entity.ID == uid;
				if (flag)
				{
					this.m_EnemyList[i].RefreshBuff();
					break;
				}
			}
		}

		// Token: 0x040069B4 RID: 27060
		private int m_MainTargetIndex = -1;

		// Token: 0x040069B5 RID: 27061
		private int m_NextMainTargetIndex = -1;

		// Token: 0x040069B6 RID: 27062
		private BattleEnemyType m_Type;

		// Token: 0x040069B7 RID: 27063
		private XUIPool m_BossPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040069B8 RID: 27064
		private XUIPool m_RolePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040069B9 RID: 27065
		private List<XBattleEnemyInfo> m_EnemyList = new List<XBattleEnemyInfo>();

		// Token: 0x040069BA RID: 27066
		private int m_CurUICount = 0;

		// Token: 0x040069BB RID: 27067
		private int m_MaxUICount = 3;

		// Token: 0x02001A07 RID: 6663
		private enum SwapRes
		{
			// Token: 0x04008208 RID: 33288
			Success,
			// Token: 0x04008209 RID: 33289
			Fail,
			// Token: 0x0400820A RID: 33290
			NoUI
		}
	}
}
