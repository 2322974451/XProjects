using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001B4 RID: 436
	[ProtoContract(Name = "NotifyTransferWall")]
	[Serializable]
	public class NotifyTransferWall : IExtensible
	{
		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x0600199C RID: 6556 RVA: 0x00032D28 File Offset: 0x00030F28
		// (set) Token: 0x0600199D RID: 6557 RVA: 0x00032D54 File Offset: 0x00030F54
		[ProtoMember(1, IsRequired = false, Name = "transfer", DataFormat = DataFormat.Default)]
		public bool transfer
		{
			get
			{
				return this._transfer ?? false;
			}
			set
			{
				this._transfer = new bool?(value);
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x0600199E RID: 6558 RVA: 0x00032D64 File Offset: 0x00030F64
		// (set) Token: 0x0600199F RID: 6559 RVA: 0x00032D84 File Offset: 0x00030F84
		[XmlIgnore]
		[Browsable(false)]
		public bool transferSpecified
		{
			get
			{
				return this._transfer != null;
			}
			set
			{
				bool flag = value == (this._transfer == null);
				if (flag)
				{
					this._transfer = (value ? new bool?(this.transfer) : null);
				}
			}
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x00032DC8 File Offset: 0x00030FC8
		private bool ShouldSerializetransfer()
		{
			return this.transferSpecified;
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x00032DE0 File Offset: 0x00030FE0
		private void Resettransfer()
		{
			this.transferSpecified = false;
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x060019A2 RID: 6562 RVA: 0x00032DEC File Offset: 0x00030FEC
		// (set) Token: 0x060019A3 RID: 6563 RVA: 0x00032E18 File Offset: 0x00031018
		[ProtoMember(2, IsRequired = false, Name = "wallid", DataFormat = DataFormat.TwosComplement)]
		public int wallid
		{
			get
			{
				return this._wallid ?? 0;
			}
			set
			{
				this._wallid = new int?(value);
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x060019A4 RID: 6564 RVA: 0x00032E28 File Offset: 0x00031028
		// (set) Token: 0x060019A5 RID: 6565 RVA: 0x00032E48 File Offset: 0x00031048
		[XmlIgnore]
		[Browsable(false)]
		public bool wallidSpecified
		{
			get
			{
				return this._wallid != null;
			}
			set
			{
				bool flag = value == (this._wallid == null);
				if (flag)
				{
					this._wallid = (value ? new int?(this.wallid) : null);
				}
			}
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x00032E8C File Offset: 0x0003108C
		private bool ShouldSerializewallid()
		{
			return this.wallidSpecified;
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x00032EA4 File Offset: 0x000310A4
		private void Resetwallid()
		{
			this.wallidSpecified = false;
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x00032EB0 File Offset: 0x000310B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400065E RID: 1630
		private bool? _transfer;

		// Token: 0x0400065F RID: 1631
		private int? _wallid;

		// Token: 0x04000660 RID: 1632
		private IExtension extensionObject;
	}
}
