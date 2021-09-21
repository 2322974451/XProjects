using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E2 RID: 738
	[ProtoContract(Name = "NoticeDoingGuildInherit")]
	[Serializable]
	public class NoticeDoingGuildInherit : IExtensible
	{
		// Token: 0x17000C9D RID: 3229
		// (get) Token: 0x0600289A RID: 10394 RVA: 0x0004EE14 File Offset: 0x0004D014
		// (set) Token: 0x0600289B RID: 10395 RVA: 0x0004EE41 File Offset: 0x0004D041
		[ProtoMember(1, IsRequired = false, Name = "roleOne", DataFormat = DataFormat.TwosComplement)]
		public ulong roleOne
		{
			get
			{
				return this._roleOne ?? 0UL;
			}
			set
			{
				this._roleOne = new ulong?(value);
			}
		}

		// Token: 0x17000C9E RID: 3230
		// (get) Token: 0x0600289C RID: 10396 RVA: 0x0004EE50 File Offset: 0x0004D050
		// (set) Token: 0x0600289D RID: 10397 RVA: 0x0004EE70 File Offset: 0x0004D070
		[XmlIgnore]
		[Browsable(false)]
		public bool roleOneSpecified
		{
			get
			{
				return this._roleOne != null;
			}
			set
			{
				bool flag = value == (this._roleOne == null);
				if (flag)
				{
					this._roleOne = (value ? new ulong?(this.roleOne) : null);
				}
			}
		}

		// Token: 0x0600289E RID: 10398 RVA: 0x0004EEB4 File Offset: 0x0004D0B4
		private bool ShouldSerializeroleOne()
		{
			return this.roleOneSpecified;
		}

		// Token: 0x0600289F RID: 10399 RVA: 0x0004EECC File Offset: 0x0004D0CC
		private void ResetroleOne()
		{
			this.roleOneSpecified = false;
		}

		// Token: 0x17000C9F RID: 3231
		// (get) Token: 0x060028A0 RID: 10400 RVA: 0x0004EED8 File Offset: 0x0004D0D8
		// (set) Token: 0x060028A1 RID: 10401 RVA: 0x0004EF05 File Offset: 0x0004D105
		[ProtoMember(2, IsRequired = false, Name = "roleTwo", DataFormat = DataFormat.TwosComplement)]
		public ulong roleTwo
		{
			get
			{
				return this._roleTwo ?? 0UL;
			}
			set
			{
				this._roleTwo = new ulong?(value);
			}
		}

		// Token: 0x17000CA0 RID: 3232
		// (get) Token: 0x060028A2 RID: 10402 RVA: 0x0004EF14 File Offset: 0x0004D114
		// (set) Token: 0x060028A3 RID: 10403 RVA: 0x0004EF34 File Offset: 0x0004D134
		[XmlIgnore]
		[Browsable(false)]
		public bool roleTwoSpecified
		{
			get
			{
				return this._roleTwo != null;
			}
			set
			{
				bool flag = value == (this._roleTwo == null);
				if (flag)
				{
					this._roleTwo = (value ? new ulong?(this.roleTwo) : null);
				}
			}
		}

		// Token: 0x060028A4 RID: 10404 RVA: 0x0004EF78 File Offset: 0x0004D178
		private bool ShouldSerializeroleTwo()
		{
			return this.roleTwoSpecified;
		}

		// Token: 0x060028A5 RID: 10405 RVA: 0x0004EF90 File Offset: 0x0004D190
		private void ResetroleTwo()
		{
			this.roleTwoSpecified = false;
		}

		// Token: 0x17000CA1 RID: 3233
		// (get) Token: 0x060028A6 RID: 10406 RVA: 0x0004EF9C File Offset: 0x0004D19C
		// (set) Token: 0x060028A7 RID: 10407 RVA: 0x0004EFC8 File Offset: 0x0004D1C8
		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000CA2 RID: 3234
		// (get) Token: 0x060028A8 RID: 10408 RVA: 0x0004EFD8 File Offset: 0x0004D1D8
		// (set) Token: 0x060028A9 RID: 10409 RVA: 0x0004EFF8 File Offset: 0x0004D1F8
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060028AA RID: 10410 RVA: 0x0004F03C File Offset: 0x0004D23C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060028AB RID: 10411 RVA: 0x0004F054 File Offset: 0x0004D254
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060028AC RID: 10412 RVA: 0x0004F060 File Offset: 0x0004D260
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A19 RID: 2585
		private ulong? _roleOne;

		// Token: 0x04000A1A RID: 2586
		private ulong? _roleTwo;

		// Token: 0x04000A1B RID: 2587
		private uint? _type;

		// Token: 0x04000A1C RID: 2588
		private IExtension extensionObject;
	}
}
