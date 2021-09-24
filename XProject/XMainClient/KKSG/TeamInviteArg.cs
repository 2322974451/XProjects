using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamInviteArg")]
	[Serializable]
	public class TeamInviteArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "expid", DataFormat = DataFormat.TwosComplement)]
		public int expid
		{
			get
			{
				return this._expid ?? 0;
			}
			set
			{
				this._expid = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expidSpecified
		{
			get
			{
				return this._expid != null;
			}
			set
			{
				bool flag = value == (this._expid == null);
				if (flag)
				{
					this._expid = (value ? new int?(this.expid) : null);
				}
			}
		}

		private bool ShouldSerializeexpid()
		{
			return this.expidSpecified;
		}

		private void Resetexpid()
		{
			this.expidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _expid;

		private IExtension extensionObject;
	}
}
