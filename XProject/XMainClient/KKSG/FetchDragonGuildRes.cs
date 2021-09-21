using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004BC RID: 1212
	[ProtoContract(Name = "FetchDragonGuildRes")]
	[Serializable]
	public class FetchDragonGuildRes : IExtensible
	{
		// Token: 0x17001350 RID: 4944
		// (get) Token: 0x06003F0F RID: 16143 RVA: 0x000783B4 File Offset: 0x000765B4
		// (set) Token: 0x06003F10 RID: 16144 RVA: 0x000783E0 File Offset: 0x000765E0
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17001351 RID: 4945
		// (get) Token: 0x06003F11 RID: 16145 RVA: 0x000783F0 File Offset: 0x000765F0
		// (set) Token: 0x06003F12 RID: 16146 RVA: 0x00078410 File Offset: 0x00076610
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06003F13 RID: 16147 RVA: 0x00078454 File Offset: 0x00076654
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003F14 RID: 16148 RVA: 0x0007846C File Offset: 0x0007666C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17001352 RID: 4946
		// (get) Token: 0x06003F15 RID: 16149 RVA: 0x00078478 File Offset: 0x00076678
		[ProtoMember(2, Name = "dragonguilds", DataFormat = DataFormat.Default)]
		public List<DragonGuildInfo> dragonguilds
		{
			get
			{
				return this._dragonguilds;
			}
		}

		// Token: 0x06003F16 RID: 16150 RVA: 0x00078490 File Offset: 0x00076690
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FB1 RID: 4017
		private ErrorCode? _result;

		// Token: 0x04000FB2 RID: 4018
		private readonly List<DragonGuildInfo> _dragonguilds = new List<DragonGuildInfo>();

		// Token: 0x04000FB3 RID: 4019
		private IExtension extensionObject;
	}
}
