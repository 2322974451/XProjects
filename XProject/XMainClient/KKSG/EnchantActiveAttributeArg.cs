using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000403 RID: 1027
	[ProtoContract(Name = "EnchantActiveAttributeArg")]
	[Serializable]
	public class EnchantActiveAttributeArg : IExtensible
	{
		// Token: 0x170010DA RID: 4314
		// (get) Token: 0x060036C7 RID: 14023 RVA: 0x00068F2C File Offset: 0x0006712C
		// (set) Token: 0x060036C8 RID: 14024 RVA: 0x00068F59 File Offset: 0x00067159
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170010DB RID: 4315
		// (get) Token: 0x060036C9 RID: 14025 RVA: 0x00068F68 File Offset: 0x00067168
		// (set) Token: 0x060036CA RID: 14026 RVA: 0x00068F88 File Offset: 0x00067188
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

		// Token: 0x060036CB RID: 14027 RVA: 0x00068FCC File Offset: 0x000671CC
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x060036CC RID: 14028 RVA: 0x00068FE4 File Offset: 0x000671E4
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x170010DC RID: 4316
		// (get) Token: 0x060036CD RID: 14029 RVA: 0x00068FF0 File Offset: 0x000671F0
		// (set) Token: 0x060036CE RID: 14030 RVA: 0x0006901C File Offset: 0x0006721C
		[ProtoMember(2, IsRequired = false, Name = "attrID", DataFormat = DataFormat.TwosComplement)]
		public uint attrID
		{
			get
			{
				return this._attrID ?? 0U;
			}
			set
			{
				this._attrID = new uint?(value);
			}
		}

		// Token: 0x170010DD RID: 4317
		// (get) Token: 0x060036CF RID: 14031 RVA: 0x0006902C File Offset: 0x0006722C
		// (set) Token: 0x060036D0 RID: 14032 RVA: 0x0006904C File Offset: 0x0006724C
		[XmlIgnore]
		[Browsable(false)]
		public bool attrIDSpecified
		{
			get
			{
				return this._attrID != null;
			}
			set
			{
				bool flag = value == (this._attrID == null);
				if (flag)
				{
					this._attrID = (value ? new uint?(this.attrID) : null);
				}
			}
		}

		// Token: 0x060036D1 RID: 14033 RVA: 0x00069090 File Offset: 0x00067290
		private bool ShouldSerializeattrID()
		{
			return this.attrIDSpecified;
		}

		// Token: 0x060036D2 RID: 14034 RVA: 0x000690A8 File Offset: 0x000672A8
		private void ResetattrID()
		{
			this.attrIDSpecified = false;
		}

		// Token: 0x060036D3 RID: 14035 RVA: 0x000690B4 File Offset: 0x000672B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D95 RID: 3477
		private ulong? _uid;

		// Token: 0x04000D96 RID: 3478
		private uint? _attrID;

		// Token: 0x04000D97 RID: 3479
		private IExtension extensionObject;
	}
}
