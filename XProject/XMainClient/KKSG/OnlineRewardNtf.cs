using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C5 RID: 197
	[ProtoContract(Name = "OnlineRewardNtf")]
	[Serializable]
	public class OnlineRewardNtf : IExtensible
	{
		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000D11 RID: 3345 RVA: 0x0001B670 File Offset: 0x00019870
		[ProtoMember(1, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public List<uint> state
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x0001B688 File Offset: 0x00019888
		[ProtoMember(2, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timeleft
		{
			get
			{
				return this._timeleft;
			}
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0001B6A0 File Offset: 0x000198A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000345 RID: 837
		private readonly List<uint> _state = new List<uint>();

		// Token: 0x04000346 RID: 838
		private readonly List<uint> _timeleft = new List<uint>();

		// Token: 0x04000347 RID: 839
		private IExtension extensionObject;
	}
}
