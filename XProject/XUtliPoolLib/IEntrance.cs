using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200009E RID: 158
	public interface IEntrance : IXInterface
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060004D7 RID: 1239
		bool Awaked { get; }

		// Token: 0x060004D8 RID: 1240
		void Awake();

		// Token: 0x060004D9 RID: 1241
		void Start();

		// Token: 0x060004DA RID: 1242
		void NetUpdate();

		// Token: 0x060004DB RID: 1243
		void PreUpdate();

		// Token: 0x060004DC RID: 1244
		void Update();

		// Token: 0x060004DD RID: 1245
		void PostUpdate();

		// Token: 0x060004DE RID: 1246
		void FadeUpdate();

		// Token: 0x060004DF RID: 1247
		void Quit();

		// Token: 0x060004E0 RID: 1248
		void Authorization(string token);

		// Token: 0x060004E1 RID: 1249
		void AuthorizationSignOut(string msg);

		// Token: 0x060004E2 RID: 1250
		void SetQualityLevel(int level);

		// Token: 0x060004E3 RID: 1251
		void MonoObjectRegister(string key, MonoBehaviour behavior);
	}
}
