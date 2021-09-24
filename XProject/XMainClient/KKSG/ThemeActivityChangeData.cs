using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ThemeActivityChangeData")]
	[Serializable]
	public class ThemeActivityChangeData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		[ProtoMember(2, Name = "scene", DataFormat = DataFormat.Default)]
		public List<SpFirstCompleteScene> scene
		{
			get
			{
				return this._scene;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _ishint;

		private readonly List<SpFirstCompleteScene> _scene = new List<SpFirstCompleteScene>();

		private uint? _actid;

		private IExtension extensionObject;
	}
}
