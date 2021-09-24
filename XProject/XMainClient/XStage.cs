using System;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	public abstract class XStage
	{

		public XStage(EXStage eStage)
		{
			this._eStage = eStage;
		}

		public static bool IsConcreteStage(EXStage stage)
		{
			return stage == EXStage.Hall || stage == EXStage.World;
		}

		public bool IsEntered
		{
			get
			{
				return this._entered;
			}
		}

		public virtual void Play()
		{
		}

		public virtual void OnEnterStage(EXStage eOld)
		{
			this._entered = true;
			XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
		}

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

		public EXStage Stage
		{
			get
			{
				return this._eStage;
			}
		}

		public virtual bool Initialize()
		{
			return true;
		}

		public virtual void PreUpdate(float fDeltaT)
		{
			XSingleton<XScene>.singleton.PreUpdate(fDeltaT);
		}

		public virtual void Update(float fDeltaT)
		{
			XSingleton<XScene>.singleton.Update(fDeltaT);
		}

		public void FixedUpdate()
		{
			XSingleton<XScene>.singleton.FixedUpdate();
		}

		public virtual void PostUpdate(float fDeltaT)
		{
			XSingleton<XScene>.singleton.PostUpdate(fDeltaT);
		}

		public static T CreateSpecificStage<T>() where T : new()
		{
			return Activator.CreateInstance<T>();
		}

		public virtual void OnEnterScene(uint sceneid, bool transfer)
		{
			XSingleton<XComponentMgr>.singleton.CreateComponent(XSingleton<XScene>.singleton.GameCamera, XCameraMotionComponent.uuID);
			XSingleton<XInput>.singleton.OnEnterScene();
		}

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

		protected EXStage _eStage = EXStage.Null;

		private bool _entered = false;
	}
}
