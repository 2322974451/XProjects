using System;
using System.Reflection;

namespace ProtoBuf.Meta
{

	public class CallbackSet
	{

		internal CallbackSet(MetaType metaType)
		{
			bool flag = metaType == null;
			if (flag)
			{
				throw new ArgumentNullException("metaType");
			}
			this.metaType = metaType;
		}

		internal MethodInfo this[TypeModel.CallbackType callbackType]
		{
			get
			{
				MethodInfo result;
				switch (callbackType)
				{
				case TypeModel.CallbackType.BeforeSerialize:
					result = this.beforeSerialize;
					break;
				case TypeModel.CallbackType.AfterSerialize:
					result = this.afterSerialize;
					break;
				case TypeModel.CallbackType.BeforeDeserialize:
					result = this.beforeDeserialize;
					break;
				case TypeModel.CallbackType.AfterDeserialize:
					result = this.afterDeserialize;
					break;
				default:
					throw new ArgumentException("Callback type not supported: " + callbackType.ToString(), "callbackType");
				}
				return result;
			}
		}

		internal static bool CheckCallbackParameters(TypeModel model, MethodInfo method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				bool flag = parameterType == model.MapType(typeof(SerializationContext));
				if (!flag)
				{
					bool flag2 = parameterType == model.MapType(typeof(Type));
					if (!flag2)
					{
						return false;
					}
				}
			}
			return true;
		}

		private MethodInfo SanityCheckCallback(TypeModel model, MethodInfo callback)
		{
			this.metaType.ThrowIfFrozen();
			bool flag = callback == null;
			MethodInfo result;
			if (flag)
			{
				result = callback;
			}
			else
			{
				bool isStatic = callback.IsStatic;
				if (isStatic)
				{
					throw new ArgumentException("Callbacks cannot be static", "callback");
				}
				bool flag2 = callback.ReturnType != model.MapType(typeof(void)) || !CallbackSet.CheckCallbackParameters(model, callback);
				if (flag2)
				{
					throw CallbackSet.CreateInvalidCallbackSignature(callback);
				}
				result = callback;
			}
			return result;
		}

		internal static Exception CreateInvalidCallbackSignature(MethodInfo method)
		{
			return new NotSupportedException("Invalid callback signature in " + method.DeclaringType.FullName + "." + method.Name);
		}

		public MethodInfo BeforeSerialize
		{
			get
			{
				return this.beforeSerialize;
			}
			set
			{
				this.beforeSerialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		public MethodInfo BeforeDeserialize
		{
			get
			{
				return this.beforeDeserialize;
			}
			set
			{
				this.beforeDeserialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		public MethodInfo AfterSerialize
		{
			get
			{
				return this.afterSerialize;
			}
			set
			{
				this.afterSerialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		public MethodInfo AfterDeserialize
		{
			get
			{
				return this.afterDeserialize;
			}
			set
			{
				this.afterDeserialize = this.SanityCheckCallback(this.metaType.Model, value);
			}
		}

		public bool NonTrivial
		{
			get
			{
				return this.beforeSerialize != null || this.beforeDeserialize != null || this.afterSerialize != null || this.afterDeserialize != null;
			}
		}

		private readonly MetaType metaType;

		private MethodInfo beforeSerialize;

		private MethodInfo afterSerialize;

		private MethodInfo beforeDeserialize;

		private MethodInfo afterDeserialize;
	}
}
