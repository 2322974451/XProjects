using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000EAA RID: 3754
	internal class XTouchItem
	{
		// Token: 0x170034DB RID: 13531
		// (get) Token: 0x0600C802 RID: 51202 RVA: 0x002CC478 File Offset: 0x002CA678
		// (set) Token: 0x0600C803 RID: 51203 RVA: 0x002CC480 File Offset: 0x002CA680
		public bool Fake { get; set; }

		// Token: 0x170034DC RID: 13532
		// (get) Token: 0x0600C804 RID: 51204 RVA: 0x002CC48C File Offset: 0x002CA68C
		public float DeltaTime
		{
			get
			{
				return this.Fake ? this.faketouch.deltaTime : this.touch.deltaTime;
			}
		}

		// Token: 0x170034DD RID: 13533
		// (get) Token: 0x0600C805 RID: 51205 RVA: 0x002CC4C0 File Offset: 0x002CA6C0
		public int FingerId
		{
			get
			{
				return this.Fake ? this.faketouch.fingerId : this.touch.fingerId;
			}
		}

		// Token: 0x170034DE RID: 13534
		// (get) Token: 0x0600C806 RID: 51206 RVA: 0x002CC4F4 File Offset: 0x002CA6F4
		public TouchPhase Phase
		{
			get
			{
				return this.Fake ? this.faketouch.phase : this.touch.phase;
			}
		}

		// Token: 0x170034DF RID: 13535
		// (get) Token: 0x0600C807 RID: 51207 RVA: 0x002CC528 File Offset: 0x002CA728
		public Vector2 Position
		{
			get
			{
				return this.Fake ? this.faketouch.position : this.touch.position;
			}
		}

		// Token: 0x170034E0 RID: 13536
		// (get) Token: 0x0600C808 RID: 51208 RVA: 0x002CC55C File Offset: 0x002CA75C
		public Vector2 RawPosition
		{
			get
			{
				return this.Fake ? this.faketouch.rawPosition : this.touch.rawPosition;
			}
		}

		// Token: 0x170034E1 RID: 13537
		// (get) Token: 0x0600C809 RID: 51209 RVA: 0x002CC590 File Offset: 0x002CA790
		public int TapCount
		{
			get
			{
				return this.Fake ? this.faketouch.tapCount : this.touch.tapCount;
			}
		}

		// Token: 0x0600C80A RID: 51210 RVA: 0x002CC5C4 File Offset: 0x002CA7C4
		public void Convert2FakeTouch(TouchPhase phase)
		{
			this.faketouch.fingerId = this.touch.fingerId;
			this.faketouch.position = this.touch.position;
			this.faketouch.deltaTime = this.touch.deltaTime;
			this.faketouch.deltaPosition = this.touch.deltaPosition;
			this.faketouch.phase = phase;
			this.faketouch.tapCount = this.touch.tapCount;
			this.Fake = true;
		}

		// Token: 0x0400584F RID: 22607
		public Touch touch;

		// Token: 0x04005850 RID: 22608
		public XFakeTouch faketouch;
	}
}
