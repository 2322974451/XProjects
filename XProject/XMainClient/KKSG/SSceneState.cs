using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SSceneState")]
	[Serializable]
	public class SSceneState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isready", DataFormat = DataFormat.Default)]
		public bool isready
		{
			get
			{
				return this._isready ?? false;
			}
			set
			{
				this._isready = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isreadySpecified
		{
			get
			{
				return this._isready != null;
			}
			set
			{
				bool flag = value == (this._isready == null);
				if (flag)
				{
					this._isready = (value ? new bool?(this.isready) : null);
				}
			}
		}

		private bool ShouldSerializeisready()
		{
			return this.isreadySpecified;
		}

		private void Resetisready()
		{
			this.isreadySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "runstate", DataFormat = DataFormat.TwosComplement)]
		public uint runstate
		{
			get
			{
				return this._runstate ?? 0U;
			}
			set
			{
				this._runstate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool runstateSpecified
		{
			get
			{
				return this._runstate != null;
			}
			set
			{
				bool flag = value == (this._runstate == null);
				if (flag)
				{
					this._runstate = (value ? new uint?(this.runstate) : null);
				}
			}
		}

		private bool ShouldSerializerunstate()
		{
			return this.runstateSpecified;
		}

		private void Resetrunstate()
		{
			this.runstateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isready;

		private uint? _runstate;

		private IExtension extensionObject;
	}
}
