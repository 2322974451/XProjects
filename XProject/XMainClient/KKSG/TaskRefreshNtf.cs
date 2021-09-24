using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TaskRefreshNtf")]
	[Serializable]
	public class TaskRefreshNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "remain_refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint remain_refresh_count
		{
			get
			{
				return this._remain_refresh_count ?? 0U;
			}
			set
			{
				this._remain_refresh_count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool remain_refresh_countSpecified
		{
			get
			{
				return this._remain_refresh_count != null;
			}
			set
			{
				bool flag = value == (this._remain_refresh_count == null);
				if (flag)
				{
					this._remain_refresh_count = (value ? new uint?(this.remain_refresh_count) : null);
				}
			}
		}

		private bool ShouldSerializeremain_refresh_count()
		{
			return this.remain_refresh_countSpecified;
		}

		private void Resetremain_refresh_count()
		{
			this.remain_refresh_countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _score;

		private uint? _remain_refresh_count;

		private IExtension extensionObject;
	}
}
