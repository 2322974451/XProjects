using System;

namespace XUtliPoolLib
{
	// Token: 0x0200009F RID: 159
	public interface IXCurve
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060004E4 RID: 1252
		int length { get; }

		// Token: 0x060004E5 RID: 1253
		float Evaluate(float time);

		// Token: 0x060004E6 RID: 1254
		float GetValue(int index);

		// Token: 0x060004E7 RID: 1255
		float GetTime(int index);

		// Token: 0x060004E8 RID: 1256
		float GetMaxValue();

		// Token: 0x060004E9 RID: 1257
		float GetLandValue();
	}
}
