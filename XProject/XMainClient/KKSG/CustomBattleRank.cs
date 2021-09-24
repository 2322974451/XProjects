using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleRank")]
	[Serializable]
	public class CustomBattleRank : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "rewardcd", DataFormat = DataFormat.TwosComplement)]
		public uint rewardcd
		{
			get
			{
				return this._rewardcd ?? 0U;
			}
			set
			{
				this._rewardcd = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardcdSpecified
		{
			get
			{
				return this._rewardcd != null;
			}
			set
			{
				bool flag = value == (this._rewardcd == null);
				if (flag)
				{
					this._rewardcd = (value ? new uint?(this.rewardcd) : null);
				}
			}
		}

		private bool ShouldSerializerewardcd()
		{
			return this.rewardcdSpecified;
		}

		private void Resetrewardcd()
		{
			this.rewardcdSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "istakenreward", DataFormat = DataFormat.Default)]
		public bool istakenreward
		{
			get
			{
				return this._istakenreward ?? false;
			}
			set
			{
				this._istakenreward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool istakenrewardSpecified
		{
			get
			{
				return this._istakenreward != null;
			}
			set
			{
				bool flag = value == (this._istakenreward == null);
				if (flag)
				{
					this._istakenreward = (value ? new bool?(this.istakenreward) : null);
				}
			}
		}

		private bool ShouldSerializeistakenreward()
		{
			return this.istakenrewardSpecified;
		}

		private void Resetistakenreward()
		{
			this.istakenrewardSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "timestamp", DataFormat = DataFormat.TwosComplement)]
		public uint timestamp
		{
			get
			{
				return this._timestamp ?? 0U;
			}
			set
			{
				this._timestamp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timestampSpecified
		{
			get
			{
				return this._timestamp != null;
			}
			set
			{
				bool flag = value == (this._timestamp == null);
				if (flag)
				{
					this._timestamp = (value ? new uint?(this.timestamp) : null);
				}
			}
		}

		private bool ShouldSerializetimestamp()
		{
			return this.timestampSpecified;
		}

		private void Resettimestamp()
		{
			this.timestampSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleid;

		private string _name;

		private uint? _point;

		private uint? _rewardcd;

		private bool? _istakenreward;

		private uint? _timestamp;

		private IExtension extensionObject;
	}
}
