using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200062F RID: 1583
	[ProtoContract(Name = "SpriteRecord")]
	[Serializable]
	public class SpriteRecord : IExtensible
	{
		// Token: 0x17001E9D RID: 7837
		// (get) Token: 0x0600614D RID: 24909 RVA: 0x000B9A08 File Offset: 0x000B7C08
		[ProtoMember(1, Name = "SpriteData", DataFormat = DataFormat.Default)]
		public List<SpriteInfo> SpriteData
		{
			get
			{
				return this._SpriteData;
			}
		}

		// Token: 0x17001E9E RID: 7838
		// (get) Token: 0x0600614E RID: 24910 RVA: 0x000B9A20 File Offset: 0x000B7C20
		[ProtoMember(2, Name = "InFight", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> InFight
		{
			get
			{
				return this._InFight;
			}
		}

		// Token: 0x17001E9F RID: 7839
		// (get) Token: 0x0600614F RID: 24911 RVA: 0x000B9A38 File Offset: 0x000B7C38
		[ProtoMember(3, Name = "Books", DataFormat = DataFormat.Default)]
		public List<bool> Books
		{
			get
			{
				return this._Books;
			}
		}

		// Token: 0x17001EA0 RID: 7840
		// (get) Token: 0x06006150 RID: 24912 RVA: 0x000B9A50 File Offset: 0x000B7C50
		// (set) Token: 0x06006151 RID: 24913 RVA: 0x000B9A68 File Offset: 0x000B7C68
		[ProtoMember(4, IsRequired = false, Name = "NewAwake", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteInfo NewAwake
		{
			get
			{
				return this._NewAwake;
			}
			set
			{
				this._NewAwake = value;
			}
		}

		// Token: 0x17001EA1 RID: 7841
		// (get) Token: 0x06006152 RID: 24914 RVA: 0x000B9A74 File Offset: 0x000B7C74
		// (set) Token: 0x06006153 RID: 24915 RVA: 0x000B9AA0 File Offset: 0x000B7CA0
		[ProtoMember(5, IsRequired = false, Name = "version", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001EA2 RID: 7842
		// (get) Token: 0x06006154 RID: 24916 RVA: 0x000B9AB0 File Offset: 0x000B7CB0
		// (set) Token: 0x06006155 RID: 24917 RVA: 0x000B9AD0 File Offset: 0x000B7CD0
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

		// Token: 0x06006156 RID: 24918 RVA: 0x000B9B14 File Offset: 0x000B7D14
		private bool ShouldSerializeversion()
		{
			return this.versionSpecified;
		}

		// Token: 0x06006157 RID: 24919 RVA: 0x000B9B2C File Offset: 0x000B7D2C
		private void Resetversion()
		{
			this.versionSpecified = false;
		}

		// Token: 0x06006158 RID: 24920 RVA: 0x000B9B38 File Offset: 0x000B7D38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001799 RID: 6041
		private readonly List<SpriteInfo> _SpriteData = new List<SpriteInfo>();

		// Token: 0x0400179A RID: 6042
		private readonly List<ulong> _InFight = new List<ulong>();

		// Token: 0x0400179B RID: 6043
		private readonly List<bool> _Books = new List<bool>();

		// Token: 0x0400179C RID: 6044
		private SpriteInfo _NewAwake = null;

		// Token: 0x0400179D RID: 6045
		private uint? _version;

		// Token: 0x0400179E RID: 6046
		private IExtension extensionObject;
	}
}
