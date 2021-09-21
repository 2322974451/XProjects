using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000630 RID: 1584
	[ProtoContract(Name = "SAtlasRecord")]
	[Serializable]
	public class SAtlasRecord : IExtensible
	{
		// Token: 0x17001EA3 RID: 7843
		// (get) Token: 0x0600615A RID: 24922 RVA: 0x000B9B78 File Offset: 0x000B7D78
		[ProtoMember(1, Name = "atlas", DataFormat = DataFormat.TwosComplement)]
		public List<uint> atlas
		{
			get
			{
				return this._atlas;
			}
		}

		// Token: 0x17001EA4 RID: 7844
		// (get) Token: 0x0600615B RID: 24923 RVA: 0x000B9B90 File Offset: 0x000B7D90
		[ProtoMember(2, Name = "finishdata", DataFormat = DataFormat.Default)]
		public List<atlasdata> finishdata
		{
			get
			{
				return this._finishdata;
			}
		}

		// Token: 0x0600615C RID: 24924 RVA: 0x000B9BA8 File Offset: 0x000B7DA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400179F RID: 6047
		private readonly List<uint> _atlas = new List<uint>();

		// Token: 0x040017A0 RID: 6048
		private readonly List<atlasdata> _finishdata = new List<atlasdata>();

		// Token: 0x040017A1 RID: 6049
		private IExtension extensionObject;
	}
}
