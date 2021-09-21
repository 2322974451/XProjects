using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000082 RID: 130
	[ProtoContract(Name = "ShowFlowerPageArg")]
	[Serializable]
	public class ShowFlowerPageArg : IExtensible
	{
		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000891 RID: 2193 RVA: 0x00012F14 File Offset: 0x00011114
		// (set) Token: 0x06000892 RID: 2194 RVA: 0x00012F41 File Offset: 0x00011141
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

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00012F50 File Offset: 0x00011150
		// (set) Token: 0x06000894 RID: 2196 RVA: 0x00012F70 File Offset: 0x00011170
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

		// Token: 0x06000895 RID: 2197 RVA: 0x00012FB4 File Offset: 0x000111B4
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00012FCC File Offset: 0x000111CC
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00012FD8 File Offset: 0x000111D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000239 RID: 569
		private ulong? _roleid;

		// Token: 0x0400023A RID: 570
		private IExtension extensionObject;
	}
}
