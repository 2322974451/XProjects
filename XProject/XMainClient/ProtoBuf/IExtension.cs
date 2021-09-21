using System;
using System.IO;

namespace ProtoBuf
{
	// Token: 0x02000847 RID: 2119
	public interface IExtension
	{
		// Token: 0x06008268 RID: 33384
		Stream BeginAppend();

		// Token: 0x06008269 RID: 33385
		void EndAppend(Stream stream, bool commit);

		// Token: 0x0600826A RID: 33386
		Stream BeginQuery();

		// Token: 0x0600826B RID: 33387
		void EndQuery(Stream stream);

		// Token: 0x0600826C RID: 33388
		int GetLength();
	}
}
