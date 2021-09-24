using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RewardRecord")]
	[Serializable]
	public class RewardRecord : IExtensible
	{

		[ProtoMember(1, Name = "RewardInfo", DataFormat = DataFormat.Default)]
		public List<RewardInfo> RewardInfo
		{
			get
			{
				return this._RewardInfo;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "given", DataFormat = DataFormat.Default)]
		public byte[] given
		{
			get
			{
				return this._given ?? null;
			}
			set
			{
				this._given = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool givenSpecified
		{
			get
			{
				return this._given != null;
			}
			set
			{
				bool flag = value == (this._given == null);
				if (flag)
				{
					this._given = (value ? this.given : null);
				}
			}
		}

		private bool ShouldSerializegiven()
		{
			return this.givenSpecified;
		}

		private void Resetgiven()
		{
			this.givenSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "taken", DataFormat = DataFormat.Default)]
		public byte[] taken
		{
			get
			{
				return this._taken ?? null;
			}
			set
			{
				this._taken = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool takenSpecified
		{
			get
			{
				return this._taken != null;
			}
			set
			{
				bool flag = value == (this._taken == null);
				if (flag)
				{
					this._taken = (value ? this.taken : null);
				}
			}
		}

		private bool ShouldSerializetaken()
		{
			return this.takenSpecified;
		}

		private void Resettaken()
		{
			this.takenSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "nextdayreward", DataFormat = DataFormat.TwosComplement)]
		public uint nextdayreward
		{
			get
			{
				return this._nextdayreward ?? 0U;
			}
			set
			{
				this._nextdayreward = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nextdayrewardSpecified
		{
			get
			{
				return this._nextdayreward != null;
			}
			set
			{
				bool flag = value == (this._nextdayreward == null);
				if (flag)
				{
					this._nextdayreward = (value ? new uint?(this.nextdayreward) : null);
				}
			}
		}

		private bool ShouldSerializenextdayreward()
		{
			return this.nextdayrewardSpecified;
		}

		private void Resetnextdayreward()
		{
			this.nextdayrewardSpecified = false;
		}

		[ProtoMember(5, Name = "onlinereward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> onlinereward
		{
			get
			{
				return this._onlinereward;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<RewardInfo> _RewardInfo = new List<RewardInfo>();

		private byte[] _given;

		private byte[] _taken;

		private uint? _nextdayreward;

		private readonly List<uint> _onlinereward = new List<uint>();

		private IExtension extensionObject;
	}
}
