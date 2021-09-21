using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000490 RID: 1168
	[ProtoContract(Name = "DragonGroupRecordS2C")]
	[Serializable]
	public class DragonGroupRecordS2C : IExtensible
	{
		// Token: 0x170012A9 RID: 4777
		// (get) Token: 0x06003CE0 RID: 15584 RVA: 0x00074384 File Offset: 0x00072584
		[ProtoMember(1, Name = "recordlist", DataFormat = DataFormat.Default)]
		public List<DragonGroupRecordInfoList> recordlist
		{
			get
			{
				return this._recordlist;
			}
		}

		// Token: 0x170012AA RID: 4778
		// (get) Token: 0x06003CE1 RID: 15585 RVA: 0x0007439C File Offset: 0x0007259C
		// (set) Token: 0x06003CE2 RID: 15586 RVA: 0x000743C8 File Offset: 0x000725C8
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170012AB RID: 4779
		// (get) Token: 0x06003CE3 RID: 15587 RVA: 0x000743D8 File Offset: 0x000725D8
		// (set) Token: 0x06003CE4 RID: 15588 RVA: 0x000743F8 File Offset: 0x000725F8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06003CE5 RID: 15589 RVA: 0x0007443C File Offset: 0x0007263C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06003CE6 RID: 15590 RVA: 0x00074454 File Offset: 0x00072654
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003CE7 RID: 15591 RVA: 0x00074460 File Offset: 0x00072660
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F29 RID: 3881
		private readonly List<DragonGroupRecordInfoList> _recordlist = new List<DragonGroupRecordInfoList>();

		// Token: 0x04000F2A RID: 3882
		private ErrorCode? _errorcode;

		// Token: 0x04000F2B RID: 3883
		private IExtension extensionObject;
	}
}
