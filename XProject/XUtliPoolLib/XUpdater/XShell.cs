using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using XUtliPoolLib;

namespace XUpdater
{
	// Token: 0x02000016 RID: 22
	public sealed class XShell : XSingleton<XShell>
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003B98 File Offset: 0x00001D98
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00003BB0 File Offset: 0x00001DB0
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

		// Token: 0x0600006A RID: 106 RVA: 0x00003BD8 File Offset: 0x00001DD8
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

		// Token: 0x0600006B RID: 107 RVA: 0x00003C28 File Offset: 0x00001E28
		public void Launch()
		{
			this._entrance.Awake();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003C38 File Offset: 0x00001E38
		public bool Launched()
		{
			return this._entrance.Awaked;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003C55 File Offset: 0x00001E55
		public void StartGame()
		{
			this._entrance.Start();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003C64 File Offset: 0x00001E64
		public void Awake()
		{
			bool flag = !XSingleton<XUpdater>.singleton.IsDone;
			if (flag)
			{
				XSingleton<XUpdater>.singleton.Init();
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003C90 File Offset: 0x00001E90
		public void Start()
		{
			Screen.sleepTimeout = -1;
			Application.targetFrameRate = -1;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003CA1 File Offset: 0x00001EA1
		private void NetUpdate()
		{
			this._entrance.NetUpdate();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003CB0 File Offset: 0x00001EB0
		public void PreUpdate()
		{
			this.NetUpdate();
			bool pause = this.Pause;
			if (!pause)
			{
				this._entrance.PreUpdate();
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003CE0 File Offset: 0x00001EE0
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

		// Token: 0x06000073 RID: 115 RVA: 0x00003D94 File Offset: 0x00001F94
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

		// Token: 0x06000074 RID: 116 RVA: 0x00003E08 File Offset: 0x00002008
		public void Quit()
		{
			bool isDone = XSingleton<XUpdater>.singleton.IsDone;
			if (isDone)
			{
				this._entrance.Quit();
			}
			XSingleton<XUpdater>.singleton.Uninit();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003E40 File Offset: 0x00002040
		public void MakeEntrance(Assembly main)
		{
			Type type = main.GetType("XMainClient.XGameEntrance");
			MethodInfo method = type.GetMethod("Fire");
			method.Invoke(null, null);
			this._entrance = XSingleton<XInterfaceMgr>.singleton.GetInterface<IEntrance>(0U);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003E80 File Offset: 0x00002080
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

		// Token: 0x06000077 RID: 119 RVA: 0x00003EC3 File Offset: 0x000020C3
		public void TimeMagicBack()
		{
			Time.timeScale = 1f;
			this._time_scale = 1f;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00003EDC File Offset: 0x000020DC
		public float CurrentTimeMagic
		{
			get
			{
				return Time.timeScale;
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003EF4 File Offset: 0x000020F4
		private void PauseChecker()
		{
			bool flag = this._bPause == this._bPauseTrigger;
			if (!flag)
			{
				this._bPause = this._bPauseTrigger;
				Time.timeScale = (this._bPause ? 0f : this._time_scale);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00003F40 File Offset: 0x00002140
		public override bool Init()
		{
			return true;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003284 File Offset: 0x00001484
		public override void Uninit()
		{
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003F54 File Offset: 0x00002154
		public void MonoObjectRegister(string key, MonoBehaviour behavior)
		{
			bool flag = this._entrance != null;
			if (flag)
			{
				this._entrance.MonoObjectRegister(key, behavior);
			}
		}

		// Token: 0x04000059 RID: 89
		public static readonly int TargetFrame = 30;

		// Token: 0x0400005A RID: 90
		private float _time_scale = 1f;

		// Token: 0x0400005B RID: 91
		private bool _bPause = false;

		// Token: 0x0400005C RID: 92
		private bool _bPauseTrigger = false;

		// Token: 0x0400005D RID: 93
		private IEntrance _entrance = null;
	}
}
