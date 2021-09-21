using System;

namespace XUtliPoolLib
{
	// Token: 0x02000093 RID: 147
	public interface IXVideo : IXInterface
	{
		// Token: 0x060004B8 RID: 1208
		void Play(bool loop = false);

		// Token: 0x060004B9 RID: 1209
		void Stop();

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060004BA RID: 1210
		bool isPlaying { get; }
	}
}
