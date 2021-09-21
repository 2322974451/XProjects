using System;

namespace ProtoBuf
{
	// Token: 0x02000857 RID: 2135
	public sealed class SerializationContext
	{
		// Token: 0x0600833A RID: 33594 RVA: 0x000FEB77 File Offset: 0x000FCD77
		internal void Freeze()
		{
			this.frozen = true;
		}

		// Token: 0x0600833B RID: 33595 RVA: 0x000FEB84 File Offset: 0x000FCD84
		private void ThrowIfFrozen()
		{
			bool flag = this.frozen;
			if (flag)
			{
				throw new InvalidOperationException("The serialization-context cannot be changed once it is in use");
			}
		}

		// Token: 0x17002969 RID: 10601
		// (get) Token: 0x0600833C RID: 33596 RVA: 0x000FEBA8 File Offset: 0x000FCDA8
		// (set) Token: 0x0600833D RID: 33597 RVA: 0x000FEBC0 File Offset: 0x000FCDC0
		public object Context
		{
			get
			{
				return this.context;
			}
			set
			{
				bool flag = this.context != value;
				if (flag)
				{
					this.ThrowIfFrozen();
					this.context = value;
				}
			}
		}

		// Token: 0x0600833E RID: 33598 RVA: 0x000FEBEE File Offset: 0x000FCDEE
		static SerializationContext()
		{
			SerializationContext.@default.Freeze();
		}

		// Token: 0x1700296A RID: 10602
		// (get) Token: 0x0600833F RID: 33599 RVA: 0x000FEC08 File Offset: 0x000FCE08
		internal static SerializationContext Default
		{
			get
			{
				return SerializationContext.@default;
			}
		}

		// Token: 0x040028C1 RID: 10433
		private bool frozen;

		// Token: 0x040028C2 RID: 10434
		private object context;

		// Token: 0x040028C3 RID: 10435
		private static readonly SerializationContext @default = new SerializationContext();
	}
}
