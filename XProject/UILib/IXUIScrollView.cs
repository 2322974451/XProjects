using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000029 RID: 41
	public interface IXUIScrollView : IXUIObject
	{
		// Token: 0x06000102 RID: 258
		void UpdatePosition();

		// Token: 0x06000103 RID: 259
		void ResetPosition();

		// Token: 0x06000104 RID: 260
		void SetPosition(float pos);

		// Token: 0x06000105 RID: 261
		void SetDragPositionX(float pos);

		// Token: 0x06000106 RID: 262
		void SetCustomMovement(Vector2 movement);

		// Token: 0x06000107 RID: 263
		void SetDragFinishDelegate(Delegate func);

		// Token: 0x06000108 RID: 264
		void SetAutoMove(float from, float to, float moveSpeed);

		// Token: 0x06000109 RID: 265
		bool RestrictWithinBounds(bool instant);

		// Token: 0x0600010A RID: 266
		void MoveAbsolute(Vector3 absolute);

		// Token: 0x0600010B RID: 267
		void MoveRelative(Vector3 relative);

		// Token: 0x0600010C RID: 268
		void NeedRecalcBounds();
	}
}
