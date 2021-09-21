using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020000A1 RID: 161
	public interface IXHUDDescription : IXInterface
	{
		// Token: 0x060004F7 RID: 1271
		AnimationCurve GetPosCurve();

		// Token: 0x060004F8 RID: 1272
		AnimationCurve GetAlphaCurve();

		// Token: 0x060004F9 RID: 1273
		AnimationCurve GetScaleCurve();
	}
}
