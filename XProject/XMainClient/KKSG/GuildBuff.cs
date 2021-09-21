using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C0 RID: 1728
	[ProtoContract(Name = "GuildBuff")]
	[Serializable]
	public class GuildBuff : IExtensible
	{
		// Token: 0x170023F5 RID: 9205
		// (get) Token: 0x06007197 RID: 29079 RVA: 0x000D951C File Offset: 0x000D771C
		// (set) Token: 0x06007198 RID: 29080 RVA: 0x000D9548 File Offset: 0x000D7748
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

		// Token: 0x170023F6 RID: 9206
		// (get) Token: 0x06007199 RID: 29081 RVA: 0x000D9558 File Offset: 0x000D7758
		// (set) Token: 0x0600719A RID: 29082 RVA: 0x000D9578 File Offset: 0x000D7778
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

		// Token: 0x0600719B RID: 29083 RVA: 0x000D95BC File Offset: 0x000D77BC
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x0600719C RID: 29084 RVA: 0x000D95D4 File Offset: 0x000D77D4
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x170023F7 RID: 9207
		// (get) Token: 0x0600719D RID: 29085 RVA: 0x000D95E0 File Offset: 0x000D77E0
		// (set) Token: 0x0600719E RID: 29086 RVA: 0x000D960C File Offset: 0x000D780C
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

		// Token: 0x170023F8 RID: 9208
		// (get) Token: 0x0600719F RID: 29087 RVA: 0x000D961C File Offset: 0x000D781C
		// (set) Token: 0x060071A0 RID: 29088 RVA: 0x000D963C File Offset: 0x000D783C
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

		// Token: 0x060071A1 RID: 29089 RVA: 0x000D9680 File Offset: 0x000D7880
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x060071A2 RID: 29090 RVA: 0x000D9698 File Offset: 0x000D7898
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x060071A3 RID: 29091 RVA: 0x000D96A4 File Offset: 0x000D78A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B19 RID: 6937
		private uint? _id;

		// Token: 0x04001B1A RID: 6938
		private uint? _time;

		// Token: 0x04001B1B RID: 6939
		private IExtension extensionObject;
	}
}
