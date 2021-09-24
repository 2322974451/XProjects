using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandForceClick : XBaseCommand
	{

		public override bool Execute()
		{
			bool flag = this._cmd.param2 == "_canvas/SkillFrame/Skill1";
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.AlwaysHot(1, true);
				}
				XSingleton<XEntityMgr>.singleton.Player.Skill.EndSkill(true, false);
			}
			else
			{
				bool flag3 = this._cmd.param2 == "_canvas/SkillFrame/Skill3";
				if (flag3)
				{
					bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag4)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.AlwaysHot(3, true);
					}
					XSingleton<XEntityMgr>.singleton.Player.Skill.EndSkill(true, false);
				}
			}
			base.publicModule();
			return this._execute(this._cmd.param1, this._cmd.param2, true);
		}

		public override void Update()
		{
		}

		public override void OnFinish()
		{
			this._execute(this._cmd.param1, this._cmd.param2, false);
			bool flag = this._cmd.param2 == "_canvas/SkillFrame/Skill1" && XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				Vector3 forward = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Forward;
				bool flag2 = Vector3.Angle(forward, XSingleton<XEntityMgr>.singleton.Boss.EngineObject.Forward) > 135f;
				if (flag2)
				{
					XSingleton<XEntityMgr>.singleton.Player.Net.ReportRotateAction(XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, (float)(XSingleton<XCommon>.singleton.Clockwise(forward, XSingleton<XEntityMgr>.singleton.Boss.EngineObject.Forward) ? 90 : -90), true));
				}
			}
			base.OnFinish();
		}

		protected bool _execute(string param1, string param2, bool bExculsive)
		{
			Transform transform = XSingleton<XGameUI>.singleton.UIRoot.FindChild(this._cmd.param1 + "(Clone)");
			bool flag = !transform || !transform.gameObject.activeInHierarchy;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Transform transform2 = XSingleton<UiUtility>.singleton.FindChild(transform, this._cmd.param2);
				bool flag2 = transform2 == null || !transform2.gameObject.activeInHierarchy;
				if (flag2)
				{
					bool flag3 = transform2 == null && this._cmd.isOutError;
					if (flag3)
					{
						this._cmd.isOutError = false;
						XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
						{
							"TutorialId:",
							this._cmd.TutorialID,
							" Configuration File Path Error! tag:",
							this._cmd.tag,
							"\nPath:",
							this._cmd.param1,
							"(Clone)/",
							this._cmd.param2
						}), null, null, null, null, null);
					}
					result = false;
				}
				else
				{
					this._clickGo = transform2.gameObject;
					bool flag4 = this._cmd.interalDelay > 0f;
					if (flag4)
					{
						base.SetOverlay();
					}
					if (bExculsive)
					{
						this._time = XSingleton<XTimerMgr>.singleton.SetTimer(this._cmd.interalDelay, new XTimerMgr.ElapsedEventHandler(this.ShowFinger), null);
					}
					else
					{
						this.Stop();
					}
					result = true;
				}
			}
			return result;
		}

		public override void Stop()
		{
			bool flag = this._time > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._time);
				this._time = 0U;
			}
			bool flag2 = this._finger != null;
			if (flag2)
			{
				bool flag3 = this._cmd.param3 != null;
				if (flag3)
				{
					IXUISprite ixuisprite = this._finger.transform.FindChild("Quan1").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.spriteWidth = this.orgWidth1;
					ixuisprite.spriteHeight = this.orgHeight1;
				}
				bool flag4 = this._cmd.param4 != null;
				if (flag4)
				{
					IXUISprite ixuisprite2 = this._finger.transform.FindChild("Quan2").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.spriteWidth = this.orgWidth2;
					ixuisprite2.spriteHeight = this.orgHeight2;
				}
				XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			}
			base.DestroyText();
			bool flag5 = this._cloneGo != null;
			if (flag5)
			{
				this._cloneGo.transform.parent = null;
				UnityEngine.Object.Destroy(this._cloneGo);
			}
			base.DestroyAilin();
			base.DestroyOverlay();
			bool flag6 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag6)
			{
				bool flag7 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag7)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.AlwaysHot(1, false);
				}
				bool flag8 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag8)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.AlwaysHot(3, false);
				}
			}
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		protected void ShowFinger(object o)
		{
			bool flag = this._finger == null;
			if (flag)
			{
				this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Quan", true, false) as GameObject);
			}
			this._finger.SetActive(false);
			bool flag2 = this._cmd.param3 != null;
			if (flag2)
			{
				float num = float.Parse(this._cmd.param3);
				bool flag3 = num >= 0f;
				if (flag3)
				{
					IXUISprite ixuisprite = this._finger.transform.FindChild("Quan1").GetComponent("XUISprite") as IXUISprite;
					this.orgWidth1 = ixuisprite.spriteWidth;
					this.orgHeight1 = ixuisprite.spriteHeight;
					ixuisprite.spriteWidth = (int)((float)ixuisprite.spriteWidth * num);
					ixuisprite.spriteHeight = (int)((float)ixuisprite.spriteHeight * num);
				}
			}
			bool flag4 = this._cmd.param4 != null;
			if (flag4)
			{
				float num2 = float.Parse(this._cmd.param4);
				bool flag5 = num2 >= 0f;
				if (flag5)
				{
					IXUISprite ixuisprite2 = this._finger.transform.FindChild("Quan2").GetComponent("XUISprite") as IXUISprite;
					this.orgWidth2 = ixuisprite2.spriteWidth;
					this.orgHeight2 = ixuisprite2.spriteHeight;
					ixuisprite2.spriteWidth = (int)((float)ixuisprite2.spriteWidth * num2);
					ixuisprite2.spriteHeight = (int)((float)ixuisprite2.spriteHeight * num2);
				}
			}
			base.SetOverlay();
			this._cloneGo = XCommon.Instantiate<GameObject>(this._clickGo.gameObject);
			this.SetupCloneButton(this._clickGo.gameObject, this._cloneGo);
			base.SetTutorialText(this._cmd.textPos, this._cloneGo.transform);
			base.SetAilin();
			bool pause = this._cmd.pause;
			if (pause)
			{
				XSingleton<XShell>.singleton.Pause = true;
			}
			XSingleton<XTutorialMgr>.singleton.Exculsive = true;
		}

		protected void SetupCloneButton(GameObject targetGo, GameObject cloneGo)
		{
			XSingleton<UiUtility>.singleton.AddChild(cloneGo.transform, this._finger.transform);
			bool flag = this._cmd.param5 == null;
			if (flag)
			{
				this._cmd.param5 = "0";
			}
			bool flag2 = this._cmd.param6 == null;
			if (flag2)
			{
				this._cmd.param6 = "0";
			}
			this._finger.transform.localPosition += new Vector3(float.Parse(this._cmd.param5), float.Parse(this._cmd.param6), 0f);
			cloneGo.name = targetGo.name;
			IXUIObject ixuiobject = cloneGo.GetComponent("XUIObject") as IXUIObject;
			bool flag3 = ixuiobject == null;
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XUIObject No Find", null, null, null, null, null);
			}
			ixuiobject.Exculsive = true;
			cloneGo.transform.parent = XBaseCommand._Overlay.transform;
			XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(cloneGo);
			Vector3 position = targetGo.transform.position;
			Vector3 localPosition = XBaseCommand._Overlay.transform.InverseTransformPoint(position);
			localPosition.z = 0f;
			cloneGo.transform.localPosition = localPosition;
			cloneGo.transform.localScale = targetGo.transform.localScale;
			IXUICheckBox ixuicheckBox = targetGo.GetComponent("XUICheckBox") as IXUICheckBox;
			bool flag4 = ixuicheckBox != null;
			if (flag4)
			{
				IXUICheckBox ixuicheckBox2 = cloneGo.GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox2.ID = ixuicheckBox.ID;
				ixuicheckBox2.ForceSetFlag(false);
				ixuicheckBox2.RegisterOnCheckEventHandler(ixuicheckBox.GetCheckEventHandler());
			}
			IXUIButton ixuibutton = targetGo.GetComponent("XUIButton") as IXUIButton;
			bool flag5 = ixuibutton != null;
			if (flag5)
			{
				IXUIButton ixuibutton2 = cloneGo.GetComponent("XUIButton") as IXUIButton;
				ixuibutton2.ID = ixuibutton.ID;
				ixuibutton2.RegisterClickEventHandler(ixuibutton.GetClickEventHandler());
				ixuibutton2.RegisterPressEventHandler(ixuibutton.GetPressEventHandler());
				ixuibutton2.SetClickCD(2f);
				ixuibutton2.CloseScrollView();
				this._finger.SetActive(true);
			}
			else
			{
				IXUISprite ixuisprite = targetGo.GetComponent("XUISprite") as IXUISprite;
				bool flag6 = ixuisprite != null;
				if (flag6)
				{
					IXUISprite ixuisprite2 = cloneGo.GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = ixuisprite.ID;
					ixuisprite2.RegisterSpriteClickEventHandler(ixuisprite.GetSpriteClickHandler());
					ixuisprite2.RegisterSpritePressEventHandler(ixuisprite.GetSpritePressHandler());
					ixuisprite2.SetClickCD(2f);
					ixuisprite2.CloseScrollView();
					this._finger.SetActive(true);
				}
				else
				{
					IXUITexture ixuitexture = targetGo.GetComponent("XUITexture") as IXUITexture;
					bool flag7 = ixuitexture != null;
					if (flag7)
					{
						IXUITexture ixuitexture2 = cloneGo.GetComponent("XUITexture") as IXUITexture;
						ixuitexture2.ID = ixuitexture.ID;
						ixuitexture2.RegisterLabelClickEventHandler(ixuitexture.GetTextureClickHandler());
						ixuitexture2.SetClickCD(2f);
						ixuitexture2.CloseScrollView();
						this._finger.SetActive(true);
					}
				}
			}
		}

		private GameObject _finger;

		private GameObject _clickGo;

		private GameObject _cloneGo;

		private int orgWidth1;

		private int orgHeight1;

		private int orgWidth2;

		private int orgHeight2;

		private uint _time = 0U;
	}
}
