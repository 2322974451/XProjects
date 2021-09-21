using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000073 RID: 115
	[ProtoContract(Name = "AddFriendArg")]
	[Serializable]
	public class AddFriendArg : IExtensible
	{
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0001154C File Offset: 0x0000F74C
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x00011579 File Offset: 0x0000F779
		[ProtoMember(1, IsRequired = false, Name = "friendroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong friendroleid
		{
			get
			{
				return this._friendroleid ?? 0UL;
			}
			set
			{
				this._friendroleid = new ulong?(value);
			}
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x00011588 File Offset: 0x0000F788
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x000115A8 File Offset: 0x0000F7A8
		[XmlIgnore]
		[Browsable(false)]
		public bool friendroleidSpecified
		{
			get
			{
				return this._friendroleid != null;
			}
			set
			{
				bool flag = value == (this._friendroleid == null);
				if (flag)
				{
					this._friendroleid = (value ? new ulong?(this.friendroleid) : null);
				}
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x000115EC File Offset: 0x0000F7EC
		private bool ShouldSerializefriendroleid()
		{
			return this.friendroleidSpecified;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00011604 File Offset: 0x0000F804
		private void Resetfriendroleid()
		{
			this.friendroleidSpecified = false;
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x00011610 File Offset: 0x0000F810
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x00011631 File Offset: 0x0000F831
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0001163C File Offset: 0x0000F83C
		// (set) Token: 0x060007BC RID: 1980 RVA: 0x00011658 File Offset: 0x0000F858
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

		// Token: 0x060007BD RID: 1981 RVA: 0x00011688 File Offset: 0x0000F888
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x000116A0 File Offset: 0x0000F8A0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000116AC File Offset: 0x0000F8AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001F3 RID: 499
		private ulong? _friendroleid;

		// Token: 0x040001F4 RID: 500
		private string _name;

		// Token: 0x040001F5 RID: 501
		private IExtension extensionObject;
	}
}
