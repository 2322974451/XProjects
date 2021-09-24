using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "breakAtlas")]
	[Serializable]
	public class breakAtlas : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "atlaId", DataFormat = DataFormat.TwosComplement)]
		public uint atlaId
		{
			get
			{
				return this._atlaId ?? 0U;
			}
			set
			{
				this._atlaId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool atlaIdSpecified
		{
			get
			{
				return this._atlaId != null;
			}
			set
			{
				bool flag = value == (this._atlaId == null);
				if (flag)
				{
					this._atlaId = (value ? new uint?(this.atlaId) : null);
				}
			}
		}

		private bool ShouldSerializeatlaId()
		{
			return this.atlaIdSpecified;
		}

		private void ResetatlaId()
		{
			this.atlaIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "atlaNum", DataFormat = DataFormat.TwosComplement)]
		public uint atlaNum
		{
			get
			{
				return this._atlaNum ?? 0U;
			}
			set
			{
				this._atlaNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool atlaNumSpecified
		{
			get
			{
				return this._atlaNum != null;
			}
			set
			{
				bool flag = value == (this._atlaNum == null);
				if (flag)
				{
					this._atlaNum = (value ? new uint?(this.atlaNum) : null);
				}
			}
		}

		private bool ShouldSerializeatlaNum()
		{
			return this.atlaNumSpecified;
		}

		private void ResetatlaNum()
		{
			this.atlaNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _atlaId;

		private uint? _atlaNum;

		private IExtension extensionObject;
	}
}
