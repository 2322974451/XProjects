using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SendFlowerArg")]
	[Serializable]
	public class SendFlowerArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "sendItemID", DataFormat = DataFormat.TwosComplement)]
		public uint sendItemID
		{
			get
			{
				return this._sendItemID ?? 0U;
			}
			set
			{
				this._sendItemID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sendItemIDSpecified
		{
			get
			{
				return this._sendItemID != null;
			}
			set
			{
				bool flag = value == (this._sendItemID == null);
				if (flag)
				{
					this._sendItemID = (value ? new uint?(this.sendItemID) : null);
				}
			}
		}

		private bool ShouldSerializesendItemID()
		{
			return this.sendItemIDSpecified;
		}

		private void ResetsendItemID()
		{
			this.sendItemIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "costItemID", DataFormat = DataFormat.TwosComplement)]
		public uint costItemID
		{
			get
			{
				return this._costItemID ?? 0U;
			}
			set
			{
				this._costItemID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costItemIDSpecified
		{
			get
			{
				return this._costItemID != null;
			}
			set
			{
				bool flag = value == (this._costItemID == null);
				if (flag)
				{
					this._costItemID = (value ? new uint?(this.costItemID) : null);
				}
			}
		}

		private bool ShouldSerializecostItemID()
		{
			return this.costItemIDSpecified;
		}

		private void ResetcostItemID()
		{
			this.costItemIDSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "costItemNum", DataFormat = DataFormat.TwosComplement)]
		public uint costItemNum
		{
			get
			{
				return this._costItemNum ?? 0U;
			}
			set
			{
				this._costItemNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costItemNumSpecified
		{
			get
			{
				return this._costItemNum != null;
			}
			set
			{
				bool flag = value == (this._costItemNum == null);
				if (flag)
				{
					this._costItemNum = (value ? new uint?(this.costItemNum) : null);
				}
			}
		}

		private bool ShouldSerializecostItemNum()
		{
			return this.costItemNumSpecified;
		}

		private void ResetcostItemNum()
		{
			this.costItemNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private uint? _count;

		private uint? _sendItemID;

		private uint? _costItemID;

		private uint? _costItemNum;

		private IExtension extensionObject;
	}
}
