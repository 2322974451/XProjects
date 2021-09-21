using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002CB RID: 715
	[ProtoContract(Name = "GuildBuffSimpleAllInfo")]
	[Serializable]
	public class GuildBuffSimpleAllInfo : IExtensible
	{
		// Token: 0x17000C45 RID: 3141
		// (get) Token: 0x06002778 RID: 10104 RVA: 0x0004CBC4 File Offset: 0x0004ADC4
		[ProtoMember(1, Name = "buff", DataFormat = DataFormat.Default)]
		public List<GuildBuffSimpleInfo> buff
		{
			get
			{
				return this._buff;
			}
		}

		// Token: 0x06002779 RID: 10105 RVA: 0x0004CBDC File Offset: 0x0004ADDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009D1 RID: 2513
		private readonly List<GuildBuffSimpleInfo> _buff = new List<GuildBuffSimpleInfo>();

		// Token: 0x040009D2 RID: 2514
		private IExtension extensionObject;
	}
}
