using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaRecord")]
	[Serializable]
	public class ArenaRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "OptimalRank", DataFormat = DataFormat.TwosComplement)]
		public uint OptimalRank
		{
			get
			{
				return this._OptimalRank ?? 0U;
			}
			set
			{
				this._OptimalRank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool OptimalRankSpecified
		{
			get
			{
				return this._OptimalRank != null;
			}
			set
			{
				bool flag = value == (this._OptimalRank == null);
				if (flag)
				{
					this._OptimalRank = (value ? new uint?(this.OptimalRank) : null);
				}
			}
		}

		private bool ShouldSerializeOptimalRank()
		{
			return this.OptimalRankSpecified;
		}

		private void ResetOptimalRank()
		{
			this.OptimalRankSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "dayupdate", DataFormat = DataFormat.TwosComplement)]
		public uint dayupdate
		{
			get
			{
				return this._dayupdate ?? 0U;
			}
			set
			{
				this._dayupdate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dayupdateSpecified
		{
			get
			{
				return this._dayupdate != null;
			}
			set
			{
				bool flag = value == (this._dayupdate == null);
				if (flag)
				{
					this._dayupdate = (value ? new uint?(this.dayupdate) : null);
				}
			}
		}

		private bool ShouldSerializedayupdate()
		{
			return this.dayupdateSpecified;
		}

		private void Resetdayupdate()
		{
			this.dayupdateSpecified = false;
		}

		[ProtoMember(4, Name = "pointreward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> pointreward
		{
			get
			{
				return this._pointreward;
			}
		}

		[ProtoMember(5, Name = "rankreward", DataFormat = DataFormat.TwosComplement)]
		public List<uint> rankreward
		{
			get
			{
				return this._rankreward;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _OptimalRank;

		private uint? _point;

		private uint? _dayupdate;

		private readonly List<uint> _pointreward = new List<uint>();

		private readonly List<uint> _rankreward = new List<uint>();

		private IExtension extensionObject;
	}
}
