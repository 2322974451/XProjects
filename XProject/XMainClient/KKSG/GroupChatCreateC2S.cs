using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000464 RID: 1124
	[ProtoContract(Name = "GroupChatCreateC2S")]
	[Serializable]
	public class GroupChatCreateC2S : IExtensible
	{
		// Token: 0x1700120D RID: 4621
		// (get) Token: 0x06003AE3 RID: 15075 RVA: 0x00070928 File Offset: 0x0006EB28
		// (set) Token: 0x06003AE4 RID: 15076 RVA: 0x00070949 File Offset: 0x0006EB49
		[ProtoMember(1, IsRequired = false, Name = "groupchatName", DataFormat = DataFormat.Default)]
		public string groupchatName
		{
			get
			{
				return this._groupchatName ?? "";
			}
			set
			{
				this._groupchatName = value;
			}
		}

		// Token: 0x1700120E RID: 4622
		// (get) Token: 0x06003AE5 RID: 15077 RVA: 0x00070954 File Offset: 0x0006EB54
		// (set) Token: 0x06003AE6 RID: 15078 RVA: 0x00070970 File Offset: 0x0006EB70
		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatNameSpecified
		{
			get
			{
				return this._groupchatName != null;
			}
			set
			{
				bool flag = value == (this._groupchatName == null);
				if (flag)
				{
					this._groupchatName = (value ? this.groupchatName : null);
				}
			}
		}

		// Token: 0x06003AE7 RID: 15079 RVA: 0x000709A0 File Offset: 0x0006EBA0
		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		// Token: 0x06003AE8 RID: 15080 RVA: 0x000709B8 File Offset: 0x0006EBB8
		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		// Token: 0x1700120F RID: 4623
		// (get) Token: 0x06003AE9 RID: 15081 RVA: 0x000709C4 File Offset: 0x0006EBC4
		// (set) Token: 0x06003AEA RID: 15082 RVA: 0x000709F0 File Offset: 0x0006EBF0
		[ProtoMember(2, IsRequired = false, Name = "createtype", DataFormat = DataFormat.TwosComplement)]
		public uint createtype
		{
			get
			{
				return this._createtype ?? 0U;
			}
			set
			{
				this._createtype = new uint?(value);
			}
		}

		// Token: 0x17001210 RID: 4624
		// (get) Token: 0x06003AEB RID: 15083 RVA: 0x00070A00 File Offset: 0x0006EC00
		// (set) Token: 0x06003AEC RID: 15084 RVA: 0x00070A20 File Offset: 0x0006EC20
		[XmlIgnore]
		[Browsable(false)]
		public bool createtypeSpecified
		{
			get
			{
				return this._createtype != null;
			}
			set
			{
				bool flag = value == (this._createtype == null);
				if (flag)
				{
					this._createtype = (value ? new uint?(this.createtype) : null);
				}
			}
		}

		// Token: 0x06003AED RID: 15085 RVA: 0x00070A64 File Offset: 0x0006EC64
		private bool ShouldSerializecreatetype()
		{
			return this.createtypeSpecified;
		}

		// Token: 0x06003AEE RID: 15086 RVA: 0x00070A7C File Offset: 0x0006EC7C
		private void Resetcreatetype()
		{
			this.createtypeSpecified = false;
		}

		// Token: 0x06003AEF RID: 15087 RVA: 0x00070A88 File Offset: 0x0006EC88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EA1 RID: 3745
		private string _groupchatName;

		// Token: 0x04000EA2 RID: 3746
		private uint? _createtype;

		// Token: 0x04000EA3 RID: 3747
		private IExtension extensionObject;
	}
}
