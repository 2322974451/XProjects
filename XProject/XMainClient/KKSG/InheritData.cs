using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006CF RID: 1743
	[ProtoContract(Name = "InheritData")]
	[Serializable]
	public class InheritData : IExtensible
	{
		// Token: 0x17002493 RID: 9363
		// (get) Token: 0x06007388 RID: 29576 RVA: 0x000DD0C8 File Offset: 0x000DB2C8
		// (set) Token: 0x06007389 RID: 29577 RVA: 0x000DD0E9 File Offset: 0x000DB2E9
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002494 RID: 9364
		// (get) Token: 0x0600738A RID: 29578 RVA: 0x000DD0F4 File Offset: 0x000DB2F4
		// (set) Token: 0x0600738B RID: 29579 RVA: 0x000DD110 File Offset: 0x000DB310
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x0600738C RID: 29580 RVA: 0x000DD140 File Offset: 0x000DB340
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600738D RID: 29581 RVA: 0x000DD158 File Offset: 0x000DB358
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002495 RID: 9365
		// (get) Token: 0x0600738E RID: 29582 RVA: 0x000DD164 File Offset: 0x000DB364
		// (set) Token: 0x0600738F RID: 29583 RVA: 0x000DD190 File Offset: 0x000DB390
		[ProtoMember(2, IsRequired = false, Name = "lvl", DataFormat = DataFormat.TwosComplement)]
		public uint lvl
		{
			get
			{
				return this._lvl ?? 0U;
			}
			set
			{
				this._lvl = new uint?(value);
			}
		}

		// Token: 0x17002496 RID: 9366
		// (get) Token: 0x06007390 RID: 29584 RVA: 0x000DD1A0 File Offset: 0x000DB3A0
		// (set) Token: 0x06007391 RID: 29585 RVA: 0x000DD1C0 File Offset: 0x000DB3C0
		[XmlIgnore]
		[Browsable(false)]
		public bool lvlSpecified
		{
			get
			{
				return this._lvl != null;
			}
			set
			{
				bool flag = value == (this._lvl == null);
				if (flag)
				{
					this._lvl = (value ? new uint?(this.lvl) : null);
				}
			}
		}

		// Token: 0x06007392 RID: 29586 RVA: 0x000DD204 File Offset: 0x000DB404
		private bool ShouldSerializelvl()
		{
			return this.lvlSpecified;
		}

		// Token: 0x06007393 RID: 29587 RVA: 0x000DD21C File Offset: 0x000DB41C
		private void Resetlvl()
		{
			this.lvlSpecified = false;
		}

		// Token: 0x17002497 RID: 9367
		// (get) Token: 0x06007394 RID: 29588 RVA: 0x000DD228 File Offset: 0x000DB428
		// (set) Token: 0x06007395 RID: 29589 RVA: 0x000DD254 File Offset: 0x000DB454
		[ProtoMember(3, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17002498 RID: 9368
		// (get) Token: 0x06007396 RID: 29590 RVA: 0x000DD264 File Offset: 0x000DB464
		// (set) Token: 0x06007397 RID: 29591 RVA: 0x000DD284 File Offset: 0x000DB484
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007398 RID: 29592 RVA: 0x000DD2C8 File Offset: 0x000DB4C8
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007399 RID: 29593 RVA: 0x000DD2E0 File Offset: 0x000DB4E0
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x17002499 RID: 9369
		// (get) Token: 0x0600739A RID: 29594 RVA: 0x000DD2EC File Offset: 0x000DB4EC
		// (set) Token: 0x0600739B RID: 29595 RVA: 0x000DD319 File Offset: 0x000DB519
		[ProtoMember(4, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		// Token: 0x1700249A RID: 9370
		// (get) Token: 0x0600739C RID: 29596 RVA: 0x000DD328 File Offset: 0x000DB528
		// (set) Token: 0x0600739D RID: 29597 RVA: 0x000DD348 File Offset: 0x000DB548
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		// Token: 0x0600739E RID: 29598 RVA: 0x000DD38C File Offset: 0x000DB58C
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x0600739F RID: 29599 RVA: 0x000DD3A4 File Offset: 0x000DB5A4
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x060073A0 RID: 29600 RVA: 0x000DD3B0 File Offset: 0x000DB5B0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B79 RID: 7033
		private string _name;

		// Token: 0x04001B7A RID: 7034
		private uint? _lvl;

		// Token: 0x04001B7B RID: 7035
		private uint? _time;

		// Token: 0x04001B7C RID: 7036
		private ulong? _roleId;

		// Token: 0x04001B7D RID: 7037
		private IExtension extensionObject;
	}
}
