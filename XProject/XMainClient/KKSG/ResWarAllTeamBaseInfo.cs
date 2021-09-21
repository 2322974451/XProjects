using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A3 RID: 675
	[ProtoContract(Name = "ResWarAllTeamBaseInfo")]
	[Serializable]
	public class ResWarAllTeamBaseInfo : IExtensible
	{
		// Token: 0x17000BC2 RID: 3010
		// (get) Token: 0x060025CE RID: 9678 RVA: 0x00049A28 File Offset: 0x00047C28
		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<ResWarTeamBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x060025CF RID: 9679 RVA: 0x00049A40 File Offset: 0x00047C40
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400095B RID: 2395
		private readonly List<ResWarTeamBaseInfo> _info = new List<ResWarTeamBaseInfo>();

		// Token: 0x0400095C RID: 2396
		private IExtension extensionObject;
	}
}
