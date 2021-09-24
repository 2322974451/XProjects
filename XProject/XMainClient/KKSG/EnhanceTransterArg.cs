using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnhanceTransterArg")]
	[Serializable]
	public class EnhanceTransterArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "originuid", DataFormat = DataFormat.TwosComplement)]
		public ulong originuid
		{
			get
			{
				return this._originuid ?? 0UL;
			}
			set
			{
				this._originuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool originuidSpecified
		{
			get
			{
				return this._originuid != null;
			}
			set
			{
				bool flag = value == (this._originuid == null);
				if (flag)
				{
					this._originuid = (value ? new ulong?(this.originuid) : null);
				}
			}
		}

		private bool ShouldSerializeoriginuid()
		{
			return this.originuidSpecified;
		}

		private void Resetoriginuid()
		{
			this.originuidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "destuid", DataFormat = DataFormat.TwosComplement)]
		public ulong destuid
		{
			get
			{
				return this._destuid ?? 0UL;
			}
			set
			{
				this._destuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool destuidSpecified
		{
			get
			{
				return this._destuid != null;
			}
			set
			{
				bool flag = value == (this._destuid == null);
				if (flag)
				{
					this._destuid = (value ? new ulong?(this.destuid) : null);
				}
			}
		}

		private bool ShouldSerializedestuid()
		{
			return this.destuidSpecified;
		}

		private void Resetdestuid()
		{
			this.destuidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _originuid;

		private ulong? _destuid;

		private IExtension extensionObject;
	}
}
