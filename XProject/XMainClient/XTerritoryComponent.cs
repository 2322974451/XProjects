using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F33 RID: 3891
	internal class XTerritoryComponent : XComponent
	{
		// Token: 0x170035FB RID: 13819
		// (get) Token: 0x0600CE51 RID: 52817 RVA: 0x002FC99C File Offset: 0x002FAB9C
		public override uint ID
		{
			get
			{
				return XTerritoryComponent.uuID;
			}
		}

		// Token: 0x0600CE52 RID: 52818 RVA: 0x002FC9B3 File Offset: 0x002FABB3
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._inited = false;
		}

		// Token: 0x0600CE53 RID: 52819 RVA: 0x002FC9C8 File Offset: 0x002FABC8
		private void Init()
		{
			this._bboard = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XTerritoryComponent.B_TEMPLATE, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation, true, false);
			this._bboard.name = this._entity.ID.ToString();
			this._label = (this._bboard.transform.FindChild("chattext/text").GetComponent("XUILabel") as IXUILabel);
			this._slider = (this._bboard.transform.FindChild("chattext/slider").GetComponent("XUISlider") as IXUISlider);
			this._spr = (this._bboard.transform.FindChild("chattext/p").GetComponent("XUISprite") as IXUISprite);
			this._inited = true;
		}

		// Token: 0x0600CE54 RID: 52820 RVA: 0x002FCAB4 File Offset: 0x002FACB4
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

		// Token: 0x0600CE55 RID: 52821 RVA: 0x002FCAF8 File Offset: 0x002FACF8
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

		// Token: 0x0600CE56 RID: 52822 RVA: 0x002FCB80 File Offset: 0x002FAD80
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

		// Token: 0x0600CE57 RID: 52823 RVA: 0x002FCBF8 File Offset: 0x002FADF8
		protected void DestroyGameObjects()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._bboard, true);
		}

		// Token: 0x0600CE58 RID: 52824 RVA: 0x002FCC08 File Offset: 0x002FAE08
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

		// Token: 0x0600CE59 RID: 52825 RVA: 0x002FCC58 File Offset: 0x002FAE58
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

		// Token: 0x0600CE5A RID: 52826 RVA: 0x002FCCE4 File Offset: 0x002FAEE4
		public void Interupt()
		{
			bool flag = !this._inited;
			if (!flag)
			{
				this.state = XTerritoryComponent.State.Break;
			}
		}

		// Token: 0x0600CE5B RID: 52827 RVA: 0x002FCD08 File Offset: 0x002FAF08
		public void Success()
		{
			this.state = XTerritoryComponent.State.End;
		}

		// Token: 0x0600CE5C RID: 52828 RVA: 0x002FCD14 File Offset: 0x002FAF14
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

		// Token: 0x0600CE5D RID: 52829 RVA: 0x002FCD68 File Offset: 0x002FAF68
		private void OnStart()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timer);
			this.state = XTerritoryComponent.State.Doing;
			this._slider.Value = 0f;
			this._label.SetText(XStringDefineProxy.GetString("Territory_Doing"));
		}

		// Token: 0x0600CE5E RID: 52830 RVA: 0x002FCDB8 File Offset: 0x002FAFB8
		private void OnBreak()
		{
			this._label.SetText(XStringDefineProxy.GetString("Territory_break"));
			this.state = XTerritoryComponent.State.None;
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.Fadeout), null);
		}

		// Token: 0x0600CE5F RID: 52831 RVA: 0x002FCE08 File Offset: 0x002FB008
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

		// Token: 0x0600CE60 RID: 52832 RVA: 0x002FCE8C File Offset: 0x002FB08C
		private void OnEnd()
		{
			this._label.SetText(XStringDefineProxy.GetString("Territory_success"));
			this.state = XTerritoryComponent.State.None;
			this._timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.Fadeout), null);
		}

		// Token: 0x04005C07 RID: 23559
		public static string B_TEMPLATE = "UI/Billboard/Territorybubble";

		// Token: 0x04005C08 RID: 23560
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XTerritoryComponent");

		// Token: 0x04005C09 RID: 23561
		private XBillboardComponent bbComp;

		// Token: 0x04005C0A RID: 23562
		public XTerritoryComponent.State state = XTerritoryComponent.State.None;

		// Token: 0x04005C0B RID: 23563
		private float tick_start = 0f;

		// Token: 0x04005C0C RID: 23564
		private float tick_cnt = 5f;

		// Token: 0x04005C0D RID: 23565
		private GameObject _bboard = null;

		// Token: 0x04005C0E RID: 23566
		private IXUILabel _label;

		// Token: 0x04005C0F RID: 23567
		private IXUISprite _spr;

		// Token: 0x04005C10 RID: 23568
		private IXUISlider _slider;

		// Token: 0x04005C11 RID: 23569
		private uint _timer = 0U;

		// Token: 0x04005C12 RID: 23570
		private bool _inited = false;

		// Token: 0x020019F2 RID: 6642
		public enum State
		{
			// Token: 0x040080B1 RID: 32945
			Start,
			// Token: 0x040080B2 RID: 32946
			Doing,
			// Token: 0x040080B3 RID: 32947
			End,
			// Token: 0x040080B4 RID: 32948
			Break,
			// Token: 0x040080B5 RID: 32949
			None
		}
	}
}
