using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000341 RID: 833
	[ProtoContract(Name = "ScenePrepareInfoNtf")]
	[Serializable]
	public class ScenePrepareInfoNtf : IExtensible
	{
		// Token: 0x17000E2D RID: 3629
		// (get) Token: 0x06002DAF RID: 11695 RVA: 0x00058658 File Offset: 0x00056858
		[ProtoMember(1, Name = "unreadyroles", DataFormat = DataFormat.Default)]
		public List<string> unreadyroles
		{
			get
			{
				return this._unreadyroles;
			}
		}

		// Token: 0x06002DB0 RID: 11696 RVA: 0x00058670 File Offset: 0x00056870
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B59 RID: 2905
		private readonly List<string> _unreadyroles = new List<string>();

		// Token: 0x04000B5A RID: 2906
		private IExtension extensionObject;
	}
}
