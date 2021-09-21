using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200067C RID: 1660
	[ProtoContract(Name = "NpcFeelingUnite")]
	[Serializable]
	public class NpcFeelingUnite : IExtensible
	{
		// Token: 0x170021A8 RID: 8616
		// (get) Token: 0x06006A5B RID: 27227 RVA: 0x000CB638 File Offset: 0x000C9838
		// (set) Token: 0x06006A5C RID: 27228 RVA: 0x000CB664 File Offset: 0x000C9864
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x170021A9 RID: 8617
		// (get) Token: 0x06006A5D RID: 27229 RVA: 0x000CB674 File Offset: 0x000C9874
		// (set) Token: 0x06006A5E RID: 27230 RVA: 0x000CB694 File Offset: 0x000C9894
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06006A5F RID: 27231 RVA: 0x000CB6D8 File Offset: 0x000C98D8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006A60 RID: 27232 RVA: 0x000CB6F0 File Offset: 0x000C98F0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170021AA RID: 8618
		// (get) Token: 0x06006A61 RID: 27233 RVA: 0x000CB6FC File Offset: 0x000C98FC
		// (set) Token: 0x06006A62 RID: 27234 RVA: 0x000CB728 File Offset: 0x000C9928
		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x170021AB RID: 8619
		// (get) Token: 0x06006A63 RID: 27235 RVA: 0x000CB738 File Offset: 0x000C9938
		// (set) Token: 0x06006A64 RID: 27236 RVA: 0x000CB758 File Offset: 0x000C9958
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06006A65 RID: 27237 RVA: 0x000CB79C File Offset: 0x000C999C
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06006A66 RID: 27238 RVA: 0x000CB7B4 File Offset: 0x000C99B4
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x06006A67 RID: 27239 RVA: 0x000CB7C0 File Offset: 0x000C99C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400199E RID: 6558
		private uint? _id;

		// Token: 0x0400199F RID: 6559
		private uint? _level;

		// Token: 0x040019A0 RID: 6560
		private IExtension extensionObject;
	}
}
