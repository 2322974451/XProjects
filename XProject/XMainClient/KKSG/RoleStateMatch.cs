using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleStateMatch")]
	[Serializable]
	public class RoleStateMatch : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "IsMatching", DataFormat = DataFormat.Default)]
		public bool IsMatching
		{
			get
			{
				return this._IsMatching ?? false;
			}
			set
			{
				this._IsMatching = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IsMatchingSpecified
		{
			get
			{
				return this._IsMatching != null;
			}
			set
			{
				bool flag = value == (this._IsMatching == null);
				if (flag)
				{
					this._IsMatching = (value ? new bool?(this.IsMatching) : null);
				}
			}
		}

		private bool ShouldSerializeIsMatching()
		{
			return this.IsMatchingSpecified;
		}

		private void ResetIsMatching()
		{
			this.IsMatchingSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "stopmatchreason1", DataFormat = DataFormat.TwosComplement)]
		public StopMatchReason stopmatchreason1
		{
			get
			{
				return this._stopmatchreason1 ?? StopMatchReason.STOPMATCH_NONE;
			}
			set
			{
				this._stopmatchreason1 = new StopMatchReason?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stopmatchreason1Specified
		{
			get
			{
				return this._stopmatchreason1 != null;
			}
			set
			{
				bool flag = value == (this._stopmatchreason1 == null);
				if (flag)
				{
					this._stopmatchreason1 = (value ? new StopMatchReason?(this.stopmatchreason1) : null);
				}
			}
		}

		private bool ShouldSerializestopmatchreason1()
		{
			return this.stopmatchreason1Specified;
		}

		private void Resetstopmatchreason1()
		{
			this.stopmatchreason1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "matchtype", DataFormat = DataFormat.TwosComplement)]
		public KMatchType matchtype
		{
			get
			{
				return this._matchtype ?? KMatchType.KMT_NONE;
			}
			set
			{
				this._matchtype = new KMatchType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool matchtypeSpecified
		{
			get
			{
				return this._matchtype != null;
			}
			set
			{
				bool flag = value == (this._matchtype == null);
				if (flag)
				{
					this._matchtype = (value ? new KMatchType?(this.matchtype) : null);
				}
			}
		}

		private bool ShouldSerializematchtype()
		{
			return this.matchtypeSpecified;
		}

		private void Resetmatchtype()
		{
			this.matchtypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _IsMatching;

		private StopMatchReason? _stopmatchreason1;

		private KMatchType? _matchtype;

		private IExtension extensionObject;
	}
}
