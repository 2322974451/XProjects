using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SetVoipMemberState")]
	[Serializable]
	public class SetVoipMemberState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "nstate", DataFormat = DataFormat.TwosComplement)]
		public uint nstate
		{
			get
			{
				return this._nstate ?? 0U;
			}
			set
			{
				this._nstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nstateSpecified
		{
			get
			{
				return this._nstate != null;
			}
			set
			{
				bool flag = value == (this._nstate == null);
				if (flag)
				{
					this._nstate = (value ? new uint?(this.nstate) : null);
				}
			}
		}

		private bool ShouldSerializenstate()
		{
			return this.nstateSpecified;
		}

		private void Resetnstate()
		{
			this.nstateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _nstate;

		private IExtension extensionObject;
	}
}
