using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelUpStatusDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XLevelUpStatusDocument.uuID;
			}
		}

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

		public List<uint> NewSkillID
		{
			get
			{
				return this._newSkillID;
			}
		}

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

		public ulong Exp { get; set; }

		public ulong MaxExp { get; set; }

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.CurLevel = 0U;
			this.PreLevel = 0U;
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
		}

		public override void OnEnterSceneFinally()
		{
			this._bBlock = false;
			XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.ShowLevelUp), null);
		}

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

		public void SetLevelUpStatus()
		{
			bool flag = (ulong)this.CurLevel >= (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("ShowLevelUpLimit"));
			if (flag)
			{
				this.Show = true;
				this.ShowLevelUp(null);
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("LevelUpStatusDocument");

		private uint _PreLevel;

		private uint _CurLevel;

		private List<uint> _AttrID = new List<uint>();

		private List<uint> _AttrOldValue = new List<uint>();

		private List<uint> _AttrNewValue = new List<uint>();

		public List<uint> _newSkillID = new List<uint>();

		private bool Show = false;

		private bool _bBlock;
	}
}
