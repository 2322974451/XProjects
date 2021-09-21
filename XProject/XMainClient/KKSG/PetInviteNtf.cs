using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000435 RID: 1077
	[ProtoContract(Name = "PetInviteNtf")]
	[Serializable]
	public class PetInviteNtf : IExtensible
	{
		// Token: 0x1700117E RID: 4478
		// (get) Token: 0x060038F6 RID: 14582 RVA: 0x0006D020 File Offset: 0x0006B220
		// (set) Token: 0x060038F7 RID: 14583 RVA: 0x0006D038 File Offset: 0x0006B238
		[ProtoMember(1, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PetInviteInfo info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x1700117F RID: 4479
		// (get) Token: 0x060038F8 RID: 14584 RVA: 0x0006D044 File Offset: 0x0006B244
		// (set) Token: 0x060038F9 RID: 14585 RVA: 0x0006D070 File Offset: 0x0006B270
		[ProtoMember(2, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		// Token: 0x17001180 RID: 4480
		// (get) Token: 0x060038FA RID: 14586 RVA: 0x0006D080 File Offset: 0x0006B280
		// (set) Token: 0x060038FB RID: 14587 RVA: 0x0006D0A0 File Offset: 0x0006B2A0
		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		// Token: 0x060038FC RID: 14588 RVA: 0x0006D0E4 File Offset: 0x0006B2E4
		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		// Token: 0x060038FD RID: 14589 RVA: 0x0006D0FC File Offset: 0x0006B2FC
		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		// Token: 0x060038FE RID: 14590 RVA: 0x0006D108 File Offset: 0x0006B308
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E22 RID: 3618
		private PetInviteInfo _info = null;

		// Token: 0x04000E23 RID: 3619
		private uint? _allcount;

		// Token: 0x04000E24 RID: 3620
		private IExtension extensionObject;
	}
}
