using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200021D RID: 541
	[ProtoContract(Name = "RiskBuyRequestRes")]
	[Serializable]
	public class RiskBuyRequestRes : IExtensible
	{
		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06001E32 RID: 7730 RVA: 0x0003B4D4 File Offset: 0x000396D4
		// (set) Token: 0x06001E33 RID: 7731 RVA: 0x0003B500 File Offset: 0x00039700
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

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06001E34 RID: 7732 RVA: 0x0003B510 File Offset: 0x00039710
		// (set) Token: 0x06001E35 RID: 7733 RVA: 0x0003B530 File Offset: 0x00039730
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

		// Token: 0x06001E36 RID: 7734 RVA: 0x0003B574 File Offset: 0x00039774
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x0003B58C File Offset: 0x0003978C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x06001E38 RID: 7736 RVA: 0x0003B598 File Offset: 0x00039798
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400078F RID: 1935
		private ErrorCode? _error;

		// Token: 0x04000790 RID: 1936
		private IExtension extensionObject;
	}
}
