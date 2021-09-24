using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XEngineCommandMgr : XSingleton<XEngineCommandMgr>
	{

		private SimpleQueue GetCurrentQueue()
		{
			bool flag = this.m_currentQueue == null;
			if (flag)
			{
				this.m_currentQueue = this.m_commandQueue0;
			}
			return this.m_currentQueue;
		}

		private SimpleQueue GeBackQueue(SimpleQueue queue)
		{
			bool flag = queue == this.m_commandQueue0;
			SimpleQueue result;
			if (flag)
			{
				result = this.m_commandQueue1;
			}
			else
			{
				result = this.m_commandQueue0;
			}
			return result;
		}

		private void SwapQueue()
		{
			bool flag = this.m_currentQueue != null;
			if (flag)
			{
				bool flag2 = this.m_currentQueue == this.m_commandQueue0;
				if (flag2)
				{
					this.m_currentQueue = this.m_commandQueue1;
				}
				else
				{
					this.m_currentQueue = this.m_commandQueue0;
				}
			}
		}

		public XEngineCommand CreateCommand(ExecuteCommandHandler handler, XGameObject gameObject, int commandID = -1)
		{
			bool hasData = this.m_commandQueue.HasData;
			XEngineCommand xengineCommand;
			if (hasData)
			{
				xengineCommand = this.m_commandQueue.Dequeue<XEngineCommand>();
			}
			else
			{
				xengineCommand = new XEngineCommand();
			}
			xengineCommand.gameObject = gameObject;
			xengineCommand.handler = handler;
			xengineCommand.objID = gameObject.objID;
			xengineCommand.commandID = commandID;
			xengineCommand.id = XEngineCommand.debugid++;
			return xengineCommand;
		}

		public void AppendCommand(XEngineCommand command)
		{
			bool flag = command.CanExecute();
			if (flag)
			{
				command.Execute();
				this.ReturnCommand(command);
			}
			else
			{
				bool flag2 = XEngineCommand.debug && command.debugHandler != null;
				if (flag2)
				{
					command.debugHandler(command.gameObject, command, "append", command.id);
				}
				SimpleQueue currentQueue = this.GetCurrentQueue();
				currentQueue.Enqueue(command);
			}
		}

		public XObjAsyncData GetObjAsyncData()
		{
			bool hasData = this.m_objAsyncDataQueue.HasData;
			XObjAsyncData result;
			if (hasData)
			{
				result = this.m_objAsyncDataQueue.Dequeue<XObjAsyncData>();
			}
			else
			{
				result = new XObjAsyncData();
			}
			return result;
		}

		public void ReturnCommand(XEngineCommand command)
		{
			bool flag = command.data != null;
			if (flag)
			{
				command.data.Reset();
				this.m_objAsyncDataQueue.Enqueue(command.data);
			}
			command.Reset();
			this.m_commandQueue.Enqueue(command);
		}

		public GameObject GetGameObject()
		{
			bool flag = this.m_gameObjectQueue.Count > 0;
			GameObject result;
			if (flag)
			{
				result = this.m_gameObjectQueue.Dequeue();
			}
			else
			{
				result = new GameObject("EmptyObject");
			}
			return result;
		}

		public void ReturnGameObject(GameObject go)
		{
			bool flag = go != null;
			if (flag)
			{
				Transform transform = go.transform;
				transform.parent = null;
				transform.position = XResourceLoaderMgr.Far_Far_Away;
				transform.rotation = Quaternion.identity;
				transform.localScale = Vector3.one;
				go.name = "EmptyObject";
				this.m_gameObjectQueue.Enqueue(go);
			}
		}

		public void Update()
		{
			SimpleQueue currentQueue = this.GetCurrentQueue();
			bool flag = currentQueue != null && currentQueue.HasData;
			if (flag)
			{
				SimpleQueue simpleQueue = this.GeBackQueue(currentQueue);
				while (currentQueue.HasData)
				{
					XEngineCommand xengineCommand = currentQueue.Dequeue<XEngineCommand>();
					bool flag2 = xengineCommand.IsValid();
					if (flag2)
					{
						bool flag3 = xengineCommand.CanExecute();
						if (flag3)
						{
							bool flag4 = XEngineCommand.debug && xengineCommand.debugHandler != null;
							if (flag4)
							{
								xengineCommand.debugHandler(xengineCommand.gameObject, xengineCommand, "execute", xengineCommand.id);
							}
							xengineCommand.Execute();
							this.ReturnCommand(xengineCommand);
						}
						else
						{
							simpleQueue.Enqueue(xengineCommand);
						}
					}
					else
					{
						bool flag5 = XEngineCommand.debug && xengineCommand.debugHandler != null;
						if (flag5)
						{
							xengineCommand.debugHandler(xengineCommand.gameObject, xengineCommand, "invalid", xengineCommand.id);
						}
						this.ReturnCommand(xengineCommand);
					}
				}
				this.SwapQueue();
			}
		}

		public void Clear()
		{
			while (this.m_commandQueue0.HasData)
			{
				XEngineCommand command = this.m_commandQueue0.Dequeue<XEngineCommand>();
				this.ReturnCommand(command);
			}
			while (this.m_commandQueue1.HasData)
			{
				XEngineCommand command2 = this.m_commandQueue1.Dequeue<XEngineCommand>();
				this.ReturnCommand(command2);
			}
			this.m_currentQueue = this.m_commandQueue0;
			this.m_gameObjectQueue.Clear();
			XEngineCommand.debugid = 0;
			bool debug = XEngineCommand.debug;
			if (debug)
			{
				XSingleton<XDebug>.singleton.AddWarningLog("[EngineCommand] Clear", null, null, null, null, null);
			}
		}

		private SimpleQueue m_currentQueue = null;

		private SimpleQueue m_commandQueue0 = new SimpleQueue();

		private SimpleQueue m_commandQueue1 = new SimpleQueue();

		private SimpleQueue m_commandQueue = new SimpleQueue();

		private SimpleQueue m_objAsyncDataQueue = new SimpleQueue();

		private Queue<GameObject> m_gameObjectQueue = new Queue<GameObject>();
	}
}
