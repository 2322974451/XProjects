using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009B0 RID: 2480
	internal class XLevelUpStatusDocument : XDocComponent
	{
		// Token: 0x17002D45 RID: 11589
		// (get) Token: 0x06009639 RID: 38457 RVA: 0x0016A6E4 File Offset: 0x001688E4
		public override uint ID
		{
			get
			{
				return XLevelUpStatusDocument.uuID;
			}
		}

		// Token: 0x17002D46 RID: 11590
		// (get) Token: 0x0600963A RID: 38458 RVA: 0x0016A6FC File Offset: 0x001688FC
		// (set) Token: 0x0600963B RID: 38459 RVA: 0x0016A714 File Offset: 0x00168914
		public bool bBlock
		{
			get
			{
				return this._bBlock;
			}
			set
			{
				this._bBlock = value;
				bool flag = !this._bBlock;
				if (flag)
				{
					this.CheckLevelUp();
				}
			}
		}

		// Token: 0x17002D47 RID: 11591
		// (get) Token: 0x0600963C RID: 38460 RVA: 0x0016A740 File Offset: 0x00168940
		public List<uint> NewSkillID
		{
			get
			{
				return this._newSkillID;
			}
		}

		// Token: 0x17002D48 RID: 11592
		// (get) Token: 0x0600963D RID: 38461 RVA: 0x0016A758 File Offset: 0x00168958
		// (set) Token: 0x0600963E RID: 38462 RVA: 0x0016A770 File Offset: 0x00168970
		public uint CurLevel
		{
			get
			{
				return this._CurLevel;
			}
			set
			{
				this._CurLevel = value;
			}
		}

		// Token: 0x17002D49 RID: 11593
		// (get) Token: 0x0600963F RID: 38463 RVA: 0x0016A77C File Offset: 0x0016897C
		// (set) Token: 0x06009640 RID: 38464 RVA: 0x0016A794 File Offset: 0x00168994
		public uint PreLevel
		{
			get
			{
				return this._PreLevel;
			}
			set
			{
				this._PreLevel = value;
			}
		}

		// Token: 0x17002D4A RID: 11594
		// (get) Token: 0x06009641 RID: 38465 RVA: 0x0016A7A0 File Offset: 0x001689A0
		// (set) Token: 0x06009642 RID: 38466 RVA: 0x0016A7B8 File Offset: 0x001689B8
		public List<uint> AttrID
		{
			get
			{
				return this._AttrID;
			}
			set
			{
				this._AttrID = value;
			}
		}

		// Token: 0x17002D4B RID: 11595
		// (get) Token: 0x06009643 RID: 38467 RVA: 0x0016A7C4 File Offset: 0x001689C4
		// (set) Token: 0x06009644 RID: 38468 RVA: 0x0016A7DC File Offset: 0x001689DC
		public List<uint> AttrOldValue
		{
			get
			{
				return this._AttrOldValue;
			}
			set
			{
				this._AttrOldValue = value;
			}
		}

		// Token: 0x17002D4C RID: 11596
		// (get) Token: 0x06009645 RID: 38469 RVA: 0x0016A7E8 File Offset: 0x001689E8
		// (set) Token: 0x06009646 RID: 38470 RVA: 0x0016A800 File Offset: 0x00168A00
		public List<uint> AttrNewValue
		{
			get
			{
				return this._AttrNewValue;
			}
			set
			{
				this._AttrNewValue = value;
			}
		}

		// Token: 0x17002D4D RID: 11597
		// (get) Token: 0x06009647 RID: 38471 RVA: 0x0016A80A File Offset: 0x00168A0A
		// (set) Token: 0x06009648 RID: 38472 RVA: 0x0016A812 File Offset: 0x00168A12
		public ulong Exp { get; set; }

		// Token: 0x17002D4E RID: 11598
		// (get) Token: 0x06009649 RID: 38473 RVA: 0x0016A81B File Offset: 0x00168A1B
		// (set) Token: 0x0600964A RID: 38474 RVA: 0x0016A823 File Offset: 0x00168A23
		public ulong MaxExp { get; set; }

		// Token: 0x0600964B RID: 38475 RVA: 0x0016A82C File Offset: 0x00168A2C
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.CurLevel = 0U;
			this.PreLevel = 0U;
		}

		// Token: 0x0600964C RID: 38476 RVA: 0x0014E32B File Offset: 0x0014C52B
		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		// Token: 0x0600964D RID: 38477 RVA: 0x0016A847 File Offset: 0x00168A47
		public override void OnEnterSceneFinally()
		{
			this._bBlock = false;
			XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.ShowLevelUp), null);
		}

		// Token: 0x0600964E RID: 38478 RVA: 0x0016A870 File Offset: 0x00168A70
		public void CheckLevelUp()
		{
			bool bBlock = this._bBlock;
			if (!bBlock)
			{
				bool flag = (this.CurLevel == this.PreLevel && this.CurLevel == 0U) || XSingleton<XEntityMgr>.singleton.Player == null;
				if (!flag)
				{
					XRole player = XSingleton<XEntityMgr>.singleton.Player;
					bool flag2 = (this.CurLevel != this.PreLevel || player.Attributes.Exp != this.Exp) && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
					if (flag2)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetGetExpAnimation(this.CalGetExp(player.Attributes.Exp), XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position);
					}
					player.Attributes.Level = this.CurLevel;
					player.Attributes.Exp = this.Exp;
					player.Attributes.MaxExp = this.MaxExp;
					bool flag3 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetExp(XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes);
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetLevel(this.CurLevel);
						DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(true);
						bool flag4 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._yuyinHandler != null;
						if (flag4)
						{
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._yuyinHandler.Refresh((XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL) ? YuyinIconType.Hall : YuyinIconType.Guild);
						}
					}
					bool flag5 = DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.IsVisible();
					if (flag5)
					{
						DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetExp();
					}
					bool flag6 = this.CurLevel > this.PreLevel;
					if (flag6)
					{
						XSingleton<XFxMgr>.singleton.CreateAndPlay(XSingleton<XGlobalConfig>.singleton.GetValue("LevelupFx"), player.MoveObj, Vector3.zero, Vector3.one, 1f, true, 5f, true);
						this.SetLevelUpStatus();
						XPlayerLevelChangedEventArgs @event = XEventPool<XPlayerLevelChangedEventArgs>.GetEvent();
						@event.level = this.CurLevel;
						@event.PreLevel = this.PreLevel;
						@event.Firer = XSingleton<XGame>.singleton.Doc;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
						XSingleton<XGameSysMgr>.singleton.OnLevelChanged(this._CurLevel);
						DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.OnPlayerLevelUp();
						bool flag7 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
						if (flag7)
						{
							DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.OnLevelChange();
						}
					}
				}
			}
		}

		// Token: 0x0600964F RID: 38479 RVA: 0x0016AAD0 File Offset: 0x00168CD0
		public void SetLevelUpStatus()
		{
			bool flag = (ulong)this.CurLevel >= (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("ShowLevelUpLimit"));
			if (flag)
			{
				this.Show = true;
				this.ShowLevelUp(null);
			}
		}

		// Token: 0x06009650 RID: 38480 RVA: 0x0016AB10 File Offset: 0x00168D10
		public void LevelRewardShowLevelUp()
		{
			bool show = this.Show;
			if (show)
			{
				bool flag = !DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>.singleton.SetVisible(true, true);
				}
				this.RefreshNewSkillID();
				DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>.singleton.ShowLevelUpStatus();
				this.Show = false;
			}
		}

		// Token: 0x06009651 RID: 38481 RVA: 0x0016AB64 File Offset: 0x00168D64
		public void ShowLevelUp(object o = null)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall && this.Show;
			if (flag)
			{
				bool flag2 = !DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>.singleton.SetVisible(true, true);
				}
				this.RefreshNewSkillID();
				DlgBase<XLevelUpStatusView, XLevelUpStatusBehaviour>.singleton.ShowLevelUpStatus();
				this.Show = false;
			}
		}

		// Token: 0x06009652 RID: 38482 RVA: 0x0016ABCC File Offset: 0x00168DCC
		public void RefreshNewSkillID()
		{
			this._newSkillID.Clear();
			int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession);
			int num2 = num % 10;
			int num3 = (num > 10) ? (num % 100) : 0;
			int num4 = (num > 100) ? (num % 1000) : 0;
			int num5 = (num > 1000) ? (num % 10000) : 0;
			bool flag = num2 > 0;
			if (flag)
			{
				List<uint> profSkillID = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num2);
				for (int i = 0; i < profSkillID.Count; i++)
				{
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID[i], 0U);
					bool flag2 = (uint)skillConfig.UpReqRoleLevel[0] == this.CurLevel;
					if (flag2)
					{
						this._newSkillID.Add(profSkillID[i]);
					}
				}
			}
			bool flag3 = num3 > 0;
			if (flag3)
			{
				List<uint> profSkillID2 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num3);
				for (int j = 0; j < profSkillID2.Count; j++)
				{
					SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID2[j], 0U);
					bool flag4 = (uint)skillConfig2.UpReqRoleLevel[0] == this.CurLevel;
					if (flag4)
					{
						this._newSkillID.Add(profSkillID2[j]);
					}
				}
			}
			bool flag5 = num4 > 0;
			if (flag5)
			{
				List<uint> profSkillID3 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num4);
				for (int k = 0; k < profSkillID3.Count; k++)
				{
					SkillList.RowData skillConfig3 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID3[k], 0U);
					bool flag6 = (uint)skillConfig3.UpReqRoleLevel[0] == this.CurLevel;
					if (flag6)
					{
						this._newSkillID.Add(profSkillID3[k]);
					}
				}
			}
			bool flag7 = num5 > 0;
			if (flag7)
			{
				List<uint> profSkillID4 = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID(num5);
				for (int l = 0; l < profSkillID4.Count; l++)
				{
					SkillList.RowData skillConfig4 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(profSkillID4[l], 0U);
					bool flag8 = (uint)skillConfig4.UpReqRoleLevel[0] == this.CurLevel;
					if (flag8)
					{
						this._newSkillID.Add(profSkillID4[l]);
					}
				}
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Skill, true);
		}

		// Token: 0x06009653 RID: 38483 RVA: 0x0016AE34 File Offset: 0x00169034
		private ulong CalGetExp(ulong preExp)
		{
			bool flag = this.PreLevel == this.CurLevel;
			ulong result;
			if (flag)
			{
				result = this.Exp - preExp;
			}
			else
			{
				ulong num = 0UL;
				PlayerLevelTable.RowData byLevel = XSingleton<XEntityMgr>.singleton.LevelTable.GetByLevel((int)(this.PreLevel + 1U));
				num += (ulong)(byLevel.Exp - (long)preExp);
				for (uint num2 = this.PreLevel + 1U; num2 < this.CurLevel; num2 += 1U)
				{
					byLevel = XSingleton<XEntityMgr>.singleton.LevelTable.GetByLevel((int)(num2 + 1U));
					num += (ulong)byLevel.Exp;
				}
				result = num + this.Exp;
			}
			return result;
		}

		// Token: 0x06009654 RID: 38484 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003313 RID: 13075
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LevelUpStatusDocument");

		// Token: 0x04003314 RID: 13076
		private uint _PreLevel;

		// Token: 0x04003315 RID: 13077
		private uint _CurLevel;

		// Token: 0x04003316 RID: 13078
		private List<uint> _AttrID = new List<uint>();

		// Token: 0x04003317 RID: 13079
		private List<uint> _AttrOldValue = new List<uint>();

		// Token: 0x04003318 RID: 13080
		private List<uint> _AttrNewValue = new List<uint>();

		// Token: 0x04003319 RID: 13081
		public List<uint> _newSkillID = new List<uint>();

		// Token: 0x0400331A RID: 13082
		private bool Show = false;

		// Token: 0x0400331B RID: 13083
		private bool _bBlock;
	}
}
