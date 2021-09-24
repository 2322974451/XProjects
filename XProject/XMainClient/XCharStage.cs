using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XCharStage : XStage
	{

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

		public override void OnEnterStage(EXStage eOld)
		{
			base.OnEnterStage(eOld);
			XSingleton<XGameUI>.singleton.LoadSelectCharUI(this._eStage);
			XQualitySetting.SetDofFade(0f);
			this._dofFade = 0f;
			this._setDofFade = false;
		}

		public override void OnLeaveStage(EXStage eNew)
		{
			base.OnLeaveStage(eNew);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token1);
			XSingleton<XGameUI>.singleton.UnLoadSelectCharUI();
		}

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

		public override void OnEnterScene(uint sceneid, bool transfer)
		{
			base.OnEnterScene(sceneid, transfer);
		}

		public void ShowCharacterTurn(int tag)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token1);
			XSingleton<XCutScene>.singleton.Start("CutScene/character_show_turn" + XCharStage.role_type[this._cur_tag], false, true);
			this._token1 = XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCutScene>.singleton.Length, new XTimerMgr.ElapsedEventHandler(this.OnPrelusiveDone), null);
			this._prelusive = true;
		}

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

		protected void OnPrelusiveDone(object o)
		{
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
			this.PrelusiveDone();
		}

		protected abstract void PrelusiveDone();

		protected static string[] role_type;

		private uint _token1 = 0U;

		protected int _cur_tag = 0;

		protected bool _prelusive = false;

		protected bool _auto_enter = false;

		private string[] open_profession = null;

		private float _dofFade = 0f;

		private bool _setDofFade = false;
	}
}
