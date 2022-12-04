﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_GameFramework_CustomDataCollection : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int ctor_s(IntPtr l) {
		try {
			GameFramework.CustomDataCollection o;
			o=new GameFramework.CustomDataCollection();
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
	static public int GetOrNewData(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.Object a2;
			self.GetOrNewData(a1,out a2);
			pushValue(l,true);
			pushValue(l,a2);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddData__Type__Object(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.Object a2;
			checkType(l,3,out a2);
			self.AddData(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int AddData__String__Object(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			System.Object a2;
			checkType(l,3,out a2);
			self.AddData(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveData__Type(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			self.RemoveData(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveData__String(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			self.RemoveData(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int RemoveData__Type__String(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			self.RemoveData(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int GetData__Type(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			var ret=self.GetData(a1);
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
	static public int GetData__String(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			System.String a1;
			checkType(l,2,out a1);
			var ret=self.GetData(a1);
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
	static public int Clear(IntPtr l) {
		try {
			GameFramework.CustomDataCollection self=(GameFramework.CustomDataCollection)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"GameFramework.CustomDataCollection");
		addMember(l,ctor_s);
		addMember(l,GetOrNewData);
		addMember(l,AddData__Type__Object);
		addMember(l,AddData__String__Object);
		addMember(l,RemoveData__Type);
		addMember(l,RemoveData__String);
		addMember(l,RemoveData__Type__String);
		addMember(l,GetData__Type);
		addMember(l,GetData__String);
		addMember(l,Clear);
		createTypeMetatable(l,null, typeof(GameFramework.CustomDataCollection));
	}
}
