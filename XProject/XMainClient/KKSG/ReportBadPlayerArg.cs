using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200040B RID: 1035
	[ProtoContract(Name = "ReportBadPlayerArg")]
	[Serializable]
	public class ReportBadPlayerArg : IExtensible
	{
		// Token: 0x170010F1 RID: 4337
		// (get) Token: 0x0600371A RID: 14106 RVA: 0x000698D8 File Offset: 0x00067AD8
		// (set) Token: 0x0600371B RID: 14107 RVA: 0x00069905 File Offset: 0x00067B05
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

		// Token: 0x170010F2 RID: 4338
		// (get) Token: 0x0600371C RID: 14108 RVA: 0x00069914 File Offset: 0x00067B14
		// (set) Token: 0x0600371D RID: 14109 RVA: 0x00069934 File Offset: 0x00067B34
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

		// Token: 0x0600371E RID: 14110 RVA: 0x00069978 File Offset: 0x00067B78
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600371F RID: 14111 RVA: 0x00069990 File Offset: 0x00067B90
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170010F3 RID: 4339
		// (get) Token: 0x06003720 RID: 14112 RVA: 0x0006999C File Offset: 0x00067B9C
		// (set) Token: 0x06003721 RID: 14113 RVA: 0x000699C8 File Offset: 0x00067BC8
		[ProtoMember(2, IsRequired = false, Name = "scenetype", DataFormat = DataFormat.TwosComplement)]
		public uint scenetype
		{
			get
			{
				return this._scenetype ?? 0U;
			}
			set
			{
				this._scenetype = new uint?(value);
			}
		}

		// Token: 0x170010F4 RID: 4340
		// (get) Token: 0x06003722 RID: 14114 RVA: 0x000699D8 File Offset: 0x00067BD8
		// (set) Token: 0x06003723 RID: 14115 RVA: 0x000699F8 File Offset: 0x00067BF8
		[XmlIgnore]
		[Browsable(false)]
		public bool scenetypeSpecified
		{
			get
			{
				return this._scenetype != null;
			}
			set
			{
				bool flag = value == (this._scenetype == null);
				if (flag)
				{
					this._scenetype = (value ? new uint?(this.scenetype) : null);
				}
			}
		}

		// Token: 0x06003724 RID: 14116 RVA: 0x00069A3C File Offset: 0x00067C3C
		private bool ShouldSerializescenetype()
		{
			return this.scenetypeSpecified;
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x00069A54 File Offset: 0x00067C54
		private void Resetscenetype()
		{
			this.scenetypeSpecified = false;
		}

		// Token: 0x170010F5 RID: 4341
		// (get) Token: 0x06003726 RID: 14118 RVA: 0x00069A60 File Offset: 0x00067C60
		[ProtoMember(3, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public List<uint> reason
		{
			get
			{
				return this._reason;
			}
		}

		// Token: 0x06003727 RID: 14119 RVA: 0x00069A78 File Offset: 0x00067C78
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DA9 RID: 3497
		private ulong? _roleid;

		// Token: 0x04000DAA RID: 3498
		private uint? _scenetype;

		// Token: 0x04000DAB RID: 3499
		private readonly List<uint> _reason = new List<uint>();

		// Token: 0x04000DAC RID: 3500
		private IExtension extensionObject;
	}
}
