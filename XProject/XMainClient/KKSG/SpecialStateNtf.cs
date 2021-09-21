using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000364 RID: 868
	[ProtoContract(Name = "SpecialStateNtf")]
	[Serializable]
	public class SpecialStateNtf : IExtensible
	{
		// Token: 0x17000EAA RID: 3754
		// (get) Token: 0x06002F5B RID: 12123 RVA: 0x0005B66C File Offset: 0x0005986C
		// (set) Token: 0x06002F5C RID: 12124 RVA: 0x0005B698 File Offset: 0x00059898
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17000EAB RID: 3755
		// (get) Token: 0x06002F5D RID: 12125 RVA: 0x0005B6A8 File Offset: 0x000598A8
		// (set) Token: 0x06002F5E RID: 12126 RVA: 0x0005B6C8 File Offset: 0x000598C8
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06002F5F RID: 12127 RVA: 0x0005B70C File Offset: 0x0005990C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06002F60 RID: 12128 RVA: 0x0005B724 File Offset: 0x00059924
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17000EAC RID: 3756
		// (get) Token: 0x06002F61 RID: 12129 RVA: 0x0005B730 File Offset: 0x00059930
		// (set) Token: 0x06002F62 RID: 12130 RVA: 0x0005B75C File Offset: 0x0005995C
		[ProtoMember(2, IsRequired = false, Name = "effectmask", DataFormat = DataFormat.TwosComplement)]
		public uint effectmask
		{
			get
			{
				return this._effectmask ?? 0U;
			}
			set
			{
				this._effectmask = new uint?(value);
			}
		}

		// Token: 0x17000EAD RID: 3757
		// (get) Token: 0x06002F63 RID: 12131 RVA: 0x0005B76C File Offset: 0x0005996C
		// (set) Token: 0x06002F64 RID: 12132 RVA: 0x0005B78C File Offset: 0x0005998C
		[XmlIgnore]
		[Browsable(false)]
		public bool effectmaskSpecified
		{
			get
			{
				return this._effectmask != null;
			}
			set
			{
				bool flag = value == (this._effectmask == null);
				if (flag)
				{
					this._effectmask = (value ? new uint?(this.effectmask) : null);
				}
			}
		}

		// Token: 0x06002F65 RID: 12133 RVA: 0x0005B7D0 File Offset: 0x000599D0
		private bool ShouldSerializeeffectmask()
		{
			return this.effectmaskSpecified;
		}

		// Token: 0x06002F66 RID: 12134 RVA: 0x0005B7E8 File Offset: 0x000599E8
		private void Reseteffectmask()
		{
			this.effectmaskSpecified = false;
		}

		// Token: 0x17000EAE RID: 3758
		// (get) Token: 0x06002F67 RID: 12135 RVA: 0x0005B7F4 File Offset: 0x000599F4
		// (set) Token: 0x06002F68 RID: 12136 RVA: 0x0005B821 File Offset: 0x00059A21
		[ProtoMember(3, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x17000EAF RID: 3759
		// (get) Token: 0x06002F69 RID: 12137 RVA: 0x0005B830 File Offset: 0x00059A30
		// (set) Token: 0x06002F6A RID: 12138 RVA: 0x0005B850 File Offset: 0x00059A50
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x0005B894 File Offset: 0x00059A94
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06002F6C RID: 12140 RVA: 0x0005B8AC File Offset: 0x00059AAC
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x0005B8B8 File Offset: 0x00059AB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BBF RID: 3007
		private uint? _state;

		// Token: 0x04000BC0 RID: 3008
		private uint? _effectmask;

		// Token: 0x04000BC1 RID: 3009
		private ulong? _uid;

		// Token: 0x04000BC2 RID: 3010
		private IExtension extensionObject;
	}
}
