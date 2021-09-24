using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BossRushResult")]
	[Serializable]
	public class BossRushResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "currentmax", DataFormat = DataFormat.TwosComplement)]
		public uint currentmax
		{
			get
			{
				return this._currentmax ?? 0U;
			}
			set
			{
				this._currentmax = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool currentmaxSpecified
		{
			get
			{
				return this._currentmax != null;
			}
			set
			{
				bool flag = value == (this._currentmax == null);
				if (flag)
				{
					this._currentmax = (value ? new uint?(this.currentmax) : null);
				}
			}
		}

		private bool ShouldSerializecurrentmax()
		{
			return this.currentmaxSpecified;
		}

		private void Resetcurrentmax()
		{
			this.currentmaxSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lastmax", DataFormat = DataFormat.TwosComplement)]
		public uint lastmax
		{
			get
			{
				return this._lastmax ?? 0U;
			}
			set
			{
				this._lastmax = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastmaxSpecified
		{
			get
			{
				return this._lastmax != null;
			}
			set
			{
				bool flag = value == (this._lastmax == null);
				if (flag)
				{
					this._lastmax = (value ? new uint?(this.lastmax) : null);
				}
			}
		}

		private bool ShouldSerializelastmax()
		{
			return this.lastmaxSpecified;
		}

		private void Resetlastmax()
		{
			this.lastmaxSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _currentmax;

		private uint? _lastmax;

		private IExtension extensionObject;
	}
}
