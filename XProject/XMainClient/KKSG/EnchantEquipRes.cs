using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000303 RID: 771
	[ProtoContract(Name = "EnchantEquipRes")]
	[Serializable]
	public class EnchantEquipRes : IExtensible
	{
		// Token: 0x17000D10 RID: 3344
		// (get) Token: 0x06002A26 RID: 10790 RVA: 0x00051B7C File Offset: 0x0004FD7C
		// (set) Token: 0x06002A27 RID: 10791 RVA: 0x00051BA8 File Offset: 0x0004FDA8
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

		// Token: 0x17000D11 RID: 3345
		// (get) Token: 0x06002A28 RID: 10792 RVA: 0x00051BB8 File Offset: 0x0004FDB8
		// (set) Token: 0x06002A29 RID: 10793 RVA: 0x00051BD8 File Offset: 0x0004FDD8
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

		// Token: 0x06002A2A RID: 10794 RVA: 0x00051C1C File Offset: 0x0004FE1C
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002A2B RID: 10795 RVA: 0x00051C34 File Offset: 0x0004FE34
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000D12 RID: 3346
		// (get) Token: 0x06002A2C RID: 10796 RVA: 0x00051C40 File Offset: 0x0004FE40
		// (set) Token: 0x06002A2D RID: 10797 RVA: 0x00051C58 File Offset: 0x0004FE58
		[ProtoMember(2, IsRequired = false, Name = "attr", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AttributeInfo attr
		{
			get
			{
				return this._attr;
			}
			set
			{
				this._attr = value;
			}
		}

		// Token: 0x06002A2E RID: 10798 RVA: 0x00051C64 File Offset: 0x0004FE64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A78 RID: 2680
		private ErrorCode? _errorcode;

		// Token: 0x04000A79 RID: 2681
		private AttributeInfo _attr = null;

		// Token: 0x04000A7A RID: 2682
		private IExtension extensionObject;
	}
}
