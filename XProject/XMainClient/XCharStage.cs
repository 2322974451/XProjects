using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D9D RID: 3485
	internal abstract class XCharStage : XStage
	{
		// Token: 0x0600BD80 RID: 48512 RVA: 0x00275F20 File Offset: 0x00274120
		public XCharStage(EXStage eStage) : base(eStage)
		{
			bool flag = XCharStage.role_type == null || XCharStage.role_type.Length != XGame.RoleCount + 1;
			if (flag)
			{
				XCharStage.role_type = new string[XGame.RoleCount + 1];
			}
			for (int i = 1; i <= XGame.RoleCount; i++)
			{
				XCharStage.role_type[i] = "_" + XSingleton<XProfessionSkillMgr>.singleton.GetLowerCaseWord((uint)i);
			}
		}

		// Token: 0x0600BD81 RID: 48513 RVA: 0x00275FD2 File Offset: 0x002741D2
		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
			XSingleton<XGameUI>.singleton.LoadSelectCharUI(this._eStage);
			XQualitySetting.SetDofFade(0f);
			this._dofFade = 0f;
			this._setDofFade = false;
		}

		// Token: 0x0600BD82 RID: 48514 RVA: 0x0027600B File Offset: 0x0027420B
		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token1);
			XSingleton<XGameUI>.singleton.UnLoadSelectCharUI();
		}

		// Token: 0x0600BD83 RID: 48515 RVA: 0x00276034 File Offset: 0x00274234
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			XSingleton<XLoginDocument>.singleton.Update();
			bool flag = this._setDofFade && this._dofFade < 1f;
			if (flag)
			{
				this._dofFade += fDeltaT;
				XQualitySetting.SetDofFade(this._dofFade);
			}
		}

		// Token: 0x0600BD84 RID: 48516 RVA: 0x0027608D File Offset: 0x0027428D
		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
		}

		// Token: 0x0600BD85 RID: 48517 RVA: 0x0027609C File Offset: 0x0027429C
		public void ShowCharacterTurn(int tag)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token1);
			XSingleton<XCutScene>.singleton.Start("CutScene/character_show_turn" + XCharStage.role_type[this._cur_tag], false, true);
			this._token1 = XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCutScene>.singleton.Length, new XTimerMgr.ElapsedEventHandler(this.OnPrelusiveDone), null);
			this._prelusive = true;
		}

		// Token: 0x0600BD86 RID: 48518 RVA: 0x0027610C File Offset: 0x0027430C
		public void ShowCharacter(int tag)
		{
			bool flag = tag == 0 || tag == this._cur_tag;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("Error Tag: ", tag.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				this._prelusive = false;
			}
			else
			{
				bool flag2 = tag - 1 >= XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("Character with tag ", tag.ToString(), " exceeded server PlayerBriefInfo count.", null, null, null, XDebugColor.XDebug_None);
				}
				else
				{
					bool flag3 = this.open_profession == null;
					if (flag3)
					{
						this.open_profession = XSingleton<XGlobalConfig>.singleton.GetValue("OpenProfession").Split(XGlobalConfig.ListSeparator);
					}
					bool flag4 = true;
					for (int i = 0; i < this.open_profession.Length; i++)
					{
						bool flag5 = int.Parse(this.open_profession[i]) == tag;
						if (flag5)
						{
							flag4 = false;
							break;
						}
					}
					bool flag6 = flag4;
					if (flag6)
					{
						this._prelusive = false;
					}
					else
					{
						bool flag7 = !this._setDofFade;
						if (flag7)
						{
							this._setDofFade = true;
						}
						XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(true);
						bool flag8 = !this._auto_enter;
						if (flag8)
						{
							XSingleton<XLoginDocument>.singleton.ShowSelectCharGerenalUI();
							DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.SwitchProfession(tag);
						}
						XSingleton<XTimerMgr>.singleton.KillTimer(this._token1);
						XSingleton<XCutScene>.singleton.Start("CutScene/character_select" + XCharStage.role_type[tag], false, true);
						this._token1 = XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCutScene>.singleton.Length, new XTimerMgr.ElapsedEventHandler(this.OnPrelusiveDone), null);
						this._cur_tag = tag;
						this._prelusive = true;
					}
				}
			}
		}

		// Token: 0x0600BD87 RID: 48519 RVA: 0x002762CB File Offset: 0x002744CB
		protected void OnPrelusiveDone(object o)
		{
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
			this.PrelusiveDone();
		}

		// Token: 0x0600BD88 RID: 48520
		protected abstract void PrelusiveDone();

		// Token: 0x04004D33 RID: 19763
		protected static string[] role_type;

		// Token: 0x04004D34 RID: 19764
		private uint _token1 = 0U;

		// Token: 0x04004D35 RID: 19765
		protected int _cur_tag = 0;

		// Token: 0x04004D36 RID: 19766
		protected bool _prelusive = false;

		// Token: 0x04004D37 RID: 19767
		protected bool _auto_enter = false;

		// Token: 0x04004D38 RID: 19768
		private string[] open_profession = null;

		// Token: 0x04004D39 RID: 19769
		private float _dofFade = 0f;

		// Token: 0x04004D3A RID: 19770
		private bool _setDofFade = false;
	}
}
