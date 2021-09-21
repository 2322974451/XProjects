using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000515 RID: 1301
	[ProtoContract(Name = "BigMeleePointOutLook")]
	[Serializable]
	public class BigMeleePointOutLook : IExtensible
	{
		// Token: 0x17001473 RID: 5235
		// (get) Token: 0x060042E3 RID: 17123 RVA: 0x0007F450 File Offset: 0x0007D650
		// (set) Token: 0x060042E4 RID: 17124 RVA: 0x0007F47D File Offset: 0x0007D67D
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17001474 RID: 5236
		// (get) Token: 0x060042E5 RID: 17125 RVA: 0x0007F48C File Offset: 0x0007D68C
		// (set) Token: 0x060042E6 RID: 17126 RVA: 0x0007F4AC File Offset: 0x0007D6AC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x060042E7 RID: 17127 RVA: 0x0007F4F0 File Offset: 0x0007D6F0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x060042E8 RID: 17128 RVA: 0x0007F508 File Offset: 0x0007D708
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001475 RID: 5237
		// (get) Token: 0x060042E9 RID: 17129 RVA: 0x0007F514 File Offset: 0x0007D714
		// (set) Token: 0x060042EA RID: 17130 RVA: 0x0007F540 File Offset: 0x0007D740
		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001476 RID: 5238
		// (get) Token: 0x060042EB RID: 17131 RVA: 0x0007F550 File Offset: 0x0007D750
		// (set) Token: 0x060042EC RID: 17132 RVA: 0x0007F570 File Offset: 0x0007D770
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x060042ED RID: 17133 RVA: 0x0007F5B4 File Offset: 0x0007D7B4
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x060042EE RID: 17134 RVA: 0x0007F5CC File Offset: 0x0007D7CC
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x060042EF RID: 17135 RVA: 0x0007F5D8 File Offset: 0x0007D7D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010AF RID: 4271
		private ulong? _roleid;

		// Token: 0x040010B0 RID: 4272
		private uint? _point;

		// Token: 0x040010B1 RID: 4273
		private IExtension extensionObject;
	}
}
