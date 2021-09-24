using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StageAssistOne")]
	[Serializable]
	public class StageAssistOne : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "stageid", DataFormat = DataFormat.TwosComplement)]
		public uint stageid
		{
			get
			{
				return this._stageid ?? 0U;
			}
			set
			{
				this._stageid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stageidSpecified
		{
			get
			{
				return this._stageid != null;
			}
			set
			{
				bool flag = value == (this._stageid == null);
				if (flag)
				{
					this._stageid = (value ? new uint?(this.stageid) : null);
				}
			}
		}

		private bool ShouldSerializestageid()
		{
			return this.stageidSpecified;
		}

		private void Resetstageid()
		{
			this.stageidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public int point
		{
			get
			{
				return this._point ?? 0;
			}
			set
			{
				this._point = new int?(value);
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
					this._point = (value ? new int?(this.point) : null);
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _stageid;

		private int? _point;

		private IExtension extensionObject;
	}
}
