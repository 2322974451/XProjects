using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003D6 RID: 982
	[ProtoContract(Name = "ArenaStarPara")]
	[Serializable]
	public class ArenaStarPara : IExtensible
	{
		// Token: 0x1700101B RID: 4123
		// (get) Token: 0x06003453 RID: 13395 RVA: 0x00064638 File Offset: 0x00062838
		[ProtoMember(1, Name = "newdata", DataFormat = DataFormat.TwosComplement)]
		public List<ArenaStarType> newdata
		{
			get
			{
				return this._newdata;
			}
		}

		// Token: 0x06003454 RID: 13396 RVA: 0x00064650 File Offset: 0x00062850
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CFE RID: 3326
		private readonly List<ArenaStarType> _newdata = new List<ArenaStarType>();

		// Token: 0x04000CFF RID: 3327
		private IExtension extensionObject;
	}
}
