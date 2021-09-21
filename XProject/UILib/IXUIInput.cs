using System;

namespace UILib
{
	// Token: 0x02000019 RID: 25
	public interface IXUIInput : IXUIObject
	{
		// Token: 0x060000A1 RID: 161
		string GetText();

		// Token: 0x060000A2 RID: 162
		void SetText(string strText);

		// Token: 0x060000A3 RID: 163
		void SetCharacterLimit(int num);

		// Token: 0x060000A4 RID: 164
		void SetDefault(string strText);

		// Token: 0x060000A5 RID: 165
		string GetDefault();

		// Token: 0x060000A6 RID: 166
		void RegisterKeyTriggeredEventHandler(InputKeyTriggeredEventHandler eventHandler);

		// Token: 0x060000A7 RID: 167
		void RegisterSubmitEventHandler(InputSubmitEventHandler eventHandler);

		// Token: 0x060000A8 RID: 168
		void RegisterChangeEventHandler(InputChangeEventHandler eventHandler);

		// Token: 0x060000A9 RID: 169
		void selected(bool value);
	}
}
