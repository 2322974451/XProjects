using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ItemFuse")]
	[Serializable]
	public class ItemFuse : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "fuseLevel", DataFormat = DataFormat.TwosComplement)]
		public uint fuseLevel
		{
			get
			{
				return this._fuseLevel ?? 0U;
			}
			set
			{
				this._fuseLevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fuseLevelSpecified
		{
			get
			{
				return this._fuseLevel != null;
			}
			set
			{
				bool flag = value == (this._fuseLevel == null);
				if (flag)
				{
					this._fuseLevel = (value ? new uint?(this.fuseLevel) : null);
				}
			}
		}

		private bool ShouldSerializefuseLevel()
		{
			return this.fuseLevelSpecified;
		}

		private void ResetfuseLevel()
		{
			this.fuseLevelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "fuseExpCount", DataFormat = DataFormat.TwosComplement)]
		public uint fuseExpCount
		{
			get
			{
				return this._fuseExpCount ?? 0U;
			}
			set
			{
				this._fuseExpCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fuseExpCountSpecified
		{
			get
			{
				return this._fuseExpCount != null;
			}
			set
			{
				bool flag = value == (this._fuseExpCount == null);
				if (flag)
				{
					this._fuseExpCount = (value ? new uint?(this.fuseExpCount) : null);
				}
			}
		}

		private bool ShouldSerializefuseExpCount()
		{
			return this.fuseExpCountSpecified;
		}

		private void ResetfuseExpCount()
		{
			this.fuseExpCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _fuseLevel;

		private uint? _fuseExpCount;

		private IExtension extensionObject;
	}
}
