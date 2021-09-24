using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginChallenge")]
	[Serializable]
	public class LoginChallenge : IExtensible
	{

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

		private bool ShouldSerializechallenge()
		{
			return this.challengeSpecified;
		}

		private void Resetchallenge()
		{
			this.challengeSpecified = false;
		}

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

		private bool ShouldSerializesession()
		{
			return this.sessionSpecified;
		}

		private void Resetsession()
		{
			this.sessionSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _challenge;

		private ulong? _session;

		private IExtension extensionObject;
	}
}
