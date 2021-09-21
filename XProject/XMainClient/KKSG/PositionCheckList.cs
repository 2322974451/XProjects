using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000CE RID: 206
	[ProtoContract(Name = "PositionCheckList")]
	[Serializable]
	public class PositionCheckList : IExtensible
	{
		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x0001BC98 File Offset: 0x00019E98
		[ProtoMember(1, Name = "positions", DataFormat = DataFormat.Default)]
		public List<PositionCheck> positions
		{
			get
			{
				return this._positions;
			}
		}

		// Token: 0x06000D4B RID: 3403 RVA: 0x0001BCB0 File Offset: 0x00019EB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000357 RID: 855
		private readonly List<PositionCheck> _positions = new List<PositionCheck>();

		// Token: 0x04000358 RID: 856
		private IExtension extensionObject;
	}
}
