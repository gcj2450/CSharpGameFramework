﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_GameFramework_PoolAllocatedFunc : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ctor_s(IntPtr l) {
		try {
			GameFramework.PoolAllocatedFunc o;
			o=new GameFramework.PoolAllocatedFunc();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Init(IntPtr l) {
		try {
			GameFramework.PoolAllocatedFunc self=(GameFramework.PoolAllocatedFunc)checkSelf(l);
			GameFramework.MyFunc a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			self.Init(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Run(IntPtr l) {
		try {
			GameFramework.PoolAllocatedFunc self=(GameFramework.PoolAllocatedFunc)checkSelf(l);
			self.Run();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Downcast(IntPtr l) {
		try {
			GameFramework.PoolAllocatedFunc self=(GameFramework.PoolAllocatedFunc)checkSelf(l);
			var ret=self.Downcast();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetPoolRecycleLock(IntPtr l) {
		try {
			GameFramework.PoolAllocatedFunc self=(GameFramework.PoolAllocatedFunc)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			self.SetPoolRecycleLock(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"GameFramework.PoolAllocatedFunc");
		addMember(l,ctor_s);
		addMember(l,Init);
		addMember(l,Run);
		addMember(l,Downcast);
		addMember(l,SetPoolRecycleLock);
		createTypeMetatable(l,null, typeof(GameFramework.PoolAllocatedFunc));
	}
}
