using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200038B RID: 907
	[ProtoContract(Name = "PushPraise")]
	[Serializable]
	public class PushPraise : IExtensible
	{
		// Token: 0x17000F37 RID: 3895
		// (get) Token: 0x06003130 RID: 12592 RVA: 0x0005EC84 File Offset: 0x0005CE84
		// (set) Token: 0x06003131 RID: 12593 RVA: 0x0005ECB0 File Offset: 0x0005CEB0
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public CommentType type
		{
			get
			{
				return this._type ?? CommentType.COMMENT_NEST;
			}
			set
			{
				this._type = new CommentType?(value);
			}
		}

		// Token: 0x17000F38 RID: 3896
		// (get) Token: 0x06003132 RID: 12594 RVA: 0x0005ECC0 File Offset: 0x0005CEC0
		// (set) Token: 0x06003133 RID: 12595 RVA: 0x0005ECE0 File Offset: 0x0005CEE0
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new CommentType?(this.type) : null);
				}
			}
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x0005ED24 File Offset: 0x0005CF24
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06003135 RID: 12597 RVA: 0x0005ED3C File Offset: 0x0005CF3C
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000F39 RID: 3897
		// (get) Token: 0x06003136 RID: 12598 RVA: 0x0005ED48 File Offset: 0x0005CF48
		// (set) Token: 0x06003137 RID: 12599 RVA: 0x0005ED74 File Offset: 0x0005CF74
		[ProtoMember(2, IsRequired = false, Name = "spriteid", DataFormat = DataFormat.TwosComplement)]
		public uint spriteid
		{
			get
			{
				return this._spriteid ?? 0U;
			}
			set
			{
				this._spriteid = new uint?(value);
			}
		}

		// Token: 0x17000F3A RID: 3898
		// (get) Token: 0x06003138 RID: 12600 RVA: 0x0005ED84 File Offset: 0x0005CF84
		// (set) Token: 0x06003139 RID: 12601 RVA: 0x0005EDA4 File Offset: 0x0005CFA4
		[XmlIgnore]
		[Browsable(false)]
		public bool spriteidSpecified
		{
			get
			{
				return this._spriteid != null;
			}
			set
			{
				bool flag = value == (this._spriteid == null);
				if (flag)
				{
					this._spriteid = (value ? new uint?(this.spriteid) : null);
				}
			}
		}

		// Token: 0x0600313A RID: 12602 RVA: 0x0005EDE8 File Offset: 0x0005CFE8
		private bool ShouldSerializespriteid()
		{
			return this.spriteidSpecified;
		}

		// Token: 0x0600313B RID: 12603 RVA: 0x0005EE00 File Offset: 0x0005D000
		private void Resetspriteid()
		{
			this.spriteidSpecified = false;
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x0005EE0C File Offset: 0x0005D00C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C37 RID: 3127
		private CommentType? _type;

		// Token: 0x04000C38 RID: 3128
		private uint? _spriteid;

		// Token: 0x04000C39 RID: 3129
		private IExtension extensionObject;
	}
}
