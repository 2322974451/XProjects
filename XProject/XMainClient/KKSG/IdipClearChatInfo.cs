using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000231 RID: 561
	[ProtoContract(Name = "IdipClearChatInfo")]
	[Serializable]
	public class IdipClearChatInfo : IExtensible
	{
		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x06001F47 RID: 8007 RVA: 0x0003D57C File Offset: 0x0003B77C
		// (set) Token: 0x06001F48 RID: 8008 RVA: 0x0003D5A9 File Offset: 0x0003B7A9
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

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x06001F49 RID: 8009 RVA: 0x0003D5B8 File Offset: 0x0003B7B8
		// (set) Token: 0x06001F4A RID: 8010 RVA: 0x0003D5D8 File Offset: 0x0003B7D8
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

		// Token: 0x06001F4B RID: 8011 RVA: 0x0003D61C File Offset: 0x0003B81C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x0003D634 File Offset: 0x0003B834
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06001F4D RID: 8013 RVA: 0x0003D640 File Offset: 0x0003B840
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007CD RID: 1997
		private ulong? _roleid;

		// Token: 0x040007CE RID: 1998
		private IExtension extensionObject;
	}
}
