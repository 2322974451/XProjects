using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetOperationOtherArg")]
	[Serializable]
	public class PetOperationOtherArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public PetOtherOp op
		{
			get
			{
				return this._op ?? PetOtherOp.DoPetPairRide;
			}
			set
			{
				this._op = new PetOtherOp?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool opSpecified
		{
			get
			{
				return this._op != null;
			}
			set
			{
				bool flag = value == (this._op == null);
				if (flag)
				{
					this._op = (value ? new PetOtherOp?(this.op) : null);
				}
			}
		}

		private bool ShouldSerializeop()
		{
			return this.opSpecified;
		}

		private void Resetop()
		{
			this.opSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong otherroleid
		{
			get
			{
				return this._otherroleid ?? 0UL;
			}
			set
			{
				this._otherroleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool otherroleidSpecified
		{
			get
			{
				return this._otherroleid != null;
			}
			set
			{
				bool flag = value == (this._otherroleid == null);
				if (flag)
				{
					this._otherroleid = (value ? new ulong?(this.otherroleid) : null);
				}
			}
		}

		private bool ShouldSerializeotherroleid()
		{
			return this.otherroleidSpecified;
		}

		private void Resetotherroleid()
		{
			this.otherroleidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private PetOtherOp? _op;

		private ulong? _otherroleid;

		private IExtension extensionObject;
	}
}
