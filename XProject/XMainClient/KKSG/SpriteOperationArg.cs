using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpriteOperationArg")]
	[Serializable]
	public class SpriteOperationArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public SpriteType Type
		{
			get
			{
				return this._Type ?? SpriteType.Sprite_Feed;
			}
			set
			{
				this._Type = new SpriteType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool TypeSpecified
		{
			get
			{
				return this._Type != null;
			}
			set
			{
				bool flag = value == (this._Type == null);
				if (flag)
				{
					this._Type = (value ? new SpriteType?(this.Type) : null);
				}
			}
		}

		private bool ShouldSerializeType()
		{
			return this.TypeSpecified;
		}

		private void ResetType()
		{
			this.TypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "FeedItemID", DataFormat = DataFormat.TwosComplement)]
		public uint FeedItemID
		{
			get
			{
				return this._FeedItemID ?? 0U;
			}
			set
			{
				this._FeedItemID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool FeedItemIDSpecified
		{
			get
			{
				return this._FeedItemID != null;
			}
			set
			{
				bool flag = value == (this._FeedItemID == null);
				if (flag)
				{
					this._FeedItemID = (value ? new uint?(this.FeedItemID) : null);
				}
			}
		}

		private bool ShouldSerializeFeedItemID()
		{
			return this.FeedItemIDSpecified;
		}

		private void ResetFeedItemID()
		{
			this.FeedItemIDSpecified = false;
		}

		[ProtoMember(4, Name = "uids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> uids
		{
			get
			{
				return this._uids;
			}
		}

		[ProtoMember(5, Name = "notToChoose", DataFormat = DataFormat.TwosComplement)]
		public List<uint> notToChoose
		{
			get
			{
				return this._notToChoose;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "resetTrainChoose", DataFormat = DataFormat.TwosComplement)]
		public uint resetTrainChoose
		{
			get
			{
				return this._resetTrainChoose ?? 0U;
			}
			set
			{
				this._resetTrainChoose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resetTrainChooseSpecified
		{
			get
			{
				return this._resetTrainChoose != null;
			}
			set
			{
				bool flag = value == (this._resetTrainChoose == null);
				if (flag)
				{
					this._resetTrainChoose = (value ? new uint?(this.resetTrainChoose) : null);
				}
			}
		}

		private bool ShouldSerializeresetTrainChoose()
		{
			return this.resetTrainChooseSpecified;
		}

		private void ResetresetTrainChoose()
		{
			this.resetTrainChooseSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private SpriteType? _Type;

		private ulong? _uid;

		private uint? _FeedItemID;

		private readonly List<ulong> _uids = new List<ulong>();

		private readonly List<uint> _notToChoose = new List<uint>();

		private uint? _resetTrainChoose;

		private IExtension extensionObject;
	}
}
