using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200039E RID: 926
	[ProtoContract(Name = "EnchantTransferRes")]
	[Serializable]
	public class EnchantTransferRes : IExtensible
	{
		// Token: 0x17000F74 RID: 3956
		// (get) Token: 0x06003207 RID: 12807 RVA: 0x00060550 File Offset: 0x0005E750
		// (set) Token: 0x06003208 RID: 12808 RVA: 0x0006057C File Offset: 0x0005E77C
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000F75 RID: 3957
		// (get) Token: 0x06003209 RID: 12809 RVA: 0x0006058C File Offset: 0x0005E78C
		// (set) Token: 0x0600320A RID: 12810 RVA: 0x000605AC File Offset: 0x0005E7AC
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

		// Token: 0x0600320B RID: 12811 RVA: 0x000605F0 File Offset: 0x0005E7F0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x00060608 File Offset: 0x0005E808
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600320D RID: 12813 RVA: 0x00060614 File Offset: 0x0005E814
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C6A RID: 3178
		private ErrorCode? _errorcode;

		// Token: 0x04000C6B RID: 3179
		private IExtension extensionObject;
	}
}
