using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005AE RID: 1454
	[ProtoContract(Name = "SelfServerData")]
	[Serializable]
	public class SelfServerData : IExtensible
	{
		// Token: 0x1700186B RID: 6251
		// (get) Token: 0x06004F20 RID: 20256 RVA: 0x000967F0 File Offset: 0x000949F0
		// (set) Token: 0x06004F21 RID: 20257 RVA: 0x00096808 File Offset: 0x00094A08
		[ProtoMember(1, IsRequired = false, Name = "servers", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LoginGateData servers
		{
			get
			{
				return this._servers;
			}
			set
			{
				this._servers = value;
			}
		}

		// Token: 0x1700186C RID: 6252
		// (get) Token: 0x06004F22 RID: 20258 RVA: 0x00096814 File Offset: 0x00094A14
		// (set) Token: 0x06004F23 RID: 20259 RVA: 0x00096840 File Offset: 0x00094A40
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

		// Token: 0x1700186D RID: 6253
		// (get) Token: 0x06004F24 RID: 20260 RVA: 0x00096850 File Offset: 0x00094A50
		// (set) Token: 0x06004F25 RID: 20261 RVA: 0x00096870 File Offset: 0x00094A70
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

		// Token: 0x06004F26 RID: 20262 RVA: 0x000968B4 File Offset: 0x00094AB4
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06004F27 RID: 20263 RVA: 0x000968CC File Offset: 0x00094ACC
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x06004F28 RID: 20264 RVA: 0x000968D8 File Offset: 0x00094AD8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001389 RID: 5001
		private LoginGateData _servers = null;

		// Token: 0x0400138A RID: 5002
		private uint? _level;

		// Token: 0x0400138B RID: 5003
		private IExtension extensionObject;
	}
}
