using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTerritoryComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XTerritoryComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._inited = false;
		}

		private void Init()
		{
			this._bboard = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XTerritoryComponent.B_TEMPLATE, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation, true, false);
			this._bboard.name = this._entity.ID.ToString();
			this._label = (this._bboard.transform.FindChild("chattext/text").GetComponent("XUILabel") as IXUILabel);
			this._slider = (this._bboard.transform.FindChild("chattext/slider").GetComponent("XUISlider") as IXUISlider);
			this._spr = (this._bboard.transform.FindChild("chattext/p").GetComponent("XUISprite") as IXUISprite);
			this._inited = true;
		}

		public override void OnDetachFromHost()
		{
			bool flag = this._timer > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
			}
			this._inited = false;
			this.DestroyGameObjects();
			base.OnDetachFromHost();
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = !this._inited;
			if (!flag)
			{
				bool flag2 = this.state == XTerritoryComponent.State.Start;
				if (flag2)
				{
					this.OnStart();
				}
				else
				{
					bool flag3 = this.state == XTerritoryComponent.State.Break;
					if (flag3)
					{
						this.OnBreak();
					}
					else
					{
						bool flag4 = this.state == XTerritoryComponent.State.Doing;
						if (flag4)
						{
							this.OnDoing();
						}
						else
						{
							bool flag5 = this.state == XTerritoryComponent.State.End;
							if (flag5)
							{
								this.OnEnd();
							}
						}
					}
				}
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._host == null;
			if (!flag)
			{
				XEntity xentity = this._host as XEntity;
				bool flag2 = xentity == null || this._bboard == null || !this._inited || XSingleton<XScene>.singleton.GameCamera != null;
				if (!flag2)
				{
					this._bboard.transform.rotation = XSingleton<XScene>.singleton.GameCamera.Rotaton;
				}
			}
		}

		protected void DestroyGameObjects()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._bboard, true);
		}

		private void SetBillBoardDepth(float dis = 0f)
		{
			int num = -(int)(dis * 100f);
			bool flag = this._label != null && this._spr != null;
			if (flag)
			{
				this._label.spriteDepth = num + 1;
				this._spr.spriteDepth = num;
			}
		}

		public void ToStart()
		{
			bool flag = !this._inited;
			if (flag)
			{
				this.Init();
			}
			this.bbComp = this._entity.BillBoard;
			bool flag2 = this.bbComp != null;
			if (flag2)
			{
				this.bbComp.AttachChild(this._bboard.transform, false, 60f);
			}
			bool flag3 = this._bboard != null;
			if (flag3)
			{
				this._bboard.SetActive(true);
			}
			this.tick_start = Time.time;
			this.state = XTerritoryComponent.State.Start;
		}

		public void Interupt()
		{
			bool flag = !this._inited;
			if (!flag)
			{
				this.state = XTerritoryComponent.State.Break;
			}
		}

		public void Success()
		{
			this.state = XTerritoryComponent.State.End;
		}

		private void Fadeout(object o)
		{
			bool flag = !this._inited;
			if (!flag)
			{
				bool flag2 = this.bbComp != null;
				if (flag2)
				{
					bool flag3 = this.bbComp.UnAttachChild(this._bboard.transform);
					if (flag3)
					{
						this._bboard.SetActive(false);
					}
				}
			}
		}

		private void OnStart()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
			this.state = XTerritoryComponent.State.Doing;
			this._slider.Value = 0f;
			this._label.SetText(XStringDefineProxy.GetString("Territory_Doing"));
		}

		private void OnBreak()
		{
			this._label.SetText(XStringDefineProxy.GetString("Territory_break"));
			this.state = XTerritoryComponent.State.None;
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.Fadeout), null);
		}

		private void OnDoing()
		{
			bool flag = Time.time - this.tick_start >= this.tick_cnt;
			if (flag)
			{
				this.state = XTerritoryComponent.State.None;
				this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(4f, new XTimerMgr.ElapsedEventHandler(this.Fadeout), null);
			}
			else
			{
				bool flag2 = this._slider != null;
				if (flag2)
				{
					this._slider.Value = (Time.time - this.tick_start) / this.tick_cnt;
				}
			}
		}

		private void OnEnd()
		{
			this._label.SetText(XStringDefineProxy.GetString("Territory_success"));
			this.state = XTerritoryComponent.State.None;
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.Fadeout), null);
		}

		public static string B_TEMPLATE = "UI/Billboard/Territorybubble";

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XTerritoryComponent");

		private XBillboardComponent bbComp;

		public XTerritoryComponent.State state = XTerritoryComponent.State.None;

		private float tick_start = 0f;

		private float tick_cnt = 5f;

		private GameObject _bboard = null;

		private IXUILabel _label;

		private IXUISprite _spr;

		private IXUISlider _slider;

		private uint _timer = 0U;

		private bool _inited = false;

		public enum State
		{

			Start,

			Doing,

			End,

			Break,

			None
		}
	}
}
