using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "getguildbosstimeleftRes")]
	[Serializable]
	public class getguildbosstimeleftRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "addAttrCount", DataFormat = DataFormat.TwosComplement)]
		public uint addAttrCount
		{
			get
			{
				return this._addAttrCount ?? 0U;
			}
			set
			{
				this._addAttrCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool addAttrCountSpecified
		{
			get
			{
				return this._addAttrCount != null;
			}
			set
			{
				bool flag = value == (this._addAttrCount == null);
				if (flag)
				{
					this._addAttrCount = (value ? new uint?(this.addAttrCount) : null);
				}
			}
		}

		private bool ShouldSerializeaddAttrCount()
		{
			return this.addAttrCountSpecified;
		}

		private void ResetaddAttrCount()
		{
			this.addAttrCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _timeleft;

		private uint? _addAttrCount;

		private IExtension extensionObject;
	}
}
