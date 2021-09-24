using System;
using UnityEngine;

namespace XMainClient
{

	internal class XTouchItem
	{

		public bool Fake { get; set; }

		public float DeltaTime
		{
			get
			{
				return this.Fake ? this.faketouch.deltaTime : this.touch.deltaTime;
			}
		}

		public int FingerId
		{
			get
			{
				return this.Fake ? this.faketouch.fingerId : this.touch.fingerId;
			}
		}

		public TouchPhase Phase
		{
			get
			{
				return this.Fake ? this.faketouch.phase : this.touch.phase;
			}
		}

		public Vector2 Position
		{
			get
			{
				return this.Fake ? this.faketouch.position : this.touch.position;
			}
		}

		public Vector2 RawPosition
		{
			get
			{
				return this.Fake ? this.faketouch.rawPosition : this.touch.rawPosition;
			}
		}

		public int TapCount
		{
			get
			{
				return this.Fake ? this.faketouch.tapCount : this.touch.tapCount;
			}
		}

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

		public Touch touch;

		public XFakeTouch faketouch;
	}
}
