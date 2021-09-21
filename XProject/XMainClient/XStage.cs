using System;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EEC RID: 3820
	public abstract class XStage
	{
		// Token: 0x0600CAD0 RID: 51920 RVA: 0x002E0784 File Offset: 0x002DE984
		public XStage(EXStage eStage)
		{
			this._eStage = eStage;
		}

		// Token: 0x0600CAD1 RID: 51921 RVA: 0x002E07A4 File Offset: 0x002DE9A4
		public static bool IsConcreteStage(EXStage stage)
		{
			return stage == EXStage.Hall || stage == EXStage.World;
		}

		// Token: 0x17003560 RID: 13664
		// (get) Token: 0x0600CAD2 RID: 51922 RVA: 0x002E07C4 File Offset: 0x002DE9C4
		public bool IsEntered
		{
			get
			{
				return this._entered;
			}
		}

		// Token: 0x0600CAD3 RID: 51923 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Play()
		{
		}

		// Token: 0x0600CAD4 RID: 51924 RVA: 0x002E07DC File Offset: 0x002DE9DC
		public virtual void OnEnterStage(EXStage eOld)
		{
			this._entered = true;
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
		}

		// Token: 0x0600CAD5 RID: 51925 RVA: 0x002E07F4 File Offset: 0x002DE9F4
		public virtual void OnLeaveStage(EXStage eNew)
		{
			this._entered = false;
			XSingleton<XCutScene>.singleton.Stop(true);
			XSingleton<XBulletMgr>.singleton.OnLeaveStage();
			XSingleton<UIManager>.singleton.CloseAllUI();
			XSingleton<XFxMgr>.singleton.OnLeaveStage();
			XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.luaUIManager.Clear();
			XSingleton<XTimerMgr>.singleton.KillTimerAll();
		}

		// Token: 0x17003561 RID: 13665
		// (get) Token: 0x0600CAD6 RID: 51926 RVA: 0x002E0858 File Offset: 0x002DEA58
		public EXStage Stage
		{
			get
			{
				return this._eStage;
			}
		}

		// Token: 0x0600CAD7 RID: 51927 RVA: 0x002E0870 File Offset: 0x002DEA70
		public virtual bool Initialize()
		{
			return true;
		}

		// Token: 0x0600CAD8 RID: 51928 RVA: 0x002E0883 File Offset: 0x002DEA83
		public virtual void PreUpdate(float fDeltaT)
		{
			XSingleton<XScene>.singleton.PreUpdate(fDeltaT);
		}

		// Token: 0x0600CAD9 RID: 51929 RVA: 0x002E0892 File Offset: 0x002DEA92
		public virtual void Update(float fDeltaT)
		{
			XSingleton<XScene>.singleton.Update(fDeltaT);
		}

		// Token: 0x0600CADA RID: 51930 RVA: 0x002E08A1 File Offset: 0x002DEAA1
		public void FixedUpdate()
		{
			XSingleton<XScene>.singleton.FixedUpdate();
		}

		// Token: 0x0600CADB RID: 51931 RVA: 0x002E08AF File Offset: 0x002DEAAF
		public virtual void PostUpdate(float fDeltaT)
		{
			XSingleton<XScene>.singleton.PostUpdate(fDeltaT);
		}

		// Token: 0x0600CADC RID: 51932 RVA: 0x002E08C0 File Offset: 0x002DEAC0
		public static T CreateSpecificStage<T>() where T : new()
		{
			return Activator.CreateInstance<T>();
		}

		// Token: 0x0600CADD RID: 51933 RVA: 0x002E08D7 File Offset: 0x002DEAD7
		public virtual void OnEnterScene(uint sceneid, bool transfer)
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraMotionComponent.uuID);
			XSingleton<XInput>.singleton.OnEnterScene();
		}

		// Token: 0x0600CADE RID: 51934 RVA: 0x002E0900 File Offset: 0x002DEB00
		public virtual void OnLeaveScene(bool transfer)
		{
			XSingleton<XEngineCommandMgr>.singleton.Clear();
			XSingleton<XEntityMgr>.singleton.OnLeaveScene();
			XSingleton<XComponentMgr>.singleton.ClearAll();
			XSingleton<XInput>.singleton.OnLeaveScene();
			XSingleton<XCutScene>.singleton.ClearCommon();
			XSingleton<UIManager>.singleton.OnLeaveScene(false);
			XSingleton<XItemDrawerMgr>.singleton.OnleaveScene();
			XSingleton<XSkillFactory>.singleton.OnLeaveScene();
		}

		// Token: 0x040059B4 RID: 22964
		protected EXStage _eStage = EXStage.Null;

		// Token: 0x040059B5 RID: 22965
		private bool _entered = false;
	}
}
