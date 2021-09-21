using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D2 RID: 210
	[ProtoContract(Name = "EnemyDropDoodadInfo")]
	[Serializable]
	public class EnemyDropDoodadInfo : IExtensible
	{
		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000D8D RID: 3469 RVA: 0x0001C490 File Offset: 0x0001A690
		[ProtoMember(1, Name = "doodadInfo", DataFormat = DataFormat.Default)]
		public List<EnemyDoodadInfo> doodadInfo
		{
			get
			{
				return this._doodadInfo;
			}
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x0001C4A8 File Offset: 0x0001A6A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000367 RID: 871
		private readonly List<EnemyDoodadInfo> _doodadInfo = new List<EnemyDoodadInfo>();

		// Token: 0x04000368 RID: 872
		private IExtension extensionObject;
	}
}
