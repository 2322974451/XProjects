using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FriendOpNotify")]
	[Serializable]
	public class FriendOpNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "op", DataFormat = DataFormat.TwosComplement)]
		public FriendOpType op
		{
			get
			{
				return this._op ?? FriendOpType.Friend_AgreeApply;
			}
			set
			{
				this._op = new FriendOpType?(value);
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
					this._op = (value ? new FriendOpType?(this.op) : null);
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

		[ProtoMember(2, Name = "friendlist", DataFormat = DataFormat.Default)]
		public List<Friend2Client> friendlist
		{
			get
			{
				return this._friendlist;
			}
		}

		[ProtoMember(3, Name = "applylist", DataFormat = DataFormat.Default)]
		public List<Friend2Client> applylist
		{
			get
			{
				return this._applylist;
			}
		}

		[ProtoMember(4, Name = "deletelist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> deletelist
		{
			get
			{
				return this._deletelist;
			}
		}

		[ProtoMember(5, Name = "deleteapplylist", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> deleteapplylist
		{
			get
			{
				return this._deleteapplylist;
			}
		}

		[ProtoMember(6, Name = "senderid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> senderid
		{
			get
			{
				return this._senderid;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "giftcount", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public FriendGift giftcount
		{
			get
			{
				return this._giftcount;
			}
			set
			{
				this._giftcount = value;
			}
		}

		[ProtoMember(8, Name = "receivedtime", DataFormat = DataFormat.TwosComplement)]
		public List<uint> receivedtime
		{
			get
			{
				return this._receivedtime;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private FriendOpType? _op;

		private readonly List<Friend2Client> _friendlist = new List<Friend2Client>();

		private readonly List<Friend2Client> _applylist = new List<Friend2Client>();

		private readonly List<ulong> _deletelist = new List<ulong>();

		private readonly List<ulong> _deleteapplylist = new List<ulong>();

		private readonly List<ulong> _senderid = new List<ulong>();

		private FriendGift _giftcount = null;

		private readonly List<uint> _receivedtime = new List<uint>();

		private IExtension extensionObject;
	}
}
