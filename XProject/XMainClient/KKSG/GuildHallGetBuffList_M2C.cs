using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildHallGetBuffList_M2C")]
	[Serializable]
	public class GuildHallGetBuffList_M2C : IExtensible
	{

		[ProtoMember(1, Name = "bufflist", DataFormat = DataFormat.Default)]
		public List<GuildHallBuffData> bufflist
		{
			get
			{
				return this._bufflist;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "enableUpdate", DataFormat = DataFormat.Default)]
		public bool enableUpdate
		{
			get
			{
				return this._enableUpdate ?? false;
			}
			set
			{
				this._enableUpdate = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enableUpdateSpecified
		{
			get
			{
				return this._enableUpdate != null;
			}
			set
			{
				bool flag = value == (this._enableUpdate == null);
				if (flag)
				{
					this._enableUpdate = (value ? new bool?(this.enableUpdate) : null);
				}
			}
		}

		private bool ShouldSerializeenableUpdate()
		{
			return this.enableUpdateSpecified;
		}

		private void ResetenableUpdate()
		{
			this.enableUpdateSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "ec", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ec
		{
			get
			{
				return this._ec ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ec = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ecSpecified
		{
			get
			{
				return this._ec != null;
			}
			set
			{
				bool flag = value == (this._ec == null);
				if (flag)
				{
					this._ec = (value ? new ErrorCode?(this.ec) : null);
				}
			}
		}

		private bool ShouldSerializeec()
		{
			return this.ecSpecified;
		}

		private void Resetec()
		{
			this.ecSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GuildHallBuffData> _bufflist = new List<GuildHallBuffData>();

		private bool? _enableUpdate;

		private ErrorCode? _ec;

		private IExtension extensionObject;
	}
}
