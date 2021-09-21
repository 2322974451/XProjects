using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000057 RID: 87
	[ProtoContract(Name = "ReviveArg")]
	[Serializable]
	public class ReviveArg : IExtensible
	{
		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000DC94 File Offset: 0x0000BE94
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0000DCC0 File Offset: 0x0000BEC0
		[ProtoMember(1, IsRequired = false, Name = "selectBuff", DataFormat = DataFormat.TwosComplement)]
		public uint selectBuff
		{
			get
			{
				return this._selectBuff ?? 0U;
			}
			set
			{
				this._selectBuff = new uint?(value);
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0000DCD0 File Offset: 0x0000BED0
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		[XmlIgnore]
		[Browsable(false)]
		public bool selectBuffSpecified
		{
			get
			{
				return this._selectBuff != null;
			}
			set
			{
				bool flag = value == (this._selectBuff == null);
				if (flag)
				{
					this._selectBuff = (value ? new uint?(this.selectBuff) : null);
				}
			}
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x0000DD34 File Offset: 0x0000BF34
		private bool ShouldSerializeselectBuff()
		{
			return this.selectBuffSpecified;
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0000DD4C File Offset: 0x0000BF4C
		private void ResetselectBuff()
		{
			this.selectBuffSpecified = false;
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0000DD58 File Offset: 0x0000BF58
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x0000DD84 File Offset: 0x0000BF84
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public ReviveType type
		{
			get
			{
				return this._type ?? ReviveType.ReviveNone;
			}
			set
			{
				this._type = new ReviveType?(value);
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0000DD94 File Offset: 0x0000BF94
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x0000DDB4 File Offset: 0x0000BFB4
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new ReviveType?(this.type) : null);
				}
			}
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0000DDF8 File Offset: 0x0000BFF8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0000DE10 File Offset: 0x0000C010
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x0000DE1C File Offset: 0x0000C01C
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x0000DE34 File Offset: 0x0000C034
		[ProtoMember(3, IsRequired = false, Name = "clientinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ClientReviveInfo clientinfo
		{
			get
			{
				return this._clientinfo;
			}
			set
			{
				this._clientinfo = value;
			}
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0000DE40 File Offset: 0x0000C040
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400017A RID: 378
		private uint? _selectBuff;

		// Token: 0x0400017B RID: 379
		private ReviveType? _type;

		// Token: 0x0400017C RID: 380
		private ClientReviveInfo _clientinfo = null;

		// Token: 0x0400017D RID: 381
		private IExtension extensionObject;
	}
}
