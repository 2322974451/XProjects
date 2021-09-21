using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E9 RID: 233
	[ProtoContract(Name = "ChangeSupplementReport")]
	[Serializable]
	public class ChangeSupplementReport : IExtensible
	{
		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0001EDCC File Offset: 0x0001CFCC
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x0001EDF9 File Offset: 0x0001CFF9
		[ProtoMember(1, IsRequired = false, Name = "uniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong uniqueid
		{
			get
			{
				return this._uniqueid ?? 0UL;
			}
			set
			{
				this._uniqueid = new ulong?(value);
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x0001EE08 File Offset: 0x0001D008
		// (set) Token: 0x06000EF1 RID: 3825 RVA: 0x0001EE28 File Offset: 0x0001D028
		[XmlIgnore]
		[Browsable(false)]
		public bool uniqueidSpecified
		{
			get
			{
				return this._uniqueid != null;
			}
			set
			{
				bool flag = value == (this._uniqueid == null);
				if (flag)
				{
					this._uniqueid = (value ? new ulong?(this.uniqueid) : null);
				}
			}
		}

		// Token: 0x06000EF2 RID: 3826 RVA: 0x0001EE6C File Offset: 0x0001D06C
		private bool ShouldSerializeuniqueid()
		{
			return this.uniqueidSpecified;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x0001EE84 File Offset: 0x0001D084
		private void Resetuniqueid()
		{
			this.uniqueidSpecified = false;
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x0001EE90 File Offset: 0x0001D090
		// (set) Token: 0x06000EF5 RID: 3829 RVA: 0x0001EEBC File Offset: 0x0001D0BC
		[ProtoMember(2, IsRequired = false, Name = "slot", DataFormat = DataFormat.TwosComplement)]
		public uint slot
		{
			get
			{
				return this._slot ?? 0U;
			}
			set
			{
				this._slot = new uint?(value);
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x0001EECC File Offset: 0x0001D0CC
		// (set) Token: 0x06000EF7 RID: 3831 RVA: 0x0001EEEC File Offset: 0x0001D0EC
		[XmlIgnore]
		[Browsable(false)]
		public bool slotSpecified
		{
			get
			{
				return this._slot != null;
			}
			set
			{
				bool flag = value == (this._slot == null);
				if (flag)
				{
					this._slot = (value ? new uint?(this.slot) : null);
				}
			}
		}

		// Token: 0x06000EF8 RID: 3832 RVA: 0x0001EF30 File Offset: 0x0001D130
		private bool ShouldSerializeslot()
		{
			return this.slotSpecified;
		}

		// Token: 0x06000EF9 RID: 3833 RVA: 0x0001EF48 File Offset: 0x0001D148
		private void Resetslot()
		{
			this.slotSpecified = false;
		}

		// Token: 0x06000EFA RID: 3834 RVA: 0x0001EF54 File Offset: 0x0001D154
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003C1 RID: 961
		private ulong? _uniqueid;

		// Token: 0x040003C2 RID: 962
		private uint? _slot;

		// Token: 0x040003C3 RID: 963
		private IExtension extensionObject;
	}
}
