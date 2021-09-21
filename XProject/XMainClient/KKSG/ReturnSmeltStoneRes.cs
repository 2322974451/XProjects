using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000413 RID: 1043
	[ProtoContract(Name = "ReturnSmeltStoneRes")]
	[Serializable]
	public class ReturnSmeltStoneRes : IExtensible
	{
		// Token: 0x1700110D RID: 4365
		// (get) Token: 0x0600377A RID: 14202 RVA: 0x0006A3C0 File Offset: 0x000685C0
		// (set) Token: 0x0600377B RID: 14203 RVA: 0x0006A3EC File Offset: 0x000685EC
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

		// Token: 0x1700110E RID: 4366
		// (get) Token: 0x0600377C RID: 14204 RVA: 0x0006A3FC File Offset: 0x000685FC
		// (set) Token: 0x0600377D RID: 14205 RVA: 0x0006A41C File Offset: 0x0006861C
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

		// Token: 0x0600377E RID: 14206 RVA: 0x0006A460 File Offset: 0x00068660
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600377F RID: 14207 RVA: 0x0006A478 File Offset: 0x00068678
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003780 RID: 14208 RVA: 0x0006A484 File Offset: 0x00068684
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DC0 RID: 3520
		private ErrorCode? _errorcode;

		// Token: 0x04000DC1 RID: 3521
		private IExtension extensionObject;
	}
}
