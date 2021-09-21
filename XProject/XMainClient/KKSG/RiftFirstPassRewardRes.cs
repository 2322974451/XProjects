using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200052A RID: 1322
	[ProtoContract(Name = "RiftFirstPassRewardRes")]
	[Serializable]
	public class RiftFirstPassRewardRes : IExtensible
	{
		// Token: 0x170014C6 RID: 5318
		// (get) Token: 0x060043F6 RID: 17398 RVA: 0x000814B4 File Offset: 0x0007F6B4
		// (set) Token: 0x060043F7 RID: 17399 RVA: 0x000814E0 File Offset: 0x0007F6E0
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170014C7 RID: 5319
		// (get) Token: 0x060043F8 RID: 17400 RVA: 0x000814F0 File Offset: 0x0007F6F0
		// (set) Token: 0x060043F9 RID: 17401 RVA: 0x00081510 File Offset: 0x0007F710
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060043FA RID: 17402 RVA: 0x00081554 File Offset: 0x0007F754
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060043FB RID: 17403 RVA: 0x0008156C File Offset: 0x0007F76C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170014C8 RID: 5320
		// (get) Token: 0x060043FC RID: 17404 RVA: 0x00081578 File Offset: 0x0007F778
		[ProtoMember(2, Name = "floorInfos", DataFormat = DataFormat.Default)]
		public List<RiftEachFloorInfo> floorInfos
		{
			get
			{
				return this._floorInfos;
			}
		}

		// Token: 0x060043FD RID: 17405 RVA: 0x00081590 File Offset: 0x0007F790
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010F2 RID: 4338
		private ErrorCode? _error;

		// Token: 0x040010F3 RID: 4339
		private readonly List<RiftEachFloorInfo> _floorInfos = new List<RiftEachFloorInfo>();

		// Token: 0x040010F4 RID: 4340
		private IExtension extensionObject;
	}
}
