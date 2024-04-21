﻿using System;
using System.Collections;
using System.Collections.Generic;
using ScriptRuntime;
using StorySystem;

namespace StorySystem.CommonFunctions
{
    /// <summary>
    /// Dummy value, used to register functions that
    /// have no corresponding implementation (registration is required for parsing).
    /// </summary>
    public sealed class DummyValue : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
            }
        }
        public IStoryFunction Clone()
        {
            DummyValue val = new DummyValue();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            m_HaveValue = true;
            m_Value = 0;
        }

        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class EvalFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
                for (int i = 0; i < callData.GetParamNum(); ++i) {
                    StoryValue val = new StoryValue();
                    val.InitFromDsl(callData.GetParam(i));
                    m_Args.Add(val);
                }
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            EvalFunction val = new EvalFunction();
            for (int i = 0; i < m_Args.Count; i++) {
                val.m_Args.Add(m_Args[i].Clone());
            }
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            for (int i = 0; i < m_Args.Count; i++) {
                m_Args[i].Evaluate(instance, handler, iterator, args);
            }
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            bool canCalc = true;
            for (int i = 0; i < m_Args.Count; i++) {
                if (!m_Args[i].HaveValue) {
                    canCalc = false;
                    break;
                }
            }
            if (canCalc) {
                m_HaveValue = true;
                m_Value = m_Args[m_Args.Count - 1].Value;
            }
        }

        private List<IStoryFunction> m_Args = new List<IStoryFunction>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class NamespaceFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
            }
        }
        public IStoryFunction Clone()
        {
            NamespaceFunction val = new NamespaceFunction();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;

            TryUpdateValue(instance);
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance)
        {
            m_HaveValue = true;
            m_Value = instance.Namespace;
        }
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class StoryIdFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
            }
        }
        public IStoryFunction Clone()
        {
            StoryIdFunction val = new StoryIdFunction();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;

            TryUpdateValue(instance);
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance)
        {
            m_HaveValue = true;
            m_Value = instance.StoryId;
        }
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class MessageIdFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
            }
        }
        public IStoryFunction Clone()
        {
            MessageIdFunction val = new MessageIdFunction();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;

            TryUpdateValue(instance, handler);
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance, StoryMessageHandler handler)
        {
            m_HaveValue = true;
            m_Value = handler.MessageId;
        }
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class CountCommandFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
                m_ParamNum = callData.GetParamNum();
                if (m_ParamNum > 0)
                    m_Level.InitFromDsl(callData.GetParam(0));
            }
        }
        public IStoryFunction Clone()
        {
            CountCommandFunction val = new CountCommandFunction();
            val.m_ParamNum = m_ParamNum;
            val.m_Level = m_Level.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            if (m_ParamNum > 0)
                m_Level.Evaluate(instance, handler, iterator, args);
            TryUpdateValue(instance, handler);
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance, StoryMessageHandler handler)
        {
            m_HaveValue = true;
            int level = 0;
            if (m_ParamNum > 0) {
                level = m_Level.Value;
            }
            if (level <= 0)
                m_Value = handler.PeekRuntime().CountCommand();
            else {
                var stack = handler.RuntimeStack;
                int i = 0;
                foreach(var runtime in stack) {
                    if (i == level) {
                        m_Value = runtime.CountCommand();
                        break;
                    }
                    ++i;
                }
            }
        }
        private int m_ParamNum = 0;
        private IStoryFunction<int> m_Level = new StoryValue<int>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class CountHandlerCommandFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
            }
        }
        public IStoryFunction Clone()
        {
            CountHandlerCommandFunction val = new CountHandlerCommandFunction();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;

            TryUpdateValue(instance, handler);
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance, StoryMessageHandler handler)
        {
            m_HaveValue = true;
            m_Value = handler.CountCommand();
        }
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class PropGetFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
                m_ParamNum = callData.GetParamNum();
                if (m_ParamNum > 0) {
                    m_VarName.InitFromDsl(callData.GetParam(0));
                }
                if (m_ParamNum > 1) {
                    m_DefaultValue.InitFromDsl(callData.GetParam(1));
                }
            }
        }
        public IStoryFunction Clone()
        {
            PropGetFunction val = new PropGetFunction();
            val.m_ParamNum = m_ParamNum;
            val.m_VarName = m_VarName.Clone();
            val.m_DefaultValue = m_DefaultValue.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            if (m_ParamNum > 0)
                m_VarName.Evaluate(instance, handler, iterator, args);
            if (m_ParamNum > 1)
                m_DefaultValue.Evaluate(instance, handler, iterator, args);
            TryUpdateValue(instance, handler, iterator, args);
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            if (m_VarName.HaveValue) {
                m_HaveValue = true;
                string varName = m_VarName.Value;
                if (varName.StartsWith("@") && !varName.StartsWith("@@")) {
                    BoxedValue val;
                    if (instance.LocalVariables.TryGetValue(varName, out val)) {
                        m_Value = val;
                    } else if (m_ParamNum > 1) {
                        m_Value = m_DefaultValue.Value;
                    } else {
                        m_Value = BoxedValue.NullObject;
                    }
                } else if (varName.StartsWith("$")) {
                    if (varName.StartsWith("$$")) {
                        m_Value = iterator;
                    } else if (null != args) {
                        string realName = varName.Substring(1);
                        try {
                            if (char.IsDigit(realName, 0)) {
                                int index = int.Parse(realName);
                                if (index >= 0 && index < args.Count) {
                                    m_Value = args[index];
                                } else if (m_ParamNum > 1) {
                                    m_Value = m_DefaultValue.Value;
                                } else {
                                    m_Value = BoxedValue.NullObject;
                                }
                            } else {
                                BoxedValue val;
                                if (instance.StackVariables.TryGetValue(varName, out val)) {
                                    m_Value = val;
                                } else if (m_ParamNum > 1) {
                                    m_Value = m_DefaultValue.Value;
                                } else {
                                    m_Value = BoxedValue.NullObject;
                                }
                            }
                        } catch {
                            if (m_ParamNum > 1) {
                                m_Value = m_DefaultValue.Value;
                            } else {
                                m_Value = BoxedValue.NullObject;
                            }
                        }
                    }
                } else {
                    BoxedValue val;
                    if (null != instance.GlobalVariables && instance.GlobalVariables.TryGetValue(varName, out val)) {
                        m_Value = val;
                    } else if (m_ParamNum > 1) {
                        m_Value = m_DefaultValue.Value;
                    } else {
                        m_Value = BoxedValue.NullObject;
                    }
                }
            }
        }

        private int m_ParamNum = 0;
        private IStoryFunction<string> m_VarName = new StoryValue<string>();
        private IStoryFunction m_DefaultValue = new StoryValue();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class RandomIntFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 2) {
                m_Min.InitFromDsl(callData.GetParam(0));
                m_Max.InitFromDsl(callData.GetParam(1));
            }
        }
        public IStoryFunction Clone()
        {
            RandomIntFunction val = new RandomIntFunction();
            val.m_Min = m_Min.Clone();
            val.m_Max = m_Max.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Min.Evaluate(instance, handler, iterator, args);
            m_Max.Evaluate(instance, handler, iterator, args);
            TryUpdateValue(instance);
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance)
        {
            if (m_Min.HaveValue && m_Max.HaveValue) {
                m_HaveValue = true;
                int min = m_Min.Value;
                int max = m_Max.Value;
                m_Value = GameFramework.Helper.Random.Next(min, max);
            }
        }
        private IStoryFunction<int> m_Min = new StoryValue<int>();
        private IStoryFunction<int> m_Max = new StoryValue<int>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class RandomFloatFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
            }
        }
        public IStoryFunction Clone()
        {
            RandomFloatFunction val = new RandomFloatFunction();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;

            TryUpdateValue(instance);
        }
        public void Analyze(StoryInstance instance)
        { }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue(StoryInstance instance)
        {
            m_HaveValue = true;
            m_Value = GameFramework.Helper.Random.NextFloat();
        }
        private IStoryFunction<int> m_Min = new StoryValue<int>();
        private IStoryFunction<int> m_Max = new StoryValue<int>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector2Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 2) {
                m_X.InitFromDsl(callData.GetParam(0));
                m_Y.InitFromDsl(callData.GetParam(1));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector2Function val = new Vector2Function();
            val.m_X = m_X.Clone();
            val.m_Y = m_Y.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;

            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);

            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue) {
                m_HaveValue = true;
                m_Value = new Vector2(m_X.Value, m_Y.Value);
            }
        }
        private IStoryFunction<float> m_X = new StoryValue<float>();
        private IStoryFunction<float> m_Y = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector3Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 3) {
                m_X.InitFromDsl(callData.GetParam(0));
                m_Y.InitFromDsl(callData.GetParam(1));
                m_Z.InitFromDsl(callData.GetParam(2));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector3Function val = new Vector3Function();
            val.m_X = m_X.Clone();
            val.m_Y = m_Y.Clone();
            val.m_Z = m_Z.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue) {
                m_HaveValue = true;
                m_Value = new Vector3(m_X.Value, m_Y.Value, m_Z.Value);
            }
        }
        private IStoryFunction<float> m_X = new StoryValue<float>();
        private IStoryFunction<float> m_Y = new StoryValue<float>();
        private IStoryFunction<float> m_Z = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector4Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 4) {
                m_X.InitFromDsl(callData.GetParam(0));
                m_Y.InitFromDsl(callData.GetParam(1));
                m_Z.InitFromDsl(callData.GetParam(2));
                m_W.InitFromDsl(callData.GetParam(3));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector4Function val = new Vector4Function();
            val.m_X = m_X.Clone();
            val.m_Y = m_Y.Clone();
            val.m_Z = m_Z.Clone();
            val.m_W = m_W.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            m_W.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue && m_W.HaveValue) {
                m_HaveValue = true;
                m_Value = new Vector4(m_X.Value, m_Y.Value, m_Z.Value, m_W.Value);
            }
        }
        private IStoryFunction<float> m_X = new StoryValue<float>();
        private IStoryFunction<float> m_Y = new StoryValue<float>();
        private IStoryFunction<float> m_Z = new StoryValue<float>();
        private IStoryFunction<float> m_W = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class QuaternionFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 4) {
                m_X.InitFromDsl(callData.GetParam(0));
                m_Y.InitFromDsl(callData.GetParam(1));
                m_Z.InitFromDsl(callData.GetParam(2));
                m_W.InitFromDsl(callData.GetParam(3));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            QuaternionFunction val = new QuaternionFunction();
            val.m_X = m_X.Clone();
            val.m_Y = m_Y.Clone();
            val.m_Z = m_Z.Clone();
            val.m_W = m_W.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            m_W.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue && m_W.HaveValue) {
                m_HaveValue = true;
                m_Value = new Quaternion(m_X.Value, m_Y.Value, m_Z.Value, m_W.Value);
            }
        }
        private IStoryFunction<float> m_X = new StoryValue<float>();
        private IStoryFunction<float> m_Y = new StoryValue<float>();
        private IStoryFunction<float> m_Z = new StoryValue<float>();
        private IStoryFunction<float> m_W = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class EularFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 3) {
                m_X.InitFromDsl(callData.GetParam(0));
                m_Y.InitFromDsl(callData.GetParam(1));
                m_Z.InitFromDsl(callData.GetParam(2));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            EularFunction val = new EularFunction();
            val.m_X = m_X.Clone();
            val.m_Y = m_Y.Clone();
            val.m_Z = m_Z.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue) {
                m_HaveValue = true;
                m_Value = Quaternion.CreateFromYawPitchRoll(m_X.Value, m_Y.Value, m_Z.Value);
            }
        }
        private IStoryFunction<float> m_X = new StoryValue<float>();
        private IStoryFunction<float> m_Y = new StoryValue<float>();
        private IStoryFunction<float> m_Z = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ColorFunction : IStoryFunction
    {
        private IStoryFunction<float> m_X = new StoryValue<float>();

        private IStoryFunction<float> m_Y = new StoryValue<float>();

        private IStoryFunction<float> m_Z = new StoryValue<float>();

        private IStoryFunction<float> m_W = new StoryValue<float>();

        private bool m_HaveValue;

        private BoxedValue m_Value;

        public bool HaveValue => m_HaveValue;

        public BoxedValue Value => m_Value;

        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            if (param is Dsl.FunctionData functionData && functionData.GetParamNum() == 4) {
                m_X.InitFromDsl(functionData.GetParam(0));
                m_Y.InitFromDsl(functionData.GetParam(1));
                m_Z.InitFromDsl(functionData.GetParam(2));
                m_W.InitFromDsl(functionData.GetParam(3));
                TryUpdateValue();
            }
        }

        public IStoryFunction Clone()
        {
            ColorFunction colorValue = new ColorFunction();
            colorValue.m_X = m_X.Clone();
            colorValue.m_Y = m_Y.Clone();
            colorValue.m_Z = m_Z.Clone();
            colorValue.m_W = m_W.Clone();
            colorValue.m_HaveValue = m_HaveValue;
            colorValue.m_Value = m_Value;
            return colorValue;
        }

        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            m_W.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue && m_W.HaveValue) {
                m_HaveValue = true;
                m_Value = new ColorF(m_X.Value, m_Y.Value, m_Z.Value, m_W.Value);
            }
        }
    }
    public sealed class Color32Function : IStoryFunction
    {
        private IStoryFunction<byte> m_X = new StoryValue<byte>();

        private IStoryFunction<byte> m_Y = new StoryValue<byte>();

        private IStoryFunction<byte> m_Z = new StoryValue<byte>();

        private IStoryFunction<byte> m_W = new StoryValue<byte>();

        private bool m_HaveValue;

        private BoxedValue m_Value;

        public bool HaveValue => m_HaveValue;

        public BoxedValue Value => m_Value;

        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            if (param is Dsl.FunctionData functionData && functionData.GetParamNum() == 4) {
                m_X.InitFromDsl(functionData.GetParam(0));
                m_Y.InitFromDsl(functionData.GetParam(1));
                m_Z.InitFromDsl(functionData.GetParam(2));
                m_W.InitFromDsl(functionData.GetParam(3));
                TryUpdateValue();
            }
        }

        public IStoryFunction Clone()
        {
            Color32Function colorValue = new Color32Function();
            colorValue.m_X = m_X.Clone();
            colorValue.m_Y = m_Y.Clone();
            colorValue.m_Z = m_Z.Clone();
            colorValue.m_W = m_W.Clone();
            colorValue.m_HaveValue = m_HaveValue;
            colorValue.m_Value = m_Value;
            return colorValue;
        }

        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            m_W.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue && m_W.HaveValue) {
                m_HaveValue = true;
                m_Value = new Color32(m_X.Value, m_Y.Value, m_Z.Value, m_W.Value);
            }
        }
    }
    public sealed class Vector2IntFunction : IStoryFunction
    {
        private IStoryFunction<int> m_X = new StoryValue<int>();

        private IStoryFunction<int> m_Y = new StoryValue<int>();

        private bool m_HaveValue;

        private BoxedValue m_Value;

        public bool HaveValue => m_HaveValue;

        public BoxedValue Value => m_Value;

        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            if (param is Dsl.FunctionData functionData && functionData.GetParamNum() == 2) {
                m_X.InitFromDsl(functionData.GetParam(0));
                m_Y.InitFromDsl(functionData.GetParam(1));
                TryUpdateValue();
            }
        }

        public IStoryFunction Clone()
        {
            Vector2IntFunction vector2Value = new Vector2IntFunction();
            vector2Value.m_X = m_X.Clone();
            vector2Value.m_Y = m_Y.Clone();
            vector2Value.m_HaveValue = m_HaveValue;
            vector2Value.m_Value = m_Value;
            return vector2Value;
        }

        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue) {
                m_HaveValue = true;
                m_Value = BoxedValue.FromObject(new Vector2Int(m_X.Value, m_Y.Value));
            }
        }
    }
    public sealed class Vector3IntFunction : IStoryFunction
    {
        private IStoryFunction<int> m_X = new StoryValue<int>();

        private IStoryFunction<int> m_Y = new StoryValue<int>();

        private IStoryFunction<int> m_Z = new StoryValue<int>();

        private bool m_HaveValue;

        private BoxedValue m_Value;

        public bool HaveValue => m_HaveValue;

        public BoxedValue Value => m_Value;

        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            if (param is Dsl.FunctionData functionData && functionData.GetParamNum() == 3) {
                m_X.InitFromDsl(functionData.GetParam(0));
                m_Y.InitFromDsl(functionData.GetParam(1));
                m_Z.InitFromDsl(functionData.GetParam(2));
                TryUpdateValue();
            }
        }

        public IStoryFunction Clone()
        {
            Vector3IntFunction vector3Value = new Vector3IntFunction();
            vector3Value.m_X = m_X.Clone();
            vector3Value.m_Y = m_Y.Clone();
            vector3Value.m_Z = m_Z.Clone();
            vector3Value.m_HaveValue = m_HaveValue;
            vector3Value.m_Value = m_Value;
            return vector3Value;
        }

        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_X.Evaluate(instance, handler, iterator, args);
            m_Y.Evaluate(instance, handler, iterator, args);
            m_Z.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }

        private void TryUpdateValue()
        {
            if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue) {
                m_HaveValue = true;
                m_Value = BoxedValue.FromObject(new Vector3Int(m_X.Value, m_Y.Value, m_Z.Value));
            }
        }
    }
    public sealed class Vector2DistanceFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 2) {
                m_Pt1.InitFromDsl(callData.GetParam(0));
                m_Pt2.InitFromDsl(callData.GetParam(1));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector2DistanceFunction val = new Vector2DistanceFunction();
            val.m_Pt1 = m_Pt1.Clone();
            val.m_Pt2 = m_Pt2.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Pt1.Evaluate(instance, handler, iterator, args);
            m_Pt2.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_Pt1.HaveValue && m_Pt2.HaveValue) {
                m_HaveValue = true;
                m_Value = (m_Pt1.Value - m_Pt2.Value).Length();
            }
        }
        private IStoryFunction<Vector2> m_Pt1 = new StoryValue<Vector2>();
        private IStoryFunction<Vector2> m_Pt2 = new StoryValue<Vector2>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector3DistanceFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 2) {
                m_Pt1.InitFromDsl(callData.GetParam(0));
                m_Pt2.InitFromDsl(callData.GetParam(1));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector3DistanceFunction val = new Vector3DistanceFunction();
            val.m_Pt1 = m_Pt1.Clone();
            val.m_Pt2 = m_Pt2.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Pt1.Evaluate(instance, handler, iterator, args);
            m_Pt2.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_Pt1.HaveValue && m_Pt2.HaveValue) {
                m_HaveValue = true;
                m_Value = GameFramework.Geometry.Distance(m_Pt1.Value, m_Pt2.Value);
            }
        }
        private IStoryFunction<Vector3> m_Pt1 = new StoryValue<Vector3>();
        private IStoryFunction<Vector3> m_Pt2 = new StoryValue<Vector3>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector2To3Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_Pt.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector2To3Function val = new Vector2To3Function();
            val.m_Pt = m_Pt.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Pt.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_Pt.HaveValue) {
                m_HaveValue = true;
                m_Value = new Vector3(m_Pt.Value.X, 0, m_Pt.Value.Y);
            }
        }
        private IStoryFunction<Vector2> m_Pt = new StoryValue<Vector2>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector3To2Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_Pt.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector3To2Function val = new Vector3To2Function();
            val.m_Pt = m_Pt.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Pt.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_Pt.HaveValue) {
                m_HaveValue = true;
                m_Value = new Vector2(m_Pt.Value.X, m_Pt.Value.Z);
            }
        }
        private IStoryFunction<Vector3> m_Pt = new StoryValue<Vector3>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class StringListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListString.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            StringListFunction val = new StringListFunction();
            val.m_ListString = m_ListString.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListString.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListString.HaveValue) {
                m_HaveValue = true;
                List<string> list = GameFramework.Converter.ConvertStringList(m_ListString.Value);
                var v = new ObjList();
                for (int i = 0; i < list.Count; ++i) {
                    v.Add(list[i]);
                }
                m_Value = BoxedValue.FromObject(v);
            }
        }
        private IStoryFunction<string> m_ListString = new StoryValue<string>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class IntListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListString.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            IntListFunction val = new IntListFunction();
            val.m_ListString = m_ListString.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListString.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListString.HaveValue) {
                m_HaveValue = true;
                List<int> list = GameFramework.Converter.ConvertNumericList<int>(m_ListString.Value);
                var v = new ObjList();
                for (int i = 0; i < list.Count; ++i) {
                    v.Add(list[i]);
                }
                m_Value = BoxedValue.FromObject(v);
            }
        }
        private IStoryFunction<string> m_ListString = new StoryValue<string>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class FloatListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListString.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            FloatListFunction val = new FloatListFunction();
            val.m_ListString = m_ListString.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListString.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListString.HaveValue) {
                m_HaveValue = true;
                List<float> list = GameFramework.Converter.ConvertNumericList<float>(m_ListString.Value);
                var v = new ObjList();
                for (int i = 0; i < list.Count; ++i) {
                    v.Add(list[i]);
                }
                m_Value = BoxedValue.FromObject(v);
            }
        }
        private IStoryFunction<string> m_ListString = new StoryValue<string>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector2ListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListString.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector2ListFunction val = new Vector2ListFunction();
            val.m_ListString = m_ListString.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListString.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListString.HaveValue) {
                m_HaveValue = true;
                var list = GameFramework.Converter.ConvertVector2DList(m_ListString.Value);
                var v = new ObjList();
                for (int i = 0; i < list.Count; ++i) {
                    v.Add(list[i]);
                }
                m_Value = BoxedValue.FromObject(v);
            }
        }
        private IStoryFunction<string> m_ListString = new StoryValue<string>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class Vector3ListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListString.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            Vector3ListFunction val = new Vector3ListFunction();
            val.m_ListString = m_ListString.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListString.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListString.HaveValue) {
                m_HaveValue = true;
                var list = GameFramework.Converter.ConvertVector3DList(m_ListString.Value);
                var v = new ObjList();
                for (int i = 0; i < list.Count; ++i) {
                    v.Add(list[i]);
                }
                m_Value = BoxedValue.FromObject(v);
            }
        }
        private IStoryFunction<string> m_ListString = new StoryValue<string>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ArrayFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {

                for (int i = 0; i < callData.GetParamNum(); ++i) {
                    Dsl.ISyntaxComponent arg = callData.GetParam(i);
                    StoryValue val = new StoryValue();
                    val.InitFromDsl(arg);
                    m_List.Add(val);
                }
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            ArrayFunction val = new ArrayFunction();
            for (int i = 0; i < m_List.Count; i++) {
                val.m_List.Add(m_List[i]);
            }
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            for (int i = 0; i < m_List.Count; i++) {
                m_List[i].Evaluate(instance, handler, iterator, args);
            }
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            bool canCalc = true;
            for (int i = 0; i < m_List.Count; i++) {
                if (!m_List[i].HaveValue) {
                    canCalc = false;
                    break;
                }
            }
            if (canCalc) {
                m_HaveValue = true;
                var list = new ObjList();
                for (int i = 0; i < m_List.Count; i++) {
                    list.Add(m_List[i].Value.GetObject());
                }
                m_Value = BoxedValue.FromObject(list.ToArray());
            }
        }
        private List<IStoryFunction> m_List = new List<IStoryFunction>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ToArrayFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListValue.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            ToArrayFunction val = new ToArrayFunction();
            val.m_ListValue = m_ListValue.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListValue.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListValue.HaveValue) {
                m_HaveValue = true;
                object list = m_ListValue.Value.GetObject();
                IEnumerable obj = list as IEnumerable;
                if (null != obj) {
                    ArrayList al = new ArrayList();
                    IEnumerator enumer = obj.GetEnumerator();
                    while (enumer.MoveNext()) {
                        object val = enumer.Current;
                        al.Add(val);
                    }
                    m_Value = BoxedValue.FromObject(al.ToArray());
                } else {
                    m_Value = BoxedValue.NullObject;
                }
            }
        }
        private IStoryFunction m_ListValue = new StoryValue();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {

                for (int i = 0; i < callData.GetParamNum(); ++i) {
                    Dsl.ISyntaxComponent arg = callData.GetParam(i);
                    StoryValue val = new StoryValue();
                    val.InitFromDsl(arg);
                    m_List.Add(val);
                }
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            ListFunction val = new ListFunction();
            for (int i = 0; i < m_List.Count; i++) {
                val.m_List.Add(m_List[i]);
            }
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            for (int i = 0; i < m_List.Count; i++) {
                m_List[i].Evaluate(instance, handler, iterator, args);
            }
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            bool canCalc = true;
            for (int i = 0; i < m_List.Count; i++) {
                if (!m_List[i].HaveValue) {
                    canCalc = false;
                    break;
                }
            }
            if (canCalc) {
                m_HaveValue = true;
                var v = new ObjList();
                for (int i = 0; i < m_List.Count; i++) {
                    v.Add(m_List[i].Value.GetObject());
                }
                m_Value = BoxedValue.FromObject(v);
            }
        }
        private List<IStoryFunction> m_List = new List<IStoryFunction>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class RandomFromListFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {
                m_ParamNum = callData.GetParamNum();
                if (m_ParamNum > 0) {
                    m_ListValue.InitFromDsl(callData.GetParam(0));
                }
                if (m_ParamNum > 1) {
                    m_DefaultValue.InitFromDsl(callData.GetParam(1));
                }
            }
        }
        public IStoryFunction Clone()
        {
            RandomFromListFunction val = new RandomFromListFunction();
            val.m_ParamNum = m_ParamNum;
            val.m_ListValue = m_ListValue.Clone();
            val.m_DefaultValue = m_DefaultValue.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            if (m_ParamNum > 0)
                m_ListValue.Evaluate(instance, handler, iterator, args);
            if (m_ParamNum > 1)
                m_DefaultValue.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListValue.HaveValue) {
                m_HaveValue = true;
                IList listValue = m_ListValue.Value;
                int ct = listValue.Count;
                int ix = GameFramework.Helper.Random.Next(ct);
                if (ix >= 0 && ix < ct) {
                    m_Value = BoxedValue.FromObject(listValue[ix]);
                } else if (ct > 0) {
                    m_Value = BoxedValue.FromObject(listValue[0]);
                } else if (m_ParamNum > 1) {
                    m_Value = m_DefaultValue.Value;
                } else {
                    m_Value = BoxedValue.NullObject;
                }
            }
        }
        private int m_ParamNum = 0;
        private IStoryFunction<IList> m_ListValue = new StoryValue<IList>();
        private IStoryFunction m_DefaultValue = new StoryValue();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ListGetFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {

                m_ParamNum = callData.GetParamNum();
                if (m_ParamNum > 1) {
                    m_ListValue.InitFromDsl(callData.GetParam(0));
                    m_IndexValue.InitFromDsl(callData.GetParam(1));
                    if (m_ParamNum > 2) {
                        m_DefaultValue.InitFromDsl(callData.GetParam(2));
                    }
                    TryUpdateValue();
                }
            }
        }
        public IStoryFunction Clone()
        {
            ListGetFunction val = new ListGetFunction();
            val.m_ParamNum = m_ParamNum;
            val.m_ListValue = m_ListValue.Clone();
            val.m_IndexValue = m_IndexValue.Clone();
            val.m_DefaultValue = m_DefaultValue.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            if (m_ParamNum > 1) {
                m_ListValue.Evaluate(instance, handler, iterator, args);
                m_IndexValue.Evaluate(instance, handler, iterator, args);
            }
            if (m_ParamNum > 2) {
                m_DefaultValue.Evaluate(instance, handler, iterator, args);
            }
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListValue.HaveValue && m_IndexValue.HaveValue) {
                m_HaveValue = true;
                IList listValue = m_ListValue.Value;
                int ix = m_IndexValue.Value;
                int ct = listValue.Count;
                if (ix >= 0 && ix < ct) {
                    m_Value = BoxedValue.FromObject(listValue[ix]);
                } else if (ct > 0) {
                    m_Value = BoxedValue.FromObject(listValue[ct - 1]);
                } else if (m_ParamNum > 2) {
                    m_Value = m_DefaultValue.Value;
                } else {
                    m_Value = BoxedValue.NullObject;
                }
            }
        }
        private int m_ParamNum = 0;
        private IStoryFunction<IList> m_ListValue = new StoryValue<IList>();
        private IStoryFunction<int> m_IndexValue = new StoryValue<int>();
        private IStoryFunction m_DefaultValue = new StoryValue();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ListSizeFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 1) {
                m_ListValue.InitFromDsl(callData.GetParam(0));
                TryUpdateValue();
            }
        }
        public IStoryFunction Clone()
        {
            ListSizeFunction val = new ListSizeFunction();
            val.m_ListValue = m_ListValue.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_ListValue.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListValue.HaveValue) {
                m_HaveValue = true;
                IList listValue = m_ListValue.Value;
                int ct = listValue.Count;
                m_Value = ct;
            }
        }
        private IStoryFunction<IList> m_ListValue = new StoryValue<IList>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class ListIndexOfFunction : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData) {

                m_ParamNum = callData.GetParamNum();
                if (m_ParamNum > 1) {
                    m_ListValue.InitFromDsl(callData.GetParam(0));
                    m_IndexOfValue.InitFromDsl(callData.GetParam(1));
                    TryUpdateValue();
                }
            }
        }
        public IStoryFunction Clone()
        {
            ListIndexOfFunction val = new ListIndexOfFunction();
            val.m_ParamNum = m_ParamNum;
            val.m_ListValue = m_ListValue.Clone();
            val.m_IndexOfValue = m_IndexOfValue.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            if (m_ParamNum > 1) {
                m_ListValue.Evaluate(instance, handler, iterator, args);
                m_IndexOfValue.Evaluate(instance, handler, iterator, args);
            }
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_ListValue.HaveValue && m_IndexOfValue.HaveValue) {
                m_HaveValue = true;
                IList listValue = m_ListValue.Value;
                object val = m_IndexOfValue.Value.GetObject();
                m_Value = listValue.IndexOf(val);
            }
        }
        private int m_ParamNum = 0;
        private IStoryFunction<IList> m_ListValue = new StoryValue<IList>();
        private IStoryFunction m_IndexOfValue = new StoryValue();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class RandVector3Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 2) {
                m_Pt.InitFromDsl(callData.GetParam(0));
                m_Radius.InitFromDsl(callData.GetParam(1));
            }
        }
        public IStoryFunction Clone()
        {
            RandVector3Function val = new RandVector3Function();
            val.m_Pt = m_Pt.Clone();
            val.m_Radius = m_Radius.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Pt.Evaluate(instance, handler, iterator, args);
            m_Radius.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_Pt.HaveValue) {
                m_HaveValue = true;
                float r = m_Radius.Value;
                Vector3 pt = m_Pt.Value;
                float deltaX = (GameFramework.Helper.Random.NextFloat() - 0.5f) * r;
                float deltaZ = (GameFramework.Helper.Random.NextFloat() - 0.5f) * r;
                m_Value = new Vector3(pt.X + deltaX, pt.Y, pt.Z + deltaZ);
            }
        }
        private IStoryFunction<Vector3> m_Pt = new StoryValue<Vector3>();
        private IStoryFunction<float> m_Radius = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
    public sealed class RandVector2Function : IStoryFunction
    {
        public void InitFromDsl(Dsl.ISyntaxComponent param)
        {
            Dsl.FunctionData callData = param as Dsl.FunctionData;
            if (null != callData && callData.GetParamNum() == 2) {
                m_Pt.InitFromDsl(callData.GetParam(0));
                m_Radius.InitFromDsl(callData.GetParam(1));
            }
        }
        public IStoryFunction Clone()
        {
            RandVector2Function val = new RandVector2Function();
            val.m_Pt = m_Pt.Clone();
            val.m_Radius = m_Radius.Clone();
            val.m_HaveValue = m_HaveValue;
            val.m_Value = m_Value;
            return val;
        }
        public void Evaluate(StoryInstance instance, StoryMessageHandler handler, BoxedValue iterator, BoxedValueList args)
        {
            m_HaveValue = false;
            m_Pt.Evaluate(instance, handler, iterator, args);
            m_Radius.Evaluate(instance, handler, iterator, args);
            TryUpdateValue();
        }
        public bool HaveValue
        {
            get
            {
                return m_HaveValue;
            }
        }
        public BoxedValue Value
        {
            get
            {
                return m_Value;
            }
        }

        private void TryUpdateValue()
        {
            if (m_Pt.HaveValue) {
                m_HaveValue = true;
                float r = m_Radius.Value;
                Vector2 pt = m_Pt.Value;
                float deltaX = (GameFramework.Helper.Random.NextFloat() - 0.5f) * r;
                float deltaZ = (GameFramework.Helper.Random.NextFloat() - 0.5f) * r;
                m_Value = new Vector2(pt.X + deltaX, pt.Y + deltaZ);
            }
        }
        private IStoryFunction<Vector2> m_Pt = new StoryValue<Vector2>();
        private IStoryFunction<float> m_Radius = new StoryValue<float>();
        private bool m_HaveValue;
        private BoxedValue m_Value;
    }
}
