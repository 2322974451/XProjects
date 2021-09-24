using System;

namespace XUpdater
{

	internal sealed class AsyncWriteRequest
	{

		public bool IsDone = false;

		public bool HasError = false;

		public string Location = null;

		public string Name = null;

		public uint Size = 0U;
	}
}
