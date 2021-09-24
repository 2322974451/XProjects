using System;
using System.Reflection;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandNewIcon : XBaseCommand
	{

		public override bool Execute()
		{
			base.publicModule();
			return this._execute(this._cmd.param1, this._cmd.param2);
		}

		public override void OnFinish()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			base.OnFinish();
		}

		public bool _execute(string param1, string param2)
		{
			this.CachedOpenSystem = uint.Parse(param1);
			XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
			bool flag = xplayerAttributes.IsSystemOpened(this.CachedOpenSystem);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !XSingleton<XTutorialHelper>.singleton.IsSysOpend(this.CachedOpenSystem);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = this.CachedOpenSystem > 0U;
					if (flag3)
					{
						string systemIcon = this.GetSystemIcon(this.CachedOpenSystem);
						XSingleton<XDebug>.singleton.AddLog("new icon executed", this.CachedOpenSystem.ToString(), ",", systemIcon, null, null, XDebugColor.XDebug_None);
						XResourceLoaderMgr.SafeDestroy(ref this._newicon, false);
						bool flag4 = this.CachedOpenSystem < 10U;
						if (flag4)
						{
							this._newicon = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/NewSkill", true, false) as GameObject);
						}
						else
						{
							this._newicon = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/NewIcon", true, false) as GameObject);
						}
						base.SetOverlay();
						IXUISprite ixuisprite = this._newicon.GetComponent("XUISprite") as IXUISprite;
						ixuisprite.spriteName = systemIcon;
						XSingleton<UiUtility>.singleton.AddChild(XBaseCommand._Overlay.transform, this._newicon.transform);
						IXUITweenTool ixuitweenTool = this._newicon.GetComponent("XUIPlayTween") as IXUITweenTool;
						ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnNewIconTweenFinished));
						bool flag5 = param1 != null && param1.Length > 0 && param2 != null && param2.Length > 0;
						if (flag5)
						{
							Type type = Type.GetType("XMainClient.UI." + param1);
							MethodInfo method = type.GetMethod("GetChildWorldPos", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
							Vector3 vector = (Vector3)method.Invoke(null, new object[]
							{
								param2
							});
							Vector3 to = XSingleton<XGameUI>.singleton.UIRoot.InverseTransformPoint(vector);
							ixuitweenTool.SetPositionTweenPos(0, Vector3.zero, to);
						}
						else
						{
							Vector3 newIconFlyPosH = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.GetNewIconFlyPosH1((XSysDefine)this.CachedOpenSystem);
							ixuitweenTool.SetPositionTweenPos(0, Vector3.zero, newIconFlyPosH);
						}
						ixuitweenTool.SetTargetGameObject(this._newicon);
						ixuitweenTool.PlayTween(true, -1f);
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.ForceOpenSysIcons((XSysDefine)this.CachedOpenSystem);
						XSingleton<XTutorialMgr>.singleton.Exculsive = true;
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		protected string GetSystemIcon(uint sysID)
		{
			bool flag = sysID < 10U;
			string result;
			if (flag)
			{
				RoleType profession = XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession;
				string str = XSingleton<UiUtility>.singleton.RoleTypeToString(profession) + "_B" + sysID;
				uint skillHash = XSingleton<XCommon>.singleton.XHash(str);
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillHash, 1U);
				result = skillConfig.Icon;
			}
			else
			{
				result = XSingleton<XGameSysMgr>.singleton.GetSysIcon((int)sysID);
			}
			return result;
		}

		protected void OnNewIconTweenFinished(IXUITweenTool tween)
		{
			XResourceLoaderMgr.SafeDestroy(ref this._newicon, false);
			(XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes).ReallyOpenSystem(this.CachedOpenSystem);
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSysChange((XSysDefine)this.CachedOpenSystem);
			}
		}

		public override void Stop()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._newicon, false);
			base.Stop();
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
		}

		private GameObject _newicon = null;

		private uint CachedOpenSystem;
	}
}
