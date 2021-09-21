using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200000A RID: 10
	[ProtoContract(Name = "LoginChallenge")]
	[Serializable]
	public class LoginChallenge : IExtensible
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000037FC File Offset: 0x000019FC
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000381D File Offset: 0x00001A1D
		[ProtoMember(1, IsRequired = false, Name = "challenge", DataFormat = DataFormat.Default)]
		public string challenge
		{
			get
			{
				return this._challenge ?? "";
			}
			set
			{
				this._challenge = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00003828 File Offset: 0x00001A28
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00003844 File Offset: 0x00001A44
		[XmlIgnore]
		[Browsable(false)]
		public bool challengeSpecified
		{
			get
			{
				return this._challenge != null;
			}
			set
			{
				bool flag = value == (this._challenge == null);
				if (flag)
				{
					this._challenge = (value ? this.challenge : null);
				}
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003874 File Offset: 0x00001A74
		private bool ShouldSerializechallenge()
		{
			return this.challengeSpecified;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000388C File Offset: 0x00001A8C
		private void Resetchallenge()
		{
			this.challengeSpecified = false;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00003898 File Offset: 0x00001A98
		// (set) Token: 0x0600007A RID: 122 RVA: 0x000038C5 File Offset: 0x00001AC5
		[ProtoMember(2, IsRequired = false, Name = "session", DataFormat = DataFormat.TwosComplement)]
		public ulong session
		{
			get
			{
				return this._session ?? 0UL;
			}
			set
			{
				this._session = new ulong?(value);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600007B RID: 123 RVA: 0x000038D4 File Offset: 0x00001AD4
		// (set) Token: 0x0600007C RID: 124 RVA: 0x000038F4 File Offset: 0x00001AF4
		[XmlIgnore]
		[Browsable(false)]
		public bool sessionSpecified
		{
			get
			{
				return this._session != null;
			}
			set
			{
				bool flag = value == (this._session == null);
				if (flag)
				{
					this._session = (value ? new ulong?(this.session) : null);
				}
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003938 File Offset: 0x00001B38
		private bool ShouldSerializesession()
		{
			return this.sessionSpecified;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003950 File Offset: 0x00001B50
		private void Resetsession()
		{
			this.sessionSpecified = false;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000395C File Offset: 0x00001B5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000025 RID: 37
		private string _challenge;

		// Token: 0x04000026 RID: 38
		private ulong? _session;

		// Token: 0x04000027 RID: 39
		private IExtension extensionObject;
	}
}
