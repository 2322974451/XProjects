using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006BD RID: 1725
	[ProtoContract(Name = "GuildBuffRecord")]
	[Serializable]
	public class GuildBuffRecord : IExtensible
	{
		// Token: 0x170023E6 RID: 9190
		// (get) Token: 0x06007166 RID: 29030 RVA: 0x000D8F5C File Offset: 0x000D715C
		// (set) Token: 0x06007167 RID: 29031 RVA: 0x000D8F88 File Offset: 0x000D7188
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

		// Token: 0x170023E7 RID: 9191
		// (get) Token: 0x06007168 RID: 29032 RVA: 0x000D8F98 File Offset: 0x000D7198
		// (set) Token: 0x06007169 RID: 29033 RVA: 0x000D8FB8 File Offset: 0x000D71B8
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

		// Token: 0x0600716A RID: 29034 RVA: 0x000D8FFC File Offset: 0x000D71FC
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x0600716B RID: 29035 RVA: 0x000D9014 File Offset: 0x000D7214
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170023E8 RID: 9192
		// (get) Token: 0x0600716C RID: 29036 RVA: 0x000D9020 File Offset: 0x000D7220
		// (set) Token: 0x0600716D RID: 29037 RVA: 0x000D904C File Offset: 0x000D724C
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170023E9 RID: 9193
		// (get) Token: 0x0600716E RID: 29038 RVA: 0x000D905C File Offset: 0x000D725C
		// (set) Token: 0x0600716F RID: 29039 RVA: 0x000D907C File Offset: 0x000D727C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06007170 RID: 29040 RVA: 0x000D90C0 File Offset: 0x000D72C0
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06007171 RID: 29041 RVA: 0x000D90D8 File Offset: 0x000D72D8
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06007172 RID: 29042 RVA: 0x000D90E4 File Offset: 0x000D72E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B0E RID: 6926
		private uint? _id;

		// Token: 0x04001B0F RID: 6927
		private uint? _time;

		// Token: 0x04001B10 RID: 6928
		private IExtension extensionObject;
	}
}
