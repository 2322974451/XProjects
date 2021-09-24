using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "WatchBattleData")]
	[Serializable]
	public class WatchBattleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "watchNum", DataFormat = DataFormat.TwosComplement)]
		public int watchNum
		{
			get
			{
				return this._watchNum ?? 0;
			}
			set
			{
				this._watchNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool watchNumSpecified
		{
			get
			{
				return this._watchNum != null;
			}
			set
			{
				bool flag = value == (this._watchNum == null);
				if (flag)
				{
					this._watchNum = (value ? new int?(this.watchNum) : null);
				}
			}
		}

		private bool ShouldSerializewatchNum()
		{
			return this.watchNumSpecified;
		}

		private void ResetwatchNum()
		{
			this.watchNumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _watchNum;

		private int? _commendNum;

		private IExtension extensionObject;
	}
}
