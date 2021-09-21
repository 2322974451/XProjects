using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000696 RID: 1686
	[ProtoContract(Name = "GmfHalfRoles")]
	[Serializable]
	public class GmfHalfRoles : IExtensible
	{
		// Token: 0x17002299 RID: 8857
		// (get) Token: 0x06006D52 RID: 27986 RVA: 0x000D12C0 File Offset: 0x000CF4C0
		[ProtoMember(1, Name = "roles", DataFormat = DataFormat.Default)]
		public List<GmfRole> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x1700229A RID: 8858
		// (get) Token: 0x06006D53 RID: 27987 RVA: 0x000D12D8 File Offset: 0x000CF4D8
		// (set) Token: 0x06006D54 RID: 27988 RVA: 0x000D12F0 File Offset: 0x000CF4F0
		[ProtoMember(2, IsRequired = false, Name = "guildb", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfGuildBrief guildb
		{
			get
			{
				return this._guildb;
			}
			set
			{
				this._guildb = value;
			}
		}

		// Token: 0x1700229B RID: 8859
		// (get) Token: 0x06006D55 RID: 27989 RVA: 0x000D12FC File Offset: 0x000CF4FC
		// (set) Token: 0x06006D56 RID: 27990 RVA: 0x000D1328 File Offset: 0x000CF528
		[ProtoMember(3, IsRequired = false, Name = "inspire", DataFormat = DataFormat.TwosComplement)]
		public uint inspire
		{
			get
			{
				return this._inspire ?? 0U;
			}
			set
			{
				this._inspire = new uint?(value);
			}
		}

		// Token: 0x1700229C RID: 8860
		// (get) Token: 0x06006D57 RID: 27991 RVA: 0x000D1338 File Offset: 0x000CF538
		// (set) Token: 0x06006D58 RID: 27992 RVA: 0x000D1358 File Offset: 0x000CF558
		[XmlIgnore]
		[Browsable(false)]
		public bool inspireSpecified
		{
			get
			{
				return this._inspire != null;
			}
			set
			{
				bool flag = value == (this._inspire == null);
				if (flag)
				{
					this._inspire = (value ? new uint?(this.inspire) : null);
				}
			}
		}

		// Token: 0x06006D59 RID: 27993 RVA: 0x000D139C File Offset: 0x000CF59C
		private bool ShouldSerializeinspire()
		{
			return this.inspireSpecified;
		}

		// Token: 0x06006D5A RID: 27994 RVA: 0x000D13B4 File Offset: 0x000CF5B4
		private void Resetinspire()
		{
			this.inspireSpecified = false;
		}

		// Token: 0x06006D5B RID: 27995 RVA: 0x000D13C0 File Offset: 0x000CF5C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A35 RID: 6709
		private readonly List<GmfRole> _roles = new List<GmfRole>();

		// Token: 0x04001A36 RID: 6710
		private GmfGuildBrief _guildb = null;

		// Token: 0x04001A37 RID: 6711
		private uint? _inspire;

		// Token: 0x04001A38 RID: 6712
		private IExtension extensionObject;
	}
}
