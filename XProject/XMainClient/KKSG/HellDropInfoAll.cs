using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000677 RID: 1655
	[ProtoContract(Name = "HellDropInfoAll")]
	[Serializable]
	public class HellDropInfoAll : IExtensible
	{
		// Token: 0x17002175 RID: 8565
		// (get) Token: 0x060069C6 RID: 27078 RVA: 0x000CA3C4 File Offset: 0x000C85C4
		[ProtoMember(1, Name = "all", DataFormat = DataFormat.Default)]
		public List<HellDropInfo> all
		{
			get
			{
				return this._all;
			}
		}

		// Token: 0x17002176 RID: 8566
		// (get) Token: 0x060069C7 RID: 27079 RVA: 0x000CA3DC File Offset: 0x000C85DC
		// (set) Token: 0x060069C8 RID: 27080 RVA: 0x000CA408 File Offset: 0x000C8608
		[ProtoMember(2, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement)]
		public uint version
		{
			get
			{
				return this._version ?? 0U;
			}
			set
			{
				this._version = new uint?(value);
			}
		}

		// Token: 0x17002177 RID: 8567
		// (get) Token: 0x060069C9 RID: 27081 RVA: 0x000CA418 File Offset: 0x000C8618
		// (set) Token: 0x060069CA RID: 27082 RVA: 0x000CA438 File Offset: 0x000C8638
		[XmlIgnore]
		[Browsable(false)]
		public bool versionSpecified
		{
			get
			{
				return this._version != null;
			}
			set
			{
				bool flag = value == (this._version == null);
				if (flag)
				{
					this._version = (value ? new uint?(this.version) : null);
				}
			}
		}

		// Token: 0x060069CB RID: 27083 RVA: 0x000CA47C File Offset: 0x000C867C
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x060069CC RID: 27084 RVA: 0x000CA494 File Offset: 0x000C8694
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x060069CD RID: 27085 RVA: 0x000CA4A0 File Offset: 0x000C86A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400197C RID: 6524
		private readonly List<HellDropInfo> _all = new List<HellDropInfo>();

		// Token: 0x0400197D RID: 6525
		private uint? _version;

		// Token: 0x0400197E RID: 6526
		private IExtension extensionObject;
	}
}
