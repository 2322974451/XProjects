using System;

namespace ProtoBuf
{
	// Token: 0x0200084E RID: 2126
	public class ProtoException : Exception
	{
		// Token: 0x06008294 RID: 33428 RVA: 0x000FAB46 File Offset: 0x000F8D46
		public ProtoException()
		{
		}

		// Token: 0x06008295 RID: 33429 RVA: 0x000FAB50 File Offset: 0x000F8D50
		public ProtoException(string message) : base(message)
		{
		}

		// Token: 0x06008296 RID: 33430 RVA: 0x000FAB5B File Offset: 0x000F8D5B
		public ProtoException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
