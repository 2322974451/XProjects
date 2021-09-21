using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000040 RID: 64
	public interface IXUITweenTool
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001A6 RID: 422
		bool bPlayForward { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001A7 RID: 423
		int TweenGroup { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001A8 RID: 424
		GameObject gameObject { get; }

		// Token: 0x060001A9 RID: 425
		void SetTargetGameObject(GameObject go);

		// Token: 0x060001AA RID: 426
		void PlayTween(bool bForward, float duaration = -1f);

		// Token: 0x060001AB RID: 427
		void ResetTween(bool bForward);

		// Token: 0x060001AC RID: 428
		void ResetTweenByGroup(bool bForward, int group = 0);

		// Token: 0x060001AD RID: 429
		void ResetTweenExceptGroup(bool bForward, int group);

		// Token: 0x060001AE RID: 430
		void ResetTweenByCurGroup(bool bForward);

		// Token: 0x060001AF RID: 431
		void StopTween();

		// Token: 0x060001B0 RID: 432
		void StopTweenByGroup(int group = 0);

		// Token: 0x060001B1 RID: 433
		void StopTweenExceptGroup(int group);

		// Token: 0x060001B2 RID: 434
		void SetPositionTweenPos(int group, Vector3 from, Vector3 to);

		// Token: 0x060001B3 RID: 435
		void SetTweenGroup(int group);

		// Token: 0x060001B4 RID: 436
		void SetTweenEnabledWhenFinish(bool enabled);

		// Token: 0x060001B5 RID: 437
		void RegisterOnFinishEventHandler(OnTweenFinishEventHandler eventHandler);
	}
}
