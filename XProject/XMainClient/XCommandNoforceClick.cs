using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DFA RID: 3578
	internal class XCommandNoforceClick : XBaseCommand
	{
		// Token: 0x0600C166 RID: 49510 RVA: 0x00292CD8 File Offset: 0x00290ED8
		public override bool Execute()
		{
			bool flag = this._cmd.param2 == "_canvas/SkillFrame/Skill0";
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.AlwaysHot(0, true);
				}
				XSingleton<XEntityMgr>.singleton.Player.Skill.EndSkill(true, false);
			}
			Transform transform = XSingleton<XGameUI>.singleton.UIRoot.FindChild(this._cmd.param1 + "(Clone)");
			bool flag3 = !transform || !transform.gameObject.activeInHierarchy;
			bool result;
			if (flag3)
			{
				result = false;
			}
			else
			{
				Transform transform2 = XSingleton<UiUtility>.singleton.FindChild(transform, this._cmd.param2);
				bool flag4 = transform2 == null || !transform2.gameObject.activeInHierarchy;
				if (flag4)
				{
					bool flag5 = transform2 == null && this._cmd.isOutError;
					if (flag5)
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
					this._startTime = Time.time;
					bool flag6 = this._finger == null;
					if (flag6)
					{
						this._finger = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/Quan", true, false) as GameObject);
					}
					bool flag7 = this._cmd.param3 != null;
					if (flag7)
					{
						float num = float.Parse(this._cmd.param3);
						bool flag8 = num >= 0f;
						if (flag8)
						{
							IXUISprite ixuisprite = this._finger.transform.FindChild("Quan1").GetComponent("XUISprite") as IXUISprite;
							this.orgWidth1 = ixuisprite.spriteWidth;
							this.orgHeight1 = ixuisprite.spriteHeight;
							ixuisprite.spriteWidth = (int)((float)ixuisprite.spriteWidth * num);
							ixuisprite.spriteHeight = (int)((float)ixuisprite.spriteHeight * num);
						}
					}
					bool flag9 = this._cmd.param4 != null;
					if (flag9)
					{
						float num2 = float.Parse(this._cmd.param4);
						bool flag10 = num2 >= 0f;
						if (flag10)
						{
							IXUISprite ixuisprite2 = this._finger.transform.FindChild("Quan2").GetComponent("XUISprite") as IXUISprite;
							this.orgWidth2 = ixuisprite2.spriteWidth;
							this.orgHeight2 = ixuisprite2.spriteHeight;
							ixuisprite2.spriteWidth = (int)((float)ixuisprite2.spriteWidth * num2);
							ixuisprite2.spriteHeight = (int)((float)ixuisprite2.spriteHeight * num2);
						}
					}
					IXUIObject ixuiobject = transform2.GetComponent("XUIObject") as IXUIObject;
					ixuiobject.Exculsive = true;
					XSingleton<UiUtility>.singleton.AddChild(transform2, this._finger.transform);
					bool flag11 = this._cmd.param5 == null;
					if (flag11)
					{
						this._cmd.param5 = "0";
					}
					bool flag12 = this._cmd.param6 == null;
					if (flag12)
					{
						this._cmd.param6 = "0";
					}
					this._finger.transform.localPosition += new Vector3(float.Parse(this._cmd.param5), float.Parse(this._cmd.param6), 0f);
					this._finger.SetActive(false);
					this._finger.SetActive(true);
					base.SetTutorialText(this._cmd.textPos, transform2);
					base.SetButtomText();
					base.SetAilin();
					bool pause = this._cmd.pause;
					if (pause)
					{
						XSingleton<XShell>.singleton.Pause = true;
					}
					XSingleton<XTutorialMgr>.singleton.NoforceClick = true;
					base.publicModule();
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600C167 RID: 49511 RVA: 0x001E3B34 File Offset: 0x001E1D34
		public override void OnFinish()
		{
			this.Stop();
		}

		// Token: 0x0600C168 RID: 49512 RVA: 0x0029312C File Offset: 0x0029132C
		public override void Stop()
		{
			bool flag = this._finger != null;
			if (flag)
			{
				bool flag2 = this._cmd.param3 != null;
				if (flag2)
				{
					IXUISprite ixuisprite = this._finger.transform.FindChild("Quan1").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.spriteWidth = this.orgWidth1;
					ixuisprite.spriteHeight = this.orgHeight1;
				}
				bool flag3 = this._cmd.param4 != null;
				if (flag3)
				{
					IXUISprite ixuisprite2 = this._finger.transform.FindChild("Quan2").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.spriteWidth = this.orgWidth2;
					ixuisprite2.spriteHeight = this.orgHeight2;
				}
				XResourceLoaderMgr.SafeDestroy(ref this._finger, false);
			}
			base.DestroyAilin();
			XSingleton<XShell>.singleton.Pause = false;
			XSingleton<XTutorialMgr>.singleton.NoforceClick = false;
			bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
			if (flag4)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.AlwaysHot(0, false);
			}
			base.Stop();
		}

		// Token: 0x04005184 RID: 20868
		private GameObject _finger;

		// Token: 0x04005185 RID: 20869
		private int orgWidth1;

		// Token: 0x04005186 RID: 20870
		private int orgHeight1;

		// Token: 0x04005187 RID: 20871
		private int orgWidth2;

		// Token: 0x04005188 RID: 20872
		private int orgHeight2;
	}
}
