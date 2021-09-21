using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F2 RID: 754
	[ProtoContract(Name = "ResWarBuffRes")]
	[Serializable]
	public class ResWarBuffRes : IExtensible
	{
		// Token: 0x17000CDD RID: 3293
		// (get) Token: 0x06002971 RID: 10609 RVA: 0x000506E0 File Offset: 0x0004E8E0
		// (set) Token: 0x06002972 RID: 10610 RVA: 0x0005070C File Offset: 0x0004E90C
		[ProtoMember(1, IsRequired = false, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public uint buffid
		{
			get
			{
				return this._buffid ?? 0U;
			}
			set
			{
				this._buffid = new uint?(value);
			}
		}

		// Token: 0x17000CDE RID: 3294
		// (get) Token: 0x06002973 RID: 10611 RVA: 0x0005071C File Offset: 0x0004E91C
		// (set) Token: 0x06002974 RID: 10612 RVA: 0x0005073C File Offset: 0x0004E93C
		[XmlIgnore]
		[Browsable(false)]
		public bool buffidSpecified
		{
			get
			{
				return this._buffid != null;
			}
			set
			{
				bool flag = value == (this._buffid == null);
				if (flag)
				{
					this._buffid = (value ? new uint?(this.buffid) : null);
				}
			}
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x00050780 File Offset: 0x0004E980
		private bool ShouldSerializebuffid()
		{
			return this.buffidSpecified;
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x00050798 File Offset: 0x0004E998
		private void Resetbuffid()
		{
			this.buffidSpecified = false;
		}

		// Token: 0x17000CDF RID: 3295
		// (get) Token: 0x06002977 RID: 10615 RVA: 0x000507A4 File Offset: 0x0004E9A4
		// (set) Token: 0x06002978 RID: 10616 RVA: 0x000507D0 File Offset: 0x0004E9D0
		[ProtoMember(2, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000CE0 RID: 3296
		// (get) Token: 0x06002979 RID: 10617 RVA: 0x000507E0 File Offset: 0x0004E9E0
		// (set) Token: 0x0600297A RID: 10618 RVA: 0x00050800 File Offset: 0x0004EA00
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

		// Token: 0x0600297B RID: 10619 RVA: 0x00050844 File Offset: 0x0004EA44
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x0005085C File Offset: 0x0004EA5C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x00050868 File Offset: 0x0004EA68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A4C RID: 2636
		private uint? _buffid;

		// Token: 0x04000A4D RID: 2637
		private ErrorCode? _error;

		// Token: 0x04000A4E RID: 2638
		private IExtension extensionObject;
	}
}
