using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000523 RID: 1315
	[ProtoContract(Name = "UpdateStageInfoNtf")]
	[Serializable]
	public class UpdateStageInfoNtf : IExtensible
	{
		// Token: 0x170014AC RID: 5292
		// (get) Token: 0x060043A5 RID: 17317 RVA: 0x00080B28 File Offset: 0x0007ED28
		// (set) Token: 0x060043A6 RID: 17318 RVA: 0x00080B40 File Offset: 0x0007ED40
		[ProtoMember(1, IsRequired = false, Name = "Stages", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public StageInfo Stages
		{
			get
			{
				return this._Stages;
			}
			set
			{
				this._Stages = value;
			}
		}

		// Token: 0x060043A7 RID: 17319 RVA: 0x00080B4C File Offset: 0x0007ED4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010DB RID: 4315
		private StageInfo _Stages = null;

		// Token: 0x040010DC RID: 4316
		private IExtension extensionObject;
	}
}
