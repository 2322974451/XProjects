using System;

namespace XUtliPoolLib
{
	// Token: 0x0200007F RID: 127
	public interface IXGameSirControl
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000449 RID: 1097
		bool IsOpen { get; }

		// Token: 0x0600044A RID: 1098
		void Init();

		// Token: 0x0600044B RID: 1099
		void StartSir();

		// Token: 0x0600044C RID: 1100
		void StopSir();

		// Token: 0x0600044D RID: 1101
		bool IsConnected();

		// Token: 0x0600044E RID: 1102
		int GetGameSirState();

		// Token: 0x0600044F RID: 1103
		bool GetButton(string buttonName);

		// Token: 0x06000450 RID: 1104
		float GetAxis(string axisName);

		// Token: 0x06000451 RID: 1105
		void ShowGameSirDialog();
	}
}
