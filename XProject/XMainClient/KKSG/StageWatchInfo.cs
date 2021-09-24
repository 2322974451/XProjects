using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageWatchInfo")]
	[Serializable]
	public class StageWatchInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "wathccount", DataFormat = DataFormat.TwosComplement)]
		public uint wathccount
		{
			get
			{
				return this._wathccount ?? 0U;
			}
			set
			{
				this._wathccount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wathccountSpecified
		{
			get
			{
				return this._wathccount != null;
			}
			set
			{
				bool flag = value == (this._wathccount == null);
				if (flag)
				{
					this._wathccount = (value ? new uint?(this.wathccount) : null);
				}
			}
		}

		private bool ShouldSerializewathccount()
		{
			return this.wathccountSpecified;
		}

		private void Resetwathccount()
		{
			this.wathccountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "likecount", DataFormat = DataFormat.TwosComplement)]
		public uint likecount
		{
			get
			{
				return this._likecount ?? 0U;
			}
			set
			{
				this._likecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool likecountSpecified
		{
			get
			{
				return this._likecount != null;
			}
			set
			{
				bool flag = value == (this._likecount == null);
				if (flag)
				{
					this._likecount = (value ? new uint?(this.likecount) : null);
				}
			}
		}

		private bool ShouldSerializelikecount()
		{
			return this.likecountSpecified;
		}

		private void Resetlikecount()
		{
			this.likecountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _wathccount;

		private uint? _likecount;

		private IExtension extensionObject;
	}
}
