using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000693 RID: 1683
	[ProtoContract(Name = "GuildDarenaUnit")]
	[Serializable]
	public class GuildDarenaUnit : IExtensible
	{
		// Token: 0x17002287 RID: 8839
		// (get) Token: 0x06006D16 RID: 27926 RVA: 0x000D0BB0 File Offset: 0x000CEDB0
		// (set) Token: 0x06006D17 RID: 27927 RVA: 0x000D0BDD File Offset: 0x000CEDDD
		[ProtoMember(1, IsRequired = false, Name = "roleId", DataFormat = DataFormat.TwosComplement)]
		public ulong roleId
		{
			get
			{
				return this._roleId ?? 0UL;
			}
			set
			{
				this._roleId = new ulong?(value);
			}
		}

		// Token: 0x17002288 RID: 8840
		// (get) Token: 0x06006D18 RID: 27928 RVA: 0x000D0BEC File Offset: 0x000CEDEC
		// (set) Token: 0x06006D19 RID: 27929 RVA: 0x000D0C0C File Offset: 0x000CEE0C
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIdSpecified
		{
			get
			{
				return this._roleId != null;
			}
			set
			{
				bool flag = value == (this._roleId == null);
				if (flag)
				{
					this._roleId = (value ? new ulong?(this.roleId) : null);
				}
			}
		}

		// Token: 0x06006D1A RID: 27930 RVA: 0x000D0C50 File Offset: 0x000CEE50
		private bool ShouldSerializeroleId()
		{
			return this.roleIdSpecified;
		}

		// Token: 0x06006D1B RID: 27931 RVA: 0x000D0C68 File Offset: 0x000CEE68
		private void ResetroleId()
		{
			this.roleIdSpecified = false;
		}

		// Token: 0x17002289 RID: 8841
		// (get) Token: 0x06006D1C RID: 27932 RVA: 0x000D0C74 File Offset: 0x000CEE74
		// (set) Token: 0x06006D1D RID: 27933 RVA: 0x000D0CA0 File Offset: 0x000CEEA0
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x1700228A RID: 8842
		// (get) Token: 0x06006D1E RID: 27934 RVA: 0x000D0CB0 File Offset: 0x000CEEB0
		// (set) Token: 0x06006D1F RID: 27935 RVA: 0x000D0CD0 File Offset: 0x000CEED0
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06006D20 RID: 27936 RVA: 0x000D0D14 File Offset: 0x000CEF14
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06006D21 RID: 27937 RVA: 0x000D0D2C File Offset: 0x000CEF2C
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06006D22 RID: 27938 RVA: 0x000D0D38 File Offset: 0x000CEF38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A29 RID: 6697
		private ulong? _roleId;

		// Token: 0x04001A2A RID: 6698
		private uint? _state;

		// Token: 0x04001A2B RID: 6699
		private IExtension extensionObject;
	}
}
