using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200026F RID: 623
	[ProtoContract(Name = "GetSpActivityRewardRes")]
	[Serializable]
	public class GetSpActivityRewardRes : IExtensible
	{
		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x060022BC RID: 8892 RVA: 0x00043DB0 File Offset: 0x00041FB0
		// (set) Token: 0x060022BD RID: 8893 RVA: 0x00043DDC File Offset: 0x00041FDC
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

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x060022BE RID: 8894 RVA: 0x00043DEC File Offset: 0x00041FEC
		// (set) Token: 0x060022BF RID: 8895 RVA: 0x00043E0C File Offset: 0x0004200C
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

		// Token: 0x060022C0 RID: 8896 RVA: 0x00043E50 File Offset: 0x00042050
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x00043E68 File Offset: 0x00042068
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x00043E74 File Offset: 0x00042074
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400089F RID: 2207
		private ErrorCode? _errorcode;

		// Token: 0x040008A0 RID: 2208
		private IExtension extensionObject;
	}
}
