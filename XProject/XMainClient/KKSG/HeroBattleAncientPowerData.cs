using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000461 RID: 1121
	[ProtoContract(Name = "HeroBattleAncientPowerData")]
	[Serializable]
	public class HeroBattleAncientPowerData : IExtensible
	{
		// Token: 0x17001207 RID: 4615
		// (get) Token: 0x06003ACF RID: 15055 RVA: 0x00070710 File Offset: 0x0006E910
		[ProtoMember(1, Name = "roleids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleids
		{
			get
			{
				return this._roleids;
			}
		}

		// Token: 0x17001208 RID: 4616
		// (get) Token: 0x06003AD0 RID: 15056 RVA: 0x00070728 File Offset: 0x0006E928
		[ProtoMember(2, Name = "ancientpower", DataFormat = DataFormat.TwosComplement)]
		public List<double> ancientpower
		{
			get
			{
				return this._ancientpower;
			}
		}

		// Token: 0x06003AD1 RID: 15057 RVA: 0x00070740 File Offset: 0x0006E940
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E9A RID: 3738
		private readonly List<ulong> _roleids = new List<ulong>();

		// Token: 0x04000E9B RID: 3739
		private readonly List<double> _ancientpower = new List<double>();

		// Token: 0x04000E9C RID: 3740
		private IExtension extensionObject;
	}
}
