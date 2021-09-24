using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ExecuteLevelScriptNtf")]
	[Serializable]
	public class ExecuteLevelScriptNtf : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "script", DataFormat = DataFormat.Default)]
		public string script
		{
			get
			{
				return this._script ?? "";
			}
			set
			{
				this._script = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool scriptSpecified
		{
			get
			{
				return this._script != null;
			}
			set
			{
				bool flag = value == (this._script == null);
				if (flag)
				{
					this._script = (value ? this.script : null);
				}
			}
		}

		private bool ShouldSerializescript()
		{
			return this.scriptSpecified;
		}

		private void Resetscript()
		{
			this.scriptSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _script;

		private IExtension extensionObject;
	}
}
