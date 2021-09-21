using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000577 RID: 1399
	[ProtoContract(Name = "OutLookState")]
	[Serializable]
	public class OutLookState : IExtensible
	{
		// Token: 0x1700161B RID: 5659
		// (get) Token: 0x06004824 RID: 18468 RVA: 0x0008907C File Offset: 0x0008727C
		// (set) Token: 0x06004825 RID: 18469 RVA: 0x000890A8 File Offset: 0x000872A8
		[ProtoMember(1, IsRequired = false, Name = "statetype", DataFormat = DataFormat.TwosComplement)]
		public OutLookStateType statetype
		{
			get
			{
				return this._statetype ?? OutLookStateType.OutLook_Normal;
			}
			set
			{
				this._statetype = new OutLookStateType?(value);
			}
		}

		// Token: 0x1700161C RID: 5660
		// (get) Token: 0x06004826 RID: 18470 RVA: 0x000890B8 File Offset: 0x000872B8
		// (set) Token: 0x06004827 RID: 18471 RVA: 0x000890D8 File Offset: 0x000872D8
		[XmlIgnore]
		[Browsable(false)]
		public bool statetypeSpecified
		{
			get
			{
				return this._statetype != null;
			}
			set
			{
				bool flag = value == (this._statetype == null);
				if (flag)
				{
					this._statetype = (value ? new OutLookStateType?(this.statetype) : null);
				}
			}
		}

		// Token: 0x06004828 RID: 18472 RVA: 0x0008911C File Offset: 0x0008731C
		private bool ShouldSerializestatetype()
		{
			return this.statetypeSpecified;
		}

		// Token: 0x06004829 RID: 18473 RVA: 0x00089134 File Offset: 0x00087334
		private void Resetstatetype()
		{
			this.statetypeSpecified = false;
		}

		// Token: 0x1700161D RID: 5661
		// (get) Token: 0x0600482A RID: 18474 RVA: 0x00089140 File Offset: 0x00087340
		// (set) Token: 0x0600482B RID: 18475 RVA: 0x0008916C File Offset: 0x0008736C
		[ProtoMember(2, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x1700161E RID: 5662
		// (get) Token: 0x0600482C RID: 18476 RVA: 0x0008917C File Offset: 0x0008737C
		// (set) Token: 0x0600482D RID: 18477 RVA: 0x0008919C File Offset: 0x0008739C
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x0600482E RID: 18478 RVA: 0x000891E0 File Offset: 0x000873E0
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x0600482F RID: 18479 RVA: 0x000891F8 File Offset: 0x000873F8
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x1700161F RID: 5663
		// (get) Token: 0x06004830 RID: 18480 RVA: 0x00089204 File Offset: 0x00087404
		// (set) Token: 0x06004831 RID: 18481 RVA: 0x00089231 File Offset: 0x00087431
		[ProtoMember(3, IsRequired = false, Name = "paramother", DataFormat = DataFormat.TwosComplement)]
		public ulong paramother
		{
			get
			{
				return this._paramother ?? 0UL;
			}
			set
			{
				this._paramother = new ulong?(value);
			}
		}

		// Token: 0x17001620 RID: 5664
		// (get) Token: 0x06004832 RID: 18482 RVA: 0x00089240 File Offset: 0x00087440
		// (set) Token: 0x06004833 RID: 18483 RVA: 0x00089260 File Offset: 0x00087460
		[XmlIgnore]
		[Browsable(false)]
		public bool paramotherSpecified
		{
			get
			{
				return this._paramother != null;
			}
			set
			{
				bool flag = value == (this._paramother == null);
				if (flag)
				{
					this._paramother = (value ? new ulong?(this.paramother) : null);
				}
			}
		}

		// Token: 0x06004834 RID: 18484 RVA: 0x000892A4 File Offset: 0x000874A4
		private bool ShouldSerializeparamother()
		{
			return this.paramotherSpecified;
		}

		// Token: 0x06004835 RID: 18485 RVA: 0x000892BC File Offset: 0x000874BC
		private void Resetparamother()
		{
			this.paramotherSpecified = false;
		}

		// Token: 0x06004836 RID: 18486 RVA: 0x000892C8 File Offset: 0x000874C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400120A RID: 4618
		private OutLookStateType? _statetype;

		// Token: 0x0400120B RID: 4619
		private uint? _param;

		// Token: 0x0400120C RID: 4620
		private ulong? _paramother;

		// Token: 0x0400120D RID: 4621
		private IExtension extensionObject;
	}
}
