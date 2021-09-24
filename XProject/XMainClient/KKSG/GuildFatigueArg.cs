using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildFatigueArg")]
	[Serializable]
	public class GuildFatigueArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "optype", DataFormat = DataFormat.TwosComplement)]
		public int optype
		{
			get
			{
				return this._optype ?? 0;
			}
			set
			{
				this._optype = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool optypeSpecified
		{
			get
			{
				return this._optype != null;
			}
			set
			{
				bool flag = value == (this._optype == null);
				if (flag)
				{
					this._optype = (value ? new int?(this.optype) : null);
				}
			}
		}

		private bool ShouldSerializeoptype()
		{
			return this.optypeSpecified;
		}

		private void Resetoptype()
		{
			this.optypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "targetID", DataFormat = DataFormat.TwosComplement)]
		public ulong targetID
		{
			get
			{
				return this._targetID ?? 0UL;
			}
			set
			{
				this._targetID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool targetIDSpecified
		{
			get
			{
				return this._targetID != null;
			}
			set
			{
				bool flag = value == (this._targetID == null);
				if (flag)
				{
					this._targetID = (value ? new ulong?(this.targetID) : null);
				}
			}
		}

		private bool ShouldSerializetargetID()
		{
			return this.targetIDSpecified;
		}

		private void ResettargetID()
		{
			this.targetIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _optype;

		private ulong? _targetID;

		private IExtension extensionObject;
	}
}
