using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using XUtliPoolLib;

namespace XUpdater
{

	public sealed class XShell : XSingleton<XShell>
	{

		public bool Pause
		{
			get
			{
				return this._bPause;
			}
			set
			{
				bool isDone = XSingleton<XUpdater>.singleton.IsDone;
				if (isDone)
				{
					this._bPauseTrigger = value;
				}
			}
		}

		public void PreLaunch()
		{
			this._entrance.Awake();
			bool flag = this._entrance != null;
			if (flag)
			{
				IPlatform xplatform = XSingleton<XUpdater>.singleton.XPlatform;
				bool flag2 = xplatform != null;
				if (flag2)
				{
					this._entrance.SetQualityLevel(xplatform.GetQualityLevel());
				}
			}
		}

		public void Launch()
		{
			this._entrance.Awake();
		}

		public bool Launched()
		{
			return this._entrance.Awaked;
		}

		public void StartGame()
		{
			this._entrance.Start();
		}

		public void Awake()
		{
			bool flag = !XSingleton<XUpdater>.singleton.IsDone;
			if (flag)
			{
				XSingleton<XUpdater>.singleton.Init();
			}
		}

		public void Start()
		{
			Screen.sleepTimeout = -1;
			Application.targetFrameRate = -1;
		}

		private void NetUpdate()
		{
			this._entrance.NetUpdate();
		}

		public void PreUpdate()
		{
			this.NetUpdate();
			bool pause = this.Pause;
			if (!pause)
			{
				this._entrance.PreUpdate();
			}
		}

		public void Update()
		{
			bool isDone = XSingleton<XUpdater>.singleton.IsDone;
			if (isDone)
			{
				XSingleton<XTimerMgr>.singleton.updateStartTime = Time.time;
				this.PreUpdate();
				bool pause = this.Pause;
				if (!pause)
				{
					bool update = XSingleton<XTimerMgr>.singleton.update;
					if (update)
					{
						XSingleton<XTimerMgr>.singleton.Update(Time.deltaTime);
					}
					bool needFixedUpdate = XSingleton<XTimerMgr>.singleton.NeedFixedUpdate;
					if (needFixedUpdate)
					{
						XSingleton<XResourceLoaderMgr>.singleton.Update(Time.deltaTime);
					}
					XSingleton<XEngineCommandMgr>.singleton.Update();
					this._entrance.Update();
				}
			}
			else
			{
				XSingleton<XTimerMgr>.singleton.Update(Time.deltaTime);
				XSingleton<XUpdater>.singleton.Update();
			}
		}

		public void PostUpdate()
		{
			bool isDone = XSingleton<XUpdater>.singleton.IsDone;
			if (isDone)
			{
				this.PauseChecker();
				this._entrance.FadeUpdate();
				bool pause = this.Pause;
				if (pause)
				{
					return;
				}
				this._entrance.PostUpdate();
				XSingleton<XTimerMgr>.singleton.PostUpdate();
			}
			bool reboot = XSingleton<XUpdater>.singleton.Reboot;
			if (reboot)
			{
				this.Quit();
				SceneManager.LoadScene(0);
			}
		}

		public void Quit()
		{
			bool isDone = XSingleton<XUpdater>.singleton.IsDone;
			if (isDone)
			{
				this._entrance.Quit();
			}
			XSingleton<XUpdater>.singleton.Uninit();
		}

		public void MakeEntrance(Assembly main)
		{
			Type type = main.GetType("XMainClient.XGameEntrance");
			MethodInfo method = type.GetMethod("Fire");
			method.Invoke(null, null);
			this._entrance = XSingleton<XInterfaceMgr>.singleton.GetInterface<IEntrance>(0U);
		}

		public float TimeMagic(float value)
		{
			bool flag = Time.timeScale == 1f && !this._bPause;
			if (flag)
			{
				Time.timeScale = value;
				this._time_scale = value;
			}
			return Time.timeScale;
		}

		public void TimeMagicBack()
		{
			Time.timeScale = 1f;
			this._time_scale = 1f;
		}

		public float CurrentTimeMagic
		{
			get
			{
				return Time.timeScale;
			}
		}

		private void PauseChecker()
		{
			bool flag = this._bPause == this._bPauseTrigger;
			if (!flag)
			{
				this._bPause = this._bPauseTrigger;
				Time.timeScale = (this._bPause ? 0f : this._time_scale);
			}
		}

		public override bool Init()
		{
			return true;
		}

		public override void Uninit()
		{
		}

		public void MonoObjectRegister(string key, MonoBehaviour behavior)
		{
			bool flag = this._entrance != null;
			if (flag)
			{
				this._entrance.MonoObjectRegister(key, behavior);
			}
		}

		public static readonly int TargetFrame = 30;

		private float _time_scale = 1f;

		private bool _bPause = false;

		private bool _bPauseTrigger = false;

		private IEntrance _entrance = null;
	}
}
